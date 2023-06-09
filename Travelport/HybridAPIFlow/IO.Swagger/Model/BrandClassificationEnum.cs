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
    /// The Travelport classification used for a category of ancillaries such as Seat, Bags, etc. This is an initial list that will be added to.
    /// </summary>
    /// <value>The Travelport classification used for a category of ancillaries such as Seat, Bags, etc. This is an initial list that will be added to.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum BrandClassificationEnum
    {
        
        /// <summary>
        /// Enum CheckedBag for value: CheckedBag
        /// </summary>
        [EnumMember(Value = "CheckedBag")]
        CheckedBag = 1,
        
        /// <summary>
        /// Enum CarryOn for value: CarryOn
        /// </summary>
        [EnumMember(Value = "CarryOn")]
        CarryOn = 2,
        
        /// <summary>
        /// Enum PersonalItem for value: PersonalItem
        /// </summary>
        [EnumMember(Value = "PersonalItem")]
        PersonalItem = 3,
        
        /// <summary>
        /// Enum Rebooking for value: Rebooking
        /// </summary>
        [EnumMember(Value = "Rebooking")]
        Rebooking = 4,
        
        /// <summary>
        /// Enum Refund for value: Refund
        /// </summary>
        [EnumMember(Value = "Refund")]
        Refund = 5,
        
        /// <summary>
        /// Enum SeatAssignment for value: SeatAssignment
        /// </summary>
        [EnumMember(Value = "SeatAssignment")]
        SeatAssignment = 6,
        
        /// <summary>
        /// Enum PremiumSeat for value: PremiumSeat
        /// </summary>
        [EnumMember(Value = "PremiumSeat")]
        PremiumSeat = 7,
        
        /// <summary>
        /// Enum LieFlatSeat for value: LieFlatSeat
        /// </summary>
        [EnumMember(Value = "LieFlatSeat")]
        LieFlatSeat = 8,
        
        /// <summary>
        /// Enum Meals for value: Meals
        /// </summary>
        [EnumMember(Value = "Meals")]
        Meals = 9,
        
        /// <summary>
        /// Enum WiFi for value: WiFi
        /// </summary>
        [EnumMember(Value = "WiFi")]
        WiFi = 10,
        
        /// <summary>
        /// Enum Other for value: Other
        /// </summary>
        [EnumMember(Value = "Other")]
        Other = 11
    }

}
