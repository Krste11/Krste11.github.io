namespace _1_Task.Entities.Modals
{
    public class BaseEntity
    {
        public int Id { get; set; }
        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
