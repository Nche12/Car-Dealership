namespace Car_Dealership.Interfaces
{
    public interface IAuditable
    {
        User AddedBy { get; set; }
        int? AddedById { get; set; }
        DateTime? AddedDate { get; set; }
        User DeletedBy { get; set; }
        int? DeletedById { get; set; }
        DateTime? DeletedDate { get; set; }
        bool? IsDeleted { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
