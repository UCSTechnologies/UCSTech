using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFS.Models
{
    public class Audit
    {
        // Audit Properties
        public Guid AuditID { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime DateAccessed { get; set; }

        // Default Constructor
        public Audit() { }
    }
}