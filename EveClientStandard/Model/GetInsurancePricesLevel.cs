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
    /// level object
    /// </summary>
    [DataContract]
    public partial class GetInsurancePricesLevel :  IEquatable<GetInsurancePricesLevel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInsurancePricesLevel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetInsurancePricesLevel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInsurancePricesLevel" /> class.
        /// </summary>
        /// <param name="Cost">cost number (required).</param>
        /// <param name="Name">Localized insurance level (required).</param>
        /// <param name="Payout">payout number (required).</param>
        public GetInsurancePricesLevel(float? Cost = default(float?), string Name = default(string), float? Payout = default(float?))
        {
            // to ensure "Cost" is required (not null)
            if (Cost == null)
            {
                throw new InvalidDataException("Cost is a required property for GetInsurancePricesLevel and cannot be null");
            }
            else
            {
                this.Cost = Cost;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for GetInsurancePricesLevel and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            // to ensure "Payout" is required (not null)
            if (Payout == null)
            {
                throw new InvalidDataException("Payout is a required property for GetInsurancePricesLevel and cannot be null");
            }
            else
            {
                this.Payout = Payout;
            }
        }
        
        /// <summary>
        /// cost number
        /// </summary>
        /// <value>cost number</value>
        [DataMember(Name="cost", EmitDefaultValue=false)]
        public float? Cost { get; set; }

        /// <summary>
        /// Localized insurance level
        /// </summary>
        /// <value>Localized insurance level</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// payout number
        /// </summary>
        /// <value>payout number</value>
        [DataMember(Name="payout", EmitDefaultValue=false)]
        public float? Payout { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetInsurancePricesLevel {\n");
            sb.Append("  Cost: ").Append(Cost).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Payout: ").Append(Payout).Append("\n");
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
            return this.Equals(input as GetInsurancePricesLevel);
        }

        /// <summary>
        /// Returns true if GetInsurancePricesLevel instances are equal
        /// </summary>
        /// <param name="input">Instance of GetInsurancePricesLevel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetInsurancePricesLevel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Cost == input.Cost ||
                    (this.Cost != null &&
                    this.Cost.Equals(input.Cost))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Payout == input.Payout ||
                    (this.Payout != null &&
                    this.Payout.Equals(input.Payout))
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
                if (this.Cost != null)
                    hashCode = hashCode * 59 + this.Cost.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Payout != null)
                    hashCode = hashCode * 59 + this.Payout.GetHashCode();
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