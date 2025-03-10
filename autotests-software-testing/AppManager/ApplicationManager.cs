﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Stop()
        {
            Driver.Quit();
        }
        
        public LoginHelper Auth { get => loginHelper; }
        public NavigationHelper Navigator { get => navigationHelper; }
        public GroupHelper Groups { get => groupHelper; }
        public ContactHelper Contacts { get => contactHelper; }
        public IWebDriver Driver { get => driver; }
 
    }
}
