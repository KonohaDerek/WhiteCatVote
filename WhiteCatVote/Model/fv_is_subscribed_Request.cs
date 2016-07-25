using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WhiteCatVote.Model
{
    public class fv_is_subscribed_Request
    {
        public string action { get { return "fv_is_subscribed"; } }

        public int contest_id { get; set; }
        public string uid { get; set; }
        public string fuckcache { get; set; }
        public bool subscribe_hash { get { return false; } }

        public string ToRequestString() {
            StringBuilder postData = new StringBuilder();
            postData.Append("action=" + HttpUtility.UrlEncode(action) + "&");
            postData.Append("contest_id=" + contest_id + "&");
            postData.Append("uid=" + HttpUtility.UrlEncode(uid) + "&");
            postData.Append("fuckcache=" + HttpUtility.UrlEncode(fuckcache));
            postData.Append("subscribe_hash=" + subscribe_hash);
            return postData.ToString();
        }
    }
}
