using Permission_Domen.Common;

namespace VehicleManagement_Domen.Entityes
{
    public class Students : AuditTable
    {

        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? ImageUrl { get; set; }
        public int age {  get; set; }
    }
}
