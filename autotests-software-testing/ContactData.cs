using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string _name;
        private string _lastName;
        private string _nickName;
        private string _photo;
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
        private string _bday;
        private string _bmonth;
        private string _byear;
        private string _aday;
        private string _amonth;
        private string _ayear;


        public ContactData(string name, string lastName, string email)
        {
            this._name = name;
            this._lastName = lastName;
            this._email1 = email;
        }

      
        public string Name { get => _name; set => _name = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string NickName { get => _nickName; set => _nickName = value; }
        public string Photo { get => _photo; set => _photo = value; }
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
        public string Bday { get => _bday; set => _bday = value; }
        public string Bmonth { get => _bmonth; set => _bmonth = value; }
        public string Byear { get => _byear; set => _byear = value; }
        public string Aday { get => _aday; set => _aday = value; }
        public string Amonth { get => _amonth; set => _amonth = value; }
        public string Ayear { get => _ayear; set => _ayear = value; }

    }
}
