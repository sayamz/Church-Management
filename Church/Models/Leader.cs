using Church.Helpers;

namespace Church.Models
{
    public class Leader
    {
        public int Id { get; set; }
        public virtual Member member { get; set; }
        public virtual Department Department { get; set; }
        public RecordStatus Status { get; set; }
    }
}