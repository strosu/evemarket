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
    /// recipient object
    /// </summary>
    [DataContract]
    public partial class PostCharactersCharacterIdMailRecipient :  IEquatable<PostCharactersCharacterIdMailRecipient>, IValidatableObject
    {
        /// <summary>
        /// recipient_type string
        /// </summary>
        /// <value>recipient_type string</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RecipientTypeEnum
        {
            
            /// <summary>
            /// Enum Alliance for value: alliance
            /// </summary>
            [EnumMember(Value = "alliance")]
            Alliance = 1,
            
            /// <summary>
            /// Enum Character for value: character
            /// </summary>
            [EnumMember(Value = "character")]
            Character = 2,
            
            /// <summary>
            /// Enum Corporation for value: corporation
            /// </summary>
            [EnumMember(Value = "corporation")]
            Corporation = 3,
            
            /// <summary>
            /// Enum Mailinglist for value: mailing_list
            /// </summary>
            [EnumMember(Value = "mailing_list")]
            Mailinglist = 4
        }

        /// <summary>
        /// recipient_type string
        /// </summary>
        /// <value>recipient_type string</value>
        [DataMember(Name="recipient_type", EmitDefaultValue=false)]
        public RecipientTypeEnum RecipientType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PostCharactersCharacterIdMailRecipient" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PostCharactersCharacterIdMailRecipient() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PostCharactersCharacterIdMailRecipient" /> class.
        /// </summary>
        /// <param name="RecipientId">recipient_id integer (required).</param>
        /// <param name="RecipientType">recipient_type string (required).</param>
        public PostCharactersCharacterIdMailRecipient(int? RecipientId = default(int?), RecipientTypeEnum RecipientType = default(RecipientTypeEnum))
        {
            // to ensure "RecipientId" is required (not null)
            if (RecipientId == null)
            {
                throw new InvalidDataException("RecipientId is a required property for PostCharactersCharacterIdMailRecipient and cannot be null");
            }
            else
            {
                this.RecipientId = RecipientId;
            }
            // to ensure "RecipientType" is required (not null)
            if (RecipientType == null)
            {
                throw new InvalidDataException("RecipientType is a required property for PostCharactersCharacterIdMailRecipient and cannot be null");
            }
            else
            {
                this.RecipientType = RecipientType;
            }
        }
        
        /// <summary>
        /// recipient_id integer
        /// </summary>
        /// <value>recipient_id integer</value>
        [DataMember(Name="recipient_id", EmitDefaultValue=false)]
        public int? RecipientId { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PostCharactersCharacterIdMailRecipient {\n");
            sb.Append("  RecipientId: ").Append(RecipientId).Append("\n");
            sb.Append("  RecipientType: ").Append(RecipientType).Append("\n");
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
            return this.Equals(input as PostCharactersCharacterIdMailRecipient);
        }

        /// <summary>
        /// Returns true if PostCharactersCharacterIdMailRecipient instances are equal
        /// </summary>
        /// <param name="input">Instance of PostCharactersCharacterIdMailRecipient to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PostCharactersCharacterIdMailRecipient input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RecipientId == input.RecipientId ||
                    (this.RecipientId != null &&
                    this.RecipientId.Equals(input.RecipientId))
                ) && 
                (
                    this.RecipientType == input.RecipientType ||
                    (this.RecipientType != null &&
                    this.RecipientType.Equals(input.RecipientType))
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
                if (this.RecipientId != null)
                    hashCode = hashCode * 59 + this.RecipientId.GetHashCode();
                if (this.RecipientType != null)
                    hashCode = hashCode * 59 + this.RecipientType.GetHashCode();
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
