using Church.Helpers;

namespace Church.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RecordStatus Status { get; set; }
    }
}