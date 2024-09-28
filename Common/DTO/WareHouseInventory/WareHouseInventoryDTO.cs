using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.WareHouseInventory
{
    public class WareHouseInventoryDTO
    {
        public Int64? LineId { get; set; }
        [Key]
        public Guid? WareHouseInventoryUID { get; set; }
        public string EmployeeFullName { get; set; }
        public string InventoryTypes { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Quantity { get; set; }
        public string DateInventory { get; set; }
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
