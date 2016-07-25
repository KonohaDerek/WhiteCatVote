using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WhiteCatVote.Model;

namespace WhiteCatVote
{
   public class RandomUtil
    {
        private const string CHARS_LETTERS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz-_";
        private static string PASSWORD_CHARS_NUMERIC = "1234567890";
        private static readonly string[] phoneHS = new string[]{ "0905", "0909", "0908", "0906", "0907", "0903", "0918", "0928", "0938", "0928", "0918", "0938" };
        private static readonly string[] emailHS = new string[] { "jack", "mary", "matt", "liu", "angel", "king", "nil", "rose", "yogg", "tony", "link", "clock", "happy", "tank", "akali", "yona", "keren", "miss" };
        private static readonly string[] emailES = new string[] { "gmail.com", "yahoo.com.tw", "hinet.net", "hotmail.com", "engadget.com", "msn.com", "walla.com" };
        private static readonly string[] nameH1 = new string[] { "張", "陳", "李", "葉", "徐", "劉", "林", "馬", "何", "王", "趙", "周", "吳", "鄭", "楊", "許", "金", "黃", "胡", "唐", "朱", "江", "方", "丁", "孫" };
        private static readonly string[] nameH2 = new string[] { "一", "二", "三", "信", "偉", "德", "銘", "秀", "鈺", "中", "思", "恩", "守", "英", "水", "明", "月", "日", "大", "梅", "玉", "章", "景", "平", "佩", "瑜", "詩", "音", "飛", "菲", "安", "娜", "佳", "宏", "龍", "祥", "興", "倉", "山", "皇", "曉", "海", "天", "地", "春", "風", "成" };

        private static readonly string[] maleNames = new string[] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" ,""};
        private static readonly string[] femaleNames = new string[] { "abby", "abigail", "adele", "adrian","Chen" , "Ko","Kao","Ken","Lin","Chung" };
        private static readonly string[] lastNames = new string[] { "abbott", "acosta", "adams", "adkins", "aguilar" , "Carina" };

        /// <summary>
        /// 依類型產生隨機密碼
        /// </summary>
        /// <param name="length"></param>
        /// <param name="pwdType"></param>
        /// <returns></returns>
        public static string GerneratePwd(int length)
        {
            char[][] charGroups = new char[][]
                            {
                                CHARS_LETTERS.ToCharArray()
                            };

            int[] charsLeftInGroup = new int[charGroups.Length];

            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            int[] leftGroupsOrder = new int[charGroups.Length];

            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            byte[] randomBytes = new byte[4];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            int seed = (randomBytes[0] & 0x7f) << 24 |
                        randomBytes[1] << 16 |
                        randomBytes[2] << 8 |
                        randomBytes[3];

            Random random = new Random(seed);

            char[] password = new char[length];
            int nextCharIdx;
            int nextGroupIdx;
            int nextLeftGroupsOrderIdx;
            int lastCharIdx;
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            for (int i = 0; i < length; i++)
            {
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx);

                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                else
                {
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    charsLeftInGroup[nextGroupIdx]--;
                }

                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                else
                {
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    lastLeftGroupsOrderIdx--;
                }
            }
            return new string(password);
        }

        public static string GernerateEmail() {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var e1 = rnd.Next(0, emailHS.Length - 1);
            var email1 = emailHS[e1];
            email1 += rnd.Next(10, 99999).ToString();
            var e2 = rnd.Next(0, emailES.Length - 1);
            var email2 = emailES[e2];

            return email1 + "@" + email2;
        }

        public static string GernerateNumber(int length) {
            char[][] charGroups = new char[][]
                               {
                                PASSWORD_CHARS_NUMERIC.ToCharArray()
                               };

            int[] charsLeftInGroup = new int[charGroups.Length];

            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            int[] leftGroupsOrder = new int[charGroups.Length];

            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            byte[] randomBytes = new byte[4];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            int seed = (randomBytes[0] & 0x7f) << 24 |
                        randomBytes[1] << 16 |
                        randomBytes[2] << 8 |
                        randomBytes[3];

            Random random = new Random(seed);

            char[] password = new char[length];
            int nextCharIdx;
            int nextGroupIdx;
            int nextLeftGroupsOrderIdx;
            int lastCharIdx;
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            for (int i = 0; i < length; i++)
            {
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx);

                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                else
                {
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    charsLeftInGroup[nextGroupIdx]--;
                }

                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                else
                {
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    lastLeftGroupsOrderIdx--;
                }
            }
            return new string(password);

        }

        private static string GernerateChinessName() {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var user_name = string.Empty;
            var user_info = string.Empty;

            // 隨機人名
            var n1 = rnd.Next(0, nameH1.Length - 1);
            var name1 = nameH1[n1];
            var n2 = rnd.Next(0, nameH2.Length - 1);
            var name2 = nameH2[n2];
            var n3 = rnd.Next(-1, nameH2.Length - 1);
            if (n3 > 0) name2 += nameH2[n3];

            user_name = name1 + name2;
            return user_name;
        }


        public static List<FBUser> GernerateFbUserList(string FID) {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(FID);
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
            var json = JsonConvert.DeserializeObject<JObject>(result);
            var list = JsonConvert.DeserializeObject<List<FBUser>>(
                        JsonConvert.DeserializeObject < JObject > (JsonConvert.DeserializeObject < JArray >( json.GetValue("data").ToString()).ToList()[1].ToString()).GetValue("fql_result_set").ToString()).ToList();
            return list;
        }


    }
}
