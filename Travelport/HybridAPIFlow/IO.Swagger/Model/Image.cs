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
    /// URL of the image
    /// </summary>
    [DataContract]
    public partial class Image :  IEquatable<Image>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="dimensionCategory">Assigned Type: c-1100:StringCharacterOne.</param>
        /// <param name="width">Width of image.</param>
        /// <param name="height">Height.</param>
        /// <param name="caption">Assigned Type: c-1100:StringShort.</param>
        /// <param name="pictureCategory">Assigned Type: c-1100:NumberDoubleDigit.</param>
        public Image(string value = default(string), string dimensionCategory = default(string), int? width = default(int?), int? height = default(int?), string caption = default(string), int? pictureCategory = default(int?))
        {
            this.Value = value;
            this.DimensionCategory = dimensionCategory;
            this.Width = width;
            this.Height = height;
            this.Caption = caption;
            this.PictureCategory = pictureCategory;
        }
        
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringCharacterOne
        /// </summary>
        /// <value>Assigned Type: c-1100:StringCharacterOne</value>
        [DataMember(Name="dimensionCategory", EmitDefaultValue=false)]
        public string DimensionCategory { get; set; }

        /// <summary>
        /// Width of image
        /// </summary>
        /// <value>Width of image</value>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public int? Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        /// <value>Height</value>
        [DataMember(Name="height", EmitDefaultValue=false)]
        public int? Height { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:StringShort
        /// </summary>
        /// <value>Assigned Type: c-1100:StringShort</value>
        [DataMember(Name="caption", EmitDefaultValue=false)]
        public string Caption { get; set; }

        /// <summary>
        /// Assigned Type: c-1100:NumberDoubleDigit
        /// </summary>
        /// <value>Assigned Type: c-1100:NumberDoubleDigit</value>
        [DataMember(Name="pictureCategory", EmitDefaultValue=false)]
        public int? PictureCategory { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Image {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  DimensionCategory: ").Append(DimensionCategory).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Caption: ").Append(Caption).Append("\n");
            sb.Append("  PictureCategory: ").Append(PictureCategory).Append("\n");
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
            return this.Equals(input as Image);
        }

        /// <summary>
        /// Returns true if Image instances are equal
        /// </summary>
        /// <param name="input">Instance of Image to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Image input)
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
                    this.DimensionCategory == input.DimensionCategory ||
                    (this.DimensionCategory != null &&
                    this.DimensionCategory.Equals(input.DimensionCategory))
                ) && 
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
                ) && 
                (
                    this.Height == input.Height ||
                    (this.Height != null &&
                    this.Height.Equals(input.Height))
                ) && 
                (
                    this.Caption == input.Caption ||
                    (this.Caption != null &&
                    this.Caption.Equals(input.Caption))
                ) && 
                (
                    this.PictureCategory == input.PictureCategory ||
                    (this.PictureCategory != null &&
                    this.PictureCategory.Equals(input.PictureCategory))
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
                if (this.DimensionCategory != null)
                    hashCode = hashCode * 59 + this.DimensionCategory.GetHashCode();
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
                if (this.Caption != null)
                    hashCode = hashCode * 59 + this.Caption.GetHashCode();
                if (this.PictureCategory != null)
                    hashCode = hashCode * 59 + this.PictureCategory.GetHashCode();
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
            // DimensionCategory (string) maxLength
            if(this.DimensionCategory != null && this.DimensionCategory.Length > 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DimensionCategory, length must be less than 1.", new [] { "DimensionCategory" });
            }

            // Caption (string) maxLength
            if(this.Caption != null && this.Caption.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Caption, length must be less than 128.", new [] { "Caption" });
            }

            yield break;
        }
    }

}
