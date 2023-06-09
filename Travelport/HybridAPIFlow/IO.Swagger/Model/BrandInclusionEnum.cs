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
    /// The indicator as to hoe the brand and the product are associated.
    /// </summary>
    /// <value>The indicator as to hoe the brand and the product are associated.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum BrandInclusionEnum
    {
        
        /// <summary>
        /// Enum Included for value: Included
        /// </summary>
        [EnumMember(Value = "Included")]
        Included = 1,
        
        /// <summary>
        /// Enum Chargeable for value: Chargeable
        /// </summary>
        [EnumMember(Value = "Chargeable")]
        Chargeable = 2,
        
        /// <summary>
        /// Enum NotOffered for value: Not Offered
        /// </summary>
        [EnumMember(Value = "Not Offered")]
        NotOffered = 3
    }

}
