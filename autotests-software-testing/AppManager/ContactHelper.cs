
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillFormContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("homepage"), contact.HomePage);
            Select(By.Name("bday"), contact.Bday);
            Select(By.Name("bmonth"), contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            Select(By.Name("aday"), contact.Aday);
            Select(By.Name("amonth"), contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"//table[@id=\'maintable\']/tbody/tr[{index}]/td/input")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value=\'Delete\']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper ViewContactProperties(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            manager.Navigator.GoToHomePage();
            return this;
        }



        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactPage();
            FillFormContact(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }


        public ContactHelper Delete(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            DeleteContact();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact, int index)
        {
            manager.Navigator.GoToHomePage();
            EditContact(index);
            FillFormContact(contact);
            UpdateContact();
            ReturnToHomePage();
            return this;
        }

        public bool ContactExists()
        {
            return IsElementPresent(By.XPath("//tr/td[@class = 'center']/input"));
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table/tbody/tr[@name = 'entry']"));

                foreach (IWebElement element in elements)
                {
                    string firstName = element.FindElement(By.XPath("./td[3]")).Text;
                    string lastName = element.FindElement(By.XPath("./td[2]")).Text;
                    contactCache.Add(new ContactData(firstName, lastName));
                }

            }

            return new List<ContactData>(contactCache);
        }


        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr[@name = 'entry']")).Count;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            EditContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                NickName = nickName,
                Company = company,
                Title = title,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3
            };

        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails

            };
        }


        public ContactData GetContactInformationViewProperties(int index)
        {
            manager.Navigator.GoToHomePage();
            ViewContactProperties(index);

            char[] chars = { '\r', '\n' };
            string fulltext = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            string[] values = fulltext.Split(chars);

            string fullName = values[0];
            string nickName = values[2];
            string title = values[4];
            string company = values[6];
            string address = values[8];
            string homePhone = new Regex(@"\d*\s*\(?\d+\)?\s*\d+\s*-?\d+\s*-?\d+").Match(values[12]).Value.Trim();
            string mobilePhone = new Regex(@"\d*\s*\(?\d+\)?\s*\d+\s*-?\d+\s*-?\d+").Match(values[14]).Value.Trim();
            string workPhone = new Regex(@"\d*\s*\(?\d+\)?\s*\d+\s*-?\d+\s*-?\d+").Match(values[16]).Value.Trim();



            return new ContactData()
            {
                FullName = fullName,
                NickName = nickName,
                Title = title,
                Company = company,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,

            };

        }

    }
}
