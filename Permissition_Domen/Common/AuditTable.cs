namespace Permission_Domen.Common
{
    public abstract class AuditTable : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
