namespace TelefonRehberi.API.Models
{
    public class PersonModel
    {
        public Guid PersonId { get; set; }
        public Guid DirectoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

    }
}
