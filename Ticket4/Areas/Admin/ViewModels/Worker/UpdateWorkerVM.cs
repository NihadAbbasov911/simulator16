
using Ticket4.Models;

namespace Ticket4.Areas.Admin.ViewModels.Worker
{
    public class UpdateWorkerVM
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}
