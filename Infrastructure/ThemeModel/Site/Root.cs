using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Site{ 

    public class Root
    {
        [JsonPropertyName("requiredTargets")]
        public List<object> RequiredTargets;

        [JsonPropertyName("publicWritable")]
        public bool PublicWritable;

        [JsonPropertyName("fields")]
        public List<Field> Fields;

        [JsonPropertyName("sendToMongoDb")]
        public bool SendToMongoDb;

        [JsonPropertyName("archived")]
        public bool Archived;

        [JsonPropertyName("componentsOnlyMode")]
        public bool ComponentsOnlyMode;

        [JsonPropertyName("autoTracked")]
        public bool AutoTracked;

        [JsonPropertyName("allowTests")]
        public bool AllowTests;

        [JsonPropertyName("showScheduling")]
        public bool ShowScheduling;

        [JsonPropertyName("designerVersion")]
        public int DesignerVersion;

        [JsonPropertyName("getSchemaFromPage")]
        public bool GetSchemaFromPage;

        [JsonPropertyName("injectWcAt")]
        public string InjectWcAt;

        [JsonPropertyName("sendToElasticSearch")]
        public bool SendToElasticSearch;

        [JsonPropertyName("individualEmbed")]
        public bool IndividualEmbed;

        [JsonPropertyName("hidden")]
        public bool Hidden;

        [JsonPropertyName("injectWcPosition")]
        public string InjectWcPosition;

        [JsonPropertyName("webhooks")]
        public List<object> Webhooks;

        [JsonPropertyName("showTargeting")]
        public bool ShowTargeting;

        [JsonPropertyName("allowMetrics")]
        public bool AllowMetrics;

        [JsonPropertyName("showMetrics")]
        public bool ShowMetrics;

        [JsonPropertyName("subType")]
        public string SubType;

        [JsonPropertyName("allowHeatmap")]
        public bool AllowHeatmap;

        [JsonPropertyName("showAbTests")]
        public bool ShowAbTests;

        [JsonPropertyName("pathPrefix")]
        public string PathPrefix;

        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("isPage")]
        public bool IsPage;

        [JsonPropertyName("kind")]
        public string Kind;

        [JsonPropertyName("repeatable")]
        public bool Repeatable;

        [JsonPropertyName("lastUpdateBy")]
        public object LastUpdateBy;

        [JsonPropertyName("hooks")]
        public Hooks Hooks;

        [JsonPropertyName("hideOptions")]
        public bool HideOptions;

        [JsonPropertyName("strictPrivateRead")]
        public bool StrictPrivateRead;

        [JsonPropertyName("strictPrivateWrite")]
        public bool StrictPrivateWrite;

        [JsonPropertyName("hideFromUI")]
        public bool HideFromUI;

        [JsonPropertyName("examplePageUrl")]
        public string ExamplePageUrl;

        [JsonPropertyName("allowBuiltInComponents")]
        public bool AllowBuiltInComponents;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("singleton")]
        public bool Singleton;

        [JsonPropertyName("useQueryParamTargetingClientSide")]
        public bool UseQueryParamTargetingClientSide;

        [JsonPropertyName("publicReadable")]
        public bool PublicReadable;

        [JsonPropertyName("defaultQuery")]
        public List<object> DefaultQuery;

        [JsonPropertyName("helperText")]
        public string HelperText;

        [JsonPropertyName("bigData")]
        public bool BigData;

        [JsonPropertyName("schema")]
        public Schema Schema;

        [JsonPropertyName("@originId")]
        public string OriginId;
    }

}