using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            driver.Url = "https://d3nay7txmslpgb.cloudfront.net/#/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        [TestMethod]
        public void ClickLoginAndVerifyErrorMessage_FillInDetails_VerifyPopupText()
        {
            // Arrange
            var signUp = new SignUp(driver);
            signUp.NavigateLoginButton();
            signUp.NavigateSignUpText();
            System.Threading.Thread.Sleep(1000);
            signUp.ClickSubmit();
            Assert.IsTrue(signUp.CheckError("username-err", "Username is required"));
            Assert.IsTrue(signUp.CheckError("password-err", "Password is required"));
            Assert.IsTrue(signUp.CheckError("confirm-err", "Please confirm your password"));

            // Act
            System.Threading.Thread.Sleep(1000);
            signUp.EnterDetails("input-91", "abc");
            signUp.EnterDetails("input-94", "abc");
            signUp.EnterDetails("input-97", "def");
            Assert.IsTrue(signUp.CheckError("username-err", "Username must be minimum of 6 characters"));
            Assert.IsTrue(signUp.CheckError("password-err", "Password must be minimum of 8 characters"));
            Assert.IsTrue(signUp.CheckError("confirm-err", "Your passwords do not match"));
            System.Threading.Thread.Sleep(1000);
            signUp.NavigateLoginText();
            signUp.NavigateSignUpText();
            System.Threading.Thread.Sleep(1000);
            signUp.EnterDetails("input-91", "donaldtrump");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("[aria-label=signup]")).Click();
            Assert.IsTrue(signUp.CheckError("username-err", "Username already exists"));
            signUp.NavigateLoginText();
            signUp.NavigateSignUpText();
            signUp.EnterDetails("input-91", "robinhood");
            signUp.EnterDetails("input-94", "letmein2019");
            signUp.EnterDetails("input-97", "letmein2019");
            Assert.IsTrue(signUp.CheckErrorGone("username-err"));

            // Assert
            System.Threading.Thread.Sleep(1000);
            signUp.ClickSubmit();
            Assert.IsTrue(signUp.VerifyPopupText("robinhood"));
        }

        [TestMethod]
        public void ClickMenuAndSides_LocateSide_VerifyKilojoulesAndPrice()
        {
            // Arrange
            var menu = new Menu(driver);
            menu.NavigateMenuButton();
            menu.NavigateSidesButton();

            // Act
            // I would have also included a class for the side panel so that it would be easy
            // to get the kilojoules and price for the side without having to keep inserting
            // the side name into each method. 
            menu.FindSideName("Chunk Chips and Aioli");

            // Assert
            menu.VerifyKilojoules(3273, "Chunk Chips and Aioli");
            menu.VerifyPrice(9.99, "Chunk Chips and Aioli");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}