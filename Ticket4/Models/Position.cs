using Ticket4.Models.Base;

namespace Ticket4.Models
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        List <Worker> Workers { get; set; }
    }
}
