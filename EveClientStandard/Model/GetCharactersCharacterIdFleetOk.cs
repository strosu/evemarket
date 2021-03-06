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
    public partial class GetCharactersCharacterIdFleetOk :  IEquatable<GetCharactersCharacterIdFleetOk>, IValidatableObject
    {
        /// <summary>
        /// Member’s role in fleet
        /// </summary>
        /// <value>Member’s role in fleet</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RoleEnum
        {
            
            /// <summary>
            /// Enum Fleetcommander for value: fleet_commander
            /// </summary>
            [EnumMember(Value = "fleet_commander")]
            Fleetcommander = 1,
            
            /// <summary>
            /// Enum Squadcommander for value: squad_commander
            /// </summary>
            [EnumMember(Value = "squad_commander")]
            Squadcommander = 2,
            
            /// <summary>
            /// Enum Squadmember for value: squad_member
            /// </summary>
            [EnumMember(Value = "squad_member")]
            Squadmember = 3,
            
            /// <summary>
            /// Enum Wingcommander for value: wing_commander
            /// </summary>
            [EnumMember(Value = "wing_commander")]
            Wingcommander = 4
        }

        /// <summary>
        /// Member’s role in fleet
        /// </summary>
        /// <value>Member’s role in fleet</value>
        [DataMember(Name="role", EmitDefaultValue=false)]
        public RoleEnum Role { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdFleetOk" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCharactersCharacterIdFleetOk() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdFleetOk" /> class.
        /// </summary>
        /// <param name="FleetId">The character&#39;s current fleet ID (required).</param>
        /// <param name="Role">Member’s role in fleet (required).</param>
        /// <param name="SquadId">ID of the squad the member is in. If not applicable, will be set to -1 (required).</param>
        /// <param name="WingId">ID of the wing the member is in. If not applicable, will be set to -1 (required).</param>
        public GetCharactersCharacterIdFleetOk(long? FleetId = default(long?), RoleEnum Role = default(RoleEnum), long? SquadId = default(long?), long? WingId = default(long?))
        {
            // to ensure "FleetId" is required (not null)
            if (FleetId == null)
            {
                throw new InvalidDataException("FleetId is a required property for GetCharactersCharacterIdFleetOk and cannot be null");
            }
            else
            {
                this.FleetId = FleetId;
            }
            // to ensure "Role" is required (not null)
            if (Role == null)
            {
                throw new InvalidDataException("Role is a required property for GetCharactersCharacterIdFleetOk and cannot be null");
            }
            else
            {
                this.Role = Role;
            }
            // to ensure "SquadId" is required (not null)
            if (SquadId == null)
            {
                throw new InvalidDataException("SquadId is a required property for GetCharactersCharacterIdFleetOk and cannot be null");
            }
            else
            {
                this.SquadId = SquadId;
            }
            // to ensure "WingId" is required (not null)
            if (WingId == null)
            {
                throw new InvalidDataException("WingId is a required property for GetCharactersCharacterIdFleetOk and cannot be null");
            }
            else
            {
                this.WingId = WingId;
            }
        }
        
        /// <summary>
        /// The character&#39;s current fleet ID
        /// </summary>
        /// <value>The character&#39;s current fleet ID</value>
        [DataMember(Name="fleet_id", EmitDefaultValue=false)]
        public long? FleetId { get; set; }


        /// <summary>
        /// ID of the squad the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the squad the member is in. If not applicable, will be set to -1</value>
        [DataMember(Name="squad_id", EmitDefaultValue=false)]
        public long? SquadId { get; set; }

        /// <summary>
        /// ID of the wing the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the wing the member is in. If not applicable, will be set to -1</value>
        [DataMember(Name="wing_id", EmitDefaultValue=false)]
        public long? WingId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdFleetOk {\n");
            sb.Append("  FleetId: ").Append(FleetId).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  SquadId: ").Append(SquadId).Append("\n");
            sb.Append("  WingId: ").Append(WingId).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdFleetOk);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdFleetOk instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdFleetOk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdFleetOk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FleetId == input.FleetId ||
                    (this.FleetId != null &&
                    this.FleetId.Equals(input.FleetId))
                ) && 
                (
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
                ) && 
                (
                    this.SquadId == input.SquadId ||
                    (this.SquadId != null &&
                    this.SquadId.Equals(input.SquadId))
                ) && 
                (
                    this.WingId == input.WingId ||
                    (this.WingId != null &&
                    this.WingId.Equals(input.WingId))
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
                if (this.FleetId != null)
                    hashCode = hashCode * 59 + this.FleetId.GetHashCode();
                if (this.Role != null)
                    hashCode = hashCode * 59 + this.Role.GetHashCode();
                if (this.SquadId != null)
                    hashCode = hashCode * 59 + this.SquadId.GetHashCode();
                if (this.WingId != null)
                    hashCode = hashCode * 59 + this.WingId.GetHashCode();
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
