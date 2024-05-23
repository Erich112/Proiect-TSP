using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace CentricProiect.PageObjectModel
{
    class CreatePage
    {
        private IWebDriver driver;
        public CreatePage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement txtEmail => driver.FindElement(By.Id("customer_signup__email"));
        public IWebElement txtPassword => driver.FindElement(By.Id("customer_signup__password"));
        public IWebElement txtName => driver.FindElement(By.Id("customer_signup__name"));
        public IWebElement phoneNumber => driver.FindElement(By.Id("customer_signup__phone"));
        public IWebElement txtAdress => driver.FindElement(By.Id("customer_signup__address_1"));
        public IWebElement txtPostalCode => driver.FindElement(By.Id("customer_signup__postal_code"));
        public IWebElement termsAccept => driver.FindElement(By.Id("customer_signup__agree_terms"));
        public IWebElement reCaptcha => driver.FindElement(By.ClassName("recaptcha-checkbox"));
        public IWebElement btnSignIn => driver.FindElement(By.Id("customer_signup__submit"));


        public HomePage SignInAccount(string email, string password, string name, string phone, string address, string postal)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            txtName.SendKeys(name);
            phoneNumber.SendKeys(phone);
            txtAdress.SendKeys(address);
            txtPostalCode.SendKeys(postal);
            Thread.Sleep(1000);
            termsAccept.Click();
            Thread.Sleep(1000);
            reCaptcha.Click();
            btnSignIn.Click();
            return new HomePage(driver);
        }
    }
}
