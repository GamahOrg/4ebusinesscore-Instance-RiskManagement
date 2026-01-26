using _4EPlatform.Domain.CustomValidationInjection;

namespace _4EPlatform.Domain.Models
{
    public class Cateory : AuditEntity<Guid>
    {
        [PreventInjection]
        public string NameAr { get; set; }
        [PreventInjection]

        public string NameEn { get; set; }
        public virtual ICollection<SubCateory> SubCateories { get; set; } = new HashSet<SubCateory>();
    }
}
