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
    /// DepartureFlightID
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    [JsonSubtypes.KnownSubType(typeof(DepartureFlight), "DepartureFlight")]
    [JsonSubtypes.KnownSubType(typeof(DepartureFlightDetail), "DepartureFlightDetail")]
    [JsonSubtypes.KnownSubType(typeof(DepartureFlightSummary), "DepartureFlightSummary")]
    public partial class DepartureFlightID :  IEquatable<DepartureFlightID>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartureFlightID" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DepartureFlightID() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartureFlightID" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="id">Internal ID.</param>
        /// <param name="flightRef">Reference to a Flight object eslewhere in the message.</param>
        /// <param name="identifier">Assigned Type: c-1100:Identifier.</param>
        public DepartureFlightID(string type = default(string), string id = default(string), string flightRef = default(string), Identifier identifier = default(Identifier))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for DepartureFlightID and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            this.Id = id;
            this.FlightRef = flightRef;
            this.Identifier = identifier;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Internal ID
        /// </summary>
        /// <value>Internal ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Reference to a Flight object eslewhere in the message
        /// </summary>
        /// <value>Reference to a Flight object eslewhere in the message</value>
        [DataMember(Name="FlightRef", EmitDefaultValue=false)]
        public string FlightRef { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Identifier
        /// </summary>
        /// <value>Assigned Type: c-1100:Identifier</value>
        [DataMember(Name="Identifier", EmitDefaultValue=false)]
        public Identifier Identifier { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DepartureFlightID {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FlightRef: ").Append(FlightRef).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
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
            return this.Equals(input as DepartureFlightID);
        }

        /// <summary>
        /// Returns true if DepartureFlightID instances are equal
        /// </summary>
        /// <param name="input">Instance of DepartureFlightID to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DepartureFlightID input)
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
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.FlightRef == input.FlightRef ||
                    (this.FlightRef != null &&
                    this.FlightRef.Equals(input.FlightRef))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.FlightRef != null)
                    hashCode = hashCode * 59 + this.FlightRef.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
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
