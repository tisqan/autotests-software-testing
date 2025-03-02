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

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreatecontactTest
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
        public void CreateContact()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("Jhon", "Wick", "111@jw.com");
            contact.NickName = "JW5";
            contact.Title = "Jhon Wick";
            contact.Company = "JWCompany";
            contact.Address = "Russia";
            contact.HomePhone = "123-123";
            contact.MobilePhone = "32323232";
            contact.Work = "GeneralWorker";
            contact.Email2 = "222@jw.com";
            contact.HomePage = "HomePage";
            contact.Bday = "18";
            contact.Bmonth = "June";
            contact.Byear = "1985";
            FillFormContact(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }

        private void ReturnToHomePage()
        {
            _driver.FindElement(By.LinkText("home page")).Click();
        }

        private void SubmitContactCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        private void FillFormContact(ContactData contact)
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

        private void InitContactCreation()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
            _driver.FindElement(By.Name("theform")).Click();
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
