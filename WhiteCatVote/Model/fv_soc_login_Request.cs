using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WhiteCatVote.Model
{
    public class fv_soc_login_Request
    {
        public string action { get { return "fv_soc_login"; } }


        public int contest_id { get { return 1; } }

        public string fuckcache { get; set; }

        public string some_str { get; set; }

        public string email { get; set; }

        public string soc_name { get; set; }

        public string soc_profile { get; set; }

        public string soc_network { get { return "facebook"; } }

        public string soc_uid { get; set; }


        public string ToRequestString()
        {
            StringBuilder postData = new StringBuilder();
            postData.Append("action=" + HttpUtility.UrlEncode(action) + "&");
            postData.Append("contest_id=" + contest_id + "&");
            postData.Append("fuckcache=" + HttpUtility.UrlEncode(fuckcache) + "&");
            postData.Append("some_str=" + some_str + "&");
            postData.Append("email=" + email + "&");
            postData.Append("soc_name=" + soc_name + "&");
            postData.Append("soc_profile=" + soc_profile + "&");
            postData.Append("soc_network=" + soc_network + "&");
            postData.Append("soc_uid=" + soc_uid);
            return postData.ToString();
        }

    }
}
