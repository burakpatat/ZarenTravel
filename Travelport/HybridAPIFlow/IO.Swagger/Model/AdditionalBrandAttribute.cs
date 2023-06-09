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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// AdditionalBrandAttribute
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    [JsonSubtypes.KnownSubType(typeof(AdditionalBrandAttributeCompleteInfo), "AdditionalBrandAttributeCompleteInfo")]
    public partial class AdditionalBrandAttribute :  IEquatable<AdditionalBrandAttribute>, IValidatableObject
    {
        /// <summary>
        /// Assigned Type: ctbr-1100:BrandInclusionEnum
        /// </summary>
        /// <value>Assigned Type: ctbr-1100:BrandInclusionEnum</value>
        [DataMember(Name="Inclusion", EmitDefaultValue=false)]
        public BrandInclusionEnum Inclusion { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalBrandAttribute" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AdditionalBrandAttribute() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalBrandAttribute" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="classification">The Travelport classification used for categories of ancillaries (required).</param>
        /// <param name="inclusion">Assigned Type: ctbr-1100:BrandInclusionEnum (required).</param>
        /// <param name="matchedAttributeInd">If true, this is a matched attribute.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public AdditionalBrandAttribute(string type = default(string), string classification = default(string), BrandInclusionEnum inclusion = default(BrandInclusionEnum), bool? matchedAttributeInd = default(bool?), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for AdditionalBrandAttribute and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "classification" is required (not null)
            if (classification == null)
            {
                throw new InvalidDataException("classification is a required property for AdditionalBrandAttribute and cannot be null");
            }
            else
            {
                this.Classification = classification;
            }
            // to ensure "inclusion" is required (not null)
            if (inclusion == null)
            {
                throw new InvalidDataException("inclusion is a required property for AdditionalBrandAttribute and cannot be null");
            }
            else
            {
                this.Inclusion = inclusion;
            }
            this.MatchedAttributeInd = matchedAttributeInd;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// The Travelport classification used for categories of ancillaries
        /// </summary>
        /// <value>The Travelport classification used for categories of ancillaries</value>
        [DataMember(Name="Classification", EmitDefaultValue=false)]
        public string Classification { get; set; }


        /// <summary>
        /// If true, this is a matched attribute
        /// </summary>
        /// <value>If true, this is a matched attribute</value>
        [DataMember(Name="matchedAttributeInd", EmitDefaultValue=false)]
        public bool? MatchedAttributeInd { get; set; }

        /// <summary>
        /// Gets or Sets ExtensionPoint
        /// </summary>
        [DataMember(Name="ExtensionPoint", EmitDefaultValue=false)]
        public Object ExtensionPoint { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AdditionalBrandAttribute {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Classification: ").Append(Classification).Append("\n");
            sb.Append("  Inclusion: ").Append(Inclusion).Append("\n");
            sb.Append("  MatchedAttributeInd: ").Append(MatchedAttributeInd).Append("\n");
            sb.Append("  ExtensionPoint: ").Append(ExtensionPoint).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return this.Equals(input as AdditionalBrandAttribute);
        }

        /// <summary>
        /// Returns true if AdditionalBrandAttribute instances are equal
        /// </summary>
        /// <param name="input">Instance of AdditionalBrandAttribute to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AdditionalBrandAttribute input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Classification == input.Classification ||
                    (this.Classification != null &&
                    this.Classification.Equals(input.Classification))
                ) && 
                (
                    this.Inclusion == input.Inclusion ||
                    (this.Inclusion != null &&
                    this.Inclusion.Equals(input.Inclusion))
                ) && 
                (
                    this.MatchedAttributeInd == input.MatchedAttributeInd ||
                    (this.MatchedAttributeInd != null &&
                    this.MatchedAttributeInd.Equals(input.MatchedAttributeInd))
                ) && 
                (
                    this.ExtensionPoint == input.ExtensionPoint ||
                    (this.ExtensionPoint != null &&
                    this.ExtensionPoint.Equals(input.ExtensionPoint))
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
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Classification != null)
                    hashCode = hashCode * 59 + this.Classification.GetHashCode();
                if (this.Inclusion != null)
                    hashCode = hashCode * 59 + this.Inclusion.GetHashCode();
                if (this.MatchedAttributeInd != null)
                    hashCode = hashCode * 59 + this.MatchedAttributeInd.GetHashCode();
                if (this.ExtensionPoint != null)
                    hashCode = hashCode * 59 + this.ExtensionPoint.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            // Classification (string) maxLength
            if(this.Classification != null && this.Classification.Length > 512)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Classification, length must be less than 512.", new [] { "Classification" });
            }

            yield break;
        }
    }

}
