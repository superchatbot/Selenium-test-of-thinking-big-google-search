using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace thinkingbigsearch
{
    [Binding]
    public class Hook
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\Users\succe\source\repos\thinkingbigsearch\thinkingbigsearch\bin\Debug\geckodriver.exe");
            _driver = new FirefoxDriver();
            //_driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
