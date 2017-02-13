using Church.Helpers;
using Church.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Church.ViewModels
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Mobile Number")]
        public string CellPhone { get; set; }
        [Display(Name = "Home Number")]
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Envelope Number")]
        public string EnvelopeNumber { get; set; }
        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public RecordStatus Status { get; set; }
    } 
}