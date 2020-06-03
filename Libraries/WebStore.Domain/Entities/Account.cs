
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string AvatarUrl { get; set; }
    }
}
