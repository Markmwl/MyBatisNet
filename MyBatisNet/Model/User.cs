using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisNet.Model
{
    public class User
    {
        //VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL
        public string VC_ID { get; set; }
        public string VC_USERNAME { get; set; }
        public string VC_USERPASS { get; set; }
        public string VC_DEPNAME { get; set; }
        public string VC_ISADMIN { get; set; }
        public string VC_CID { get; set; }
        public DateTime D_CDATE { get; set; }
        public string VC_MID { get; set; }
        public DateTime D_MDATE { get; set; }
        public string VC_ISDEL { get; set; }

        public User() { }

        
    }
}
