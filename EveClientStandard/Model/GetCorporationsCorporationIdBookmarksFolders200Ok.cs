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
    public partial class GetCorporationsCorporationIdBookmarksFolders200Ok :  IEquatable<GetCorporationsCorporationIdBookmarksFolders200Ok>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdBookmarksFolders200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCorporationsCorporationIdBookmarksFolders200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdBookmarksFolders200Ok" /> class.
        /// </summary>
        /// <param name="CreatorId">creator_id integer.</param>
        /// <param name="FolderId">folder_id integer (required).</param>
        /// <param name="Name">name string (required).</param>
        public GetCorporationsCorporationIdBookmarksFolders200Ok(int? CreatorId = default(int?), int? FolderId = default(int?), string Name = default(string))
        {
            // to ensure "FolderId" is required (not null)
            if (FolderId == null)
            {
                throw new InvalidDataException("FolderId is a required property for GetCorporationsCorporationIdBookmarksFolders200Ok and cannot be null");
            }
            else
            {
                this.FolderId = FolderId;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for GetCorporationsCorporationIdBookmarksFolders200Ok and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this.CreatorId = CreatorId;
        }
        
        /// <summary>
        /// creator_id integer
        /// </summary>
        /// <value>creator_id integer</value>
        [DataMember(Name="creator_id", EmitDefaultValue=false)]
        public int? CreatorId { get; set; }

        /// <summary>
        /// folder_id integer
        /// </summary>
        /// <value>folder_id integer</value>
        [DataMember(Name="folder_id", EmitDefaultValue=false)]
        public int? FolderId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCorporationsCorporationIdBookmarksFolders200Ok {\n");
            sb.Append("  CreatorId: ").Append(CreatorId).Append("\n");
            sb.Append("  FolderId: ").Append(FolderId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as GetCorporationsCorporationIdBookmarksFolders200Ok);
        }

        /// <summary>
        /// Returns true if GetCorporationsCorporationIdBookmarksFolders200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCorporationsCorporationIdBookmarksFolders200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCorporationsCorporationIdBookmarksFolders200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CreatorId == input.CreatorId ||
                    (this.CreatorId != null &&
                    this.CreatorId.Equals(input.CreatorId))
                ) && 
                (
                    this.FolderId == input.FolderId ||
                    (this.FolderId != null &&
                    this.FolderId.Equals(input.FolderId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                if (this.CreatorId != null)
                    hashCode = hashCode * 59 + this.CreatorId.GetHashCode();
                if (this.FolderId != null)
                    hashCode = hashCode * 59 + this.FolderId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
