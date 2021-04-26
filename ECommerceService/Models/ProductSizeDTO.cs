using Newtonsoft.Json;
using System;

namespace ECommerceService.Models
{
    [Serializable]
    public class ProductSizeDTO : EntityDTO
    {
        [JsonIgnore]
        public override string Value => Size;

        [JsonProperty("sizeName")]
        public string Size { get; set; }

        [JsonProperty]
        public int Quantity { get; set; }
    }
}