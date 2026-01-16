using Ticket4.Models;

namespace Ticket4.Areas.Admin.ViewModels.Worker
{
    public class CreateWorkerVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }

        public List<Position>  Positions { get; set; } = new List<Position>();
        public  IFormFile ImageFile { get; set; }   
    }
}
