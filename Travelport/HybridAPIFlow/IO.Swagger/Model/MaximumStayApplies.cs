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
    /// MaximumStayApplies
    /// </summary>
    [DataContract]
    public partial class MaximumStayApplies : MaximumStay,  IEquatable<MaximumStayApplies>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaximumStayApplies" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MaximumStayApplies() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MaximumStayApplies" /> class.
        /// </summary>
        /// <param name="maximumStayDuration">maximumStayDuration.</param>
        /// <param name="maximumStayDate">maximumStayDate.</param>
        /// <param name="returnTime">Assigned Type: ota2:LocalTime.</param>
        /// <param name="mustCommenceByInd">Indicates if travel must commence by this date/duration.</param>
        /// <param name="mustCompleteByInd">Indicates if travel must complete by this date/duration.</param>
        /// <param name="fromDateOfIssueInd">If true the Maximum stay is calculated from the date of ticket issuance.</param>
        /// <param name="earliestAppliesInd">If true, the earlier of the Maximum stay conditions apply.</param>
        /// <param name="latestAppliesInd">If true, the later of the Maximum stay conditions apply.</param>
        /// <param name="extensionPointChoice">extensionPointChoice.</param>
        public MaximumStayApplies(string maximumStayDuration = default(string), DateTime? maximumStayDate = default(DateTime?), string returnTime = default(string), bool? mustCommenceByInd = default(bool?), bool? mustCompleteByInd = default(bool?), bool? fromDateOfIssueInd = default(bool?), bool? earliestAppliesInd = default(bool?), bool? latestAppliesInd = default(bool?), ExtensionPointChoice extensionPointChoice = default(ExtensionPointChoice), string type = "MaximumStayApplies", Object extensionPoint = default(Object)) : base(type, extensionPoint)
        {
            this.MaximumStayDuration = maximumStayDuration;
            this.MaximumStayDate = maximumStayDate;
            this.ReturnTime = returnTime;
            this.MustCommenceByInd = mustCommenceByInd;
            this.MustCompleteByInd = mustCompleteByInd;
            this.FromDateOfIssueInd = fromDateOfIssueInd;
            this.EarliestAppliesInd = earliestAppliesInd;
            this.LatestAppliesInd = latestAppliesInd;
            this.ExtensionPointChoice = extensionPointChoice;
        }
        
        /// <summary>
        /// Gets or Sets MaximumStayDuration
        /// </summary>
        [DataMember(Name="maximumStayDuration", EmitDefaultValue=false)]
        public string MaximumStayDuration { get; set; }

        /// <summary>
        /// Gets or Sets MaximumStayDate
        /// </summary>
        [DataMember(Name="maximumStayDate", EmitDefaultValue=false)]
        [JsonConverter(typeof(SwaggerDateConverter))]
        public DateTime? MaximumStayDate { get; set; }

        /// <summary>
        /// Assigned Type: ota2:LocalTime
        /// </summary>
        /// <value>Assigned Type: ota2:LocalTime</value>
        [DataMember(Name="returnTime", EmitDefaultValue=false)]
        public string ReturnTime { get; set; }

        /// <summary>
        /// Indicates if travel must commence by this date/duration
        /// </summary>
        /// <value>Indicates if travel must commence by this date/duration</value>
        [DataMember(Name="mustCommenceByInd", EmitDefaultValue=false)]
        public bool? MustCommenceByInd { get; set; }

        /// <summary>
        /// Indicates if travel must complete by this date/duration
        /// </summary>
        /// <value>Indicates if travel must complete by this date/duration</value>
        [DataMember(Name="mustCompleteByInd", EmitDefaultValue=false)]
        public bool? MustCompleteByInd { get; set; }

        /// <summary>
        /// If true the Maximum stay is calculated from the date of ticket issuance
        /// </summary>
        /// <value>If true the Maximum stay is calculated from the date of ticket issuance</value>
        [DataMember(Name="fromDateOfIssueInd", EmitDefaultValue=false)]
        public bool? FromDateOfIssueInd { get; set; }

        /// <summary>
        /// If true, the earlier of the Maximum stay conditions apply
        /// </summary>
        /// <value>If true, the earlier of the Maximum stay conditions apply</value>
        [DataMember(Name="earliestAppliesInd", EmitDefaultValue=false)]
        public bool? EarliestAppliesInd { get; set; }

        /// <summary>
        /// If true, the later of the Maximum stay conditions apply
        /// </summary>
        /// <value>If true, the later of the Maximum stay conditions apply</value>
        [DataMember(Name="latestAppliesInd", EmitDefaultValue=false)]
        public bool? LatestAppliesInd { get; set; }

        /// <summary>
        /// Gets or Sets ExtensionPointChoice
        /// </summary>
        [DataMember(Name="ExtensionPoint_Choice", EmitDefaultValue=false)]
        public ExtensionPointChoice ExtensionPointChoice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MaximumStayApplies {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  MaximumStayDuration: ").Append(MaximumStayDuration).Append("\n");
            sb.Append("  MaximumStayDate: ").Append(MaximumStayDate).Append("\n");
            sb.Append("  ReturnTime: ").Append(ReturnTime).Append("\n");
            sb.Append("  MustCommenceByInd: ").Append(MustCommenceByInd).Append("\n");
            sb.Append("  MustCompleteByInd: ").Append(MustCompleteByInd).Append("\n");
            sb.Append("  FromDateOfIssueInd: ").Append(FromDateOfIssueInd).Append("\n");
            sb.Append("  EarliestAppliesInd: ").Append(EarliestAppliesInd).Append("\n");
            sb.Append("  LatestAppliesInd: ").Append(LatestAppliesInd).Append("\n");
            sb.Append("  ExtensionPointChoice: ").Append(ExtensionPointChoice).Append("\n");
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
            return this.Equals(input as MaximumStayApplies);
        }

        /// <summary>
        /// Returns true if MaximumStayApplies instances are equal
        /// </summary>
        /// <param name="input">Instance of MaximumStayApplies to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MaximumStayApplies input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.MaximumStayDuration == input.MaximumStayDuration ||
                    (this.MaximumStayDuration != null &&
                    this.MaximumStayDuration.Equals(input.MaximumStayDuration))
                ) && base.Equals(input) && 
                (
                    this.MaximumStayDate == input.MaximumStayDate ||
                    (this.MaximumStayDate != null &&
                    this.MaximumStayDate.Equals(input.MaximumStayDate))
                ) && base.Equals(input) && 
                (
                    this.ReturnTime == input.ReturnTime ||
                    (this.ReturnTime != null &&
                    this.ReturnTime.Equals(input.ReturnTime))
                ) && base.Equals(input) && 
                (
                    this.MustCommenceByInd == input.MustCommenceByInd ||
                    (this.MustCommenceByInd != null &&
                    this.MustCommenceByInd.Equals(input.MustCommenceByInd))
                ) && base.Equals(input) && 
                (
                    this.MustCompleteByInd == input.MustCompleteByInd ||
                    (this.MustCompleteByInd != null &&
                    this.MustCompleteByInd.Equals(input.MustCompleteByInd))
                ) && base.Equals(input) && 
                (
                    this.FromDateOfIssueInd == input.FromDateOfIssueInd ||
                    (this.FromDateOfIssueInd != null &&
                    this.FromDateOfIssueInd.Equals(input.FromDateOfIssueInd))
                ) && base.Equals(input) && 
                (
                    this.EarliestAppliesInd == input.EarliestAppliesInd ||
                    (this.EarliestAppliesInd != null &&
                    this.EarliestAppliesInd.Equals(input.EarliestAppliesInd))
                ) && base.Equals(input) && 
                (
                    this.LatestAppliesInd == input.LatestAppliesInd ||
                    (this.LatestAppliesInd != null &&
                    this.LatestAppliesInd.Equals(input.LatestAppliesInd))
                ) && base.Equals(input) && 
                (
                    this.ExtensionPointChoice == input.ExtensionPointChoice ||
                    (this.ExtensionPointChoice != null &&
                    this.ExtensionPointChoice.Equals(input.ExtensionPointChoice))
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
                if (this.MaximumStayDuration != null)
                    hashCode = hashCode * 59 + this.MaximumStayDuration.GetHashCode();
                if (this.MaximumStayDate != null)
                    hashCode = hashCode * 59 + this.MaximumStayDate.GetHashCode();
                if (this.ReturnTime != null)
                    hashCode = hashCode * 59 + this.ReturnTime.GetHashCode();
                if (this.MustCommenceByInd != null)
                    hashCode = hashCode * 59 + this.MustCommenceByInd.GetHashCode();
                if (this.MustCompleteByInd != null)
                    hashCode = hashCode * 59 + this.MustCompleteByInd.GetHashCode();
                if (this.FromDateOfIssueInd != null)
                    hashCode = hashCode * 59 + this.FromDateOfIssueInd.GetHashCode();
                if (this.EarliestAppliesInd != null)
                    hashCode = hashCode * 59 + this.EarliestAppliesInd.GetHashCode();
                if (this.LatestAppliesInd != null)
                    hashCode = hashCode * 59 + this.LatestAppliesInd.GetHashCode();
                if (this.ExtensionPointChoice != null)
                    hashCode = hashCode * 59 + this.ExtensionPointChoice.GetHashCode();
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
            // ReturnTime (string) pattern
            Regex regexReturnTime = new Regex(@"(([01]\\d|2[0-3])((:?)[0-5]\\d)?|24\\:?00)((:?)[0-5]\\d)?([\\.,]\\d+(?!:))?", RegexOptions.CultureInvariant);
            if (false == regexReturnTime.Match(this.ReturnTime).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReturnTime, must match a pattern of " + regexReturnTime, new [] { "ReturnTime" });
            }

            yield break;
        }
    }

}
