using OpenQA.Selenium;

namespace CodeCampDec22MatthewCivitareseAssignment
{
    internal class Menu
    {
        private WebDriver driver;

        public Menu(WebDriver driver)
        {
            this.driver = driver;
        }

        internal void FindSideName(string sideName)
        {
            var sideDish = driver.FindElement(By.ClassName("name"));
            if (sideDish.Text == sideName)
            {
                sideDish.Click();
            }
        }

        internal void NavigateMenuButton()
        {
            driver.FindElement(By.CssSelector("[aria-label=menu]")).Click();
        }

        internal void NavigateSidesButton()
        {
            var sides = driver.FindElement(By.CssSelector("[aria-selected=false]"));
            if (sides.Text == " Sides ")
            {
                sides.Click();
            }
        }

        internal void VerifyKilojoules(int kilojoulesValue, string sideName)
        {
            var sideDish = driver.FindElement(By.ClassName("name"));
            if (sideDish.Text == sideName)
            {
                Assert.AreEqual(kilojoulesValue, sideDish.FindElement(By.ClassName("kilojoules")).Text);
            }
        }

        internal void VerifyPrice(double priceValue, string sideName)
        {
            var sideDish = driver.FindElement(By.ClassName("name"));
            if (sideDish.Text == sideName)
            {
                Assert.AreEqual(priceValue, 
                    sideDish.FindElement(By.ClassName("price")).Text.Replace("$", ""));
            }
        }
    }
}