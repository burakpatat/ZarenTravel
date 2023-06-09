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
    /// AncillaryOfferingsBuildFromOffer
    /// </summary>
    [DataContract]
    public partial class AncillaryOfferingsBuildFromOffer : AncillaryOfferings,  IEquatable<AncillaryOfferingsBuildFromOffer>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AncillaryOfferingsBuildFromOffer" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AncillaryOfferingsBuildFromOffer() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AncillaryOfferingsBuildFromOffer" /> class.
        /// </summary>
        /// <param name="buildFromOffer">Assigned Type: ctlg-1100:BuildFromOffer (required).</param>
        /// <param name="extensionPointChoice">extensionPointChoice.</param>
        public AncillaryOfferingsBuildFromOffer(BuildFromOffer buildFromOffer = default(BuildFromOffer), ExtensionPointChoice extensionPointChoice = default(ExtensionPointChoice), string type = "AncillaryOfferingsBuildFromOffer", bool? includeUnsellableAncillariesInd = default(bool?), Object extensionPoint = default(Object)) : base(type, includeUnsellableAncillariesInd, extensionPoint)
        {
            // to ensure "buildFromOffer" is required (not null)
            if (buildFromOffer == null)
            {
                throw new InvalidDataException("buildFromOffer is a required property for AncillaryOfferingsBuildFromOffer and cannot be null");
            }
            else
            {
                this.BuildFromOffer = buildFromOffer;
            }
            this.ExtensionPointChoice = extensionPointChoice;
        }
        
        /// <summary>
        /// Assigned Type: ctlg-1100:BuildFromOffer
        /// </summary>
        /// <value>Assigned Type: ctlg-1100:BuildFromOffer</value>
        [DataMember(Name="BuildFromOffer", EmitDefaultValue=false)]
        public BuildFromOffer BuildFromOffer { get; set; }

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
            sb.Append("class AncillaryOfferingsBuildFromOffer {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  BuildFromOffer: ").Append(BuildFromOffer).Append("\n");
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
            return this.Equals(input as AncillaryOfferingsBuildFromOffer);
        }

        /// <summary>
        /// Returns true if AncillaryOfferingsBuildFromOffer instances are equal
        /// </summary>
        /// <param name="input">Instance of AncillaryOfferingsBuildFromOffer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AncillaryOfferingsBuildFromOffer input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.BuildFromOffer == input.BuildFromOffer ||
                    (this.BuildFromOffer != null &&
                    this.BuildFromOffer.Equals(input.BuildFromOffer))
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
                if (this.BuildFromOffer != null)
                    hashCode = hashCode * 59 + this.BuildFromOffer.GetHashCode();
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
