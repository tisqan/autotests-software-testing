using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using autotests_software_testing;

namespace WebAddressbookTests
{

    [TestFixture]
    public class AddNewGroupTest
    {
        private IWebDriver _driver;
        private string _baseURL;
        
        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _baseURL = "http://vm-tisqanwork";
        }

        [TearDown]
        protected void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void CreateGroup()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("testNamegroup");
            group.Header = "testHeadergroup";
            group.Footer = "testFootergroup";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            
        }

        private void ReturnToGroupsPage()
        {
            _driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).Click();
            _driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            _driver.FindElement(By.Name("group_header")).Click();
            _driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            _driver.FindElement(By.Name("group_footer")).Click();
            _driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        private void InitGroupCreation()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Click();
            _driver.FindElement(By.Name("user")).SendKeys(account.Username);
            _driver.FindElement(By.Name("pass")).Click();
            _driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        private void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseURL + "/addressbook/");
            _driver.Manage().Window.Maximize();
        }
    }
}
