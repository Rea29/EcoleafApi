using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.AccountingManagementSystem
{
    public class AccountingManagementSystemDTO
    {

       
        public long?  LineId { get; set; }
        [Key]
        public Guid? AccountingManagementSystemUID { get; set; }
        public string ProjectCodeID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ContractAmount { get; set; }
        public string TotalContractAmount { get; set; }
        public string PurchaseOrderDate { get; set; }
        public string ProjectStartDate { get; set; }
        public string SalesInvoice { get; set; }
        public string Downpayment { get; set; }
        public string BillingAmount { get; set; }
        public string AmountReceived { get; set; }
        public string DateCheckedReceived { get; set; }
        public string BillingStatement { get; set; }
        public string ProgressBilling { get; set; }
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
