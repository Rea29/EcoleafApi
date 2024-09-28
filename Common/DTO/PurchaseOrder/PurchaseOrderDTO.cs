using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.PurchaseOrder
{
    public class PurchaseOrderDTO
    {
        [Key]
        public Int64? LineId { get; set; }
        public Guid? PurchaseOrderUID { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string ShipTo { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string UnitPrice { get; set; }
        public string Amount { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
