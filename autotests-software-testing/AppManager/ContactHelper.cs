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
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Name);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.Work);
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
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{index}]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
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

        public List<ContactData> GetGroupList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table/tbody/tr[@name = 'entry']"));

            foreach (IWebElement element in elements)
            {
                string firstName = element.FindElement(By.XPath("./td[3]")).Text;
                string lastName = element.FindElement(By.XPath("./td[2]")).Text;
                contacts.Add(new ContactData(firstName, lastName));
            }

            return contacts;
        }

    }
}
