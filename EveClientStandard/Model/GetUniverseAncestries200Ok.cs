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
    public partial class GetUniverseAncestries200Ok :  IEquatable<GetUniverseAncestries200Ok>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseAncestries200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetUniverseAncestries200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseAncestries200Ok" /> class.
        /// </summary>
        /// <param name="BloodlineId">The bloodline associated with this ancestry (required).</param>
        /// <param name="Description">description string (required).</param>
        /// <param name="IconId">icon_id integer.</param>
        /// <param name="Id">id integer (required).</param>
        /// <param name="Name">name string (required).</param>
        /// <param name="ShortDescription">short_description string.</param>
        public GetUniverseAncestries200Ok(int? BloodlineId = default(int?), string Description = default(string), int? IconId = default(int?), int? Id = default(int?), string Name = default(string), string ShortDescription = default(string))
        {
            // to ensure "BloodlineId" is required (not null)
            if (BloodlineId == null)
            {
                throw new InvalidDataException("BloodlineId is a required property for GetUniverseAncestries200Ok and cannot be null");
            }
            else
            {
                this.BloodlineId = BloodlineId;
            }
            // to ensure "Description" is required (not null)
            if (Description == null)
            {
                throw new InvalidDataException("Description is a required property for GetUniverseAncestries200Ok and cannot be null");
            }
            else
            {
                this.Description = Description;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for GetUniverseAncestries200Ok and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for GetUniverseAncestries200Ok and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this.IconId = IconId;
            this.ShortDescription = ShortDescription;
        }
        
        /// <summary>
        /// The bloodline associated with this ancestry
        /// </summary>
        /// <value>The bloodline associated with this ancestry</value>
        [DataMember(Name="bloodline_id", EmitDefaultValue=false)]
        public int? BloodlineId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [DataMember(Name="icon_id", EmitDefaultValue=false)]
        public int? IconId { get; set; }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// short_description string
        /// </summary>
        /// <value>short_description string</value>
        [DataMember(Name="short_description", EmitDefaultValue=false)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUniverseAncestries200Ok {\n");
            sb.Append("  BloodlineId: ").Append(BloodlineId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  IconId: ").Append(IconId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
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
            return this.Equals(input as GetUniverseAncestries200Ok);
        }

        /// <summary>
        /// Returns true if GetUniverseAncestries200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetUniverseAncestries200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetUniverseAncestries200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BloodlineId == input.BloodlineId ||
                    (this.BloodlineId != null &&
                    this.BloodlineId.Equals(input.BloodlineId))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.IconId == input.IconId ||
                    (this.IconId != null &&
                    this.IconId.Equals(input.IconId))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ShortDescription == input.ShortDescription ||
                    (this.ShortDescription != null &&
                    this.ShortDescription.Equals(input.ShortDescription))
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
                if (this.BloodlineId != null)
                    hashCode = hashCode * 59 + this.BloodlineId.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.IconId != null)
                    hashCode = hashCode * 59 + this.IconId.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ShortDescription != null)
                    hashCode = hashCode * 59 + this.ShortDescription.GetHashCode();
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
