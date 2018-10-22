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
    public partial class GetUniverseSchematicsSchematicIdOk :  IEquatable<GetUniverseSchematicsSchematicIdOk>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseSchematicsSchematicIdOk" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetUniverseSchematicsSchematicIdOk() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUniverseSchematicsSchematicIdOk" /> class.
        /// </summary>
        /// <param name="CycleTime">Time in seconds to process a run (required).</param>
        /// <param name="SchematicName">schematic_name string (required).</param>
        public GetUniverseSchematicsSchematicIdOk(int? CycleTime = default(int?), string SchematicName = default(string))
        {
            // to ensure "CycleTime" is required (not null)
            if (CycleTime == null)
            {
                throw new InvalidDataException("CycleTime is a required property for GetUniverseSchematicsSchematicIdOk and cannot be null");
            }
            else
            {
                this.CycleTime = CycleTime;
            }
            // to ensure "SchematicName" is required (not null)
            if (SchematicName == null)
            {
                throw new InvalidDataException("SchematicName is a required property for GetUniverseSchematicsSchematicIdOk and cannot be null");
            }
            else
            {
                this.SchematicName = SchematicName;
            }
        }
        
        /// <summary>
        /// Time in seconds to process a run
        /// </summary>
        /// <value>Time in seconds to process a run</value>
        [DataMember(Name="cycle_time", EmitDefaultValue=false)]
        public int? CycleTime { get; set; }

        /// <summary>
        /// schematic_name string
        /// </summary>
        /// <value>schematic_name string</value>
        [DataMember(Name="schematic_name", EmitDefaultValue=false)]
        public string SchematicName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUniverseSchematicsSchematicIdOk {\n");
            sb.Append("  CycleTime: ").Append(CycleTime).Append("\n");
            sb.Append("  SchematicName: ").Append(SchematicName).Append("\n");
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
            return this.Equals(input as GetUniverseSchematicsSchematicIdOk);
        }

        /// <summary>
        /// Returns true if GetUniverseSchematicsSchematicIdOk instances are equal
        /// </summary>
        /// <param name="input">Instance of GetUniverseSchematicsSchematicIdOk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetUniverseSchematicsSchematicIdOk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CycleTime == input.CycleTime ||
                    (this.CycleTime != null &&
                    this.CycleTime.Equals(input.CycleTime))
                ) && 
                (
                    this.SchematicName == input.SchematicName ||
                    (this.SchematicName != null &&
                    this.SchematicName.Equals(input.SchematicName))
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
                if (this.CycleTime != null)
                    hashCode = hashCode * 59 + this.CycleTime.GetHashCode();
                if (this.SchematicName != null)
                    hashCode = hashCode * 59 + this.SchematicName.GetHashCode();
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
