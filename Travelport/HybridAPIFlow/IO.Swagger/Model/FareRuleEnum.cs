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
    /// Defines FareRuleEnum
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum FareRuleEnum
    {
        
        /// <summary>
        /// Enum Structured for value: Structured
        /// </summary>
        [EnumMember(Value = "Structured")]
        Structured = 1,
        
        /// <summary>
        /// Enum ShortText for value: ShortText
        /// </summary>
        [EnumMember(Value = "ShortText")]
        ShortText = 2,
        
        /// <summary>
        /// Enum LongText for value: LongText
        /// </summary>
        [EnumMember(Value = "LongText")]
        LongText = 3
    }

}
