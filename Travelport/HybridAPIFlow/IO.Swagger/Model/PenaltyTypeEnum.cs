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
    /// Defines PenaltyTypeEnum
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum PenaltyTypeEnum
    {
        
        /// <summary>
        /// Enum BeforeDeparture for value: BeforeDeparture
        /// </summary>
        [EnumMember(Value = "BeforeDeparture")]
        BeforeDeparture = 1,
        
        /// <summary>
        /// Enum AfterDeparture for value: AfterDeparture
        /// </summary>
        [EnumMember(Value = "AfterDeparture")]
        AfterDeparture = 2,
        
        /// <summary>
        /// Enum Anytime for value: Anytime
        /// </summary>
        [EnumMember(Value = "Anytime")]
        Anytime = 3,
        
        /// <summary>
        /// Enum NoShow for value: NoShow
        /// </summary>
        [EnumMember(Value = "NoShow")]
        NoShow = 4,
        
        /// <summary>
        /// Enum Minimum for value: Minimum
        /// </summary>
        [EnumMember(Value = "Minimum")]
        Minimum = 5,
        
        /// <summary>
        /// Enum Maximum for value: Maximum
        /// </summary>
        [EnumMember(Value = "Maximum")]
        Maximum = 6,
        
        /// <summary>
        /// Enum ExchangeRequired for value: ExchangeRequired
        /// </summary>
        [EnumMember(Value = "ExchangeRequired")]
        ExchangeRequired = 7,
        
        /// <summary>
        /// Enum ExchangeNotRequired for value: ExchangeNotRequired
        /// </summary>
        [EnumMember(Value = "ExchangeNotRequired")]
        ExchangeNotRequired = 8
    }

}
