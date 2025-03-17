using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private string baseURL;
        private LoginHelper loginHelper;
        private NavigationHelper navigationHelper;
        private GroupHelper groupHelper;
        private ContactHelper contactHelper;
        
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {

            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://vm-tisqanwork";


            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }

            catch (Exception)
            {
                
            }

        }

        public static ApplicationManager GetInstance()
        {
            
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;

            }

            return app.Value;

        }

        public LoginHelper Auth { get => loginHelper; }
        public NavigationHelper Navigator { get => navigationHelper; }
        public GroupHelper Groups { get => groupHelper; }
        public ContactHelper Contacts { get => contactHelper; }
        public IWebDriver Driver { get => driver; }
 
    }
}
