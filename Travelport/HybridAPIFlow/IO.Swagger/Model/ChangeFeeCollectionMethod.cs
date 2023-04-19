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
    /// ChangeFeeCollectionMethod
    /// </summary>
    [DataContract]
    public partial class ChangeFeeCollectionMethod :  IEquatable<ChangeFeeCollectionMethod>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeeCollectionMethod" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChangeFeeCollectionMethod() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeeCollectionMethod" /> class.
        /// </summary>
        /// <param name="extension">extension.</param>
        /// <param name="value">Assigned Type: ctar-1100:ChangeFeeMethodEnum.</param>
        /// <param name="code">Assigned Type: c-1100:StringTiny (required).</param>
        /// <param name="subCode">Assigned Type: c-1100:StringTiny.</param>
        /// <param name="description">Assigned Type: c-1100:StringShort.</param>
        public ChangeFeeCollectionMethod(string extension = default(string), ChangeFeeMethodEnumBase value = default(ChangeFeeMethodEnumBase), string code = default(string), string subCode = default(string), string description = default(string))
        {
            // to ensure "code" is required (not null)
            if (code == null)
            {
                throw new InvalidDataException("code is a required property for ChangeFeeCollectionMethod and cannot be null");
            }
            else
            {
                this.Code = code;
            }
            this.Extension = extension;
            this.Value = value;
            this.SubCode = subCode;
            this.Description = description;
        }
        
        /// <summary>
        /// Gets or Sets Extension
        /// </summary>
        [DataMember(Name="extension", EmitDefaultValue=false)]
        public string Extension { get; set; }

        /// <summary>
        /// Assigned Type: ctar-1100:ChangeFeeMethodEnum
        /// </summary>
        /// <value>Assigned Type: ctar-1100:ChangeFeeMethodEnum</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public ChangeFeeMethodEnumBase Value { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringTiny
        /// </summary>
        /// <value>Assigned Type: c-1100:StringTiny</value>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringTiny
        /// </summary>
        /// <value>Assigned Type: c-1100:StringTiny</value>
        [DataMember(Name="subCode", EmitDefaultValue=false)]
        public string SubCode { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringShort
        /// </summary>
        /// <value>Assigned Type: c-1100:StringShort</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChangeFeeCollectionMethod {\n");
            sb.Append("  Extension: ").Append(Extension).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  SubCode: ").Append(SubCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as ChangeFeeCollectionMethod);
        }

        /// <summary>
        /// Returns true if ChangeFeeCollectionMethod instances are equal
        /// </summary>
        /// <param name="input">Instance of ChangeFeeCollectionMethod to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChangeFeeCollectionMethod input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Extension == input.Extension ||
                    (this.Extension != null &&
                    this.Extension.Equals(input.Extension))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.SubCode == input.SubCode ||
                    (this.SubCode != null &&
                    this.SubCode.Equals(input.SubCode))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                if (this.Extension != null)
                    hashCode = hashCode * 59 + this.Extension.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.SubCode != null)
                    hashCode = hashCode * 59 + this.SubCode.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
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
            // Extension (string) maxLength
            if(this.Extension != null && this.Extension.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Extension, length must be less than 128.", new [] { "Extension" });
            }

            // Extension (string) minLength
            if(this.Extension != null && this.Extension.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Extension, length must be greater than 1.", new [] { "Extension" });
            }

            // Code (string) maxLength
            if(this.Code != null && this.Code.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Code, length must be less than 32.", new [] { "Code" });
            }

            // SubCode (string) maxLength
            if(this.SubCode != null && this.SubCode.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SubCode, length must be less than 32.", new [] { "SubCode" });
            }

            // Description (string) maxLength
            if(this.Description != null && this.Description.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 128.", new [] { "Description" });
            }

            yield break;
        }
    }

}
