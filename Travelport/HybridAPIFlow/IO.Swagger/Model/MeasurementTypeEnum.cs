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
    /// The type of measurement such as width, height, weight
    /// </summary>
    /// <value>The type of measurement such as width, height, weight</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum MeasurementTypeEnum
    {
        
        /// <summary>
        /// Enum Width for value: Width
        /// </summary>
        [EnumMember(Value = "Width")]
        Width = 1,
        
        /// <summary>
        /// Enum Height for value: Height
        /// </summary>
        [EnumMember(Value = "Height")]
        Height = 2,
        
        /// <summary>
        /// Enum Depth for value: Depth
        /// </summary>
        [EnumMember(Value = "Depth")]
        Depth = 3,
        
        /// <summary>
        /// Enum Weight for value: Weight
        /// </summary>
        [EnumMember(Value = "Weight")]
        Weight = 4,
        
        /// <summary>
        /// Enum OverallDimension for value: OverallDimension
        /// </summary>
        [EnumMember(Value = "OverallDimension")]
        OverallDimension = 5
    }

}
