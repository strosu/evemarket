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
    /// isk object
    /// </summary>
    [DataContract]
    public partial class GetCharactersCharacterIdStatsIsk :  IEquatable<GetCharactersCharacterIdStatsIsk>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdStatsIsk" /> class.
        /// </summary>
        /// <param name="_In">in integer.</param>
        /// <param name="_Out">out integer.</param>
        public GetCharactersCharacterIdStatsIsk(long? _In = default(long?), long? _Out = default(long?))
        {
            this._In = _In;
            this._Out = _Out;
        }
        
        /// <summary>
        /// in integer
        /// </summary>
        /// <value>in integer</value>
        [DataMember(Name="in", EmitDefaultValue=false)]
        public long? _In { get; set; }

        /// <summary>
        /// out integer
        /// </summary>
        /// <value>out integer</value>
        [DataMember(Name="out", EmitDefaultValue=false)]
        public long? _Out { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdStatsIsk {\n");
            sb.Append("  _In: ").Append(_In).Append("\n");
            sb.Append("  _Out: ").Append(_Out).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdStatsIsk);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdStatsIsk instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdStatsIsk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdStatsIsk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this._In == input._In ||
                    (this._In != null &&
                    this._In.Equals(input._In))
                ) && 
                (
                    this._Out == input._Out ||
                    (this._Out != null &&
                    this._Out.Equals(input._Out))
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
                if (this._In != null)
                    hashCode = hashCode * 59 + this._In.GetHashCode();
                if (this._Out != null)
                    hashCode = hashCode * 59 + this._Out.GetHashCode();
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
