using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PowerToolsInventory
{
    public class PowerToolsInventoryDTO
    {
        [Key]
        public Int64? LineId { get; set; }
        public Guid? PowerToolsInventoryUID { get; set; }
        public string InventoryTypes { get; set; }
        public string ProjectId { get; set; }
        public string ProjectLocation { get; set; }
        public string SerialNumber { get; set; }
        public string CodeNumber { get; set; }
        public string Quantity { get; set; }
        public string DateInventory { get; set; }
        public string ItemLocation { get; set; }
        public string ItemDescription { get; set; }
        public string Remarks { get; set; }
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
