using Domain.Concrete.Base;

namespace Domain.Concrete.Schema.Accounting
{
    public class Roles : BaseEntity
    {
        public Roles()
        {
            Name = "hamid";
            IsDeleted = false;
        }
        public virtual byte Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual Boolean IsDeleted { get; set; }
        public override string ToString()
        {
            return $"{Name} {CreationDate}";
        }
    }
}
