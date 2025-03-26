using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> groupCache = null;

        public GroupHelper(ApplicationManager manager) : base(manager)
        { 
           
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name=\'selected[]\'])[{index + 1}]")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper EditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();

            return this;

        }

        public GroupHelper Delete(int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            DeleteGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            EditGroup();
            FillGroupForm(group);
            UpdateGroup();
            ReturnToGroupsPage();
            return this;
        }

        public bool GroupExists()
        {
            manager.Navigator.GoToGroupPage();
            return IsElementPresent(By.XPath("//form[@action = '/addressbook/group.php']/span[@class = 'group']"));
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (IWebElement element in elements)
                {
                    
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

            }
            
            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

    }
}
