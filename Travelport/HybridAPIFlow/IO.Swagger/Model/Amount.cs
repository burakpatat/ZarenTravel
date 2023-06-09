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
    /// Amount
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    public partial class Amount :  IEquatable<Amount>, IValidatableObject
    {
        /// <summary>
        /// Source of the selection of this currenct
        /// </summary>
        /// <value>Source of the selection of this currenct</value>
        [DataMember(Name="currencySource", EmitDefaultValue=false)]
        public CurrencySourceEnum? CurrencySource { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Amount" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Amount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Amount" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="currencySource">Source of the selection of this currenct.</param>
        /// <param name="currencyCode">Assigned Type: c-1100:CurrencyCode.</param>
        /// <param name="_base">The price prior to all applicable taxes of a product such as the rate for a room or fare for a flight..</param>
        /// <param name="taxes">Assigned Type: c-1100:Taxes.</param>
        /// <param name="fees">Assigned Type: c-1100:Fees.</param>
        /// <param name="total">Specifies the total price including base + taxes + fees.</param>
        /// <param name="approximateInd">True if this amount has been converted from the original amount.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public Amount(string type = default(string), CurrencySourceEnum? currencySource = default(CurrencySourceEnum?), CurrencyCode currencyCode = default(CurrencyCode), float? _base = default(float?), Taxes taxes = default(Taxes), Fees fees = default(Fees), float? total = default(float?), bool? approximateInd = default(bool?), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for Amount and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            this.CurrencySource = currencySource;
            this.CurrencyCode = currencyCode;
            this.Base = _base;
            this.Taxes = taxes;
            this.Fees = fees;
            this.Total = total;
            this.ApproximateInd = approximateInd;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }


        /// <summary>
        /// Assigned Type: c-1100:CurrencyCode
        /// </summary>
        /// <value>Assigned Type: c-1100:CurrencyCode</value>
        [DataMember(Name="CurrencyCode", EmitDefaultValue=false)]
        public CurrencyCode CurrencyCode { get; set; }

        /// <summary>
        /// The price prior to all applicable taxes of a product such as the rate for a room or fare for a flight.
        /// </summary>
        /// <value>The price prior to all applicable taxes of a product such as the rate for a room or fare for a flight.</value>
        [DataMember(Name="Base", EmitDefaultValue=false)]
        public float? Base { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Taxes
        /// </summary>
        /// <value>Assigned Type: c-1100:Taxes</value>
        [DataMember(Name="Taxes", EmitDefaultValue=false)]
        public Taxes Taxes { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Fees
        /// </summary>
        /// <value>Assigned Type: c-1100:Fees</value>
        [DataMember(Name="Fees", EmitDefaultValue=false)]
        public Fees Fees { get; set; }

        /// <summary>
        /// Specifies the total price including base + taxes + fees
        /// </summary>
        /// <value>Specifies the total price including base + taxes + fees</value>
        [DataMember(Name="Total", EmitDefaultValue=false)]
        public float? Total { get; set; }

        /// <summary>
        /// True if this amount has been converted from the original amount
        /// </summary>
        /// <value>True if this amount has been converted from the original amount</value>
        [DataMember(Name="approximateInd", EmitDefaultValue=false)]
        public bool? ApproximateInd { get; set; }

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
            sb.Append("class Amount {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CurrencySource: ").Append(CurrencySource).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Base: ").Append(Base).Append("\n");
            sb.Append("  Taxes: ").Append(Taxes).Append("\n");
            sb.Append("  Fees: ").Append(Fees).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  ApproximateInd: ").Append(ApproximateInd).Append("\n");
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
            return this.Equals(input as Amount);
        }

        /// <summary>
        /// Returns true if Amount instances are equal
        /// </summary>
        /// <param name="input">Instance of Amount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Amount input)
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
                    this.CurrencySource == input.CurrencySource ||
                    (this.CurrencySource != null &&
                    this.CurrencySource.Equals(input.CurrencySource))
                ) && 
                (
                    this.CurrencyCode == input.CurrencyCode ||
                    (this.CurrencyCode != null &&
                    this.CurrencyCode.Equals(input.CurrencyCode))
                ) && 
                (
                    this.Base == input.Base ||
                    (this.Base != null &&
                    this.Base.Equals(input.Base))
                ) && 
                (
                    this.Taxes == input.Taxes ||
                    (this.Taxes != null &&
                    this.Taxes.Equals(input.Taxes))
                ) && 
                (
                    this.Fees == input.Fees ||
                    (this.Fees != null &&
                    this.Fees.Equals(input.Fees))
                ) && 
                (
                    this.Total == input.Total ||
                    (this.Total != null &&
                    this.Total.Equals(input.Total))
                ) && 
                (
                    this.ApproximateInd == input.ApproximateInd ||
                    (this.ApproximateInd != null &&
                    this.ApproximateInd.Equals(input.ApproximateInd))
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
                if (this.CurrencySource != null)
                    hashCode = hashCode * 59 + this.CurrencySource.GetHashCode();
                if (this.CurrencyCode != null)
                    hashCode = hashCode * 59 + this.CurrencyCode.GetHashCode();
                if (this.Base != null)
                    hashCode = hashCode * 59 + this.Base.GetHashCode();
                if (this.Taxes != null)
                    hashCode = hashCode * 59 + this.Taxes.GetHashCode();
                if (this.Fees != null)
                    hashCode = hashCode * 59 + this.Fees.GetHashCode();
                if (this.Total != null)
                    hashCode = hashCode * 59 + this.Total.GetHashCode();
                if (this.ApproximateInd != null)
                    hashCode = hashCode * 59 + this.ApproximateInd.GetHashCode();
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
