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
    /// CatalogProductOfferingsResponse
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "@type")]
    public partial class CatalogProductOfferingsResponse :  IEquatable<CatalogProductOfferingsResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogProductOfferingsResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CatalogProductOfferingsResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogProductOfferingsResponse" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="catalogProductOfferings">Assigned Type: ctlg-1100:CatalogProductOfferings (required).</param>
        /// <param name="transactionId">Unique transaction, correlation or tracking id for a single request and reply i.e. for a single transaction. Should be a 128 bit GUID format. Also know as E2ETrackingId..</param>
        /// <param name="traceId">Optional ID for internal child transactions created for processing a single request (single transaction). Should be a 128 bit GUID format. Also known as ChildTrackingId..</param>
        /// <param name="result">Assigned Type: c-1100:Result.</param>
        /// <param name="identifier">Assigned Type: c-1100:Identifier.</param>
        /// <param name="nextSteps">Assigned Type: c-1100:NextSteps.</param>
        /// <param name="referenceList">referenceList.</param>
        /// <param name="currencyRateConversion">currencyRateConversion.</param>
        /// <param name="supplementalInformation">supplementalInformation.</param>
        /// <param name="diagnosticResponse">diagnosticResponse.</param>
        /// <param name="extensionPoint">extensionPoint.</param>
        public CatalogProductOfferingsResponse(string type = default(string), CatalogProductOfferingsID catalogProductOfferings = default(CatalogProductOfferingsID), string transactionId = default(string), string traceId = default(string), Result result = default(Result), Identifier identifier = default(Identifier), NextSteps nextSteps = default(NextSteps), List<ReferenceList> referenceList = default(List<ReferenceList>), List<CurrencyRateConversion> currencyRateConversion = default(List<CurrencyRateConversion>), List<SupplementalInformation> supplementalInformation = default(List<SupplementalInformation>), List<NameValuePair> diagnosticResponse = default(List<NameValuePair>), Object extensionPoint = default(Object))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for CatalogProductOfferingsResponse and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "catalogProductOfferings" is required (not null)
            if (catalogProductOfferings == null)
            {
                throw new InvalidDataException("catalogProductOfferings is a required property for CatalogProductOfferingsResponse and cannot be null");
            }
            else
            {
                this.CatalogProductOfferings = catalogProductOfferings;
            }
            this.TransactionId = transactionId;
            this.TraceId = traceId;
            this.Result = result;
            this.Identifier = identifier;
            this.NextSteps = nextSteps;
            this.ReferenceList = referenceList;
            this.CurrencyRateConversion = currencyRateConversion;
            this.SupplementalInformation = supplementalInformation;
            this.DiagnosticResponse = diagnosticResponse;
            this.ExtensionPoint = extensionPoint;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="@type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Assigned Type: ctlg-1100:CatalogProductOfferings
        /// </summary>
        /// <value>Assigned Type: ctlg-1100:CatalogProductOfferings</value>
        [DataMember(Name="CatalogProductOfferings", EmitDefaultValue=false)]
        public CatalogProductOfferingsID CatalogProductOfferings { get; set; }

        /// <summary>
        /// Unique transaction, correlation or tracking id for a single request and reply i.e. for a single transaction. Should be a 128 bit GUID format. Also know as E2ETrackingId.
        /// </summary>
        /// <value>Unique transaction, correlation or tracking id for a single request and reply i.e. for a single transaction. Should be a 128 bit GUID format. Also know as E2ETrackingId.</value>
        [DataMember(Name="transactionId", EmitDefaultValue=false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Optional ID for internal child transactions created for processing a single request (single transaction). Should be a 128 bit GUID format. Also known as ChildTrackingId.
        /// </summary>
        /// <value>Optional ID for internal child transactions created for processing a single request (single transaction). Should be a 128 bit GUID format. Also known as ChildTrackingId.</value>
        [DataMember(Name="traceId", EmitDefaultValue=false)]
        public string TraceId { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Result
        /// </summary>
        /// <value>Assigned Type: c-1100:Result</value>
        [DataMember(Name="Result", EmitDefaultValue=false)]
        public Result Result { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:Identifier
        /// </summary>
        /// <value>Assigned Type: c-1100:Identifier</value>
        [DataMember(Name="Identifier", EmitDefaultValue=false)]
        public Identifier Identifier { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NextSteps
        /// </summary>
        /// <value>Assigned Type: c-1100:NextSteps</value>
        [DataMember(Name="NextSteps", EmitDefaultValue=false)]
        public NextSteps NextSteps { get; set; }

        /// <summary>
        /// Gets or Sets ReferenceList
        /// </summary>
        [DataMember(Name="ReferenceList", EmitDefaultValue=false)]
        public List<ReferenceList> ReferenceList { get; set; }

        /// <summary>
        /// Gets or Sets CurrencyRateConversion
        /// </summary>
        [DataMember(Name="CurrencyRateConversion", EmitDefaultValue=false)]
        public List<CurrencyRateConversion> CurrencyRateConversion { get; set; }

        /// <summary>
        /// Gets or Sets SupplementalInformation
        /// </summary>
        [DataMember(Name="SupplementalInformation", EmitDefaultValue=false)]
        public List<SupplementalInformation> SupplementalInformation { get; set; }

        /// <summary>
        /// Gets or Sets DiagnosticResponse
        /// </summary>
        [DataMember(Name="DiagnosticResponse", EmitDefaultValue=false)]
        public List<NameValuePair> DiagnosticResponse { get; set; }

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
            sb.Append("class CatalogProductOfferingsResponse {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CatalogProductOfferings: ").Append(CatalogProductOfferings).Append("\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  TraceId: ").Append(TraceId).Append("\n");
            sb.Append("  Result: ").Append(Result).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  NextSteps: ").Append(NextSteps).Append("\n");
            sb.Append("  ReferenceList: ").Append(ReferenceList).Append("\n");
            sb.Append("  CurrencyRateConversion: ").Append(CurrencyRateConversion).Append("\n");
            sb.Append("  SupplementalInformation: ").Append(SupplementalInformation).Append("\n");
            sb.Append("  DiagnosticResponse: ").Append(DiagnosticResponse).Append("\n");
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
            return this.Equals(input as CatalogProductOfferingsResponse);
        }

        /// <summary>
        /// Returns true if CatalogProductOfferingsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CatalogProductOfferingsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CatalogProductOfferingsResponse input)
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
                    this.CatalogProductOfferings == input.CatalogProductOfferings ||
                    (this.CatalogProductOfferings != null &&
                    this.CatalogProductOfferings.Equals(input.CatalogProductOfferings))
                ) && 
                (
                    this.TransactionId == input.TransactionId ||
                    (this.TransactionId != null &&
                    this.TransactionId.Equals(input.TransactionId))
                ) && 
                (
                    this.TraceId == input.TraceId ||
                    (this.TraceId != null &&
                    this.TraceId.Equals(input.TraceId))
                ) && 
                (
                    this.Result == input.Result ||
                    (this.Result != null &&
                    this.Result.Equals(input.Result))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.NextSteps == input.NextSteps ||
                    (this.NextSteps != null &&
                    this.NextSteps.Equals(input.NextSteps))
                ) && 
                (
                    this.ReferenceList == input.ReferenceList ||
                    this.ReferenceList != null &&
                    this.ReferenceList.SequenceEqual(input.ReferenceList)
                ) && 
                (
                    this.CurrencyRateConversion == input.CurrencyRateConversion ||
                    this.CurrencyRateConversion != null &&
                    this.CurrencyRateConversion.SequenceEqual(input.CurrencyRateConversion)
                ) && 
                (
                    this.SupplementalInformation == input.SupplementalInformation ||
                    this.SupplementalInformation != null &&
                    this.SupplementalInformation.SequenceEqual(input.SupplementalInformation)
                ) && 
                (
                    this.DiagnosticResponse == input.DiagnosticResponse ||
                    this.DiagnosticResponse != null &&
                    this.DiagnosticResponse.SequenceEqual(input.DiagnosticResponse)
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
                if (this.CatalogProductOfferings != null)
                    hashCode = hashCode * 59 + this.CatalogProductOfferings.GetHashCode();
                if (this.TransactionId != null)
                    hashCode = hashCode * 59 + this.TransactionId.GetHashCode();
                if (this.TraceId != null)
                    hashCode = hashCode * 59 + this.TraceId.GetHashCode();
                if (this.Result != null)
                    hashCode = hashCode * 59 + this.Result.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.NextSteps != null)
                    hashCode = hashCode * 59 + this.NextSteps.GetHashCode();
                if (this.ReferenceList != null)
                    hashCode = hashCode * 59 + this.ReferenceList.GetHashCode();
                if (this.CurrencyRateConversion != null)
                    hashCode = hashCode * 59 + this.CurrencyRateConversion.GetHashCode();
                if (this.SupplementalInformation != null)
                    hashCode = hashCode * 59 + this.SupplementalInformation.GetHashCode();
                if (this.DiagnosticResponse != null)
                    hashCode = hashCode * 59 + this.DiagnosticResponse.GetHashCode();
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