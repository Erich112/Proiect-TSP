using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class CheckoutPage
    {
        private IWebDriver driver;

        public CheckoutPage(IWebDriver browser)
        {
            driver = browser;
        }
        IWebElement radioButtonCurierDomiciliu => driver.FindElement(By.Id("checkout_preview__shipping_method_1"));
        IWebElement observatiiTextArea => driver.FindElement(By.Id("checkout_preview__customer_note"));
        IWebElement payButton => driver.FindElement(By.Id("checkout_preview__submit"));

        public void SelectDelivery()
        {
            radioButtonCurierDomiciliu.Click();
            observatiiTextArea.Clear();
            observatiiTextArea.SendKeys("Fara sos iute va rog");
        }
        public void GoToPay()
        {
            Thread.Sleep(2000);
            payButton.Click();
        }
    }
}
