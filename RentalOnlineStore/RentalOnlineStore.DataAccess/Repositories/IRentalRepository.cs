using RentalOnlineStore.Domain.DomainModals;

namespace RentalOnlineStore.DataAccess.Repositories
{
    public interface IRentalRepository
    {
        Rental GetById(int id);
        IEnumerable<Rental> GetAll();
        IEnumerable<Rental> GetByUserId(int userId);
        Rental Add(Rental rental);
        void Update(Rental rental);
    }
}