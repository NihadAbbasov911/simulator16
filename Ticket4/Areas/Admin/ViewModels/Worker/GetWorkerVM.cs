

using Ticket4.Models;

namespace Ticket4.Areas.Admin.ViewModels.Worker
{
    public class GetWorkerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public Position Position { get; set; }
    }
}
