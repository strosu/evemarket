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
    /// content object
    /// </summary>
    [DataContract]
    public partial class GetCharactersCharacterIdPlanetsPlanetIdContent :  IEquatable<GetCharactersCharacterIdPlanetsPlanetIdContent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdPlanetsPlanetIdContent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCharactersCharacterIdPlanetsPlanetIdContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdPlanetsPlanetIdContent" /> class.
        /// </summary>
        /// <param name="Amount">amount integer (required).</param>
        /// <param name="TypeId">type_id integer (required).</param>
        public GetCharactersCharacterIdPlanetsPlanetIdContent(long? Amount = default(long?), int? TypeId = default(int?))
        {
            // to ensure "Amount" is required (not null)
            if (Amount == null)
            {
                throw new InvalidDataException("Amount is a required property for GetCharactersCharacterIdPlanetsPlanetIdContent and cannot be null");
            }
            else
            {
                this.Amount = Amount;
            }
            // to ensure "TypeId" is required (not null)
            if (TypeId == null)
            {
                throw new InvalidDataException("TypeId is a required property for GetCharactersCharacterIdPlanetsPlanetIdContent and cannot be null");
            }
            else
            {
                this.TypeId = TypeId;
            }
        }
        
        /// <summary>
        /// amount integer
        /// </summary>
        /// <value>amount integer</value>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public long? Amount { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [DataMember(Name="type_id", EmitDefaultValue=false)]
        public int? TypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdPlanetsPlanetIdContent {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  TypeId: ").Append(TypeId).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdPlanetsPlanetIdContent);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdPlanetsPlanetIdContent instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdPlanetsPlanetIdContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdPlanetsPlanetIdContent input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.TypeId == input.TypeId ||
                    (this.TypeId != null &&
                    this.TypeId.Equals(input.TypeId))
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
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.TypeId != null)
                    hashCode = hashCode * 59 + this.TypeId.GetHashCode();
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
