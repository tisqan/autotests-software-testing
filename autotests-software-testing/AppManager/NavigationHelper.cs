using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        { 
            this.baseURL = baseURL;
        }

        public void GoToGroupPage()
        {
            if(driver.Url == baseURL + "/addressbook/group.php" &&
                IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddContactPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php" &&
                IsElementPresent(By.Name("submit")))
            {
                return;
            }

            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            
        }

    }
}
