using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteCatVote.Model
{
    public class IndexPageModel
    {
        public string wp_lang { get; set; }


        public string user_lang { get; set; }

        public int post_id { get; set; }

        public int contest_id { get; set; }

        public string vote_u { get; set; }

        public string paged_url { get; set; }

        public string security_type { get; set; }

        public string ajax_url { get; set; }

        public string some_str { get; set; }

        public string plugin_url { get; set; }

        public string fv_appId { get; set; }

        public Dictionary<string, UserData> data { get; set; }

        public List<UserData> _data { get; set; }
        //public IEnumerable<UserData> data { get; set; }
    }

    public class UserData {
        public int id { get; set; }

        public int contest_id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string social_description { get; set; }

        public string url { get; set; }

        string url_min { get; set; }

        public int image_id { get; set; }

        public int votes_count { get; set; }

        public float votes_average { get; set; }

        public string user_id { get; set; }

        public int ct_id { get; set; }
    }

}
