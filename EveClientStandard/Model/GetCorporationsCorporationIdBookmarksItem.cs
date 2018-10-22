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
    /// Optional object that is returned if a bookmark was made on a particular item.
    /// </summary>
    [DataContract]
    public partial class GetCorporationsCorporationIdBookmarksItem :  IEquatable<GetCorporationsCorporationIdBookmarksItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdBookmarksItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCorporationsCorporationIdBookmarksItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdBookmarksItem" /> class.
        /// </summary>
        /// <param name="ItemId">item_id integer (required).</param>
        /// <param name="TypeId">type_id integer (required).</param>
        public GetCorporationsCorporationIdBookmarksItem(long? ItemId = default(long?), int? TypeId = default(int?))
        {
            // to ensure "ItemId" is required (not null)
            if (ItemId == null)
            {
                throw new InvalidDataException("ItemId is a required property for GetCorporationsCorporationIdBookmarksItem and cannot be null");
            }
            else
            {
                this.ItemId = ItemId;
            }
            // to ensure "TypeId" is required (not null)
            if (TypeId == null)
            {
                throw new InvalidDataException("TypeId is a required property for GetCorporationsCorporationIdBookmarksItem and cannot be null");
            }
            else
            {
                this.TypeId = TypeId;
            }
        }
        
        /// <summary>
        /// item_id integer
        /// </summary>
        /// <value>item_id integer</value>
        [DataMember(Name="item_id", EmitDefaultValue=false)]
        public long? ItemId { get; set; }

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
            sb.Append("class GetCorporationsCorporationIdBookmarksItem {\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
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
            return this.Equals(input as GetCorporationsCorporationIdBookmarksItem);
        }

        /// <summary>
        /// Returns true if GetCorporationsCorporationIdBookmarksItem instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCorporationsCorporationIdBookmarksItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCorporationsCorporationIdBookmarksItem input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ItemId == input.ItemId ||
                    (this.ItemId != null &&
                    this.ItemId.Equals(input.ItemId))
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
                if (this.ItemId != null)
                    hashCode = hashCode * 59 + this.ItemId.GetHashCode();
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
