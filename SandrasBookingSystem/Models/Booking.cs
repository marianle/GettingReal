using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SandrasBookingSystem.Models;

namespace SandrasBookingSystem.Models
{
    public class Booking 
    {
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyCVR_nr { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Comment { get; set; }

        public Booking(DateTime date, string companyName, string companyPhoneNumber, string companyCVR_nr, string city, string street, string comment)
        {
            Date = date;
            CompanyName = companyName;
            CompanyPhoneNumber = companyPhoneNumber;
            CompanyCVR_nr = companyCVR_nr;
            City = city;
            Street = street;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"{Date}, {CompanyName}, {Street}, {City}";

        }
    }
}
