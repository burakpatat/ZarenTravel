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
    /// ProductBrandOffering
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    [JsonSubtypes.KnownSubType(typeof(ProductBrandOfferingModify), "ProductBrandOfferingModify")]
    public partial class ProductBrandOffering :  IEquatable<ProductBrandOffering>, IValidatableObject
    {
        /// <summary>
        /// Assigned Type: ctbr-1101:BrandStatusEnum
        /// </summary>
        /// <value>Assigned Type: ctbr-1101:BrandStatusEnum</value>
        [DataMember(Name="BrandStatus", EmitDefaultValue=false)]
        public BrandStatusEnum? BrandStatus { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBrandOffering" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProductBrandOffering() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBrandOffering" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="identifier">Assigned Type: c-1100:Identifier.</param>
        /// <param name="price">Assigned Type: c-1100:Price.</param>
        /// <param name="brand">Assigned Type: ctbr-1100:Brand.</param>
        /// <param name="product">product.</param>
        /// <param name="termsAndConditions">Assigned Type: ctlg-1100:TermsAndConditions.</param>
        /// <param name="combinabilityCode">combinabilityCode.</param>
        /// <param name="bestCombinablePrice">Assigned Type: c-1100:BestCombinablePrice.</param>
        /// <param name="desirability">The desirability of the offering expressed as a percentage. The higher the percentage the more desirable the offering..</param>
        /// <param name="matchedAttributes">The number of matched attributes according to the request modifiers.</param>
        /// <param name="brandStatus">Assigned Type: ctbr-1101:BrandStatusEnum.</param>
        /// <param name="bestMatchInd">If true, this Offering is the best match according to the request modifiers.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public ProductBrandOffering(string type = default(string), Identifier identifier = default(Identifier), Price price = default(Price), BrandID brand = default(BrandID), List<ProductID> product = default(List<ProductID>), TermsAndConditionsID termsAndConditions = default(TermsAndConditionsID), List<string> combinabilityCode = default(List<string>), BestCombinablePrice bestCombinablePrice = default(BestCombinablePrice), float? desirability = default(float?), int? matchedAttributes = default(int?), BrandStatusEnum? brandStatus = default(BrandStatusEnum?), bool? bestMatchInd = default(bool?), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for ProductBrandOffering and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            this.Identifier = identifier;
            this.Price = price;
            this.Brand = brand;
            this.Product = product;
            this.TermsAndConditions = termsAndConditions;
            this.CombinabilityCode = combinabilityCode;
            this.BestCombinablePrice = bestCombinablePrice;
            this.Desirability = desirability;
            this.MatchedAttributes = matchedAttributes;
            this.BrandStatus = brandStatus;
            this.BestMatchInd = bestMatchInd;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Identifier
        /// </summary>
        /// <value>Assigned Type: c-1100:Identifier</value>
        [DataMember(Name="Identifier", EmitDefaultValue=false)]
        public Identifier Identifier { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Price
        /// </summary>
        /// <value>Assigned Type: c-1100:Price</value>
        [DataMember(Name="Price", EmitDefaultValue=false)]
        public Price Price { get; set; }

        /// <summary>
        /// Assigned Type: ctbr-1100:Brand
        /// </summary>
        /// <value>Assigned Type: ctbr-1100:Brand</value>
        [DataMember(Name="Brand", EmitDefaultValue=false)]
        public BrandID Brand { get; set; }

        /// <summary>
        /// Gets or Sets Product
        /// </summary>
        [DataMember(Name="Product", EmitDefaultValue=false)]
        public List<ProductID> Product { get; set; }

        /// <summary>
        /// Assigned Type: ctlg-1100:TermsAndConditions
        /// </summary>
        /// <value>Assigned Type: ctlg-1100:TermsAndConditions</value>
        [DataMember(Name="TermsAndConditions", EmitDefaultValue=false)]
        public TermsAndConditionsID TermsAndConditions { get; set; }

        /// <summary>
        /// Gets or Sets CombinabilityCode
        /// </summary>
        [DataMember(Name="CombinabilityCode", EmitDefaultValue=false)]
        public List<string> CombinabilityCode { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:BestCombinablePrice
        /// </summary>
        /// <value>Assigned Type: c-1100:BestCombinablePrice</value>
        [DataMember(Name="BestCombinablePrice", EmitDefaultValue=false)]
        public BestCombinablePrice BestCombinablePrice { get; set; }

        /// <summary>
        /// The desirability of the offering expressed as a percentage. The higher the percentage the more desirable the offering.
        /// </summary>
        /// <value>The desirability of the offering expressed as a percentage. The higher the percentage the more desirable the offering.</value>
        [DataMember(Name="Desirability", EmitDefaultValue=false)]
        public float? Desirability { get; set; }

        /// <summary>
        /// The number of matched attributes according to the request modifiers
        /// </summary>
        /// <value>The number of matched attributes according to the request modifiers</value>
        [DataMember(Name="MatchedAttributes", EmitDefaultValue=false)]
        public int? MatchedAttributes { get; set; }


        /// <summary>
        /// If true, this Offering is the best match according to the request modifiers
        /// </summary>
        /// <value>If true, this Offering is the best match according to the request modifiers</value>
        [DataMember(Name="bestMatchInd", EmitDefaultValue=false)]
        public bool? BestMatchInd { get; set; }

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
            sb.Append("class ProductBrandOffering {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Brand: ").Append(Brand).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
            sb.Append("  TermsAndConditions: ").Append(TermsAndConditions).Append("\n");
            sb.Append("  CombinabilityCode: ").Append(CombinabilityCode).Append("\n");
            sb.Append("  BestCombinablePrice: ").Append(BestCombinablePrice).Append("\n");
            sb.Append("  Desirability: ").Append(Desirability).Append("\n");
            sb.Append("  MatchedAttributes: ").Append(MatchedAttributes).Append("\n");
            sb.Append("  BrandStatus: ").Append(BrandStatus).Append("\n");
            sb.Append("  BestMatchInd: ").Append(BestMatchInd).Append("\n");
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
            return this.Equals(input as ProductBrandOffering);
        }

        /// <summary>
        /// Returns true if ProductBrandOffering instances are equal
        /// </summary>
        /// <param name="input">Instance of ProductBrandOffering to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProductBrandOffering input)
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
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Brand == input.Brand ||
                    (this.Brand != null &&
                    this.Brand.Equals(input.Brand))
                ) && 
                (
                    this.Product == input.Product ||
                    this.Product != null &&
                    this.Product.SequenceEqual(input.Product)
                ) && 
                (
                    this.TermsAndConditions == input.TermsAndConditions ||
                    (this.TermsAndConditions != null &&
                    this.TermsAndConditions.Equals(input.TermsAndConditions))
                ) && 
                (
                    this.CombinabilityCode == input.CombinabilityCode ||
                    this.CombinabilityCode != null &&
                    this.CombinabilityCode.SequenceEqual(input.CombinabilityCode)
                ) && 
                (
                    this.BestCombinablePrice == input.BestCombinablePrice ||
                    (this.BestCombinablePrice != null &&
                    this.BestCombinablePrice.Equals(input.BestCombinablePrice))
                ) && 
                (
                    this.Desirability == input.Desirability ||
                    (this.Desirability != null &&
                    this.Desirability.Equals(input.Desirability))
                ) && 
                (
                    this.MatchedAttributes == input.MatchedAttributes ||
                    (this.MatchedAttributes != null &&
                    this.MatchedAttributes.Equals(input.MatchedAttributes))
                ) && 
                (
                    this.BrandStatus == input.BrandStatus ||
                    (this.BrandStatus != null &&
                    this.BrandStatus.Equals(input.BrandStatus))
                ) && 
                (
                    this.BestMatchInd == input.BestMatchInd ||
                    (this.BestMatchInd != null &&
                    this.BestMatchInd.Equals(input.BestMatchInd))
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
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Brand != null)
                    hashCode = hashCode * 59 + this.Brand.GetHashCode();
                if (this.Product != null)
                    hashCode = hashCode * 59 + this.Product.GetHashCode();
                if (this.TermsAndConditions != null)
                    hashCode = hashCode * 59 + this.TermsAndConditions.GetHashCode();
                if (this.CombinabilityCode != null)
                    hashCode = hashCode * 59 + this.CombinabilityCode.GetHashCode();
                if (this.BestCombinablePrice != null)
                    hashCode = hashCode * 59 + this.BestCombinablePrice.GetHashCode();
                if (this.Desirability != null)
                    hashCode = hashCode * 59 + this.Desirability.GetHashCode();
                if (this.MatchedAttributes != null)
                    hashCode = hashCode * 59 + this.MatchedAttributes.GetHashCode();
                if (this.BrandStatus != null)
                    hashCode = hashCode * 59 + this.BrandStatus.GetHashCode();
                if (this.BestMatchInd != null)
                    hashCode = hashCode * 59 + this.BestMatchInd.GetHashCode();
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
            // Desirability (float?) minimum
            if(this.Desirability < (float?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Desirability, must be a value greater than or equal to 0.", new [] { "Desirability" });
            }

            // MatchedAttributes (int?) minimum
            if(this.MatchedAttributes < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MatchedAttributes, must be a value greater than or equal to 0.", new [] { "MatchedAttributes" });
            }

            yield break;
        }
    }

}
