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
    public partial class GetUniverseFactions200Ok :  IEquatable<GetUniverseFactions200Ok>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseFactions200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetUniverseFactions200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseFactions200Ok" /> class.
        /// </summary>
        /// <param name="CorporationId">corporation_id integer.</param>
        /// <param name="Description">description string (required).</param>
        /// <param name="FactionId">faction_id integer (required).</param>
        /// <param name="IsUnique">is_unique boolean (required).</param>
        /// <param name="MilitiaCorporationId">militia_corporation_id integer.</param>
        /// <param name="Name">name string (required).</param>
        /// <param name="SizeFactor">size_factor number (required).</param>
        /// <param name="SolarSystemId">solar_system_id integer.</param>
        /// <param name="StationCount">station_count integer (required).</param>
        /// <param name="StationSystemCount">station_system_count integer (required).</param>
        public GetUniverseFactions200Ok(int? CorporationId = default(int?), string Description = default(string), int? FactionId = default(int?), bool? IsUnique = default(bool?), int? MilitiaCorporationId = default(int?), string Name = default(string), float? SizeFactor = default(float?), int? SolarSystemId = default(int?), int? StationCount = default(int?), int? StationSystemCount = default(int?))
        {
            // to ensure "Description" is required (not null)
            if (Description == null)
            {
                throw new InvalidDataException("Description is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.Description = Description;
            }
            // to ensure "FactionId" is required (not null)
            if (FactionId == null)
            {
                throw new InvalidDataException("FactionId is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.FactionId = FactionId;
            }
            // to ensure "IsUnique" is required (not null)
            if (IsUnique == null)
            {
                throw new InvalidDataException("IsUnique is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.IsUnique = IsUnique;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            // to ensure "SizeFactor" is required (not null)
            if (SizeFactor == null)
            {
                throw new InvalidDataException("SizeFactor is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.SizeFactor = SizeFactor;
            }
            // to ensure "StationCount" is required (not null)
            if (StationCount == null)
            {
                throw new InvalidDataException("StationCount is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.StationCount = StationCount;
            }
            // to ensure "StationSystemCount" is required (not null)
            if (StationSystemCount == null)
            {
                throw new InvalidDataException("StationSystemCount is a required property for GetUniverseFactions200Ok and cannot be null");
            }
            else
            {
                this.StationSystemCount = StationSystemCount;
            }
            this.CorporationId = CorporationId;
            this.MilitiaCorporationId = MilitiaCorporationId;
            this.SolarSystemId = SolarSystemId;
        }
        
        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [DataMember(Name="corporation_id", EmitDefaultValue=false)]
        public int? CorporationId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [DataMember(Name="faction_id", EmitDefaultValue=false)]
        public int? FactionId { get; set; }

        /// <summary>
        /// is_unique boolean
        /// </summary>
        /// <value>is_unique boolean</value>
        [DataMember(Name="is_unique", EmitDefaultValue=false)]
        public bool? IsUnique { get; set; }

        /// <summary>
        /// militia_corporation_id integer
        /// </summary>
        /// <value>militia_corporation_id integer</value>
        [DataMember(Name="militia_corporation_id", EmitDefaultValue=false)]
        public int? MilitiaCorporationId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// size_factor number
        /// </summary>
        /// <value>size_factor number</value>
        [DataMember(Name="size_factor", EmitDefaultValue=false)]
        public float? SizeFactor { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [DataMember(Name="solar_system_id", EmitDefaultValue=false)]
        public int? SolarSystemId { get; set; }

        /// <summary>
        /// station_count integer
        /// </summary>
        /// <value>station_count integer</value>
        [DataMember(Name="station_count", EmitDefaultValue=false)]
        public int? StationCount { get; set; }

        /// <summary>
        /// station_system_count integer
        /// </summary>
        /// <value>station_system_count integer</value>
        [DataMember(Name="station_system_count", EmitDefaultValue=false)]
        public int? StationSystemCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUniverseFactions200Ok {\n");
            sb.Append("  CorporationId: ").Append(CorporationId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FactionId: ").Append(FactionId).Append("\n");
            sb.Append("  IsUnique: ").Append(IsUnique).Append("\n");
            sb.Append("  MilitiaCorporationId: ").Append(MilitiaCorporationId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SizeFactor: ").Append(SizeFactor).Append("\n");
            sb.Append("  SolarSystemId: ").Append(SolarSystemId).Append("\n");
            sb.Append("  StationCount: ").Append(StationCount).Append("\n");
            sb.Append("  StationSystemCount: ").Append(StationSystemCount).Append("\n");
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
            return this.Equals(input as GetUniverseFactions200Ok);
        }

        /// <summary>
        /// Returns true if GetUniverseFactions200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetUniverseFactions200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetUniverseFactions200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CorporationId == input.CorporationId ||
                    (this.CorporationId != null &&
                    this.CorporationId.Equals(input.CorporationId))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.FactionId == input.FactionId ||
                    (this.FactionId != null &&
                    this.FactionId.Equals(input.FactionId))
                ) && 
                (
                    this.IsUnique == input.IsUnique ||
                    (this.IsUnique != null &&
                    this.IsUnique.Equals(input.IsUnique))
                ) && 
                (
                    this.MilitiaCorporationId == input.MilitiaCorporationId ||
                    (this.MilitiaCorporationId != null &&
                    this.MilitiaCorporationId.Equals(input.MilitiaCorporationId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.SizeFactor == input.SizeFactor ||
                    (this.SizeFactor != null &&
                    this.SizeFactor.Equals(input.SizeFactor))
                ) && 
                (
                    this.SolarSystemId == input.SolarSystemId ||
                    (this.SolarSystemId != null &&
                    this.SolarSystemId.Equals(input.SolarSystemId))
                ) && 
                (
                    this.StationCount == input.StationCount ||
                    (this.StationCount != null &&
                    this.StationCount.Equals(input.StationCount))
                ) && 
                (
                    this.StationSystemCount == input.StationSystemCount ||
                    (this.StationSystemCount != null &&
                    this.StationSystemCount.Equals(input.StationSystemCount))
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
                if (this.CorporationId != null)
                    hashCode = hashCode * 59 + this.CorporationId.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.FactionId != null)
                    hashCode = hashCode * 59 + this.FactionId.GetHashCode();
                if (this.IsUnique != null)
                    hashCode = hashCode * 59 + this.IsUnique.GetHashCode();
                if (this.MilitiaCorporationId != null)
                    hashCode = hashCode * 59 + this.MilitiaCorporationId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.SizeFactor != null)
                    hashCode = hashCode * 59 + this.SizeFactor.GetHashCode();
                if (this.SolarSystemId != null)
                    hashCode = hashCode * 59 + this.SolarSystemId.GetHashCode();
                if (this.StationCount != null)
                    hashCode = hashCode * 59 + this.StationCount.GetHashCode();
                if (this.StationSystemCount != null)
                    hashCode = hashCode * 59 + this.StationSystemCount.GetHashCode();
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
