using System;
using System.Collections.Generic;
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
        private string _fullName;

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
                if (_fullName != null) 
                {
                    return _fullName;
                }
                else
                {
                    return Name + " " + LastName;
                }

            }
            set => _fullName = value;
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
