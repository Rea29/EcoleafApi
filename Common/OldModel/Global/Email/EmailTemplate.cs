using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Email
{
    public class EmailTemplate
    {
        public int EmailTemplateId { get; set; }
        public string? EmailSubject { get; set;}
        public string? EmailBody { get; set; }
        public string? EmailScript { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? EmailTo { get; set; }

    }
}
