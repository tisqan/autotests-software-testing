using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentionals()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
        }

        [Test]
        public void LoginWithInvalidCredentionals()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "123123");
            app.Auth.Login(account);

            Assert.That(app.Auth.IsLoggedIn, Is.False);
        }

    }
}
