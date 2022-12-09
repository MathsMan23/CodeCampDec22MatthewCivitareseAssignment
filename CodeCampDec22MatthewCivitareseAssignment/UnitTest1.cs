using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodeCampDec22MatthewCivitareseAssignment
{
    [TestClass]
    public class UnitTest1
    {
        private WebDriver driver;

        [TestInitialize]
        public void Startup()
        {
            driver = new ChromeDriver();
            driver.Url = "";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestCleanup]
        private void CleanUp()
        {
            driver.Quit();
        }
    }
}