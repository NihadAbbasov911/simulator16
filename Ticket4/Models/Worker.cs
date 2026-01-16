using Ticket4.Models.Base;

namespace Ticket4.Models
{
    public class Worker:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FacebookUrl { get; set; }
        public string ImageUrl { get; set; }
        public string XUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkendinUrl { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }




    }
}
