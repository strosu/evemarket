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
    /// dogma_effect object
    /// </summary>
    [DataContract]
    public partial class GetUniverseTypesTypeIdDogmaEffect :  IEquatable<GetUniverseTypesTypeIdDogmaEffect>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseTypesTypeIdDogmaEffect" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetUniverseTypesTypeIdDogmaEffect() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseTypesTypeIdDogmaEffect" /> class.
        /// </summary>
        /// <param name="EffectId">effect_id integer (required).</param>
        /// <param name="IsDefault">is_default boolean (required).</param>
        public GetUniverseTypesTypeIdDogmaEffect(int? EffectId = default(int?), bool? IsDefault = default(bool?))
        {
            // to ensure "EffectId" is required (not null)
            if (EffectId == null)
            {
                throw new InvalidDataException("EffectId is a required property for GetUniverseTypesTypeIdDogmaEffect and cannot be null");
            }
            else
            {
                this.EffectId = EffectId;
            }
            // to ensure "IsDefault" is required (not null)
            if (IsDefault == null)
            {
                throw new InvalidDataException("IsDefault is a required property for GetUniverseTypesTypeIdDogmaEffect and cannot be null");
            }
            else
            {
                this.IsDefault = IsDefault;
            }
        }
        
        /// <summary>
        /// effect_id integer
        /// </summary>
        /// <value>effect_id integer</value>
        [DataMember(Name="effect_id", EmitDefaultValue=false)]
        public int? EffectId { get; set; }

        /// <summary>
        /// is_default boolean
        /// </summary>
        /// <value>is_default boolean</value>
        [DataMember(Name="is_default", EmitDefaultValue=false)]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUniverseTypesTypeIdDogmaEffect {\n");
            sb.Append("  EffectId: ").Append(EffectId).Append("\n");
            sb.Append("  IsDefault: ").Append(IsDefault).Append("\n");
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
            return this.Equals(input as GetUniverseTypesTypeIdDogmaEffect);
        }

        /// <summary>
        /// Returns true if GetUniverseTypesTypeIdDogmaEffect instances are equal
        /// </summary>
        /// <param name="input">Instance of GetUniverseTypesTypeIdDogmaEffect to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetUniverseTypesTypeIdDogmaEffect input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EffectId == input.EffectId ||
                    (this.EffectId != null &&
                    this.EffectId.Equals(input.EffectId))
                ) && 
                (
                    this.IsDefault == input.IsDefault ||
                    (this.IsDefault != null &&
                    this.IsDefault.Equals(input.IsDefault))
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
                if (this.EffectId != null)
                    hashCode = hashCode * 59 + this.EffectId.GetHashCode();
                if (this.IsDefault != null)
                    hashCode = hashCode * 59 + this.IsDefault.GetHashCode();
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
