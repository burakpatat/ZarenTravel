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
    /// A counrty, provence/state or city code
    /// </summary>
    [DataContract]
    public partial class TravelerGeographicLocation :  IEquatable<TravelerGeographicLocation>, IValidatableObject
    {
        /// <summary>
        /// The geographic location type.  For example (Country)
        /// </summary>
        /// <value>The geographic location type.  For example (Country)</value>
        [DataMember(Name="travelerGeographicLocationType", EmitDefaultValue=false)]
        public TravelerGeographicTypeEnum? TravelerGeographicLocationType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelerGeographicLocation" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="travelerGeographicLocationType">The geographic location type.  For example (Country).</param>
        public TravelerGeographicLocation(string value = default(string), TravelerGeographicTypeEnum? travelerGeographicLocationType = default(TravelerGeographicTypeEnum?))
        {
            this.Value = value;
            this.TravelerGeographicLocationType = travelerGeographicLocationType;
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
            sb.Append("class TravelerGeographicLocation {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  TravelerGeographicLocationType: ").Append(TravelerGeographicLocationType).Append("\n");
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
            return this.Equals(input as TravelerGeographicLocation);
        }

        /// <summary>
        /// Returns true if TravelerGeographicLocation instances are equal
        /// </summary>
        /// <param name="input">Instance of TravelerGeographicLocation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TravelerGeographicLocation input)
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
                    this.TravelerGeographicLocationType == input.TravelerGeographicLocationType ||
                    (this.TravelerGeographicLocationType != null &&
                    this.TravelerGeographicLocationType.Equals(input.TravelerGeographicLocationType))
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
                if (this.TravelerGeographicLocationType != null)
                    hashCode = hashCode * 59 + this.TravelerGeographicLocationType.GetHashCode();
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