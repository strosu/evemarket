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
    public partial class GetContractsPublicItemsContractId200Ok :  IEquatable<GetContractsPublicItemsContractId200Ok>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetContractsPublicItemsContractId200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetContractsPublicItemsContractId200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetContractsPublicItemsContractId200Ok" /> class.
        /// </summary>
        /// <param name="IsBlueprintCopy">is_blueprint_copy boolean.</param>
        /// <param name="IsIncluded">true if the contract issuer has submitted this item with the contract, false if the isser is asking for this item in the contract (required).</param>
        /// <param name="ItemId">Unique ID for the item being sold. Not present if item is being requested by contract rather than sold with contract.</param>
        /// <param name="MaterialEfficiency">Material Efficiency Level of the blueprint.</param>
        /// <param name="Quantity">Number of items in the stack (required).</param>
        /// <param name="RecordId">Unique ID for the item, used by the contract system (required).</param>
        /// <param name="Runs">Number of runs remaining if the blueprint is a copy, -1 if it is an original.</param>
        /// <param name="TimeEfficiency">Time Efficiency Level of the blueprint.</param>
        /// <param name="TypeId">Type ID for item (required).</param>
        public GetContractsPublicItemsContractId200Ok(bool? IsBlueprintCopy = default(bool?), bool? IsIncluded = default(bool?), long? ItemId = default(long?), int? MaterialEfficiency = default(int?), int? Quantity = default(int?), long? RecordId = default(long?), int? Runs = default(int?), int? TimeEfficiency = default(int?), int? TypeId = default(int?))
        {
            // to ensure "IsIncluded" is required (not null)
            if (IsIncluded == null)
            {
                throw new InvalidDataException("IsIncluded is a required property for GetContractsPublicItemsContractId200Ok and cannot be null");
            }
            else
            {
                this.IsIncluded = IsIncluded;
            }
            // to ensure "Quantity" is required (not null)
            if (Quantity == null)
            {
                throw new InvalidDataException("Quantity is a required property for GetContractsPublicItemsContractId200Ok and cannot be null");
            }
            else
            {
                this.Quantity = Quantity;
            }
            // to ensure "RecordId" is required (not null)
            if (RecordId == null)
            {
                throw new InvalidDataException("RecordId is a required property for GetContractsPublicItemsContractId200Ok and cannot be null");
            }
            else
            {
                this.RecordId = RecordId;
            }
            // to ensure "TypeId" is required (not null)
            if (TypeId == null)
            {
                throw new InvalidDataException("TypeId is a required property for GetContractsPublicItemsContractId200Ok and cannot be null");
            }
            else
            {
                this.TypeId = TypeId;
            }
            this.IsBlueprintCopy = IsBlueprintCopy;
            this.ItemId = ItemId;
            this.MaterialEfficiency = MaterialEfficiency;
            this.Runs = Runs;
            this.TimeEfficiency = TimeEfficiency;
        }
        
        /// <summary>
        /// is_blueprint_copy boolean
        /// </summary>
        /// <value>is_blueprint_copy boolean</value>
        [DataMember(Name="is_blueprint_copy", EmitDefaultValue=false)]
        public bool? IsBlueprintCopy { get; set; }

        /// <summary>
        /// true if the contract issuer has submitted this item with the contract, false if the isser is asking for this item in the contract
        /// </summary>
        /// <value>true if the contract issuer has submitted this item with the contract, false if the isser is asking for this item in the contract</value>
        [DataMember(Name="is_included", EmitDefaultValue=false)]
        public bool? IsIncluded { get; set; }

        /// <summary>
        /// Unique ID for the item being sold. Not present if item is being requested by contract rather than sold with contract
        /// </summary>
        /// <value>Unique ID for the item being sold. Not present if item is being requested by contract rather than sold with contract</value>
        [DataMember(Name="item_id", EmitDefaultValue=false)]
        public long? ItemId { get; set; }

        /// <summary>
        /// Material Efficiency Level of the blueprint
        /// </summary>
        /// <value>Material Efficiency Level of the blueprint</value>
        [DataMember(Name="material_efficiency", EmitDefaultValue=false)]
        public int? MaterialEfficiency { get; set; }

        /// <summary>
        /// Number of items in the stack
        /// </summary>
        /// <value>Number of items in the stack</value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Unique ID for the item, used by the contract system
        /// </summary>
        /// <value>Unique ID for the item, used by the contract system</value>
        [DataMember(Name="record_id", EmitDefaultValue=false)]
        public long? RecordId { get; set; }

        /// <summary>
        /// Number of runs remaining if the blueprint is a copy, -1 if it is an original
        /// </summary>
        /// <value>Number of runs remaining if the blueprint is a copy, -1 if it is an original</value>
        [DataMember(Name="runs", EmitDefaultValue=false)]
        public int? Runs { get; set; }

        /// <summary>
        /// Time Efficiency Level of the blueprint
        /// </summary>
        /// <value>Time Efficiency Level of the blueprint</value>
        [DataMember(Name="time_efficiency", EmitDefaultValue=false)]
        public int? TimeEfficiency { get; set; }

        /// <summary>
        /// Type ID for item
        /// </summary>
        /// <value>Type ID for item</value>
        [DataMember(Name="type_id", EmitDefaultValue=false)]
        public int? TypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetContractsPublicItemsContractId200Ok {\n");
            sb.Append("  IsBlueprintCopy: ").Append(IsBlueprintCopy).Append("\n");
            sb.Append("  IsIncluded: ").Append(IsIncluded).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  MaterialEfficiency: ").Append(MaterialEfficiency).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RecordId: ").Append(RecordId).Append("\n");
            sb.Append("  Runs: ").Append(Runs).Append("\n");
            sb.Append("  TimeEfficiency: ").Append(TimeEfficiency).Append("\n");
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
            return this.Equals(input as GetContractsPublicItemsContractId200Ok);
        }

        /// <summary>
        /// Returns true if GetContractsPublicItemsContractId200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetContractsPublicItemsContractId200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetContractsPublicItemsContractId200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.IsBlueprintCopy == input.IsBlueprintCopy ||
                    (this.IsBlueprintCopy != null &&
                    this.IsBlueprintCopy.Equals(input.IsBlueprintCopy))
                ) && 
                (
                    this.IsIncluded == input.IsIncluded ||
                    (this.IsIncluded != null &&
                    this.IsIncluded.Equals(input.IsIncluded))
                ) && 
                (
                    this.ItemId == input.ItemId ||
                    (this.ItemId != null &&
                    this.ItemId.Equals(input.ItemId))
                ) && 
                (
                    this.MaterialEfficiency == input.MaterialEfficiency ||
                    (this.MaterialEfficiency != null &&
                    this.MaterialEfficiency.Equals(input.MaterialEfficiency))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.RecordId == input.RecordId ||
                    (this.RecordId != null &&
                    this.RecordId.Equals(input.RecordId))
                ) && 
                (
                    this.Runs == input.Runs ||
                    (this.Runs != null &&
                    this.Runs.Equals(input.Runs))
                ) && 
                (
                    this.TimeEfficiency == input.TimeEfficiency ||
                    (this.TimeEfficiency != null &&
                    this.TimeEfficiency.Equals(input.TimeEfficiency))
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
                if (this.IsBlueprintCopy != null)
                    hashCode = hashCode * 59 + this.IsBlueprintCopy.GetHashCode();
                if (this.IsIncluded != null)
                    hashCode = hashCode * 59 + this.IsIncluded.GetHashCode();
                if (this.ItemId != null)
                    hashCode = hashCode * 59 + this.ItemId.GetHashCode();
                if (this.MaterialEfficiency != null)
                    hashCode = hashCode * 59 + this.MaterialEfficiency.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.RecordId != null)
                    hashCode = hashCode * 59 + this.RecordId.GetHashCode();
                if (this.Runs != null)
                    hashCode = hashCode * 59 + this.Runs.GetHashCode();
                if (this.TimeEfficiency != null)
                    hashCode = hashCode * 59 + this.TimeEfficiency.GetHashCode();
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
            // MaterialEfficiency (int?) maximum
            if(this.MaterialEfficiency > (int?)25)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaterialEfficiency, must be a value less than or equal to 25.", new [] { "MaterialEfficiency" });
            }

            // MaterialEfficiency (int?) minimum
            if(this.MaterialEfficiency < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaterialEfficiency, must be a value greater than or equal to 0.", new [] { "MaterialEfficiency" });
            }

            // Runs (int?) minimum
            if(this.Runs < (int?)-1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Runs, must be a value greater than or equal to -1.", new [] { "Runs" });
            }

            // TimeEfficiency (int?) maximum
            if(this.TimeEfficiency > (int?)20)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TimeEfficiency, must be a value less than or equal to 20.", new [] { "TimeEfficiency" });
            }

            // TimeEfficiency (int?) minimum
            if(this.TimeEfficiency < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TimeEfficiency, must be a value greater than or equal to 0.", new [] { "TimeEfficiency" });
            }

            yield break;
        }
    }

}