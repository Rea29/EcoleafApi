using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Users
{
    public class UserRoleDTO
    {
        public Int64? LineId { get; set; }
        [Key]
        public Guid? UserRoleUID { get; set; }
        public Guid? UserUID { get; set; }

        public string? ViewName { get; set; }
        public string? Access { get; set; }



        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public UserDTO User { get; set; }

    }
}
