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
    /// A URL that describes a step that can be applied to the resource containing the next step structure.
    /// </summary>
    [DataContract]
    public partial class NextStep :  IEquatable<NextStep>, IValidatableObject
    {
        /// <summary>
        /// possible action that can be performed on the returned results
        /// </summary>
        /// <value>possible action that can be performed on the returned results</value>
        [DataMember(Name="method", EmitDefaultValue=false)]
        public NextStepMethodEnum Method { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="NextStep" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NextStep() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NextStep" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="id">Identifier for the Next Step.</param>
        /// <param name="action">Assigned Type: c-1100:StringTiny (required).</param>
        /// <param name="method">possible action that can be performed on the returned results (required).</param>
        /// <param name="description">Assigned Type: c-1100:StringTiny.</param>
        public NextStep(string value = default(string), string id = default(string), string action = default(string), NextStepMethodEnum method = default(NextStepMethodEnum), string description = default(string))
        {
            // to ensure "action" is required (not null)
            if (action == null)
            {
                throw new InvalidDataException("action is a required property for NextStep and cannot be null");
            }
            else
            {
                this.Action = action;
            }
            // to ensure "method" is required (not null)
            if (method == null)
            {
                throw new InvalidDataException("method is a required property for NextStep and cannot be null");
            }
            else
            {
                this.Method = method;
            }
            this.Value = value;
            this.Id = id;
            this.Description = description;
        }
        
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Identifier for the Next Step
        /// </summary>
        /// <value>Identifier for the Next Step</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringTiny
        /// </summary>
        /// <value>Assigned Type: c-1100:StringTiny</value>
        [DataMember(Name="action", EmitDefaultValue=false)]
        public string Action { get; set; }


        /// <summary>
        /// Assigned Type: c-1100:StringTiny
        /// </summary>
        /// <value>Assigned Type: c-1100:StringTiny</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NextStep {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
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
            return this.Equals(input as NextStep);
        }

        /// <summary>
        /// Returns true if NextStep instances are equal
        /// </summary>
        /// <param name="input">Instance of NextStep to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NextStep input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Action == input.Action ||
                    (this.Action != null &&
                    this.Action.Equals(input.Action))
                ) && 
                (
                    this.Method == input.Method ||
                    (this.Method != null &&
                    this.Method.Equals(input.Method))
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
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Action != null)
                    hashCode = hashCode * 59 + this.Action.GetHashCode();
                if (this.Method != null)
                    hashCode = hashCode * 59 + this.Method.GetHashCode();
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
            // Action (string) maxLength
            if(this.Action != null && this.Action.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Action, length must be less than 32.", new [] { "Action" });
            }

            // Description (string) maxLength
            if(this.Description != null && this.Description.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 32.", new [] { "Description" });
            }

            yield break;
        }
    }

}
