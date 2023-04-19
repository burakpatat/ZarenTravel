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
    /// SearchControlConsoleChannelID
    /// </summary>
    [DataContract]
    public partial class SearchControlConsoleChannelID :  IEquatable<SearchControlConsoleChannelID>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchControlConsoleChannelID" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="sccType">Assigned Type: c-1100:StringTiny.</param>
        public SearchControlConsoleChannelID(string value = default(string), string sccType = default(string))
        {
            this.Value = value;
            this.SccType = sccType;
        }
        
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringTiny
        /// </summary>
        /// <value>Assigned Type: c-1100:StringTiny</value>
        [DataMember(Name="sccType", EmitDefaultValue=false)]
        public string SccType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SearchControlConsoleChannelID {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  SccType: ").Append(SccType).Append("\n");
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
            return this.Equals(input as SearchControlConsoleChannelID);
        }

        /// <summary>
        /// Returns true if SearchControlConsoleChannelID instances are equal
        /// </summary>
        /// <param name="input">Instance of SearchControlConsoleChannelID to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SearchControlConsoleChannelID input)
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
                    this.SccType == input.SccType ||
                    (this.SccType != null &&
                    this.SccType.Equals(input.SccType))
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
                if (this.SccType != null)
                    hashCode = hashCode * 59 + this.SccType.GetHashCode();
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

            // SccType (string) maxLength
            if(this.SccType != null && this.SccType.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SccType, length must be less than 32.", new [] { "SccType" });
            }

            yield break;
        }
    }

}