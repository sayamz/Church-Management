using Church.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Church.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }      
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public Gender Gender { get; set; }
        public string EnvelopeNumber { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual Department Department { get; set; }
        public RecordStatus Status { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}