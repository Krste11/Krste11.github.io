namespace RentalOnlineStore.Domain.DomainModals
{
    public class Cast : BaseEntity
    {
        public string MovieId { get; set; }
        public string Name { get; set; }
        public string Part { get; set; } // Consider using an Enum here
    }
}
