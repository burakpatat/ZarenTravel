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
    /// TaxesDetail
    /// </summary>
    [DataContract]
    public partial class TaxesDetail : Taxes,  IEquatable<TaxesDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxesDetail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TaxesDetail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxesDetail" /> class.
        /// </summary>
        /// <param name="tax">tax.</param>
        /// <param name="taxPercent">Assigned Type: c-1100:TaxPercent.</param>
        /// <param name="extensionPointDetail">extensionPointDetail.</param>
        public TaxesDetail(List<Tax> tax = default(List<Tax>), TaxPercent taxPercent = default(TaxPercent), ExtensionPointDetail extensionPointDetail = default(ExtensionPointDetail), string type = "TaxesDetail", float? totalTaxes = default(float?), Object extensionPoint = default(Object)) : base(type, totalTaxes, extensionPoint)
        {
            this.Tax = tax;
            this.TaxPercent = taxPercent;
            this.ExtensionPointDetail = extensionPointDetail;
        }
        
        /// <summary>
        /// Gets or Sets Tax
        /// </summary>
        [DataMember(Name="Tax", EmitDefaultValue=false)]
        public List<Tax> Tax { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:TaxPercent
        /// </summary>
        /// <value>Assigned Type: c-1100:TaxPercent</value>
        [DataMember(Name="TaxPercent", EmitDefaultValue=false)]
        public TaxPercent TaxPercent { get; set; }

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
            sb.Append("class TaxesDetail {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Tax: ").Append(Tax).Append("\n");
            sb.Append("  TaxPercent: ").Append(TaxPercent).Append("\n");
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
            return this.Equals(input as TaxesDetail);
        }

        /// <summary>
        /// Returns true if TaxesDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of TaxesDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaxesDetail input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Tax == input.Tax ||
                    this.Tax != null &&
                    this.Tax.SequenceEqual(input.Tax)
                ) && base.Equals(input) && 
                (
                    this.TaxPercent == input.TaxPercent ||
                    (this.TaxPercent != null &&
                    this.TaxPercent.Equals(input.TaxPercent))
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
                if (this.Tax != null)
                    hashCode = hashCode * 59 + this.Tax.GetHashCode();
                if (this.TaxPercent != null)
                    hashCode = hashCode * 59 + this.TaxPercent.GetHashCode();
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
            yield break;
        }
    }

}
