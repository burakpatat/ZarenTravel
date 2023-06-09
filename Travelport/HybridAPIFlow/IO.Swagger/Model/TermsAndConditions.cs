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
    /// TermsAndConditions
    /// </summary>
    [DataContract]
    public partial class TermsAndConditions : TermsAndConditionsID,  IEquatable<TermsAndConditions>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TermsAndConditions" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TermsAndConditions() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TermsAndConditions" /> class.
        /// </summary>
        /// <param name="expiryDate">The data and time range that the Offer is valid..</param>
        /// <param name="customerLoyalty">customerLoyalty.</param>
        /// <param name="travelerProduct">travelerProduct.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public TermsAndConditions(DateTime? expiryDate = default(DateTime?), List<CustomerLoyalty> customerLoyalty = default(List<CustomerLoyalty>), List<TravelerProduct> travelerProduct = default(List<TravelerProduct>), Object extensionPoint = default(Object), string type = "TermsAndConditions", string id = default(string), string termsAndConditionsRef = default(string), Identifier identifier = default(Identifier)) : base(type, id, termsAndConditionsRef, identifier)
        {
            this.ExpiryDate = expiryDate;
            this.CustomerLoyalty = customerLoyalty;
            this.TravelerProduct = travelerProduct;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// The data and time range that the Offer is valid.
        /// </summary>
        /// <value>The data and time range that the Offer is valid.</value>
        [DataMember(Name="ExpiryDate", EmitDefaultValue=false)]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or Sets CustomerLoyalty
        /// </summary>
        [DataMember(Name="CustomerLoyalty", EmitDefaultValue=false)]
        public List<CustomerLoyalty> CustomerLoyalty { get; set; }

        /// <summary>
        /// Gets or Sets TravelerProduct
        /// </summary>
        [DataMember(Name="TravelerProduct", EmitDefaultValue=false)]
        public List<TravelerProduct> TravelerProduct { get; set; }

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
            sb.Append("class TermsAndConditions {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  ExpiryDate: ").Append(ExpiryDate).Append("\n");
            sb.Append("  CustomerLoyalty: ").Append(CustomerLoyalty).Append("\n");
            sb.Append("  TravelerProduct: ").Append(TravelerProduct).Append("\n");
            sb.Append("  ExtensionPoint: ").Append(ExtensionPoint).Append("\n");
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
            return this.Equals(input as TermsAndConditions);
        }

        /// <summary>
        /// Returns true if TermsAndConditions instances are equal
        /// </summary>
        /// <param name="input">Instance of TermsAndConditions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TermsAndConditions input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.ExpiryDate == input.ExpiryDate ||
                    (this.ExpiryDate != null &&
                    this.ExpiryDate.Equals(input.ExpiryDate))
                ) && base.Equals(input) && 
                (
                    this.CustomerLoyalty == input.CustomerLoyalty ||
                    this.CustomerLoyalty != null &&
                    this.CustomerLoyalty.SequenceEqual(input.CustomerLoyalty)
                ) && base.Equals(input) && 
                (
                    this.TravelerProduct == input.TravelerProduct ||
                    this.TravelerProduct != null &&
                    this.TravelerProduct.SequenceEqual(input.TravelerProduct)
                ) && base.Equals(input) && 
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
                int hashCode = base.GetHashCode();
                if (this.ExpiryDate != null)
                    hashCode = hashCode * 59 + this.ExpiryDate.GetHashCode();
                if (this.CustomerLoyalty != null)
                    hashCode = hashCode * 59 + this.CustomerLoyalty.GetHashCode();
                if (this.TravelerProduct != null)
                    hashCode = hashCode * 59 + this.TravelerProduct.GetHashCode();
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
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
