using Church.Helpers;

namespace Church.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public virtual Member Leader { get; set; }
        public RecordStatus Status { get; set; }
    }
}