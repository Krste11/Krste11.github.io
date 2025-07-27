using RentalOnlineStore.Domain.Enums;

namespace RentalOnlineStore.Domain.Models
{
    public class Cast : BaseEntity
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public Part Part { get; set; } 
    }
}
