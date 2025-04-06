namespace Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {

        }
        public Guid Id { get; set; } = Guid.NewGuid();


    }
}
