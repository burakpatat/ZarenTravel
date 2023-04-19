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
    /// TravelerIdentifierRef
    /// </summary>
    [DataContract]
    public partial class TravelerIdentifierRef :  IEquatable<TravelerIdentifierRef>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelerIdentifierRef" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="name">Assigned Type: c-1100:PersonName_Simple.</param>
        /// <param name="passengerTypeCode">Assigned Type: c-1100:PassengerTypeCode.</param>
        /// <param name="id">A locally referenced ID.</param>
        /// <param name="description">Descriptive text used to identify the contents of a target object.</param>
        /// <param name="uris">Assigned Type: c-1100:URIs.</param>
        public TravelerIdentifierRef(string value = default(string), string name = default(string), string passengerTypeCode = default(string), string id = default(string), string description = default(string), List<string> uris = default(List<string>))
        {
            this.Value = value;
            this.Name = name;
            this.PassengerTypeCode = passengerTypeCode;
            this.Id = id;
            this.Description = description;
            this.Uris = uris;
        }
        
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:PersonName_Simple
        /// </summary>
        /// <value>Assigned Type: c-1100:PersonName_Simple</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:PassengerTypeCode
        /// </summary>
        /// <value>Assigned Type: c-1100:PassengerTypeCode</value>
        [DataMember(Name="passengerTypeCode", EmitDefaultValue=false)]
        public string PassengerTypeCode { get; set; }

        /// <summary>
        /// A locally referenced ID
        /// </summary>
        /// <value>A locally referenced ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Descriptive text used to identify the contents of a target object
        /// </summary>
        /// <value>Descriptive text used to identify the contents of a target object</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:URIs
        /// </summary>
        /// <value>Assigned Type: c-1100:URIs</value>
        [DataMember(Name="uris", EmitDefaultValue=false)]
        public List<string> Uris { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TravelerIdentifierRef {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PassengerTypeCode: ").Append(PassengerTypeCode).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Uris: ").Append(Uris).Append("\n");
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
            return this.Equals(input as TravelerIdentifierRef);
        }

        /// <summary>
        /// Returns true if TravelerIdentifierRef instances are equal
        /// </summary>
        /// <param name="input">Instance of TravelerIdentifierRef to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TravelerIdentifierRef input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.PassengerTypeCode == input.PassengerTypeCode ||
                    (this.PassengerTypeCode != null &&
                    this.PassengerTypeCode.Equals(input.PassengerTypeCode))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Uris == input.Uris ||
                    this.Uris != null &&
                    this.Uris.SequenceEqual(input.Uris)
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.PassengerTypeCode != null)
                    hashCode = hashCode * 59 + this.PassengerTypeCode.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Uris != null)
                    hashCode = hashCode * 59 + this.Uris.GetHashCode();
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
            if(this.Value != null && this.Value.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Value, length must be less than 128.", new [] { "Value" });
            }

            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 512)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 512.", new [] { "Name" });
            }

            // PassengerTypeCode (string) maxLength
            if(this.PassengerTypeCode != null && this.PassengerTypeCode.Length > 5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PassengerTypeCode, length must be less than 5.", new [] { "PassengerTypeCode" });
            }

            // PassengerTypeCode (string) minLength
            if(this.PassengerTypeCode != null && this.PassengerTypeCode.Length < 3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PassengerTypeCode, length must be greater than 3.", new [] { "PassengerTypeCode" });
            }

            // PassengerTypeCode (string) pattern
            Regex regexPassengerTypeCode = new Regex(@"([a-zA-Z0-9]{3,5})", RegexOptions.CultureInvariant);
            if (false == regexPassengerTypeCode.Match(this.PassengerTypeCode).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PassengerTypeCode, must match a pattern of " + regexPassengerTypeCode, new [] { "PassengerTypeCode" });
            }

            yield break;
        }
    }

}
