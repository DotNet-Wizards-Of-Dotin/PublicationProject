namespace FW.Domain
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            IsDeleted = false;

        }
    }

    public class BaseEntity : BaseEntity<int>
    {

    }
}
