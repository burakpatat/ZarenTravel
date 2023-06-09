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
    /// CatalogProductOfferingsRequest
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    [JsonSubtypes.KnownSubType(typeof(CatalogProductOfferingsRequestAir), "CatalogProductOfferingsRequestAir")]
    public partial class CatalogProductOfferingsRequest :  IEquatable<CatalogProductOfferingsRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogProductOfferingsRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CatalogProductOfferingsRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogProductOfferingsRequest" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="searchControlConsoleChannelID">Assigned Type: c-1100:SearchControlConsoleChannelID.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public CatalogProductOfferingsRequest(string type = default(string), SearchControlConsoleChannelID searchControlConsoleChannelID = default(SearchControlConsoleChannelID), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for CatalogProductOfferingsRequest and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            this.SearchControlConsoleChannelID = searchControlConsoleChannelID;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:SearchControlConsoleChannelID
        /// </summary>
        /// <value>Assigned Type: c-1100:SearchControlConsoleChannelID</value>
        [DataMember(Name="SearchControlConsoleChannelID", EmitDefaultValue=false)]
        public SearchControlConsoleChannelID SearchControlConsoleChannelID { get; set; }

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
            sb.Append("class CatalogProductOfferingsRequest {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  SearchControlConsoleChannelID: ").Append(SearchControlConsoleChannelID).Append("\n");
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
            return this.Equals(input as CatalogProductOfferingsRequest);
        }

        /// <summary>
        /// Returns true if CatalogProductOfferingsRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CatalogProductOfferingsRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CatalogProductOfferingsRequest input)
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
                    this.SearchControlConsoleChannelID == input.SearchControlConsoleChannelID ||
                    (this.SearchControlConsoleChannelID != null &&
                    this.SearchControlConsoleChannelID.Equals(input.SearchControlConsoleChannelID))
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
                if (this.SearchControlConsoleChannelID != null)
                    hashCode = hashCode * 59 + this.SearchControlConsoleChannelID.GetHashCode();
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
