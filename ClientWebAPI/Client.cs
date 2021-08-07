using System;
using System.ComponentModel.DataAnnotations;

namespace ClientWebAPI
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}