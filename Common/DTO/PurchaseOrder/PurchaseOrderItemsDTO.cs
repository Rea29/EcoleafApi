using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.PurchaseOrder
{
    public class PurchaseOrderItemsDTO
    {
        [Key]
        public long? LineId { get; set; }
        public Guid? PurchaseOrderItemsUID { get; set; }
        public Guid? PurchaseOrderUID { get; set; }
        public Guid? ItemsUID { get; set; }
        public string ItemsName { get; set; }
        public string ItemsNumber { get; set; }
        public string ItemsDescription { get; set; }
        public string ItemsUnit { get; set; }
        public string UnitPrice { get; set; }
        public string? Amount { get; set; }
        public string Quantity { get; set; }
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
