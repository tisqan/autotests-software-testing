using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillFormContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).SendKeys(contact.HomePhone);
            driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email1);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.HomePhone);
            driver.FindElement(By.Name("bday")).Click();
            {
                var dropdown = driver.FindElement(By.Name("bday"));
                dropdown.FindElement(By.XPath($"//option[. = '{contact.Bday}']")).Click();
            }
            driver.FindElement(By.XPath($"//option[@value='{contact.Bday}']")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            {
                var dropdown = driver.FindElement(By.Name("bmonth"));
                dropdown.FindElement(By.XPath($"//option[. = '{contact.Bmonth}']")).Click();
            }
            driver.FindElement(By.XPath($"//option[@value='{contact.Bmonth}']")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            driver.FindElement(By.Name("theform")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            FillFormContact(contact);
            SubmitContactCreation();
            return this;
        }

    }
}
