using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HttpService
    {
        /// <summary>
        /// 后台跨域请求发送代码
        /// </summary> 
        /// <param name="url">eg:http://ac.guojin.org/jeesite/regist/saveAppAgentAccount </param>
        ///<param name="postData"></param>
        ///  参数格式（手拼Json） string postData = "{\"name\":\"" + vip.comName + "\",\"shortName\":\"" + vip.shortName + + "\"}";             
        /// <returns></returns>
        public static string PostData(string postData, string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);//后台请求页面
            Encoding encoding = Encoding.GetEncoding("utf-8");//注意页面的编码，否则会出现乱码
            byte[] requestBytes = encoding.GetBytes(postData);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = requestBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));
            string backstr = sr.ReadToEnd();//可以读取到从页面返回的结果，以数据流的形式。
            sr.Close();
            res.Close();

            return backstr;
        }
    }
}
