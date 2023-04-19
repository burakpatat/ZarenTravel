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
    /// MinimumStayApplies
    /// </summary>
    [DataContract]
    public partial class MinimumStayApplies : MinimumStay,  IEquatable<MinimumStayApplies>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinimumStayApplies" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MinimumStayApplies() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MinimumStayApplies" /> class.
        /// </summary>
        /// <param name="mustIncludeDayOfWeek">This day of the week must be included as part of the minimum stay.</param>
        /// <param name="originDayOfWeek">The rule applies to trips commencing on a specific day of a week.</param>
        /// <param name="returnTime">Assigned Type: ota2:LocalTime.</param>
        /// <param name="duration">Minimum duration (required).</param>
        /// <param name="extensionPointChoice">extensionPointChoice.</param>
        public MinimumStayApplies(DayOfWeekEnum mustIncludeDayOfWeek = default(DayOfWeekEnum), DayOfWeekEnum originDayOfWeek = default(DayOfWeekEnum), string returnTime = default(string), string duration = default(string), ExtensionPointChoice extensionPointChoice = default(ExtensionPointChoice), string type = "MinimumStayApplies", Object extensionPoint = default(Object)) : base(type, extensionPoint)
        {
            // to ensure "duration" is required (not null)
            if (duration == null)
            {
                throw new InvalidDataException("duration is a required property for MinimumStayApplies and cannot be null");
            }
            else
            {
                this.Duration = duration;
            }
            this.MustIncludeDayOfWeek = mustIncludeDayOfWeek;
            this.OriginDayOfWeek = originDayOfWeek;
            this.ReturnTime = returnTime;
            this.ExtensionPointChoice = extensionPointChoice;
        }
        
        /// <summary>
        /// This day of the week must be included as part of the minimum stay
        /// </summary>
        /// <value>This day of the week must be included as part of the minimum stay</value>
        [DataMember(Name="mustIncludeDayOfWeek", EmitDefaultValue=false)]
        public DayOfWeekEnum MustIncludeDayOfWeek { get; set; }

        /// <summary>
        /// The rule applies to trips commencing on a specific day of a week
        /// </summary>
        /// <value>The rule applies to trips commencing on a specific day of a week</value>
        [DataMember(Name="originDayOfWeek", EmitDefaultValue=false)]
        public DayOfWeekEnum OriginDayOfWeek { get; set; }

        /// <summary>
        /// Assigned Type: ota2:LocalTime
        /// </summary>
        /// <value>Assigned Type: ota2:LocalTime</value>
        [DataMember(Name="returnTime", EmitDefaultValue=false)]
        public string ReturnTime { get; set; }

        /// <summary>
        /// Minimum duration
        /// </summary>
        /// <value>Minimum duration</value>
        [DataMember(Name="Duration", EmitDefaultValue=false)]
        public string Duration { get; set; }

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
            sb.Append("class MinimumStayApplies {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  MustIncludeDayOfWeek: ").Append(MustIncludeDayOfWeek).Append("\n");
            sb.Append("  OriginDayOfWeek: ").Append(OriginDayOfWeek).Append("\n");
            sb.Append("  ReturnTime: ").Append(ReturnTime).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
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
            return this.Equals(input as MinimumStayApplies);
        }

        /// <summary>
        /// Returns true if MinimumStayApplies instances are equal
        /// </summary>
        /// <param name="input">Instance of MinimumStayApplies to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MinimumStayApplies input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.MustIncludeDayOfWeek == input.MustIncludeDayOfWeek ||
                    (this.MustIncludeDayOfWeek != null &&
                    this.MustIncludeDayOfWeek.Equals(input.MustIncludeDayOfWeek))
                ) && base.Equals(input) && 
                (
                    this.OriginDayOfWeek == input.OriginDayOfWeek ||
                    (this.OriginDayOfWeek != null &&
                    this.OriginDayOfWeek.Equals(input.OriginDayOfWeek))
                ) && base.Equals(input) && 
                (
                    this.ReturnTime == input.ReturnTime ||
                    (this.ReturnTime != null &&
                    this.ReturnTime.Equals(input.ReturnTime))
                ) && base.Equals(input) && 
                (
                    this.Duration == input.Duration ||
                    (this.Duration != null &&
                    this.Duration.Equals(input.Duration))
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
                if (this.MustIncludeDayOfWeek != null)
                    hashCode = hashCode * 59 + this.MustIncludeDayOfWeek.GetHashCode();
                if (this.OriginDayOfWeek != null)
                    hashCode = hashCode * 59 + this.OriginDayOfWeek.GetHashCode();
                if (this.ReturnTime != null)
                    hashCode = hashCode * 59 + this.ReturnTime.GetHashCode();
                if (this.Duration != null)
                    hashCode = hashCode * 59 + this.Duration.GetHashCode();
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