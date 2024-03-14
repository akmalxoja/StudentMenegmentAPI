using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VehicleManagement_Domen.Entityes
{
    public class EmailModel
    {
        public string? To { get; set; }
        public string? Subject { get; set; }

        [JsonIgnore]
        public string? Body { get; set; }
    }
}
