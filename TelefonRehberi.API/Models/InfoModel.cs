using TelefonRehberi.Entities.Enums;

namespace TelefonRehberi.API.Models
{
    public class InfoModel
    {
        public Guid InfoId { get; set; }
        public Guid PersonId { get; set; }
        public InfoType InfoType { get; set; }
        public string Description { get; set; }
    }
}
