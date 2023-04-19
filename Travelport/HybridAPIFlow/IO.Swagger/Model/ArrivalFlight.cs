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
    /// ArrivalFlight
    /// </summary>
    [DataContract]
    public partial class ArrivalFlight : ArrivalFlightID,  IEquatable<ArrivalFlight>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrivalFlight" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ArrivalFlight() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrivalFlight" /> class.
        /// </summary>
        /// <param name="distance">Assigned Type: c-1100:NonnegativeInteger.</param>
        /// <param name="stops">Assigned Type: c-1100:NumberSingleDigit.</param>
        /// <param name="duration">Elapsed flight time in minutes.</param>
        /// <param name="carrier">Assigned Type: c-1100:AirlineCode (required).</param>
        /// <param name="number">Assigned Type: c-1100:FlightNumber (required).</param>
        /// <param name="operatingCarrier">Assigned Type: c-1100:AirlineCode.</param>
        /// <param name="operatingCarrierName">Assigned Type: c-1100:StringShort.</param>
        /// <param name="equipment">Assigned Type: c-1100:AirEquipCodeIATA.</param>
        /// <param name="departure">Assigned Type: c-1100:Departure (required).</param>
        /// <param name="arrival">Assigned Type: c-1100:Arrival (required).</param>
        /// <param name="intermediateStop">intermediateStop.</param>
        /// <param name="subjectToGovernmentApprovalInd">If true, this flight schedule is yet to receive government approval.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public ArrivalFlight(int? distance = default(int?), int? stops = default(int?), string duration = default(string), string carrier = default(string), string number = default(string), string operatingCarrier = default(string), string operatingCarrierName = default(string), string equipment = default(string), Departure departure = default(Departure), Arrival arrival = default(Arrival), List<IntermediateStop> intermediateStop = default(List<IntermediateStop>), bool? subjectToGovernmentApprovalInd = default(bool?), Object extensionPoint = default(Object), string type = "ArrivalFlight", string id = default(string), string flightRef = default(string), Identifier identifier = default(Identifier)) : base(type, id, flightRef, identifier)
        {
            // to ensure "carrier" is required (not null)
            if (carrier == null)
            {
                throw new InvalidDataException("carrier is a required property for ArrivalFlight and cannot be null");
            }
            else
            {
                this.Carrier = carrier;
            }
            // to ensure "number" is required (not null)
            if (number == null)
            {
                throw new InvalidDataException("number is a required property for ArrivalFlight and cannot be null");
            }
            else
            {
                this.Number = number;
            }
            // to ensure "departure" is required (not null)
            if (departure == null)
            {
                throw new InvalidDataException("departure is a required property for ArrivalFlight and cannot be null");
            }
            else
            {
                this.Departure = departure;
            }
            // to ensure "arrival" is required (not null)
            if (arrival == null)
            {
                throw new InvalidDataException("arrival is a required property for ArrivalFlight and cannot be null");
            }
            else
            {
                this.Arrival = arrival;
            }
            this.Distance = distance;
            this.Stops = stops;
            this.Duration = duration;
            this.OperatingCarrier = operatingCarrier;
            this.OperatingCarrierName = operatingCarrierName;
            this.Equipment = equipment;
            this.IntermediateStop = intermediateStop;
            this.SubjectToGovernmentApprovalInd = subjectToGovernmentApprovalInd;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Assigned Type: c-1100:NonnegativeInteger
        /// </summary>
        /// <value>Assigned Type: c-1100:NonnegativeInteger</value>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public int? Distance { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NumberSingleDigit
        /// </summary>
        /// <value>Assigned Type: c-1100:NumberSingleDigit</value>
        [DataMember(Name="stops", EmitDefaultValue=false)]
        public int? Stops { get; set; }

        /// <summary>
        /// Elapsed flight time in minutes
        /// </summary>
        /// <value>Elapsed flight time in minutes</value>
        [DataMember(Name="duration", EmitDefaultValue=false)]
        public string Duration { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:AirlineCode
        /// </summary>
        /// <value>Assigned Type: c-1100:AirlineCode</value>
        [DataMember(Name="carrier", EmitDefaultValue=false)]
        public string Carrier { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:FlightNumber
        /// </summary>
        /// <value>Assigned Type: c-1100:FlightNumber</value>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public string Number { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:AirlineCode
        /// </summary>
        /// <value>Assigned Type: c-1100:AirlineCode</value>
        [DataMember(Name="operatingCarrier", EmitDefaultValue=false)]
        public string OperatingCarrier { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringShort
        /// </summary>
        /// <value>Assigned Type: c-1100:StringShort</value>
        [DataMember(Name="operatingCarrierName", EmitDefaultValue=false)]
        public string OperatingCarrierName { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:AirEquipCodeIATA
        /// </summary>
        /// <value>Assigned Type: c-1100:AirEquipCodeIATA</value>
        [DataMember(Name="equipment", EmitDefaultValue=false)]
        public string Equipment { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Departure
        /// </summary>
        /// <value>Assigned Type: c-1100:Departure</value>
        [DataMember(Name="Departure", EmitDefaultValue=false)]
        public Departure Departure { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Arrival
        /// </summary>
        /// <value>Assigned Type: c-1100:Arrival</value>
        [DataMember(Name="Arrival", EmitDefaultValue=false)]
        public Arrival Arrival { get; set; }

        /// <summary>
        /// Gets or Sets IntermediateStop
        /// </summary>
        [DataMember(Name="IntermediateStop", EmitDefaultValue=false)]
        public List<IntermediateStop> IntermediateStop { get; set; }

        /// <summary>
        /// If true, this flight schedule is yet to receive government approval
        /// </summary>
        /// <value>If true, this flight schedule is yet to receive government approval</value>
        [DataMember(Name="subjectToGovernmentApprovalInd", EmitDefaultValue=false)]
        public bool? SubjectToGovernmentApprovalInd { get; set; }

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
            sb.Append("class ArrivalFlight {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  Stops: ").Append(Stops).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Carrier: ").Append(Carrier).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  OperatingCarrier: ").Append(OperatingCarrier).Append("\n");
            sb.Append("  OperatingCarrierName: ").Append(OperatingCarrierName).Append("\n");
            sb.Append("  Equipment: ").Append(Equipment).Append("\n");
            sb.Append("  Departure: ").Append(Departure).Append("\n");
            sb.Append("  Arrival: ").Append(Arrival).Append("\n");
            sb.Append("  IntermediateStop: ").Append(IntermediateStop).Append("\n");
            sb.Append("  SubjectToGovernmentApprovalInd: ").Append(SubjectToGovernmentApprovalInd).Append("\n");
            sb.Append("  ExtensionPoint: ").Append(ExtensionPoint).Append("\n");
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
            return this.Equals(input as ArrivalFlight);
        }

        /// <summary>
        /// Returns true if ArrivalFlight instances are equal
        /// </summary>
        /// <param name="input">Instance of ArrivalFlight to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArrivalFlight input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Distance == input.Distance ||
                    (this.Distance != null &&
                    this.Distance.Equals(input.Distance))
                ) && base.Equals(input) && 
                (
                    this.Stops == input.Stops ||
                    (this.Stops != null &&
                    this.Stops.Equals(input.Stops))
                ) && base.Equals(input) && 
                (
                    this.Duration == input.Duration ||
                    (this.Duration != null &&
                    this.Duration.Equals(input.Duration))
                ) && base.Equals(input) && 
                (
                    this.Carrier == input.Carrier ||
                    (this.Carrier != null &&
                    this.Carrier.Equals(input.Carrier))
                ) && base.Equals(input) && 
                (
                    this.Number == input.Number ||
                    (this.Number != null &&
                    this.Number.Equals(input.Number))
                ) && base.Equals(input) && 
                (
                    this.OperatingCarrier == input.OperatingCarrier ||
                    (this.OperatingCarrier != null &&
                    this.OperatingCarrier.Equals(input.OperatingCarrier))
                ) && base.Equals(input) && 
                (
                    this.OperatingCarrierName == input.OperatingCarrierName ||
                    (this.OperatingCarrierName != null &&
                    this.OperatingCarrierName.Equals(input.OperatingCarrierName))
                ) && base.Equals(input) && 
                (
                    this.Equipment == input.Equipment ||
                    (this.Equipment != null &&
                    this.Equipment.Equals(input.Equipment))
                ) && base.Equals(input) && 
                (
                    this.Departure == input.Departure ||
                    (this.Departure != null &&
                    this.Departure.Equals(input.Departure))
                ) && base.Equals(input) && 
                (
                    this.Arrival == input.Arrival ||
                    (this.Arrival != null &&
                    this.Arrival.Equals(input.Arrival))
                ) && base.Equals(input) && 
                (
                    this.IntermediateStop == input.IntermediateStop ||
                    this.IntermediateStop != null &&
                    this.IntermediateStop.SequenceEqual(input.IntermediateStop)
                ) && base.Equals(input) && 
                (
                    this.SubjectToGovernmentApprovalInd == input.SubjectToGovernmentApprovalInd ||
                    (this.SubjectToGovernmentApprovalInd != null &&
                    this.SubjectToGovernmentApprovalInd.Equals(input.SubjectToGovernmentApprovalInd))
                ) && base.Equals(input) && 
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
                int hashCode = base.GetHashCode();
                if (this.Distance != null)
                    hashCode = hashCode * 59 + this.Distance.GetHashCode();
                if (this.Stops != null)
                    hashCode = hashCode * 59 + this.Stops.GetHashCode();
                if (this.Duration != null)
                    hashCode = hashCode * 59 + this.Duration.GetHashCode();
                if (this.Carrier != null)
                    hashCode = hashCode * 59 + this.Carrier.GetHashCode();
                if (this.Number != null)
                    hashCode = hashCode * 59 + this.Number.GetHashCode();
                if (this.OperatingCarrier != null)
                    hashCode = hashCode * 59 + this.OperatingCarrier.GetHashCode();
                if (this.OperatingCarrierName != null)
                    hashCode = hashCode * 59 + this.OperatingCarrierName.GetHashCode();
                if (this.Equipment != null)
                    hashCode = hashCode * 59 + this.Equipment.GetHashCode();
                if (this.Departure != null)
                    hashCode = hashCode * 59 + this.Departure.GetHashCode();
                if (this.Arrival != null)
                    hashCode = hashCode * 59 + this.Arrival.GetHashCode();
                if (this.IntermediateStop != null)
                    hashCode = hashCode * 59 + this.IntermediateStop.GetHashCode();
                if (this.SubjectToGovernmentApprovalInd != null)
                    hashCode = hashCode * 59 + this.SubjectToGovernmentApprovalInd.GetHashCode();
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
            foreach(var x in BaseValidate(validationContext)) yield return x;
            // Distance (int?) minimum
            if(this.Distance < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Distance, must be a value greater than or equal to 0.", new [] { "Distance" });
            }

            // Carrier (string) pattern
            Regex regexCarrier = new Regex(@"([a-zA-Z0-9]{2,3})", RegexOptions.CultureInvariant);
            if (false == regexCarrier.Match(this.Carrier).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Carrier, must match a pattern of " + regexCarrier, new [] { "Carrier" });
            }

            // Number (string) pattern
            Regex regexNumber = new Regex(@"[0-9]{1,4}[A-Z]?|OPEN|ARNK", RegexOptions.CultureInvariant);
            if (false == regexNumber.Match(this.Number).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Number, must match a pattern of " + regexNumber, new [] { "Number" });
            }

            // OperatingCarrier (string) pattern
            Regex regexOperatingCarrier = new Regex(@"([a-zA-Z0-9]{2,3})", RegexOptions.CultureInvariant);
            if (false == regexOperatingCarrier.Match(this.OperatingCarrier).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OperatingCarrier, must match a pattern of " + regexOperatingCarrier, new [] { "OperatingCarrier" });
            }

            // OperatingCarrierName (string) maxLength
            if(this.OperatingCarrierName != null && this.OperatingCarrierName.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OperatingCarrierName, length must be less than 128.", new [] { "OperatingCarrierName" });
            }

            // Equipment (string) pattern
            Regex regexEquipment = new Regex(@"([A-Z0-9]{3})?", RegexOptions.CultureInvariant);
            if (false == regexEquipment.Match(this.Equipment).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Equipment, must match a pattern of " + regexEquipment, new [] { "Equipment" });
            }

            yield break;
        }
    }

}
