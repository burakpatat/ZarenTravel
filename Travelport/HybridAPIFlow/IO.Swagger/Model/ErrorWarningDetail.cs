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
    /// ErrorWarningDetail
    /// </summary>
    [DataContract]
    public partial class ErrorWarningDetail : ErrorWarning,  IEquatable<ErrorWarningDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorWarningDetail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ErrorWarningDetail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorWarningDetail" /> class.
        /// </summary>
        /// <param name="sourceID">The identifier of the source system sending the error or warning (required).</param>
        /// <param name="sourceCode">The error or warning code returned by the source airline or host system.</param>
        /// <param name="sourceDescription">The error or warning message as it is returned by the source airline or host system.</param>
        /// <param name="extensionPointDetail">extensionPointDetail.</param>
        public ErrorWarningDetail(string sourceID = default(string), string sourceCode = default(string), string sourceDescription = default(string), ExtensionPointDetail extensionPointDetail = default(ExtensionPointDetail), string type = "ErrorWarningDetail", int? statusCode = default(int?), string message = default(string), List<NameValuePair> nameValuePair = default(List<NameValuePair>), Object extensionPoint = default(Object)) : base(type, statusCode, message, nameValuePair, extensionPoint)
        {
            // to ensure "sourceID" is required (not null)
            if (sourceID == null)
            {
                throw new InvalidDataException("sourceID is a required property for ErrorWarningDetail and cannot be null");
            }
            else
            {
                this.SourceID = sourceID;
            }
            this.SourceCode = sourceCode;
            this.SourceDescription = sourceDescription;
            this.ExtensionPointDetail = extensionPointDetail;
        }
        
        /// <summary>
        /// The identifier of the source system sending the error or warning
        /// </summary>
        /// <value>The identifier of the source system sending the error or warning</value>
        [DataMember(Name="SourceID", EmitDefaultValue=false)]
        public string SourceID { get; set; }

        /// <summary>
        /// The error or warning code returned by the source airline or host system
        /// </summary>
        /// <value>The error or warning code returned by the source airline or host system</value>
        [DataMember(Name="SourceCode", EmitDefaultValue=false)]
        public string SourceCode { get; set; }

        /// <summary>
        /// The error or warning message as it is returned by the source airline or host system
        /// </summary>
        /// <value>The error or warning message as it is returned by the source airline or host system</value>
        [DataMember(Name="SourceDescription", EmitDefaultValue=false)]
        public string SourceDescription { get; set; }

        /// <summary>
        /// Gets or Sets ExtensionPointDetail
        /// </summary>
        [DataMember(Name="ExtensionPoint_Detail", EmitDefaultValue=false)]
        public ExtensionPointDetail ExtensionPointDetail { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ErrorWarningDetail {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  SourceID: ").Append(SourceID).Append("\n");
            sb.Append("  SourceCode: ").Append(SourceCode).Append("\n");
            sb.Append("  SourceDescription: ").Append(SourceDescription).Append("\n");
            sb.Append("  ExtensionPointDetail: ").Append(ExtensionPointDetail).Append("\n");
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
            return this.Equals(input as ErrorWarningDetail);
        }

        /// <summary>
        /// Returns true if ErrorWarningDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of ErrorWarningDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ErrorWarningDetail input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.SourceID == input.SourceID ||
                    (this.SourceID != null &&
                    this.SourceID.Equals(input.SourceID))
                ) && base.Equals(input) && 
                (
                    this.SourceCode == input.SourceCode ||
                    (this.SourceCode != null &&
                    this.SourceCode.Equals(input.SourceCode))
                ) && base.Equals(input) && 
                (
                    this.SourceDescription == input.SourceDescription ||
                    (this.SourceDescription != null &&
                    this.SourceDescription.Equals(input.SourceDescription))
                ) && base.Equals(input) && 
                (
                    this.ExtensionPointDetail == input.ExtensionPointDetail ||
                    (this.ExtensionPointDetail != null &&
                    this.ExtensionPointDetail.Equals(input.ExtensionPointDetail))
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
                if (this.SourceID != null)
                    hashCode = hashCode * 59 + this.SourceID.GetHashCode();
                if (this.SourceCode != null)
                    hashCode = hashCode * 59 + this.SourceCode.GetHashCode();
                if (this.SourceDescription != null)
                    hashCode = hashCode * 59 + this.SourceDescription.GetHashCode();
                if (this.ExtensionPointDetail != null)
                    hashCode = hashCode * 59 + this.ExtensionPointDetail.GetHashCode();
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
            // SourceID (string) maxLength
            if(this.SourceID != null && this.SourceID.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SourceID, length must be less than 128.", new [] { "SourceID" });
            }

            // SourceCode (string) maxLength
            if(this.SourceCode != null && this.SourceCode.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SourceCode, length must be less than 32.", new [] { "SourceCode" });
            }

            // SourceDescription (string) maxLength
            if(this.SourceDescription != null && this.SourceDescription.Length > 4096)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SourceDescription, length must be less than 4096.", new [] { "SourceDescription" });
            }

            yield break;
        }
    }

}
