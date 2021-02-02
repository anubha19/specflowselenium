namespace specflowselenium.Bindings
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using TechTalk.SpecFlow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [Binding]
    class SpecflowBindings
    {
        private IWebDriver Driver;

        [When(@"I start the browser")]
        public void WhenIStartTheBrowser()
        {
            Driver = new FirefoxDriver();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToHttpExample_Com(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        [When(@"I click on the More information")]
        public void WhenIclickMoreInformation()
        {

            Driver.FindElement(By.XPath("/html/body/div/p[2]/a")).Click();
        }


        [Then(@"a link with text '(.*)' must be present at '(.*)'")]
        public void RFCValueMustBePresent(string RFCvalue, string path)
        {
            bool present;

            string text = "";
            try
            {
                text = Driver.FindElement(By.XPath(path)).Text;

                present = true;
            }
            catch (NoSuchElementException e)
            {
                present = false;
            }
            Assert.IsTrue(present);
            Assert.AreEqual(RFCvalue, text);
        }



        [Then(@"the '(.*)' box must contain '(.*)' at index '(.*)'")]
        public void DomainNamesMustContainRootZoneManagement(string domainName, string RZM, int position)
        {
            string textDomainName = "";
            string text = "";
            bool present;
            try
            {
                textDomainName = Driver.FindElement(By.XPath("/html/body/div/div[2]/div/h2")).Text;
                string xPath = "/html/body/div/div[2]/div/ul/li[" + position + "]/a";
                text = Driver.FindElement(By.XPath(xPath)).Text;
                present = true;

            }

            catch (NoSuchElementException e)
            {
                present = false;
            }
            Assert.IsTrue(present);

            Assert.AreEqual(domainName, textDomainName);
            Assert.AreEqual(RZM, text);
        }
    }

}