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
    /// CancelNotPermitted
    /// </summary>
    [DataContract]
    public partial class CancelNotPermitted : Cancel,  IEquatable<CancelNotPermitted>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelNotPermitted" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CancelNotPermitted() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelNotPermitted" /> class.
        /// </summary>
        /// <param name="notPermittedInd">Changes are not permitted.</param>
        /// <param name="extensionPointChoice">extensionPointChoice.</param>
        public CancelNotPermitted(bool? notPermittedInd = default(bool?), ExtensionPointChoice extensionPointChoice = default(ExtensionPointChoice), string type = "CancelNotPermitted", Object extensionPoint = default(Object)) : base(type, extensionPoint)
        {
            this.NotPermittedInd = notPermittedInd;
            this.ExtensionPointChoice = extensionPointChoice;
        }
        
        /// <summary>
        /// Changes are not permitted
        /// </summary>
        /// <value>Changes are not permitted</value>
        [DataMember(Name="NotPermittedInd", EmitDefaultValue=false)]
        public bool? NotPermittedInd { get; set; }

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
            sb.Append("class CancelNotPermitted {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  NotPermittedInd: ").Append(NotPermittedInd).Append("\n");
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
            return this.Equals(input as CancelNotPermitted);
        }

        /// <summary>
        /// Returns true if CancelNotPermitted instances are equal
        /// </summary>
        /// <param name="input">Instance of CancelNotPermitted to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CancelNotPermitted input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.NotPermittedInd == input.NotPermittedInd ||
                    (this.NotPermittedInd != null &&
                    this.NotPermittedInd.Equals(input.NotPermittedInd))
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
                if (this.NotPermittedInd != null)
                    hashCode = hashCode * 59 + this.NotPermittedInd.GetHashCode();
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
            yield break;
        }
    }

}
