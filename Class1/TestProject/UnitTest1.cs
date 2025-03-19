using ClassLibrary;

namespace TestProjectPhone
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Konstruktor_DaniePoprawnie_OK()
        {
            var wlasciciel = "Jan Kowalski";
            var numer = "123456789";

            var telefon = new Phone(wlasciciel, numer);

            Assert.AreEqual(wlasciciel, telefon.Owner);
            Assert.AreEqual(numer, telefon.PhoneNumber);
            Assert.AreEqual(0, telefon.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_ZaKrotkiNumerTelefonu_ArgumentException()
        {
            var wlasciciel = "Jan Kowalski";
            var numer = "12345678";

            var telefon = new Phone(wlasciciel, numer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_NullOwner_ArgumentException()
        {
            var numer = "123456789";

            var telefon = new Phone(null, numer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_EmptyOwner_ArgumentException()
        {
            var numer = "123456789";

            var telefon = new Phone(string.Empty, numer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_InvalidPhoneNumber_ArgumentException()
        {
            var wlasciciel = "Jan Kowalski";
            var numer = "12345678a";

            var telefon = new Phone(wlasciciel, numer);
        }

        [TestMethod]
        public void AddContact_ValidContact_ShouldAddSuccessfully()
        {
            var telefon = new Phone("Jan Kowalski", "123456789");
            var contactName = "Anna Nowak";
            var contactNumber = "987654321";

            var result = telefon.AddContact(contactName, contactNumber);

            Assert.IsTrue(result);
            Assert.AreEqual(1, telefon.Count);
        }

        [TestMethod]
        public void AddContact_DuplicateContact_ShouldReturnFalse()
        {
            var telefon = new Phone("Jan Kowalski", "123456789");
            var contactName = "Anna Nowak";
            var contactNumber = "987654321";
            telefon.AddContact(contactName, contactNumber);

            var result = telefon.AddContact(contactName, contactNumber);

            Assert.IsFalse(result);
            Assert.AreEqual(1, telefon.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddContact_PhoneBookFull_ShouldThrowInvalidOperationException()
        {
            var telefon = new Phone("Jan Kowalski", "123456789");
            for (int i = 0; i < telefon.PhoneBookCapacity; i++)
            {
                telefon.AddContact($"Contact{i}", $"12345678{i % 10}");
            }

            telefon.AddContact("New Contact", "987654321");
        }

        [TestMethod]
        public void Call_ExistingContact_ShouldReturnCallingMessage()
        {
            var telefon = new Phone("Jan Kowalski", "123456789");
            var contactName = "Anna Nowak";
            var contactNumber = "987654321";
            telefon.AddContact(contactName, contactNumber);

            var result = telefon.Call(contactName);

            Assert.AreEqual($"Calling {contactNumber} ({contactName}) ...", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Call_NonExistingContact_ShouldThrowInvalidOperationException()
        {
            var telefon = new Phone("Jan Kowalski", "123456789");

            telefon.Call("NonExistingContact");
        }
    }
}