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
    /// OfferQueryBuildFromCatalogOfferings
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    public partial class OfferQueryBuildFromCatalogOfferings :  IEquatable<OfferQueryBuildFromCatalogOfferings>, IValidatableObject
    {
        /// <summary>
        /// Assigned Type: ctlg-1100:FareRuleEnum
        /// </summary>
        /// <value>Assigned Type: ctlg-1100:FareRuleEnum</value>
        [DataMember(Name="FareRuleType", EmitDefaultValue=false)]
        public FareRuleEnum? FareRuleType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferQueryBuildFromCatalogOfferings" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OfferQueryBuildFromCatalogOfferings() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferQueryBuildFromCatalogOfferings" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="buildFromCatalogOfferingsRequest">Assigned Type: ctlg-1100:BuildFromCatalogOfferingsRequest.</param>
        /// <param name="cabinPreference">Assigned Type: ctar-1100:CabinPreference.</param>
        /// <param name="paymentCriteria">Assigned Type: ctlg-1100:PaymentCriteria.</param>
        /// <param name="fareRuleType">Assigned Type: ctlg-1100:FareRuleEnum.</param>
        /// <param name="fareRuleCategory">fareRuleCategory.</param>
        /// <param name="lowFareFinderInd">If present and true, this is a low fare finder request.</param>
        /// <param name="returnBrandedFaresInd">If present and true, branded fares are returned.</param>
        /// <param name="reCheckInventoryInd">If present and true, then the host system will perform a sell inventory check..</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public OfferQueryBuildFromCatalogOfferings(string type = default(string), BuildFromCatalogOfferingsRequest buildFromCatalogOfferingsRequest = default(BuildFromCatalogOfferingsRequest), CabinPreference cabinPreference = default(CabinPreference), PaymentCriteria paymentCriteria = default(PaymentCriteria), FareRuleEnum? fareRuleType = default(FareRuleEnum?), List<FareRuleCategoryEnum> fareRuleCategory = default(List<FareRuleCategoryEnum>), bool? lowFareFinderInd = default(bool?), bool? returnBrandedFaresInd = default(bool?), bool? reCheckInventoryInd = default(bool?), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for OfferQueryBuildFromCatalogOfferings and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            this.BuildFromCatalogOfferingsRequest = buildFromCatalogOfferingsRequest;
            this.CabinPreference = cabinPreference;
            this.PaymentCriteria = paymentCriteria;
            this.FareRuleType = fareRuleType;
            this.FareRuleCategory = fareRuleCategory;
            this.LowFareFinderInd = lowFareFinderInd;
            this.ReturnBrandedFaresInd = returnBrandedFaresInd;
            this.ReCheckInventoryInd = reCheckInventoryInd;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Assigned Type: ctlg-1100:BuildFromCatalogOfferingsRequest
        /// </summary>
        /// <value>Assigned Type: ctlg-1100:BuildFromCatalogOfferingsRequest</value>
        [DataMember(Name="BuildFromCatalogOfferingsRequest", EmitDefaultValue=false)]
        public BuildFromCatalogOfferingsRequest BuildFromCatalogOfferingsRequest { get; set; }

        /// <summary>
        /// Assigned Type: ctar-1100:CabinPreference
        /// </summary>
        /// <value>Assigned Type: ctar-1100:CabinPreference</value>
        [DataMember(Name="CabinPreference", EmitDefaultValue=false)]
        public CabinPreference CabinPreference { get; set; }

        /// <summary>
        /// Assigned Type: ctlg-1100:PaymentCriteria
        /// </summary>
        /// <value>Assigned Type: ctlg-1100:PaymentCriteria</value>
        [DataMember(Name="PaymentCriteria", EmitDefaultValue=false)]
        public PaymentCriteria PaymentCriteria { get; set; }


        /// <summary>
        /// Gets or Sets FareRuleCategory
        /// </summary>
        [DataMember(Name="FareRuleCategory", EmitDefaultValue=false)]
        public List<FareRuleCategoryEnum> FareRuleCategory { get; set; }

        /// <summary>
        /// If present and true, this is a low fare finder request
        /// </summary>
        /// <value>If present and true, this is a low fare finder request</value>
        [DataMember(Name="lowFareFinderInd", EmitDefaultValue=false)]
        public bool? LowFareFinderInd { get; set; }

        /// <summary>
        /// If present and true, branded fares are returned
        /// </summary>
        /// <value>If present and true, branded fares are returned</value>
        [DataMember(Name="returnBrandedFaresInd", EmitDefaultValue=false)]
        public bool? ReturnBrandedFaresInd { get; set; }

        /// <summary>
        /// If present and true, then the host system will perform a sell inventory check.
        /// </summary>
        /// <value>If present and true, then the host system will perform a sell inventory check.</value>
        [DataMember(Name="reCheckInventoryInd", EmitDefaultValue=false)]
        public bool? ReCheckInventoryInd { get; set; }

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
            sb.Append("class OfferQueryBuildFromCatalogOfferings {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  BuildFromCatalogOfferingsRequest: ").Append(BuildFromCatalogOfferingsRequest).Append("\n");
            sb.Append("  CabinPreference: ").Append(CabinPreference).Append("\n");
            sb.Append("  PaymentCriteria: ").Append(PaymentCriteria).Append("\n");
            sb.Append("  FareRuleType: ").Append(FareRuleType).Append("\n");
            sb.Append("  FareRuleCategory: ").Append(FareRuleCategory).Append("\n");
            sb.Append("  LowFareFinderInd: ").Append(LowFareFinderInd).Append("\n");
            sb.Append("  ReturnBrandedFaresInd: ").Append(ReturnBrandedFaresInd).Append("\n");
            sb.Append("  ReCheckInventoryInd: ").Append(ReCheckInventoryInd).Append("\n");
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
            return this.Equals(input as OfferQueryBuildFromCatalogOfferings);
        }

        /// <summary>
        /// Returns true if OfferQueryBuildFromCatalogOfferings instances are equal
        /// </summary>
        /// <param name="input">Instance of OfferQueryBuildFromCatalogOfferings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OfferQueryBuildFromCatalogOfferings input)
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
                    this.BuildFromCatalogOfferingsRequest == input.BuildFromCatalogOfferingsRequest ||
                    (this.BuildFromCatalogOfferingsRequest != null &&
                    this.BuildFromCatalogOfferingsRequest.Equals(input.BuildFromCatalogOfferingsRequest))
                ) && 
                (
                    this.CabinPreference == input.CabinPreference ||
                    (this.CabinPreference != null &&
                    this.CabinPreference.Equals(input.CabinPreference))
                ) && 
                (
                    this.PaymentCriteria == input.PaymentCriteria ||
                    (this.PaymentCriteria != null &&
                    this.PaymentCriteria.Equals(input.PaymentCriteria))
                ) && 
                (
                    this.FareRuleType == input.FareRuleType ||
                    (this.FareRuleType != null &&
                    this.FareRuleType.Equals(input.FareRuleType))
                ) && 
                (
                    this.FareRuleCategory == input.FareRuleCategory ||
                    this.FareRuleCategory != null &&
                    this.FareRuleCategory.SequenceEqual(input.FareRuleCategory)
                ) && 
                (
                    this.LowFareFinderInd == input.LowFareFinderInd ||
                    (this.LowFareFinderInd != null &&
                    this.LowFareFinderInd.Equals(input.LowFareFinderInd))
                ) && 
                (
                    this.ReturnBrandedFaresInd == input.ReturnBrandedFaresInd ||
                    (this.ReturnBrandedFaresInd != null &&
                    this.ReturnBrandedFaresInd.Equals(input.ReturnBrandedFaresInd))
                ) && 
                (
                    this.ReCheckInventoryInd == input.ReCheckInventoryInd ||
                    (this.ReCheckInventoryInd != null &&
                    this.ReCheckInventoryInd.Equals(input.ReCheckInventoryInd))
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
                if (this.BuildFromCatalogOfferingsRequest != null)
                    hashCode = hashCode * 59 + this.BuildFromCatalogOfferingsRequest.GetHashCode();
                if (this.CabinPreference != null)
                    hashCode = hashCode * 59 + this.CabinPreference.GetHashCode();
                if (this.PaymentCriteria != null)
                    hashCode = hashCode * 59 + this.PaymentCriteria.GetHashCode();
                if (this.FareRuleType != null)
                    hashCode = hashCode * 59 + this.FareRuleType.GetHashCode();
                if (this.FareRuleCategory != null)
                    hashCode = hashCode * 59 + this.FareRuleCategory.GetHashCode();
                if (this.LowFareFinderInd != null)
                    hashCode = hashCode * 59 + this.LowFareFinderInd.GetHashCode();
                if (this.ReturnBrandedFaresInd != null)
                    hashCode = hashCode * 59 + this.ReturnBrandedFaresInd.GetHashCode();
                if (this.ReCheckInventoryInd != null)
                    hashCode = hashCode * 59 + this.ReCheckInventoryInd.GetHashCode();
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
