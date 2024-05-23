using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8_Centric.PageObjectModel;
using OpenQA.Selenium;
using System.Threading;
namespace CentricProiect.PageObjectModel
{
    
    class GoToSignIn : MenuItems
    {
        private IWebDriver driver;

        public GoToSignIn(IWebDriver browser) : base(browser)
        {
            driver = browser;
        }

        public IWebElement linkSign => driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div[3]/a[2]/div"));
        public IWebElement createAcc => driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div[2]/section/div/div/div/div/a"));
        
        public CreatePage GoToCreatePage()
        {
            linkSign.Click();
            Thread.Sleep(1000);
            createAcc.Click();
            return new CreatePage(driver);
        }

        public LoginPage GoToLoginPage()
        {
            linkSign.Click();
            return new LoginPage(driver);
        }

    }
}
