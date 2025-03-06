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
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_ZaKrotiNumerTelefonu_ArgumentException()
        {
            var wlasciciel = "Jan Kowalski";
            var numer = "12345678";

            var telefon = new Phone(wlasciciel, numer);

            //Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer));

            //try
            //{
            //    var temp = new Phone(wlasciciel, numer);
            //}
            //catch (ArgumentException e)
            //{
            //    Assert.ThrowsException<ArgumentException>(() => throw e);
            //    return;
            //}
        }
    }

    class Pomocnicza
    {

    }
}