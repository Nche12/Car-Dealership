namespace Car_Dealership.Models
{
    public abstract class Auditable : IAuditable
    {
        public int? AddedById { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual User? AddedBy { get; set; }
        public virtual User? DeletedBy { get; set; }
    }
}
