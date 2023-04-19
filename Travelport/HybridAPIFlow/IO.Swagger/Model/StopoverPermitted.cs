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
    /// StopoverPermitted
    /// </summary>
    [DataContract]
    public partial class StopoverPermitted : Stopover,  IEquatable<StopoverPermitted>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StopoverPermitted" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StopoverPermitted() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StopoverPermitted" /> class.
        /// </summary>
        /// <param name="journeyTypes">journeyTypes.</param>
        /// <param name="minimumDuration">The minimum amount of time permitted for a stopover (required).</param>
        /// <param name="maximumDuration">The maximum amount of time permitted for a stopover (required).</param>
        /// <param name="minimum">Assigned Type: c-1100:NonnegativeInteger (required).</param>
        /// <param name="maximum">Assigned Type: c-1100:NonnegativeInteger (required).</param>
        /// <param name="outbound">Assigned Type: c-1100:NonnegativeInteger.</param>
        /// <param name="inbound">Assigned Type: c-1100:NonnegativeInteger.</param>
        /// <param name="stopoverCharge">stopoverCharge (required).</param>
        /// <param name="stopoverRestriction">stopoverRestriction.</param>
        /// <param name="permittedAtGatewayOnlyInd">If true, stopovers are permitted at gateway points only.</param>
        /// <param name="extensionPointChoice">extensionPointChoice.</param>
        public StopoverPermitted(List<JourneyTypeEnum> journeyTypes = default(List<JourneyTypeEnum>), string minimumDuration = default(string), string maximumDuration = default(string), int? minimum = default(int?), int? maximum = default(int?), int? outbound = default(int?), int? inbound = default(int?), List<StopoverCharge> stopoverCharge = default(List<StopoverCharge>), List<StopoverRestriction> stopoverRestriction = default(List<StopoverRestriction>), bool? permittedAtGatewayOnlyInd = default(bool?), ExtensionPointChoice extensionPointChoice = default(ExtensionPointChoice), string type = "StopoverPermitted", Object extensionPoint = default(Object)) : base(type, extensionPoint)
        {
            // to ensure "minimumDuration" is required (not null)
            if (minimumDuration == null)
            {
                throw new InvalidDataException("minimumDuration is a required property for StopoverPermitted and cannot be null");
            }
            else
            {
                this.MinimumDuration = minimumDuration;
            }
            // to ensure "maximumDuration" is required (not null)
            if (maximumDuration == null)
            {
                throw new InvalidDataException("maximumDuration is a required property for StopoverPermitted and cannot be null");
            }
            else
            {
                this.MaximumDuration = maximumDuration;
            }
            // to ensure "minimum" is required (not null)
            if (minimum == null)
            {
                throw new InvalidDataException("minimum is a required property for StopoverPermitted and cannot be null");
            }
            else
            {
                this.Minimum = minimum;
            }
            // to ensure "maximum" is required (not null)
            if (maximum == null)
            {
                throw new InvalidDataException("maximum is a required property for StopoverPermitted and cannot be null");
            }
            else
            {
                this.Maximum = maximum;
            }
            // to ensure "stopoverCharge" is required (not null)
            if (stopoverCharge == null)
            {
                throw new InvalidDataException("stopoverCharge is a required property for StopoverPermitted and cannot be null");
            }
            else
            {
                this.StopoverCharge = stopoverCharge;
            }
            this.JourneyTypes = journeyTypes;
            this.Outbound = outbound;
            this.Inbound = inbound;
            this.StopoverRestriction = stopoverRestriction;
            this.PermittedAtGatewayOnlyInd = permittedAtGatewayOnlyInd;
            this.ExtensionPointChoice = extensionPointChoice;
        }
        
        /// <summary>
        /// Gets or Sets JourneyTypes
        /// </summary>
        [DataMember(Name="journeyTypes", EmitDefaultValue=false)]
        public List<JourneyTypeEnum> JourneyTypes { get; set; }

        /// <summary>
        /// The minimum amount of time permitted for a stopover
        /// </summary>
        /// <value>The minimum amount of time permitted for a stopover</value>
        [DataMember(Name="minimumDuration", EmitDefaultValue=false)]
        public string MinimumDuration { get; set; }

        /// <summary>
        /// The maximum amount of time permitted for a stopover
        /// </summary>
        /// <value>The maximum amount of time permitted for a stopover</value>
        [DataMember(Name="maximumDuration", EmitDefaultValue=false)]
        public string MaximumDuration { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NonnegativeInteger
        /// </summary>
        /// <value>Assigned Type: c-1100:NonnegativeInteger</value>
        [DataMember(Name="minimum", EmitDefaultValue=false)]
        public int? Minimum { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NonnegativeInteger
        /// </summary>
        /// <value>Assigned Type: c-1100:NonnegativeInteger</value>
        [DataMember(Name="maximum", EmitDefaultValue=false)]
        public int? Maximum { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NonnegativeInteger
        /// </summary>
        /// <value>Assigned Type: c-1100:NonnegativeInteger</value>
        [DataMember(Name="outbound", EmitDefaultValue=false)]
        public int? Outbound { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NonnegativeInteger
        /// </summary>
        /// <value>Assigned Type: c-1100:NonnegativeInteger</value>
        [DataMember(Name="inbound", EmitDefaultValue=false)]
        public int? Inbound { get; set; }

        /// <summary>
        /// Gets or Sets StopoverCharge
        /// </summary>
        [DataMember(Name="StopoverCharge", EmitDefaultValue=false)]
        public List<StopoverCharge> StopoverCharge { get; set; }

        /// <summary>
        /// Gets or Sets StopoverRestriction
        /// </summary>
        [DataMember(Name="StopoverRestriction", EmitDefaultValue=false)]
        public List<StopoverRestriction> StopoverRestriction { get; set; }

        /// <summary>
        /// If true, stopovers are permitted at gateway points only
        /// </summary>
        /// <value>If true, stopovers are permitted at gateway points only</value>
        [DataMember(Name="permittedAtGatewayOnlyInd", EmitDefaultValue=false)]
        public bool? PermittedAtGatewayOnlyInd { get; set; }

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
            sb.Append("class StopoverPermitted {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  JourneyTypes: ").Append(JourneyTypes).Append("\n");
            sb.Append("  MinimumDuration: ").Append(MinimumDuration).Append("\n");
            sb.Append("  MaximumDuration: ").Append(MaximumDuration).Append("\n");
            sb.Append("  Minimum: ").Append(Minimum).Append("\n");
            sb.Append("  Maximum: ").Append(Maximum).Append("\n");
            sb.Append("  Outbound: ").Append(Outbound).Append("\n");
            sb.Append("  Inbound: ").Append(Inbound).Append("\n");
            sb.Append("  StopoverCharge: ").Append(StopoverCharge).Append("\n");
            sb.Append("  StopoverRestriction: ").Append(StopoverRestriction).Append("\n");
            sb.Append("  PermittedAtGatewayOnlyInd: ").Append(PermittedAtGatewayOnlyInd).Append("\n");
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
            return this.Equals(input as StopoverPermitted);
        }

        /// <summary>
        /// Returns true if StopoverPermitted instances are equal
        /// </summary>
        /// <param name="input">Instance of StopoverPermitted to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StopoverPermitted input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.JourneyTypes == input.JourneyTypes ||
                    this.JourneyTypes != null &&
                    this.JourneyTypes.SequenceEqual(input.JourneyTypes)
                ) && base.Equals(input) && 
                (
                    this.MinimumDuration == input.MinimumDuration ||
                    (this.MinimumDuration != null &&
                    this.MinimumDuration.Equals(input.MinimumDuration))
                ) && base.Equals(input) && 
                (
                    this.MaximumDuration == input.MaximumDuration ||
                    (this.MaximumDuration != null &&
                    this.MaximumDuration.Equals(input.MaximumDuration))
                ) && base.Equals(input) && 
                (
                    this.Minimum == input.Minimum ||
                    (this.Minimum != null &&
                    this.Minimum.Equals(input.Minimum))
                ) && base.Equals(input) && 
                (
                    this.Maximum == input.Maximum ||
                    (this.Maximum != null &&
                    this.Maximum.Equals(input.Maximum))
                ) && base.Equals(input) && 
                (
                    this.Outbound == input.Outbound ||
                    (this.Outbound != null &&
                    this.Outbound.Equals(input.Outbound))
                ) && base.Equals(input) && 
                (
                    this.Inbound == input.Inbound ||
                    (this.Inbound != null &&
                    this.Inbound.Equals(input.Inbound))
                ) && base.Equals(input) && 
                (
                    this.StopoverCharge == input.StopoverCharge ||
                    this.StopoverCharge != null &&
                    this.StopoverCharge.SequenceEqual(input.StopoverCharge)
                ) && base.Equals(input) && 
                (
                    this.StopoverRestriction == input.StopoverRestriction ||
                    this.StopoverRestriction != null &&
                    this.StopoverRestriction.SequenceEqual(input.StopoverRestriction)
                ) && base.Equals(input) && 
                (
                    this.PermittedAtGatewayOnlyInd == input.PermittedAtGatewayOnlyInd ||
                    (this.PermittedAtGatewayOnlyInd != null &&
                    this.PermittedAtGatewayOnlyInd.Equals(input.PermittedAtGatewayOnlyInd))
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
                if (this.JourneyTypes != null)
                    hashCode = hashCode * 59 + this.JourneyTypes.GetHashCode();
                if (this.MinimumDuration != null)
                    hashCode = hashCode * 59 + this.MinimumDuration.GetHashCode();
                if (this.MaximumDuration != null)
                    hashCode = hashCode * 59 + this.MaximumDuration.GetHashCode();
                if (this.Minimum != null)
                    hashCode = hashCode * 59 + this.Minimum.GetHashCode();
                if (this.Maximum != null)
                    hashCode = hashCode * 59 + this.Maximum.GetHashCode();
                if (this.Outbound != null)
                    hashCode = hashCode * 59 + this.Outbound.GetHashCode();
                if (this.Inbound != null)
                    hashCode = hashCode * 59 + this.Inbound.GetHashCode();
                if (this.StopoverCharge != null)
                    hashCode = hashCode * 59 + this.StopoverCharge.GetHashCode();
                if (this.StopoverRestriction != null)
                    hashCode = hashCode * 59 + this.StopoverRestriction.GetHashCode();
                if (this.PermittedAtGatewayOnlyInd != null)
                    hashCode = hashCode * 59 + this.PermittedAtGatewayOnlyInd.GetHashCode();
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
            // Minimum (int?) minimum
            if(this.Minimum < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Minimum, must be a value greater than or equal to 0.", new [] { "Minimum" });
            }

            // Maximum (int?) minimum
            if(this.Maximum < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Maximum, must be a value greater than or equal to 0.", new [] { "Maximum" });
            }

            // Outbound (int?) minimum
            if(this.Outbound < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Outbound, must be a value greater than or equal to 0.", new [] { "Outbound" });
            }

            // Inbound (int?) minimum
            if(this.Inbound < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Inbound, must be a value greater than or equal to 0.", new [] { "Inbound" });
            }

            yield break;
        }
    }

}
