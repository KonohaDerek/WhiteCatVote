using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WhiteCatVote.Model;

namespace WhiteCatVote
{
    public partial class Form1 : Form
    {
        private const string voteName = "Hachi ハチ X 梅亞";

        private  string uid = "";
        private CookieContainer cookie = null;
        private List<FBUser> fbList = null;
        private Random random = new Random();
        private string some_str = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //將要取得HTML原如碼的網頁放在WebRequest.Create(@”網址” )
            cookie = new CookieContainer();
            List<UserData> users = new List<UserData>();
            users = ReadNowUserVoteInfo();
            var query = (from user in users
                        orderby user.votes_count descending
                        select user).Take(5).Where(o=>o.name == voteName).ToList();
            //取得隨機FB使用者
            try
            {
                fbList = RandomUtil.GernerateFbUserList(tbFbId.Text);
            }
            catch (Exception ex) {
                tbResult.Text += string.Format("FB授權已過期，請重新更新\r\n");
                return;
            }
            if(!bgVote.IsBusy)
             bgVote.RunWorkerAsync();
            //if (query == null || query.Count() <= 0)
            //{
            //    var voteNameData = (from user in users
            //                        where user.name == voteName
            //                        select user).FirstOrDefault();
            //    //執行投票
            //    tbResult.Text += string.Format("{0} 掉出五名之外啦!!!!!!目前票數為{1}\r\n 開始執行補票作業!!!!\r\n", voteName, voteNameData.votes_count);
            //}
            //else {
                query = (from user in users
                         orderby user.votes_count descending
                         select user).Take(5).ToList();
                for (int i = 0; i < query.Count(); i++)
                {
                    tbResult.Text += string.Format("第{0}名 : {1}({2}) , 票數為 : {3}!!!\r\n\r\n", i+1,query[i].name, query[i].id, query[i].votes_count);
                }
            //}
        }


        private void Vote(string some_str ,int vote_id,int contest_id, int ticket , int delay ) {
        
            SetCookies();
            var fuckcache = RandomUtil.GerneratePwd(8);
            var user = fbList[random.Next(0, fbList.Count-1)];
            if (tbResult.InvokeRequired)
            {
                tbResult.Invoke((MethodInvoker)delegate { tbResult.Text += string.Format("使用者 :{0} , FB_id :{1} 開始投票 \r\n", user.name, user.uid); });
            }
            else
            {
                tbResult.Text += string.Format("使用者 :{0} , FB_id :{1} 開始投票 \r\n", user.name, user.uid);
            }
        
            var fv_is_subscribed_Request = new fv_is_subscribed_Request()
            {
                contest_id = contest_id,
                fuckcache = fuckcache,
                uid = uid
            };
            var result_fv_is_subscribed = PostToAPI("http://sonetcosacghk2016.com/wp-admin/admin-ajax.php?action=fv_is_subscribed", fv_is_subscribed_Request.ToRequestString());

            if (tbResult.InvokeRequired)
            {
                tbResult.Invoke((MethodInvoker)delegate { tbResult.Text += string.Format("result_fv_is_subscribed : {0}\r\n", result_fv_is_subscribed); });
            }
            else
            {
                tbResult.Text += string.Format("result_fv_is_subscribed : {0}\r\n", result_fv_is_subscribed);
            }


            var fv_soc_login_Request = new fv_soc_login_Request()
            {
                email = user.email,
                soc_name = user.name,
                fuckcache = fuckcache,
                some_str = some_str,
                soc_profile = "https://www.facebook.com/app_scoped_user_id/"+ user.uid,
                soc_uid = user.uid
            };

            var result_fv_soc_login = PostToAPI("http://sonetcosacghk2016.com/wp-admin/admin-ajax.php?action=fv_soc_login", fv_soc_login_Request.ToRequestString());

            if (tbResult.InvokeRequired)
            {
                tbResult.Invoke((MethodInvoker)delegate { tbResult.Text += string.Format("result_fv_soc_login : {0}\r\n", result_fv_soc_login); });
            }
            else
            {
                tbResult.Text += string.Format("result_fv_soc_login : {0}\r\n", result_fv_soc_login);
            }



            var vote_Request = new vote_Request()
            {
                contest_id = contest_id,
                fuckcache = fuckcache,
                some_str = some_str,
                uid = uid,
                vote_id = vote_id,
                game_id = user.name,
                inv_code = RandomUtil.GernerateNumber(9)
            };


            var result_vote = PostToAPI("http://sonetcosacghk2016.com/wp-admin/admin-ajax.php", vote_Request.ToRequestString());


            if (tbResult.InvokeRequired)
            {
                tbResult.Invoke((MethodInvoker)delegate { tbResult.Text += string.Format("result_vote : {0}\r\n", result_vote); });
            }
            else
            {
                tbResult.Text += string.Format("result_vote : {0}\r\n", result_vote);
            }



            if (tbResult.InvokeRequired)
            {
                tbResult.Invoke((MethodInvoker)delegate { tbResult.Text += string.Format("使用者 :{0} , FB_id :{1} 投票完成 \r\n", user.name, user.uid); });
            }
            else
            {
                tbResult.Text += string.Format("使用者 :{0} , FB_id :{1} 投票完成 \r\n", user.name, user.uid);
            }

        }

        private string Get_fv_uid()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(@"http://sonetcosacghk2016.com/wp-content/plugins/wp-foto-vote/assets/evercookie/php/evercookie_etag.php?name=fv_uid");

            //Method選擇GET
            myRequest.Method = "GET";

            //取得WebRequest的回覆
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            //Streamreader讀取回覆
            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            //將全文轉成string
            string result = sr.ReadToEnd();

            //關掉StreamReader
            sr.Close();

            //關掉WebResponse
            myResponse.Close();
            return result; 
        }

        private string PostToAPI(string url , string PostData) {
            //Post資料到Web
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; zh-TW; rv:1.9.1.2) "
                             + "Gecko/20090729 Firefox/3.5.2 GTB5 (.NET CLR 3.5.30729)";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            request.Headers.Set("Accept-Language",
                "zh-tw,en-us;q=0.7,en;q=0.3");
            request.Headers.Set("Accept-Charse",
                "Big5,utf-8;q=0.7,*;q=0.7");
            //設定referer
             request.Referer = "http://sonetcosacghk2016.com/";
            //設定Cookie,Session
            request.CookieContainer = cookie;

            //將要傳遞的資料PostData轉成Byte陣列並寫入request
            byte[] byWordWriteroPost = Encoding.UTF8.GetBytes(PostData);
            request.ContentLength = byWordWriteroPost.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(byWordWriteroPost, 0, byWordWriteroPost.Length);
            stream.Close();

            //取得網頁結果
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string returnString = reader.ReadToEnd();
            response.Close();
            return returnString;

        }

        private void SetCookies() {
            cookie = new CookieContainer();
            uid = RandomUtil.GerneratePwd(8);
            Cookie ck_fv_uid = new Cookie("fv_uid", uid);
            ck_fv_uid.Domain = "sonetcosacghk2016.com";
            cookie.Add(ck_fv_uid);
            Cookie ck_vote_post_2 = new Cookie("vote_post_2","1469663940");
            ck_vote_post_2.Domain = "sonetcosacghk2016.com";
            cookie.Add(ck_vote_post_2);
            Cookie ck_user_country = new Cookie("user_country", "Taiwan");
            ck_user_country.Domain = "sonetcosacghk2016.com";
            cookie.Add(ck_user_country);

            Cookie ck_evercookie_cache = new Cookie("evercookie_cache", "uid");
            ck_evercookie_cache.Domain = "sonetcosacghk2016.com"; 
            cookie.Add(ck_evercookie_cache);

            Cookie ck_evercookie_etag = new Cookie("evercookie_etag", "uid");
            ck_evercookie_etag.Domain = "sonetcosacghk2016.com";
            cookie.Add(ck_evercookie_etag);

            Cookie ck_evercookie_png = new Cookie("evercookie_png", "uid");
            ck_evercookie_png.Domain = "sonetcosacghk2016.com";
            cookie.Add(ck_evercookie_png);

        }


        private List<UserData> ReadNowUserVoteInfo() {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(@"http://sonetcosacghk2016.com/");
            //Method選擇GET
            myRequest.Method = "GET";
            //取得WebRequest的回覆
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //Streamreader讀取回覆
            StreamReader sr = new StreamReader(myResponse.GetResponseStream());
            //將全文轉成string
            string result = sr.ReadToEnd();
            //關掉StreamReader
            sr.Close();
            //關掉WebResponse
            myResponse.Close();
            var start = result.LastIndexOf("/* <![CDATA[ */");
            var end = result.LastIndexOf("/* ]]> */");
            string HTMLCut = result.Substring(start, end - start).Replace("/* <![CDATA[ */", "").Replace("var fv = ", "").Replace(";", "").Replace("\n", "");
            IndexPageModel data = JsonConvert.DeserializeObject<IndexPageModel>(HTMLCut);
            some_str = data.some_str;

            List<UserData> users = new List<UserData>();
            users = data.data.Select(kvp => kvp.Value).ToList();
            return users;
        }

        private void bgVote_DoWork(object sender, DoWorkEventArgs e)
        {
          
            for (int i = 0; i < nbVote.Value; i++)
            {
                //bgVote.ReportProgress(i);
                Vote(some_str, 1, 1, 0, 0);

                bgVote.ReportProgress(i);
                // 隨機停頓秒數
                // 隨機停頓秒數
                var stop = random.Next(1000, (int)nbdely.Value * 1000);
                System.Threading.Thread.Sleep(stop);
            }
        }

        private void bgVote_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tbResult.Text += string.Format("目前執行完成第{0}筆資料\r\n",e.ProgressPercentage);
        }

        private void bgVote_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
