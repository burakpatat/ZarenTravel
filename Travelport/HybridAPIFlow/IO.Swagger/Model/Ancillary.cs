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
    /// Ancillary
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    public partial class Ancillary :  IEquatable<Ancillary>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ancillary" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Ancillary() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Ancillary" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="quantity">Assigned Type: c-1100:NumberDoubleDigit.</param>
        /// <param name="description">description (required).</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public Ancillary(string type = default(string), int? quantity = default(int?), List<AncillaryDescription> description = default(List<AncillaryDescription>), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for Ancillary and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for Ancillary and cannot be null");
            }
            else
            {
                this.Description = description;
            }
            this.Quantity = quantity;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NumberDoubleDigit
        /// </summary>
        /// <value>Assigned Type: c-1100:NumberDoubleDigit</value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public List<AncillaryDescription> Description { get; set; }

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
            sb.Append("class Ancillary {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as Ancillary);
        }

        /// <summary>
        /// Returns true if Ancillary instances are equal
        /// </summary>
        /// <param name="input">Instance of Ancillary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ancillary input)
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
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.Description == input.Description ||
                    this.Description != null &&
                    this.Description.SequenceEqual(input.Description)
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
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
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
            yield break;
        }
    }

}