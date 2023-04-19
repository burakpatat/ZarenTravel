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
    /// EarnedCommissionPercent
    /// </summary>
    [DataContract]
    public partial class EarnedCommissionPercent : EarnedCommission,  IEquatable<EarnedCommissionPercent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EarnedCommissionPercent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EarnedCommissionPercent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EarnedCommissionPercent" /> class.
        /// </summary>
        /// <param name="percent">Percent amount of commission.</param>
        /// <param name="extensionPointChoice">extensionPointChoice.</param>
        public EarnedCommissionPercent(float? percent = default(float?), ExtensionPointChoice extensionPointChoice = default(ExtensionPointChoice), string type = "EarnedCommissionPercent", CommissionEnum? application = default(CommissionEnum?), Object extensionPoint = default(Object)) : base(type, application, extensionPoint)
        {
            this.Percent = percent;
            this.ExtensionPointChoice = extensionPointChoice;
        }
        
        /// <summary>
        /// Percent amount of commission
        /// </summary>
        /// <value>Percent amount of commission</value>
        [DataMember(Name="Percent", EmitDefaultValue=false)]
        public float? Percent { get; set; }

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
            sb.Append("class EarnedCommissionPercent {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Percent: ").Append(Percent).Append("\n");
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
            return this.Equals(input as EarnedCommissionPercent);
        }

        /// <summary>
        /// Returns true if EarnedCommissionPercent instances are equal
        /// </summary>
        /// <param name="input">Instance of EarnedCommissionPercent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EarnedCommissionPercent input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Percent == input.Percent ||
                    (this.Percent != null &&
                    this.Percent.Equals(input.Percent))
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
                if (this.Percent != null)
                    hashCode = hashCode * 59 + this.Percent.GetHashCode();
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
            // Percent (float?) minimum
            if(this.Percent < (float?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Percent, must be a value greater than or equal to 0.", new [] { "Percent" });
            }

            yield break;
        }
    }

}
