using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.codefirst.authentication.Models
{
    public class Customer
    {
        public int Id{ get; set; }
        public string  FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
    public class CustomerAccount
    {
        public int Id { get; set; }
        public Customer Customer{ get; set; }
        public Account Account { get; set; }
        public int CustomerId { get; set; }
        public int AccountId{ get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public double Balance { get; set; }
    }
    public class CustomerViewModel {
        public int Id { get; set; }
        [Required]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DisplayName("ContactNo")]
        public string ContactNo { get; set; }
        public bool Status { get; set; }
    }
}