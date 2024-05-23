using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CentricProiect.PageObjectModel;
using System.Threading;
using CentricProiect.TestResources;

namespace CentricProiect
{
    [TestClass]
    public class UnitTest1
    {

        private IWebDriver driver;

        private string testEmail = LoginRes.Email;
        private string testPassword = LoginRes.Password;
        private CookieConsent cookieConsent;
        private GoToSignIn gsi;
        private HomePage homePage;
        private LoginPage loginPage;
        private CreatePage createPage;
        private CartPage cartPage;
        private CheckoutPage checkOut;
        private BeforeProduse bfprod;

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            cookieConsent = new CookieConsent(driver);
            homePage = new HomePage(driver);
            bfprod = new BeforeProduse(driver);
            driver.Navigate().GoToUrl("https://www.kpopclub.ro");

            // de dat cut+paste inapoi in Login()

            // end Login()
        }

        [TestMethod]
        public void Login()
        {

            Thread.Sleep(1000);
            gsi = cookieConsent.GoToMenuAfterCookieAccept();
            Thread.Sleep(1000);
            loginPage = gsi.GoToLoginPage();
            Thread.Sleep(1000);
            homePage = loginPage.SignInAccount(testEmail, testPassword);
            Assert.IsTrue(homePage.GetWelcomeText().Contains(LoginRes.welcomeMessage), ValidationText.LoginSuccessful);
        }
        [TestMethod]
        public void CreateAcc()
        {

            Thread.Sleep(1000);
            gsi = cookieConsent.GoToMenuAfterCookieAccept();
            Thread.Sleep(1000);
            createPage = gsi.GoToCreatePage();
            Thread.Sleep(1000);
            homePage = createPage.SignInAccount(CreateRes.Email, CreateRes.Password, CreateRes.Name, CreateRes.Phone, CreateRes.Address, CreateRes.Postal);

            Assert.IsTrue(homePage.GetWelcomeText().Contains(LoginRes.welcomeMessage), ValidationText.LoginSuccessful);
        }

        [TestMethod]
        public void AddToCart()
        {
            Login();
            Produse produse = bfprod.GoToProduse();

            // ne ducem la produsul cu indexul 2
            ProductPage produs = produse.GoToProduct(2);
            produs.AddToCart(3);
            cartPage = produs.GoToCartPage();
        }
        [TestMethod]
        public void CheckOut()
        {
            Login();
            Produse produse = bfprod.GoToProduse();
            ProductPage produs = produse.GoToProduct(2);
            produs.AddToCart(3);
            cartPage = produs.GoToCartPage();
            checkOut = cartPage.GoToCheckOut();
            checkOut.SelectDelivery();
            checkOut.GoToPay();
        }


        [TestCleanup]
        public void CleanUp()
        {
            //driver.Quit();
        }
    }
}
