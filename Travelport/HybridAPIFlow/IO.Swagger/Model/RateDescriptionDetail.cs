/* 
 * CatalogProductOfferingsResource
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 11.1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// RateDescriptionDetail
    /// </summary>
    [DataContract]
    public partial class RateDescriptionDetail : RateDescription,  IEquatable<RateDescriptionDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateDescriptionDetail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RateDescriptionDetail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RateDescriptionDetail" /> class.
        /// </summary>
        /// <param name="sequence">The order of the text block, if there are more than one block..</param>
        /// <param name="description">Assigned Type: c-1100:Description.</param>
        /// <param name="image">Assigned Type: c-1100:Image.</param>
        /// <param name="uRL">A URL for this block.</param>
        /// <param name="dateCreateModify">Assigned Type: c-1100:DateCreateModify (required).</param>
        /// <param name="extensionPointDetail">extensionPointDetail.</param>
        public RateDescriptionDetail(int? sequence = default(int?), string description = default(string), Image image = default(Image), string uRL = default(string), DateCreateModify dateCreateModify = default(DateCreateModify), ExtensionPointDetail extensionPointDetail = default(ExtensionPointDetail), string type = "RateDescriptionDetail", string title = default(string), string id = default(string), List<TextFormatted> textFormatted = default(List<TextFormatted>), Object extensionPoint = default(Object)) : base(type, title, id, textFormatted, extensionPoint)
        {
            // to ensure "dateCreateModify" is required (not null)
            if (dateCreateModify == null)
            {
                throw new InvalidDataException("dateCreateModify is a required property for RateDescriptionDetail and cannot be null");
            }
            else
            {
                this.DateCreateModify = dateCreateModify;
            }
            this.Sequence = sequence;
            this.Description = description;
            this.Image = image;
            this.URL = uRL;
            this.ExtensionPointDetail = extensionPointDetail;
        }
        
        /// <summary>
        /// The order of the text block, if there are more than one block.
        /// </summary>
        /// <value>The order of the text block, if there are more than one block.</value>
        [DataMember(Name="sequence", EmitDefaultValue=false)]
        public int? Sequence { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Description
        /// </summary>
        /// <value>Assigned Type: c-1100:Description</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Image
        /// </summary>
        /// <value>Assigned Type: c-1100:Image</value>
        [DataMember(Name="Image", EmitDefaultValue=false)]
        public Image Image { get; set; }

        /// <summary>
        /// A URL for this block
        /// </summary>
        /// <value>A URL for this block</value>
        [DataMember(Name="URL", EmitDefaultValue=false)]
        public string URL { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:DateCreateModify
        /// </summary>
        /// <value>Assigned Type: c-1100:DateCreateModify</value>
        [DataMember(Name="DateCreateModify", EmitDefaultValue=false)]
        public DateCreateModify DateCreateModify { get; set; }

        /// <summary>
        /// Gets or Sets ExtensionPointDetail
        /// </summary>
        [DataMember(Name="ExtensionPoint_Detail", EmitDefaultValue=false)]
        public ExtensionPointDetail ExtensionPointDetail { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RateDescriptionDetail {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Sequence: ").Append(Sequence).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  URL: ").Append(URL).Append("\n");
            sb.Append("  DateCreateModify: ").Append(DateCreateModify).Append("\n");
            sb.Append("  ExtensionPointDetail: ").Append(ExtensionPointDetail).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RateDescriptionDetail);
        }

        /// <summary>
        /// Returns true if RateDescriptionDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of RateDescriptionDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RateDescriptionDetail input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Sequence == input.Sequence ||
                    (this.Sequence != null &&
                    this.Sequence.Equals(input.Sequence))
                ) && base.Equals(input) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && base.Equals(input) && 
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) && base.Equals(input) && 
                (
                    this.URL == input.URL ||
                    (this.URL != null &&
                    this.URL.Equals(input.URL))
                ) && base.Equals(input) && 
                (
                    this.DateCreateModify == input.DateCreateModify ||
                    (this.DateCreateModify != null &&
                    this.DateCreateModify.Equals(input.DateCreateModify))
                ) && base.Equals(input) && 
                (
                    this.ExtensionPointDetail == input.ExtensionPointDetail ||
                    (this.ExtensionPointDetail != null &&
                    this.ExtensionPointDetail.Equals(input.ExtensionPointDetail))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.Sequence != null)
                    hashCode = hashCode * 59 + this.Sequence.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.URL != null)
                    hashCode = hashCode * 59 + this.URL.GetHashCode();
                if (this.DateCreateModify != null)
                    hashCode = hashCode * 59 + this.DateCreateModify.GetHashCode();
                if (this.ExtensionPointDetail != null)
                    hashCode = hashCode * 59 + this.ExtensionPointDetail.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in BaseValidate(validationContext)) yield return x;
            // Description (string) maxLength
            if(this.Description != null && this.Description.Length > 1024)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 1024.", new [] { "Description" });
            }

            yield break;
        }
    }

}
