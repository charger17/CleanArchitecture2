namespace CleanArchitecture.Identity.Models
{
    public class BaseDomainModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDay { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; }

    }
}
