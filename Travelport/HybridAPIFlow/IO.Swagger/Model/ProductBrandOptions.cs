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
    /// ProductBrandOptions
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    public partial class ProductBrandOptions :  IEquatable<ProductBrandOptions>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBrandOptions" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProductBrandOptions() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBrandOptions" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="flightRefs">Reference to the Flights that are used within ProductBrandOptions.</param>
        /// <param name="productBrandOffering">productBrandOffering (required).</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public ProductBrandOptions(string type = default(string), List<string> flightRefs = default(List<string>), List<ProductBrandOffering> productBrandOffering = default(List<ProductBrandOffering>), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for ProductBrandOptions and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "productBrandOffering" is required (not null)
            if (productBrandOffering == null)
            {
                throw new InvalidDataException("productBrandOffering is a required property for ProductBrandOptions and cannot be null");
            }
            else
            {
                this.ProductBrandOffering = productBrandOffering;
            }
            this.FlightRefs = flightRefs;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Reference to the Flights that are used within ProductBrandOptions
        /// </summary>
        /// <value>Reference to the Flights that are used within ProductBrandOptions</value>
        [DataMember(Name="flightRefs", EmitDefaultValue=false)]
        public List<string> FlightRefs { get; set; }

        /// <summary>
        /// Gets or Sets ProductBrandOffering
        /// </summary>
        [DataMember(Name="ProductBrandOffering", EmitDefaultValue=false)]
        public List<ProductBrandOffering> ProductBrandOffering { get; set; }

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
            sb.Append("class ProductBrandOptions {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FlightRefs: ").Append(FlightRefs).Append("\n");
            sb.Append("  ProductBrandOffering: ").Append(ProductBrandOffering).Append("\n");
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
            return this.Equals(input as ProductBrandOptions);
        }

        /// <summary>
        /// Returns true if ProductBrandOptions instances are equal
        /// </summary>
        /// <param name="input">Instance of ProductBrandOptions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProductBrandOptions input)
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
                    this.FlightRefs == input.FlightRefs ||
                    this.FlightRefs != null &&
                    this.FlightRefs.SequenceEqual(input.FlightRefs)
                ) && 
                (
                    this.ProductBrandOffering == input.ProductBrandOffering ||
                    this.ProductBrandOffering != null &&
                    this.ProductBrandOffering.SequenceEqual(input.ProductBrandOffering)
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
                if (this.FlightRefs != null)
                    hashCode = hashCode * 59 + this.FlightRefs.GetHashCode();
                if (this.ProductBrandOffering != null)
                    hashCode = hashCode * 59 + this.ProductBrandOffering.GetHashCode();
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
