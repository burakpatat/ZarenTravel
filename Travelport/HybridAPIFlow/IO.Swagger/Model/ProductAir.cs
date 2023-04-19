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
    /// ProductAir
    /// </summary>
    [DataContract]
    public partial class ProductAir : Product,  IEquatable<ProductAir>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAir" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProductAir() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAir" /> class.
        /// </summary>
        /// <param name="totalDuration">Total duration of all Segments that are part of this ProductAir.</param>
        /// <param name="flightSegment">flightSegment (required).</param>
        /// <param name="passengerFlight">passengerFlight (required).</param>
        /// <param name="extensionPointCustom">extensionPointCustom.</param>
        public ProductAir(string totalDuration = default(string), List<FlightSegment> flightSegment = default(List<FlightSegment>), List<PassengerFlight> passengerFlight = default(List<PassengerFlight>), ExtensionPointCustom extensionPointCustom = default(ExtensionPointCustom), string type = default(string), string id = default(string), string productRef = default(string), Identifier identifier = default(Identifier), int? quantity = default(int?), Object extensionPoint = default(Object)) : base(quantity, extensionPoint)
        {
            // to ensure "flightSegment" is required (not null)
            if (flightSegment == null)
            {
                throw new InvalidDataException("flightSegment is a required property for ProductAir and cannot be null");
            }
            else
            {
                this.FlightSegment = flightSegment;
            }
            // to ensure "passengerFlight" is required (not null)
            if (passengerFlight == null)
            {
                throw new InvalidDataException("passengerFlight is a required property for ProductAir and cannot be null");
            }
            else
            {
                this.PassengerFlight = passengerFlight;
            }
            this.TotalDuration = totalDuration;
            this.ExtensionPointCustom = extensionPointCustom;
        }
        
        /// <summary>
        /// Total duration of all Segments that are part of this ProductAir
        /// </summary>
        /// <value>Total duration of all Segments that are part of this ProductAir</value>
        [DataMember(Name="totalDuration", EmitDefaultValue=false)]
        public string TotalDuration { get; set; }

        /// <summary>
        /// Gets or Sets FlightSegment
        /// </summary>
        [DataMember(Name="FlightSegment", EmitDefaultValue=false)]
        public List<FlightSegment> FlightSegment { get; set; }

        /// <summary>
        /// Gets or Sets PassengerFlight
        /// </summary>
        [DataMember(Name="PassengerFlight", EmitDefaultValue=false)]
        public List<PassengerFlight> PassengerFlight { get; set; }

        /// <summary>
        /// Gets or Sets ExtensionPointCustom
        /// </summary>
        [DataMember(Name="ExtensionPoint_Custom", EmitDefaultValue=false)]
        public ExtensionPointCustom ExtensionPointCustom { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductAir {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  TotalDuration: ").Append(TotalDuration).Append("\n");
            sb.Append("  FlightSegment: ").Append(FlightSegment).Append("\n");
            sb.Append("  PassengerFlight: ").Append(PassengerFlight).Append("\n");
            sb.Append("  ExtensionPointCustom: ").Append(ExtensionPointCustom).Append("\n");
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
            return this.Equals(input as ProductAir);
        }

        /// <summary>
        /// Returns true if ProductAir instances are equal
        /// </summary>
        /// <param name="input">Instance of ProductAir to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProductAir input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.TotalDuration == input.TotalDuration ||
                    (this.TotalDuration != null &&
                    this.TotalDuration.Equals(input.TotalDuration))
                ) && base.Equals(input) && 
                (
                    this.FlightSegment == input.FlightSegment ||
                    this.FlightSegment != null &&
                    this.FlightSegment.SequenceEqual(input.FlightSegment)
                ) && base.Equals(input) && 
                (
                    this.PassengerFlight == input.PassengerFlight ||
                    this.PassengerFlight != null &&
                    this.PassengerFlight.SequenceEqual(input.PassengerFlight)
                ) && base.Equals(input) && 
                (
                    this.ExtensionPointCustom == input.ExtensionPointCustom ||
                    (this.ExtensionPointCustom != null &&
                    this.ExtensionPointCustom.Equals(input.ExtensionPointCustom))
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
                if (this.TotalDuration != null)
                    hashCode = hashCode * 59 + this.TotalDuration.GetHashCode();
                if (this.FlightSegment != null)
                    hashCode = hashCode * 59 + this.FlightSegment.GetHashCode();
                if (this.PassengerFlight != null)
                    hashCode = hashCode * 59 + this.PassengerFlight.GetHashCode();
                if (this.ExtensionPointCustom != null)
                    hashCode = hashCode * 59 + this.ExtensionPointCustom.GetHashCode();
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