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
    /// Defines ChangeFeeMethodEnum_Base
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum ChangeFeeMethodEnumBase
    {
        
        /// <summary>
        /// Enum EMD for value: EMD
        /// </summary>
        [EnumMember(Value = "EMD")]
        EMD = 1,
        
        /// <summary>
        /// Enum MCO for value: MCO
        /// </summary>
        [EnumMember(Value = "MCO")]
        MCO = 2,
        
        /// <summary>
        /// Enum Tax for value: Tax
        /// </summary>
        [EnumMember(Value = "Tax")]
        Tax = 3,
        
        /// <summary>
        /// Enum Unknown for value: Unknown
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 4,
        
        /// <summary>
        /// Enum Other for value: Other_
        /// </summary>
        [EnumMember(Value = "Other_")]
        Other = 5
    }

}