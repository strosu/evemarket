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
    public partial class GetCharactersCharacterIdMailMailIdOk :  IEquatable<GetCharactersCharacterIdMailMailIdOk>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdMailMailIdOk" /> class.
        /// </summary>
        /// <param name="Body">Mail&#39;s body.</param>
        /// <param name="From">From whom the mail was sent.</param>
        /// <param name="Labels">Labels attached to the mail.</param>
        /// <param name="Read">Whether the mail is flagged as read.</param>
        /// <param name="Recipients">Recipients of the mail.</param>
        /// <param name="Subject">Mail subject.</param>
        /// <param name="Timestamp">When the mail was sent.</param>
        public GetCharactersCharacterIdMailMailIdOk(string Body = default(string), int? From = default(int?), List<int?> Labels = default(List<int?>), bool? Read = default(bool?), List<GetCharactersCharacterIdMailMailIdRecipient> Recipients = default(List<GetCharactersCharacterIdMailMailIdRecipient>), string Subject = default(string), DateTime? Timestamp = default(DateTime?))
        {
            this.Body = Body;
            this.From = From;
            this.Labels = Labels;
            this.Read = Read;
            this.Recipients = Recipients;
            this.Subject = Subject;
            this.Timestamp = Timestamp;
        }
        
        /// <summary>
        /// Mail&#39;s body
        /// </summary>
        /// <value>Mail&#39;s body</value>
        [DataMember(Name="body", EmitDefaultValue=false)]
        public string Body { get; set; }

        /// <summary>
        /// From whom the mail was sent
        /// </summary>
        /// <value>From whom the mail was sent</value>
        [DataMember(Name="from", EmitDefaultValue=false)]
        public int? From { get; set; }

        /// <summary>
        /// Labels attached to the mail
        /// </summary>
        /// <value>Labels attached to the mail</value>
        [DataMember(Name="labels", EmitDefaultValue=false)]
        public List<int?> Labels { get; set; }

        /// <summary>
        /// Whether the mail is flagged as read
        /// </summary>
        /// <value>Whether the mail is flagged as read</value>
        [DataMember(Name="read", EmitDefaultValue=false)]
        public bool? Read { get; set; }

        /// <summary>
        /// Recipients of the mail
        /// </summary>
        /// <value>Recipients of the mail</value>
        [DataMember(Name="recipients", EmitDefaultValue=false)]
        public List<GetCharactersCharacterIdMailMailIdRecipient> Recipients { get; set; }

        /// <summary>
        /// Mail subject
        /// </summary>
        /// <value>Mail subject</value>
        [DataMember(Name="subject", EmitDefaultValue=false)]
        public string Subject { get; set; }

        /// <summary>
        /// When the mail was sent
        /// </summary>
        /// <value>When the mail was sent</value>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdMailMailIdOk {\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Labels: ").Append(Labels).Append("\n");
            sb.Append("  Read: ").Append(Read).Append("\n");
            sb.Append("  Recipients: ").Append(Recipients).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdMailMailIdOk);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdMailMailIdOk instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdMailMailIdOk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdMailMailIdOk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Body == input.Body ||
                    (this.Body != null &&
                    this.Body.Equals(input.Body))
                ) && 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.Labels == input.Labels ||
                    this.Labels != null &&
                    this.Labels.SequenceEqual(input.Labels)
                ) && 
                (
                    this.Read == input.Read ||
                    (this.Read != null &&
                    this.Read.Equals(input.Read))
                ) && 
                (
                    this.Recipients == input.Recipients ||
                    this.Recipients != null &&
                    this.Recipients.SequenceEqual(input.Recipients)
                ) && 
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
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
                if (this.Body != null)
                    hashCode = hashCode * 59 + this.Body.GetHashCode();
                if (this.From != null)
                    hashCode = hashCode * 59 + this.From.GetHashCode();
                if (this.Labels != null)
                    hashCode = hashCode * 59 + this.Labels.GetHashCode();
                if (this.Read != null)
                    hashCode = hashCode * 59 + this.Read.GetHashCode();
                if (this.Recipients != null)
                    hashCode = hashCode * 59 + this.Recipients.GetHashCode();
                if (this.Subject != null)
                    hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
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
