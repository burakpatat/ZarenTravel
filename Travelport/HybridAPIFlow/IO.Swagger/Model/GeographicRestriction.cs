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
    /// GeographicRestriction
    /// </summary>
    [DataContract]
    public partial class GeographicRestriction :  IEquatable<GeographicRestriction>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets GeographicRestrictionType
        /// </summary>
        [DataMember(Name="geographicRestrictionType", EmitDefaultValue=false)]
        public GeographicRestrictionTypeEnum GeographicRestrictionType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeographicRestriction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GeographicRestriction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeographicRestriction" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="geographicRestrictionType">geographicRestrictionType (required).</param>
        public GeographicRestriction(string value = default(string), GeographicRestrictionTypeEnum geographicRestrictionType = default(GeographicRestrictionTypeEnum))
        {
            // to ensure "geographicRestrictionType" is required (not null)
            if (geographicRestrictionType == null)
            {
                throw new InvalidDataException("geographicRestrictionType is a required property for GeographicRestriction and cannot be null");
            }
            else
            {
                this.GeographicRestrictionType = geographicRestrictionType;
            }
            this.Value = value;
        }
        
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GeographicRestriction {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  GeographicRestrictionType: ").Append(GeographicRestrictionType).Append("\n");
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
            return this.Equals(input as GeographicRestriction);
        }

        /// <summary>
        /// Returns true if GeographicRestriction instances are equal
        /// </summary>
        /// <param name="input">Instance of GeographicRestriction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GeographicRestriction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.GeographicRestrictionType == input.GeographicRestrictionType ||
                    (this.GeographicRestrictionType != null &&
                    this.GeographicRestrictionType.Equals(input.GeographicRestrictionType))
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
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.GeographicRestrictionType != null)
                    hashCode = hashCode * 59 + this.GeographicRestrictionType.GetHashCode();
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
            // Value (string) maxLength
            if(this.Value != null && this.Value.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Value, length must be less than 32.", new [] { "Value" });
            }

            yield break;
        }
    }

}
