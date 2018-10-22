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
    /// Summary of victory points gained for the given faction
    /// </summary>
    [DataContract]
    public partial class GetFwStatsVictoryPoints :  IEquatable<GetFwStatsVictoryPoints>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwStatsVictoryPoints" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetFwStatsVictoryPoints() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwStatsVictoryPoints" /> class.
        /// </summary>
        /// <param name="LastWeek">Last week&#39;s victory points gained (required).</param>
        /// <param name="Total">Total victory points gained since faction warfare began (required).</param>
        /// <param name="Yesterday">Yesterday&#39;s victory points gained (required).</param>
        public GetFwStatsVictoryPoints(int? LastWeek = default(int?), int? Total = default(int?), int? Yesterday = default(int?))
        {
            // to ensure "LastWeek" is required (not null)
            if (LastWeek == null)
            {
                throw new InvalidDataException("LastWeek is a required property for GetFwStatsVictoryPoints and cannot be null");
            }
            else
            {
                this.LastWeek = LastWeek;
            }
            // to ensure "Total" is required (not null)
            if (Total == null)
            {
                throw new InvalidDataException("Total is a required property for GetFwStatsVictoryPoints and cannot be null");
            }
            else
            {
                this.Total = Total;
            }
            // to ensure "Yesterday" is required (not null)
            if (Yesterday == null)
            {
                throw new InvalidDataException("Yesterday is a required property for GetFwStatsVictoryPoints and cannot be null");
            }
            else
            {
                this.Yesterday = Yesterday;
            }
        }
        
        /// <summary>
        /// Last week&#39;s victory points gained
        /// </summary>
        /// <value>Last week&#39;s victory points gained</value>
        [DataMember(Name="last_week", EmitDefaultValue=false)]
        public int? LastWeek { get; set; }

        /// <summary>
        /// Total victory points gained since faction warfare began
        /// </summary>
        /// <value>Total victory points gained since faction warfare began</value>
        [DataMember(Name="total", EmitDefaultValue=false)]
        public int? Total { get; set; }

        /// <summary>
        /// Yesterday&#39;s victory points gained
        /// </summary>
        /// <value>Yesterday&#39;s victory points gained</value>
        [DataMember(Name="yesterday", EmitDefaultValue=false)]
        public int? Yesterday { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetFwStatsVictoryPoints {\n");
            sb.Append("  LastWeek: ").Append(LastWeek).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Yesterday: ").Append(Yesterday).Append("\n");
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
            return this.Equals(input as GetFwStatsVictoryPoints);
        }

        /// <summary>
        /// Returns true if GetFwStatsVictoryPoints instances are equal
        /// </summary>
        /// <param name="input">Instance of GetFwStatsVictoryPoints to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetFwStatsVictoryPoints input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LastWeek == input.LastWeek ||
                    (this.LastWeek != null &&
                    this.LastWeek.Equals(input.LastWeek))
                ) && 
                (
                    this.Total == input.Total ||
                    (this.Total != null &&
                    this.Total.Equals(input.Total))
                ) && 
                (
                    this.Yesterday == input.Yesterday ||
                    (this.Yesterday != null &&
                    this.Yesterday.Equals(input.Yesterday))
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
                if (this.LastWeek != null)
                    hashCode = hashCode * 59 + this.LastWeek.GetHashCode();
                if (this.Total != null)
                    hashCode = hashCode * 59 + this.Total.GetHashCode();
                if (this.Yesterday != null)
                    hashCode = hashCode * 59 + this.Yesterday.GetHashCode();
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
