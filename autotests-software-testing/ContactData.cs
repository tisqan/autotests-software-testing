using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class ContactData
    {
        private string _name;
        private string _lastName;
        private string _nickName;
        private string photo;
        private string _title;
        private string _company;
        private string _address;
        private string _homePhone;
        private string _mobilePhone;
        private string _work;
        private string _email1;
        private string _email2;
        private string _email3;
        private string _homePage;
        private string bday;
        private string bmonth;
        private string byear;
        private string aday;
        private string amonth;
        private string ayear;


        public ContactData(string name, string lastName, string email)
        {
            this._name = name;
            this._lastName = lastName;
            this._email1 = email;
        }

      
        public string Name { get => _name; set => _name = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string NickName { get => _nickName; set => _nickName = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Title { get => _title; set => _title = value; }
        public string Company { get => _company; set => _company = value; }
        public string Address { get => _address; set => _address = value; }
        public string HomePhone { get => _homePhone; set => _homePhone = value; }
        public string MobilePhone { get => _mobilePhone; set => _mobilePhone = value; }
        public string Work { get => _work; set => _work = value; }
        public string Email1 { get => _email1; set => _email1 = value; }
        public string Email2 { get => _email2; set => _email2 = value; }
        public string Email3 { get => _email3; set => _email3 = value; }
        public string HomePage { get => _homePage; set => _homePage = value; }
        public string Bday { get => bday; set => bday = value; }
        public string Bmonth { get => bmonth; set => bmonth = value; }
        public string Byear { get => byear; set => byear = value; }
        public string Aday { get => aday; set => aday = value; }
        public string Amonth { get => amonth; set => amonth = value; }
        public string Ayear { get => ayear; set => ayear = value; }

    }
}
