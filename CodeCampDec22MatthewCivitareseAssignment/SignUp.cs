using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CodeCampDec22MatthewCivitareseAssignment
{
    internal class SignUp
    {
        private WebDriver driver;

        public SignUp(WebDriver driver)
        {
            this.driver = driver;
        }

        internal bool CheckError(string errorId, string errorText)
        {
            if (driver.FindElement(By.Id(errorId)).Text == errorText)
            {
                return true;
            }
            
            throw new Exception("Error message is not correct");
        }

        internal bool CheckErrorGone(string errorId)
        {
            var error = driver.FindElements(By.Id("errorId"));
            if (error.Count == 0)
            {
                return true;
            }

            throw new Exception("Error message is still present");
        }

        internal void ClickSubmit()
        {
            driver.FindElement(By.CssSelector("[aria-label=signup]")).Click();
        }

        internal void EnterDetails(string inputId, string inputText)
        {
            driver.FindElement(By.Id(inputId)).SendKeys(inputText);
        }

        internal void NavigateLoginButton()
        {
            driver.FindElement(By.ClassName("nav-login-signup")).Click();
        }

        internal void NavigateLoginText()
        {
            var login = driver.FindElements(By.TagName("a"));
            foreach (var log in login)
            {
                if (log.Text == "Login")
                {
                    log.Click();
                }
            }
        }

        internal void NavigateSignUpText()
        {
            var signup = driver.FindElements(By.TagName("a"));
            foreach (var sign in signup)
            {
                if (sign.Text == "Sign Up")
                {
                    sign.Click();
                }
            }
        }

        internal bool VerifyPopupText(string username)
        {
            var popup = driver.FindElement(By.ClassName("popup"));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(500)).Until(d => popup.Displayed);
            if ("check_circle\r\nThanks " + username + 
                ", you can now login.\r\nCLOSE" == popup.Text)
            {
                return true;
            }

            throw new Exception("The user's details have not been entered correctly");
        }
    }
}