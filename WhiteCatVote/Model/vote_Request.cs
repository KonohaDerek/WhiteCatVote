using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WhiteCatVote.Model
{
   public  class vote_Request
    {
        public string action { get { return "vote"; } }


        public int contest_id { get; set; }

        public int vote_id { get; set; }
        public int post_id { get { return 2; } }
        public string referer { get { return ""; } }
        public string uid { get; set; }
        public string pp { get { return "1050836738"; } }
        public string fuckcache { get; set; }
        public string some_str { get; set; }
        public string ds { get { return "MTkyMHgxMDgw"; } }
        public string game_id { get; set; }
        public string inv_code { get; set; }

        public string ToRequestString()
        {
            StringBuilder postData = new StringBuilder();
            postData.Append("action=" + HttpUtility.UrlEncode(action) + "&");
            postData.Append("contest_id=" + contest_id + "&");
            postData.Append("vote_id=" + vote_id + "&");
            postData.Append("post_id=" + post_id + "&");
            postData.Append("referer=" + HttpUtility.UrlEncode(referer) + "&");
            postData.Append("uid=" + HttpUtility.UrlEncode(uid) + "&");
            postData.Append("pp=" + HttpUtility.UrlEncode(pp) + "&");
            postData.Append("fuckcache=" + HttpUtility.UrlEncode(fuckcache) + "&");
            postData.Append("some_str=" + HttpUtility.UrlEncode(some_str) + "&");
            postData.Append("ds=" + HttpUtility.UrlEncode(ds) + "&");
            postData.Append("game_id=" + HttpUtility.UrlEncode(game_id) + "&");
            postData.Append("inv_code=" + inv_code);
            return postData.ToString();
        }


    }
}
