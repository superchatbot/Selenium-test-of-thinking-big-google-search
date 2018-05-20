using System;
using System.Net;
using System.IO;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace thinkingbigsearch
{
    [Binding]
    public class SearchingoogleSteps
    {
        IWebElement resultcount;
        private IWebDriver _driver;

        public SearchingoogleSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to google search page")]
        public void GivenINavigateToGoogleSearchPage()
        {
            Console.WriteLine("I am on google homepage.");
            _driver.Navigate().GoToUrl("http://www.google.com");
        }
        
        [When(@"I entered key words as ""(.*)""")]
        public void WhenIEnteredKeyWordsAs(string p0)
        {
            Console.WriteLine("I want to search " + p0 + " in google.");
            _driver.FindElement(By.Name("q")).SendKeys(p0);

        }
        
        [When(@"I pressed Enter")]
        public void WhenIPressedEnter()
        {
            _driver.FindElement(By.Name("q")).Submit();
        }
        
        [Then(@"I should see the number of searching results")]
        public void ThenIShouldSeeTheNumberOfSearchingResults()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("resultStats")));
            resultcount= _driver.FindElement(By.Id("resultStats"));
            Console.WriteLine(resultcount.Text);
        }
    }
}
