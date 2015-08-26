using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class NpDepartment : EntityBase
    {
        [JsonProperty(propertyName: "address")]
        public string Address { get; set; }

        [JsonProperty(propertyName: "addressRu")]
        public string AddressRu { get; set; }

        [JsonProperty(propertyName: "city")]
        public string City { get; set; }

        [JsonProperty(propertyName: "cityRu")]
        public string CityRu { get; set; }

        [JsonProperty(propertyName: "city_ref")]
        public string CityRef { get; set; }

        [JsonProperty(propertyName: "number")]
        public string Number { get; set; }

        [JsonProperty(propertyName: "ref")]
        public string Ref { get; set; }

        [JsonProperty(propertyName: "warehouseType")]
        public string WarehouseType { get; set; }

        [JsonProperty(propertyName: "warehouseTypeDescription")]
        public string WarehouseTypeDescription { get; set; }

        [JsonProperty(propertyName: "x")]
        public string X { get; set; }

        [JsonProperty(propertyName: "y")]
        public string Y { get; set; }
    }
}
