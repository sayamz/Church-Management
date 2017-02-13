using Church.Helpers;
using System;

namespace Church.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public virtual Member Member { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual Member Counter { get; set; }
        public RecordStatus Status { get; set; }
    }
}