using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _allEmails;
        private string _allInfoContact;

        public ContactData(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            
        }

        public ContactData()
        {

        }


        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string HomePage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string AllPhones {
            get 
            {
                if (_allPhones != null) 
                {
                    return _allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }

            }
                
                    
            
            set => _allPhones = value; }

        public string AllEmails
        {
            get
            {
                if (_allEmails != null)
                {
                    return _allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email1) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }

            }


            set => _allEmails = value;
        }

        public string FullName {
            get 
            {
                return (Name + " " + LastName).Trim(' ');
            }
            
        }

        
        public string GetAllInfoContact()
        {
            
            if (_allInfoContact != null)
            {
                return _allInfoContact;
            }
            else
            {
                
                return (GetUserInfo() + "\r\n" + GetPhones() + "\r\n" + GetEmails()).Trim();
            }
        }

        private string GetUserInfo()
        {
            string userInfo = "";
            if (FullName != "")
            {
                userInfo += FullName + "\r\n";
            }
            if (NickName != "")
            {
                userInfo += NickName + "\r\n";
            }
            if (Title != "")
            {
                userInfo += Title + "\r\n";
            }
            if (Company != "")
            {
                userInfo += Company + "\r\n";
            }
            if (Address != "")
            {
                userInfo += Address + "\r\n";
            }
            if (userInfo == "")
            {
                userInfo = userInfo.Trim('\n', '\r');
            }
            
            return userInfo;
        }

        private string GetPhones()
        {
            string phoneInfo = "";
            if (HomePhone != "")
            {
                phoneInfo += "H: " + HomePhone + "\r\n";
            }
            if (MobilePhone != "")
            {
                phoneInfo += "M: " + MobilePhone + "\r\n";
            }
            if (WorkPhone != "")
            {
                phoneInfo += "W: " + WorkPhone + "\r\n";
            }
            if(phoneInfo == "")
            {
                phoneInfo = phoneInfo.Trim('\n', '\r');
            }
            return phoneInfo;
        }

        private string GetEmails()
        {
            string emailInfo = "";
            if (Email1 != "")
            {
                emailInfo += Email1 + "\r\n";
            }
            if (Email2 != "")
            {
                emailInfo += Email2 + "\r\n";
            }
            if (Email3 != "")
            {
                emailInfo += Email3 + "\r\n";
            }
            if(emailInfo == "")
            {
                emailInfo = emailInfo.Trim('\n', '\r');
            }
            return emailInfo;
        }


        private string CleanUpPhone(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[-() ]", "") + "\r\n";
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }

            return email.Replace(" ", "") + "\r\n";
        }

        private string CleanUpTitle(string title)
        {
            if (title == null || title == "")
            {
                return "";
            }

            return title.Replace(" ", "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name && LastName == other.LastName;
        }

        public override int GetHashCode()
        {

            return (Name + LastName).GetHashCode();
            
        }

        public override string ToString()
        {
            return "firstname=" + Name + "lastName=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return (Name + LastName).CompareTo(other.Name + other.LastName);
        }
    }

    
}
