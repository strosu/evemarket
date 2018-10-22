/* 
 * EVE Swagger Interface
 *
 * An OpenAPI for EVE Online
 *
 * OpenAPI spec version: 0.8.6
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
    /// 200 ok object
    /// </summary>
    [DataContract]
    public partial class GetAlliancesAllianceIdIconsOk :  IEquatable<GetAlliancesAllianceIdIconsOk>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAlliancesAllianceIdIconsOk" /> class.
        /// </summary>
        /// <param name="Px128x128">px128x128 string.</param>
        /// <param name="Px64x64">px64x64 string.</param>
        public GetAlliancesAllianceIdIconsOk(string Px128x128 = default(string), string Px64x64 = default(string))
        {
            this.Px128x128 = Px128x128;
            this.Px64x64 = Px64x64;
        }
        
        /// <summary>
        /// px128x128 string
        /// </summary>
        /// <value>px128x128 string</value>
        [DataMember(Name="px128x128", EmitDefaultValue=false)]
        public string Px128x128 { get; set; }

        /// <summary>
        /// px64x64 string
        /// </summary>
        /// <value>px64x64 string</value>
        [DataMember(Name="px64x64", EmitDefaultValue=false)]
        public string Px64x64 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetAlliancesAllianceIdIconsOk {\n");
            sb.Append("  Px128x128: ").Append(Px128x128).Append("\n");
            sb.Append("  Px64x64: ").Append(Px64x64).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return this.Equals(input as GetAlliancesAllianceIdIconsOk);
        }

        /// <summary>
        /// Returns true if GetAlliancesAllianceIdIconsOk instances are equal
        /// </summary>
        /// <param name="input">Instance of GetAlliancesAllianceIdIconsOk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetAlliancesAllianceIdIconsOk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Px128x128 == input.Px128x128 ||
                    (this.Px128x128 != null &&
                    this.Px128x128.Equals(input.Px128x128))
                ) && 
                (
                    this.Px64x64 == input.Px64x64 ||
                    (this.Px64x64 != null &&
                    this.Px64x64.Equals(input.Px64x64))
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
                if (this.Px128x128 != null)
                    hashCode = hashCode * 59 + this.Px128x128.GetHashCode();
                if (this.Px64x64 != null)
                    hashCode = hashCode * 59 + this.Px64x64.GetHashCode();
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
            yield break;
        }
    }

}
