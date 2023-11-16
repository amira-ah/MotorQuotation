using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SystemCars.Data.Models
{
    public class VehicleQuotation
    {
        [Key]
        [JsonProperty(PropertyName = "quotationNumber")]
        public string QuotationNumber { get; set; }

        [JsonProperty(PropertyName = "policyOwner")]
        public string PolicyOwner { get; set; }

        [JsonProperty(PropertyName = "carMake")]
        public string CarMake { get; set; }

        [JsonProperty(PropertyName = "yearOfMake")]
        public Int32 YearOfMake { get; set; }

        [JsonProperty(PropertyName = "quotationStatus")]

        public string QuotationStatus { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; }


        public  static readonly List<MetadataColumDTO> GridColumns = new List<MetadataColumDTO> {
            new MetadataColumDTO { columnId = "quotationNumber", columnName = "quotationNumber", columnType = "String"},
            new MetadataColumDTO { columnId = "policyOwner", columnName = "policyOwner", columnType = "String"},
            new MetadataColumDTO { columnId = "carMake", columnName = "carMake", columnType = "String"},
            new MetadataColumDTO { columnId = "yearOfMake", columnName = "yearOfMake", columnType = "Number"},
            new MetadataColumDTO { columnId = "quotationStatus", columnName = "quotationStatus", columnType = "String"},
            new MetadataColumDTO { columnId = "creationDate", columnName = "creationDate", columnType = "object"},
        };
    }
}
