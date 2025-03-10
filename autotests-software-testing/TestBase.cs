using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected string _baseURL;

        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _baseURL = "http://vm-tisqanwork";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        protected void ReturnToGroupsPage()
        {
            _driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void SubmitGroupCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).Click();
            _driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            _driver.FindElement(By.Name("group_header")).Click();
            _driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            _driver.FindElement(By.Name("group_footer")).Click();
            _driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void InitGroupCreation()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        protected void GoToGroupPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Click();
            _driver.FindElement(By.Name("user")).SendKeys(account.Username);
            _driver.FindElement(By.Name("pass")).Click();
            _driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        protected void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseURL + "/addressbook/");
            _driver.Manage().Window.Maximize();
        }

        protected void ReturnToHomePage()
        {
            _driver.FindElement(By.LinkText("home page")).Click();
        }

        protected void SubmitContactCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillFormContact(ContactData contact)
        {
            _driver.FindElement(By.Name("firstname")).Click();
            _driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            _driver.FindElement(By.Name("lastname")).Click();
            _driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            _driver.FindElement(By.Name("nickname")).Click();
            _driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            _driver.FindElement(By.Name("title")).Click();
            _driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            _driver.FindElement(By.Name("company")).Click();
            _driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            _driver.FindElement(By.Name("address")).Click();
            _driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            _driver.FindElement(By.Name("home")).Click();
            _driver.FindElement(By.Name("home")).SendKeys(contact.HomePhone);
            _driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            _driver.FindElement(By.Name("work")).Click();
            _driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            _driver.FindElement(By.Name("email")).Click();
            _driver.FindElement(By.Name("email")).SendKeys(contact.Email1);
            _driver.FindElement(By.Name("email2")).Click();
            _driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            _driver.FindElement(By.Name("homepage")).Click();
            _driver.FindElement(By.Name("homepage")).SendKeys(contact.HomePhone);
            _driver.FindElement(By.Name("bday")).Click();
            {
                var dropdown = _driver.FindElement(By.Name("bday"));
                dropdown.FindElement(By.XPath($"//option[. = '{contact.Bday}']")).Click();
            }
            _driver.FindElement(By.XPath($"//option[@value='{contact.Bday}']")).Click();
            _driver.FindElement(By.Name("bmonth")).Click();
            {
                var dropdown = _driver.FindElement(By.Name("bmonth"));
                dropdown.FindElement(By.XPath($"//option[. = '{contact.Bmonth}']")).Click();
            }
            _driver.FindElement(By.XPath($"//option[@value='{contact.Bmonth}']")).Click();
            _driver.FindElement(By.Name("byear")).Click();
            _driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            _driver.FindElement(By.Name("theform")).Click();
        }

        protected void InitContactCreation()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
            _driver.FindElement(By.Name("theform")).Click();
        }

    }
}
