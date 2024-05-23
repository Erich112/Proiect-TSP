using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement txtEmail => driver.FindElement(By.Id("quick_login__email"));
        public IWebElement txtPassword => driver.FindElement(By.Id("quick_login__password"));
        public IWebElement btnSignIn => driver.FindElement(By.Id("quick_login__submit"));


        public HomePage SignInAccount(string email, string password)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            btnSignIn.Click();
            return new HomePage(driver);
        }
    }
}
