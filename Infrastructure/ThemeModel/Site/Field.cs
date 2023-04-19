using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace Site
{

    public class Field
    {
        [JsonPropertyName("noPhotoPicker")]
        public bool NoPhotoPicker;

        [JsonPropertyName("permissionsRequiredToEdit")]
        public string PermissionsRequiredToEdit;

        [JsonPropertyName("required")]
        public bool Required;

        [JsonPropertyName("hideFromUI")]
        public bool HideFromUI;

        [JsonPropertyName("onChange")]
        public string OnChange;

        [JsonPropertyName("hidden")]
        public bool Hidden;

        [JsonPropertyName("autoFocus")]
        public bool AutoFocus;

        [JsonPropertyName("hideFromFieldsEditor")]
        public bool HideFromFieldsEditor;

        [JsonPropertyName("simpleTextOnly")]
        public bool SimpleTextOnly;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("mandatory")]
        public bool Mandatory;

        [JsonPropertyName("showTemplatePicker")]
        public bool ShowTemplatePicker;

        [JsonPropertyName("showIf")]
        public string ShowIf;

        [JsonPropertyName("advanced")]
        public bool Advanced;

        [JsonPropertyName("copyOnAdd")]
        public bool CopyOnAdd;

        [JsonPropertyName("subFields")]
        public List<Field> SubFields;

        [JsonPropertyName("model")]
        public string Model;

        [JsonPropertyName("disallowRemove")]
        public bool DisallowRemove;

        [JsonPropertyName("@type")]
        public string Type;

        [JsonPropertyName("type")]
        public string Type2;

        [JsonPropertyName("helperText")]
        public string HelperText;

        [JsonPropertyName("defaultValue")]
        public object DefaultValue;

        [JsonPropertyName("allowedFileTypes")]
        public List<string> AllowedFileTypes;

        [JsonPropertyName("modelId")]
        public string ModelId;
    }

}