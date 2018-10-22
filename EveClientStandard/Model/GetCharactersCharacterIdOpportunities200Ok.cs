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
    public partial class GetCharactersCharacterIdOpportunities200Ok :  IEquatable<GetCharactersCharacterIdOpportunities200Ok>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdOpportunities200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCharactersCharacterIdOpportunities200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdOpportunities200Ok" /> class.
        /// </summary>
        /// <param name="CompletedAt">completed_at string (required).</param>
        /// <param name="TaskId">task_id integer (required).</param>
        public GetCharactersCharacterIdOpportunities200Ok(DateTime? CompletedAt = default(DateTime?), int? TaskId = default(int?))
        {
            // to ensure "CompletedAt" is required (not null)
            if (CompletedAt == null)
            {
                throw new InvalidDataException("CompletedAt is a required property for GetCharactersCharacterIdOpportunities200Ok and cannot be null");
            }
            else
            {
                this.CompletedAt = CompletedAt;
            }
            // to ensure "TaskId" is required (not null)
            if (TaskId == null)
            {
                throw new InvalidDataException("TaskId is a required property for GetCharactersCharacterIdOpportunities200Ok and cannot be null");
            }
            else
            {
                this.TaskId = TaskId;
            }
        }
        
        /// <summary>
        /// completed_at string
        /// </summary>
        /// <value>completed_at string</value>
        [DataMember(Name="completed_at", EmitDefaultValue=false)]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// task_id integer
        /// </summary>
        /// <value>task_id integer</value>
        [DataMember(Name="task_id", EmitDefaultValue=false)]
        public int? TaskId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdOpportunities200Ok {\n");
            sb.Append("  CompletedAt: ").Append(CompletedAt).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdOpportunities200Ok);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdOpportunities200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdOpportunities200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdOpportunities200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CompletedAt == input.CompletedAt ||
                    (this.CompletedAt != null &&
                    this.CompletedAt.Equals(input.CompletedAt))
                ) && 
                (
                    this.TaskId == input.TaskId ||
                    (this.TaskId != null &&
                    this.TaskId.Equals(input.TaskId))
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
                if (this.CompletedAt != null)
                    hashCode = hashCode * 59 + this.CompletedAt.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
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
