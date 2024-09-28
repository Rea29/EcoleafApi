using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.AuditTrail
{
	public class AuditTrailGVM
	{
		public int LineId { get; set; }
		public string ModuleName { get; set; }
		public string AppEvent { get; set; }
		public string Description { get; set; }
		public string? IpAddress { get; set; }
		public string? DeviceName { get; set; }
		public bool? IsActive { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string? UpdatedBy { get; set; } = string.Empty;
		public DateTime? UpdatedAt { get; set; }
	}
}
