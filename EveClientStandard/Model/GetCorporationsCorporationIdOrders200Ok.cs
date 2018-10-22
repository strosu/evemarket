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
    public partial class GetCorporationsCorporationIdOrders200Ok :  IEquatable<GetCorporationsCorporationIdOrders200Ok>, IValidatableObject
    {
        /// <summary>
        /// Valid order range, numbers are ranges in jumps
        /// </summary>
        /// <value>Valid order range, numbers are ranges in jumps</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RangeEnum
        {
            
            /// <summary>
            /// Enum _1 for value: 1
            /// </summary>
            [EnumMember(Value = "1")]
            _1 = 1,
            
            /// <summary>
            /// Enum _10 for value: 10
            /// </summary>
            [EnumMember(Value = "10")]
            _10 = 2,
            
            /// <summary>
            /// Enum _2 for value: 2
            /// </summary>
            [EnumMember(Value = "2")]
            _2 = 3,
            
            /// <summary>
            /// Enum _20 for value: 20
            /// </summary>
            [EnumMember(Value = "20")]
            _20 = 4,
            
            /// <summary>
            /// Enum _3 for value: 3
            /// </summary>
            [EnumMember(Value = "3")]
            _3 = 5,
            
            /// <summary>
            /// Enum _30 for value: 30
            /// </summary>
            [EnumMember(Value = "30")]
            _30 = 6,
            
            /// <summary>
            /// Enum _4 for value: 4
            /// </summary>
            [EnumMember(Value = "4")]
            _4 = 7,
            
            /// <summary>
            /// Enum _40 for value: 40
            /// </summary>
            [EnumMember(Value = "40")]
            _40 = 8,
            
            /// <summary>
            /// Enum _5 for value: 5
            /// </summary>
            [EnumMember(Value = "5")]
            _5 = 9,
            
            /// <summary>
            /// Enum Region for value: region
            /// </summary>
            [EnumMember(Value = "region")]
            Region = 10,
            
            /// <summary>
            /// Enum Solarsystem for value: solarsystem
            /// </summary>
            [EnumMember(Value = "solarsystem")]
            Solarsystem = 11,
            
            /// <summary>
            /// Enum Station for value: station
            /// </summary>
            [EnumMember(Value = "station")]
            Station = 12
        }

        /// <summary>
        /// Valid order range, numbers are ranges in jumps
        /// </summary>
        /// <value>Valid order range, numbers are ranges in jumps</value>
        [DataMember(Name="range", EmitDefaultValue=false)]
        public RangeEnum Range { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdOrders200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCorporationsCorporationIdOrders200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdOrders200Ok" /> class.
        /// </summary>
        /// <param name="Duration">Number of days for which order is valid (starting from the issued date). An order expires at time issued + duration (required).</param>
        /// <param name="Escrow">For buy orders, the amount of ISK in escrow.</param>
        /// <param name="IsBuyOrder">True if the order is a bid (buy) order.</param>
        /// <param name="Issued">Date and time when this order was issued (required).</param>
        /// <param name="IssuedBy">The character who issued this order (required).</param>
        /// <param name="LocationId">ID of the location where order was placed (required).</param>
        /// <param name="MinVolume">For buy orders, the minimum quantity that will be accepted in a matching sell order.</param>
        /// <param name="OrderId">Unique order ID (required).</param>
        /// <param name="Price">Cost per unit for this order (required).</param>
        /// <param name="Range">Valid order range, numbers are ranges in jumps (required).</param>
        /// <param name="RegionId">ID of the region where order was placed (required).</param>
        /// <param name="TypeId">The type ID of the item transacted in this order (required).</param>
        /// <param name="VolumeRemain">Quantity of items still required or offered (required).</param>
        /// <param name="VolumeTotal">Quantity of items required or offered at time order was placed (required).</param>
        /// <param name="WalletDivision">The corporation wallet division used for this order. (required).</param>
        public GetCorporationsCorporationIdOrders200Ok(int? Duration = default(int?), double? Escrow = default(double?), bool? IsBuyOrder = default(bool?), DateTime? Issued = default(DateTime?), int? IssuedBy = default(int?), long? LocationId = default(long?), int? MinVolume = default(int?), long? OrderId = default(long?), double? Price = default(double?), RangeEnum Range = default(RangeEnum), int? RegionId = default(int?), int? TypeId = default(int?), int? VolumeRemain = default(int?), int? VolumeTotal = default(int?), int? WalletDivision = default(int?))
        {
            // to ensure "Duration" is required (not null)
            if (Duration == null)
            {
                throw new InvalidDataException("Duration is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.Duration = Duration;
            }
            // to ensure "Issued" is required (not null)
            if (Issued == null)
            {
                throw new InvalidDataException("Issued is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.Issued = Issued;
            }
            // to ensure "IssuedBy" is required (not null)
            if (IssuedBy == null)
            {
                throw new InvalidDataException("IssuedBy is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.IssuedBy = IssuedBy;
            }
            // to ensure "LocationId" is required (not null)
            if (LocationId == null)
            {
                throw new InvalidDataException("LocationId is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.LocationId = LocationId;
            }
            // to ensure "OrderId" is required (not null)
            if (OrderId == null)
            {
                throw new InvalidDataException("OrderId is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.OrderId = OrderId;
            }
            // to ensure "Price" is required (not null)
            if (Price == null)
            {
                throw new InvalidDataException("Price is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.Price = Price;
            }
            // to ensure "Range" is required (not null)
            if (Range == null)
            {
                throw new InvalidDataException("Range is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.Range = Range;
            }
            // to ensure "RegionId" is required (not null)
            if (RegionId == null)
            {
                throw new InvalidDataException("RegionId is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.RegionId = RegionId;
            }
            // to ensure "TypeId" is required (not null)
            if (TypeId == null)
            {
                throw new InvalidDataException("TypeId is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.TypeId = TypeId;
            }
            // to ensure "VolumeRemain" is required (not null)
            if (VolumeRemain == null)
            {
                throw new InvalidDataException("VolumeRemain is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.VolumeRemain = VolumeRemain;
            }
            // to ensure "VolumeTotal" is required (not null)
            if (VolumeTotal == null)
            {
                throw new InvalidDataException("VolumeTotal is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.VolumeTotal = VolumeTotal;
            }
            // to ensure "WalletDivision" is required (not null)
            if (WalletDivision == null)
            {
                throw new InvalidDataException("WalletDivision is a required property for GetCorporationsCorporationIdOrders200Ok and cannot be null");
            }
            else
            {
                this.WalletDivision = WalletDivision;
            }
            this.Escrow = Escrow;
            this.IsBuyOrder = IsBuyOrder;
            this.MinVolume = MinVolume;
        }
        
        /// <summary>
        /// Number of days for which order is valid (starting from the issued date). An order expires at time issued + duration
        /// </summary>
        /// <value>Number of days for which order is valid (starting from the issued date). An order expires at time issued + duration</value>
        [DataMember(Name="duration", EmitDefaultValue=false)]
        public int? Duration { get; set; }

        /// <summary>
        /// For buy orders, the amount of ISK in escrow
        /// </summary>
        /// <value>For buy orders, the amount of ISK in escrow</value>
        [DataMember(Name="escrow", EmitDefaultValue=false)]
        public double? Escrow { get; set; }

        /// <summary>
        /// True if the order is a bid (buy) order
        /// </summary>
        /// <value>True if the order is a bid (buy) order</value>
        [DataMember(Name="is_buy_order", EmitDefaultValue=false)]
        public bool? IsBuyOrder { get; set; }

        /// <summary>
        /// Date and time when this order was issued
        /// </summary>
        /// <value>Date and time when this order was issued</value>
        [DataMember(Name="issued", EmitDefaultValue=false)]
        public DateTime? Issued { get; set; }

        /// <summary>
        /// The character who issued this order
        /// </summary>
        /// <value>The character who issued this order</value>
        [DataMember(Name="issued_by", EmitDefaultValue=false)]
        public int? IssuedBy { get; set; }

        /// <summary>
        /// ID of the location where order was placed
        /// </summary>
        /// <value>ID of the location where order was placed</value>
        [DataMember(Name="location_id", EmitDefaultValue=false)]
        public long? LocationId { get; set; }

        /// <summary>
        /// For buy orders, the minimum quantity that will be accepted in a matching sell order
        /// </summary>
        /// <value>For buy orders, the minimum quantity that will be accepted in a matching sell order</value>
        [DataMember(Name="min_volume", EmitDefaultValue=false)]
        public int? MinVolume { get; set; }

        /// <summary>
        /// Unique order ID
        /// </summary>
        /// <value>Unique order ID</value>
        [DataMember(Name="order_id", EmitDefaultValue=false)]
        public long? OrderId { get; set; }

        /// <summary>
        /// Cost per unit for this order
        /// </summary>
        /// <value>Cost per unit for this order</value>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public double? Price { get; set; }


        /// <summary>
        /// ID of the region where order was placed
        /// </summary>
        /// <value>ID of the region where order was placed</value>
        [DataMember(Name="region_id", EmitDefaultValue=false)]
        public int? RegionId { get; set; }

        /// <summary>
        /// The type ID of the item transacted in this order
        /// </summary>
        /// <value>The type ID of the item transacted in this order</value>
        [DataMember(Name="type_id", EmitDefaultValue=false)]
        public int? TypeId { get; set; }

        /// <summary>
        /// Quantity of items still required or offered
        /// </summary>
        /// <value>Quantity of items still required or offered</value>
        [DataMember(Name="volume_remain", EmitDefaultValue=false)]
        public int? VolumeRemain { get; set; }

        /// <summary>
        /// Quantity of items required or offered at time order was placed
        /// </summary>
        /// <value>Quantity of items required or offered at time order was placed</value>
        [DataMember(Name="volume_total", EmitDefaultValue=false)]
        public int? VolumeTotal { get; set; }

        /// <summary>
        /// The corporation wallet division used for this order.
        /// </summary>
        /// <value>The corporation wallet division used for this order.</value>
        [DataMember(Name="wallet_division", EmitDefaultValue=false)]
        public int? WalletDivision { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCorporationsCorporationIdOrders200Ok {\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Escrow: ").Append(Escrow).Append("\n");
            sb.Append("  IsBuyOrder: ").Append(IsBuyOrder).Append("\n");
            sb.Append("  Issued: ").Append(Issued).Append("\n");
            sb.Append("  IssuedBy: ").Append(IssuedBy).Append("\n");
            sb.Append("  LocationId: ").Append(LocationId).Append("\n");
            sb.Append("  MinVolume: ").Append(MinVolume).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Range: ").Append(Range).Append("\n");
            sb.Append("  RegionId: ").Append(RegionId).Append("\n");
            sb.Append("  TypeId: ").Append(TypeId).Append("\n");
            sb.Append("  VolumeRemain: ").Append(VolumeRemain).Append("\n");
            sb.Append("  VolumeTotal: ").Append(VolumeTotal).Append("\n");
            sb.Append("  WalletDivision: ").Append(WalletDivision).Append("\n");
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
            return this.Equals(input as GetCorporationsCorporationIdOrders200Ok);
        }

        /// <summary>
        /// Returns true if GetCorporationsCorporationIdOrders200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCorporationsCorporationIdOrders200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCorporationsCorporationIdOrders200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Duration == input.Duration ||
                    (this.Duration != null &&
                    this.Duration.Equals(input.Duration))
                ) && 
                (
                    this.Escrow == input.Escrow ||
                    (this.Escrow != null &&
                    this.Escrow.Equals(input.Escrow))
                ) && 
                (
                    this.IsBuyOrder == input.IsBuyOrder ||
                    (this.IsBuyOrder != null &&
                    this.IsBuyOrder.Equals(input.IsBuyOrder))
                ) && 
                (
                    this.Issued == input.Issued ||
                    (this.Issued != null &&
                    this.Issued.Equals(input.Issued))
                ) && 
                (
                    this.IssuedBy == input.IssuedBy ||
                    (this.IssuedBy != null &&
                    this.IssuedBy.Equals(input.IssuedBy))
                ) && 
                (
                    this.LocationId == input.LocationId ||
                    (this.LocationId != null &&
                    this.LocationId.Equals(input.LocationId))
                ) && 
                (
                    this.MinVolume == input.MinVolume ||
                    (this.MinVolume != null &&
                    this.MinVolume.Equals(input.MinVolume))
                ) && 
                (
                    this.OrderId == input.OrderId ||
                    (this.OrderId != null &&
                    this.OrderId.Equals(input.OrderId))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Range == input.Range ||
                    (this.Range != null &&
                    this.Range.Equals(input.Range))
                ) && 
                (
                    this.RegionId == input.RegionId ||
                    (this.RegionId != null &&
                    this.RegionId.Equals(input.RegionId))
                ) && 
                (
                    this.TypeId == input.TypeId ||
                    (this.TypeId != null &&
                    this.TypeId.Equals(input.TypeId))
                ) && 
                (
                    this.VolumeRemain == input.VolumeRemain ||
                    (this.VolumeRemain != null &&
                    this.VolumeRemain.Equals(input.VolumeRemain))
                ) && 
                (
                    this.VolumeTotal == input.VolumeTotal ||
                    (this.VolumeTotal != null &&
                    this.VolumeTotal.Equals(input.VolumeTotal))
                ) && 
                (
                    this.WalletDivision == input.WalletDivision ||
                    (this.WalletDivision != null &&
                    this.WalletDivision.Equals(input.WalletDivision))
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
                if (this.Duration != null)
                    hashCode = hashCode * 59 + this.Duration.GetHashCode();
                if (this.Escrow != null)
                    hashCode = hashCode * 59 + this.Escrow.GetHashCode();
                if (this.IsBuyOrder != null)
                    hashCode = hashCode * 59 + this.IsBuyOrder.GetHashCode();
                if (this.Issued != null)
                    hashCode = hashCode * 59 + this.Issued.GetHashCode();
                if (this.IssuedBy != null)
                    hashCode = hashCode * 59 + this.IssuedBy.GetHashCode();
                if (this.LocationId != null)
                    hashCode = hashCode * 59 + this.LocationId.GetHashCode();
                if (this.MinVolume != null)
                    hashCode = hashCode * 59 + this.MinVolume.GetHashCode();
                if (this.OrderId != null)
                    hashCode = hashCode * 59 + this.OrderId.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Range != null)
                    hashCode = hashCode * 59 + this.Range.GetHashCode();
                if (this.RegionId != null)
                    hashCode = hashCode * 59 + this.RegionId.GetHashCode();
                if (this.TypeId != null)
                    hashCode = hashCode * 59 + this.TypeId.GetHashCode();
                if (this.VolumeRemain != null)
                    hashCode = hashCode * 59 + this.VolumeRemain.GetHashCode();
                if (this.VolumeTotal != null)
                    hashCode = hashCode * 59 + this.VolumeTotal.GetHashCode();
                if (this.WalletDivision != null)
                    hashCode = hashCode * 59 + this.WalletDivision.GetHashCode();
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
            // WalletDivision (int?) maximum
            if(this.WalletDivision > (int?)7)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WalletDivision, must be a value less than or equal to 7.", new [] { "WalletDivision" });
            }

            // WalletDivision (int?) minimum
            if(this.WalletDivision < (int?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WalletDivision, must be a value greater than or equal to 1.", new [] { "WalletDivision" });
            }

            yield break;
        }
    }

}
