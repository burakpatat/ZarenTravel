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
    /// FareGuaranteePolicy
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    public partial class FareGuaranteePolicy :  IEquatable<FareGuaranteePolicy>, IValidatableObject
    {
        /// <summary>
        /// Assigned Type: c-1100:YesNoUnknownEnum
        /// </summary>
        /// <value>Assigned Type: c-1100:YesNoUnknownEnum</value>
        [DataMember(Name="EligibleforADMReview", EmitDefaultValue=false)]
        public YesNoUnknownEnum EligibleforADMReview { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FareGuaranteePolicy" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FareGuaranteePolicy() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FareGuaranteePolicy" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="passengerTypeCodes">Assigned Type: c-1100:PassengerTypeCodeList.</param>
        /// <param name="eligibleforADMReview">Assigned Type: c-1100:YesNoUnknownEnum (required).</param>
        /// <param name="code">Assigned Type: c-1100:Code.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public FareGuaranteePolicy(string type = default(string), List<string> passengerTypeCodes = default(List<string>), YesNoUnknownEnum eligibleforADMReview = default(YesNoUnknownEnum), Code code = default(Code), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for FareGuaranteePolicy and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "eligibleforADMReview" is required (not null)
            if (eligibleforADMReview == null)
            {
                throw new InvalidDataException("eligibleforADMReview is a required property for FareGuaranteePolicy and cannot be null");
            }
            else
            {
                this.EligibleforADMReview = eligibleforADMReview;
            }
            this.PassengerTypeCodes = passengerTypeCodes;
            this.Code = code;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:PassengerTypeCodeList
        /// </summary>
        /// <value>Assigned Type: c-1100:PassengerTypeCodeList</value>
        [DataMember(Name="passengerTypeCodes", EmitDefaultValue=false)]
        public List<string> PassengerTypeCodes { get; set; }


        /// <summary>
        /// Assigned Type: c-1100:Code
        /// </summary>
        /// <value>Assigned Type: c-1100:Code</value>
        [DataMember(Name="Code", EmitDefaultValue=false)]
        public Code Code { get; set; }

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
            sb.Append("class FareGuaranteePolicy {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  PassengerTypeCodes: ").Append(PassengerTypeCodes).Append("\n");
            sb.Append("  EligibleforADMReview: ").Append(EligibleforADMReview).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
            return this.Equals(input as FareGuaranteePolicy);
        }

        /// <summary>
        /// Returns true if FareGuaranteePolicy instances are equal
        /// </summary>
        /// <param name="input">Instance of FareGuaranteePolicy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FareGuaranteePolicy input)
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
                    this.PassengerTypeCodes == input.PassengerTypeCodes ||
                    this.PassengerTypeCodes != null &&
                    this.PassengerTypeCodes.SequenceEqual(input.PassengerTypeCodes)
                ) && 
                (
                    this.EligibleforADMReview == input.EligibleforADMReview ||
                    (this.EligibleforADMReview != null &&
                    this.EligibleforADMReview.Equals(input.EligibleforADMReview))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
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
                if (this.PassengerTypeCodes != null)
                    hashCode = hashCode * 59 + this.PassengerTypeCodes.GetHashCode();
                if (this.EligibleforADMReview != null)
                    hashCode = hashCode * 59 + this.EligibleforADMReview.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
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
