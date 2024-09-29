using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Users { 
    public class UserTokenDTO
    {
        
        public Int64? LineId { get; set; }
        [Key]
        public Guid? UserUID { get; set; }

        public string? JwtToken { get; set; }
        public bool? Islogin { get; set; }

        public DateTime? ExpiredAt { get; set; }
        public DateTime? IdleAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
