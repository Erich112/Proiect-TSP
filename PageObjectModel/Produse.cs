using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class Produse
    {
        private IWebDriver driver;

        public Produse(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement btnProduct;

        public ProductPage GoToProduct(int idx)
        {

            btnProduct = driver.FindElement(By.XPath("/html/body/div[1]/main/section/div/section/div/div[1]/div[" + idx + "]"));
            btnProduct.Click();

            return new ProductPage(driver);
        }
    }
}
