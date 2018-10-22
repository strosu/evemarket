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
    /// yesterday object
    /// </summary>
    [DataContract]
    public partial class GetFwLeaderboardsCharactersYesterdayYesterday1 :  IEquatable<GetFwLeaderboardsCharactersYesterdayYesterday1>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwLeaderboardsCharactersYesterdayYesterday1" /> class.
        /// </summary>
        /// <param name="Amount">Amount of victory points.</param>
        /// <param name="CharacterId">character_id integer.</param>
        public GetFwLeaderboardsCharactersYesterdayYesterday1(int? Amount = default(int?), int? CharacterId = default(int?))
        {
            this.Amount = Amount;
            this.CharacterId = CharacterId;
        }
        
        /// <summary>
        /// Amount of victory points
        /// </summary>
        /// <value>Amount of victory points</value>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public int? Amount { get; set; }

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [DataMember(Name="character_id", EmitDefaultValue=false)]
        public int? CharacterId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetFwLeaderboardsCharactersYesterdayYesterday1 {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  CharacterId: ").Append(CharacterId).Append("\n");
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
            return this.Equals(input as GetFwLeaderboardsCharactersYesterdayYesterday1);
        }

        /// <summary>
        /// Returns true if GetFwLeaderboardsCharactersYesterdayYesterday1 instances are equal
        /// </summary>
        /// <param name="input">Instance of GetFwLeaderboardsCharactersYesterdayYesterday1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetFwLeaderboardsCharactersYesterdayYesterday1 input)
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
                    this.CharacterId == input.CharacterId ||
                    (this.CharacterId != null &&
                    this.CharacterId.Equals(input.CharacterId))
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
                if (this.CharacterId != null)
                    hashCode = hashCode * 59 + this.CharacterId.GetHashCode();
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
