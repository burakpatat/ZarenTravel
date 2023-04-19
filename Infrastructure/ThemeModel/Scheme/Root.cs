using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Builder{ 

    public class Root
    {
        [JsonPropertyName("createdBy")]
        public string CreatedBy;

        [JsonPropertyName("createdDate")]
        public long CreatedDate;

        [JsonPropertyName("data")]
        public Data Data;

        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("lastUpdatedBy")]
        public string LastUpdatedBy;

        [JsonPropertyName("meta")]
        public Meta Meta;

        [JsonPropertyName("modelId")]
        public string ModelId;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("published")]
        public string Published;

        [JsonPropertyName("query")]
        public List<object> Query;

        [JsonPropertyName("testRatio")]
        public int TestRatio;

        [JsonPropertyName("variations")]
        public Variations Variations;

        [JsonPropertyName("lastUpdated")]
        public long LastUpdated;

        [JsonPropertyName("screenshot")]
        public string Screenshot;

        [JsonPropertyName("rev")]
        public string Rev;

        [JsonPropertyName("@originOrg")]
        public string OriginOrg;

        [JsonPropertyName("@originContentId")]
        public string OriginContentId;

        [JsonPropertyName("@originModelId")]
        public string OriginModelId;
    }

}