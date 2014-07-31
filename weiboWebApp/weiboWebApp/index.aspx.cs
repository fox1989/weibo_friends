using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetDimension.Weibo;
using System.Configuration;
using System.Text;
using System.Collections;

namespace weiboWebApp
{
    public partial class index : System.Web.UI.Page
    {
     static Client Sina=null;
     static Graph graph1, graph2;
       HttpCookie cookie;
        OAuth oauth = new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], ConfigurationManager.AppSettings["CallbackUrl"]);
        protected void Page_Load(object sender, EventArgs e)
        {
           // Sina = new Client(oauth); //用cookie里的accesstoken来实例化OAuth，这样OAuth就有操作权限了
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                //if(Request.QueryString["code"]!=null)
                {
                    var token = oauth.GetAccessTokenByAuthorizationCode(Request.QueryString["code"]);
                    string accessToken = token.Token;
                    cookie = new HttpCookie("AccessToken");
                    Response.Cookies.Add(cookie);
                    cookie.Value = accessToken;
                    Sina = new Client(new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], accessToken, null));
                    string userid = Sina.API.Entity.Account.GetUID();
                    var user = Sina.API.Dynamic.Users.Show(userid);
                  //  Response.Write(user + "<br>");
                   
                    
                }
                else
                {
                    string url = oauth.GetAuthorizeURL();
                    Response.Redirect(url);
                }

            }
            




        }

        protected void Button1_Click(object sender, EventArgs e)
        {

          //  Sina = new Client(new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], cookie.Value, null));
            string strUID = Sina.API.Entity.Account.GetUID();
            Response.Redirect("/dispose.aspx");
          //  var strname = Sina.API.Dynamic.Users.Show(screenName:"福克斯1989");
            //Response.Write(strname.id);
          //  SCGraph("2151740641", "2543945682");
            
            
           // Response.Write(aa.vertexs.IndexOf((object)v));

        }
        public void ShowUserFList(string uid)
        {int co = 1;
            
            Queue GQueue = new Queue();
            Queue FAqueue = new Queue();
            GQueue.Enqueue(uid);
            FAqueue.Enqueue(uid);
            while (GQueue.Count > 0)
            {
                co++;
                

                var json = Sina.API.Dynamic.Friendships.FriendsOnBilateralIDs(GQueue.Dequeue().ToString());

                if (json.IsDefined("ids"))
                {
                    foreach (var id in json.ids)
                    {
                        if (FAqueue.Contains(id))
                        {
                            continue;
                        }
                        FAqueue.Enqueue(id);
                        GQueue.Enqueue(id);
                        Response.Write(id + "<br>");

                    }
                   
                }
 Response.Write("_________________________<br>");
                if (co > 4) break;
            }
        
        }

        public void ShowUserFList(string uid, Graph graph)
        {


            Queue GQueue = new Queue();
            GQueue.Enqueue(uid);
            while (GQueue.Count > 0)
            {
                uid = GQueue.Dequeue().ToString();
                var json = Sina.API.Dynamic.Friendships.FriendsOnBilateralIDs(uid);
                if (json.IsDefined("ids"))
                {
                    foreach (var id in json.ids)
                    {

                        if (graph.Addvertexs(id))
                        {
                            GQueue.Enqueue(id);
                            graph.AddEdge(uid, id);
                        }
                        else
                        {
                            continue;
                        }
                    }

                }

            }

        }

        public void SCGraph(string uid1, string uid2)//找两个人的关系图
        {
            bool IsFinded = false;
            graph1 = new Graph();
            graph2 = new Graph();
            Queue GQueue1 = new Queue();
            Queue GQueue2 = new Queue();
            GQueue1.Enqueue(uid1);
            GQueue2.Enqueue(uid2);
            string uid;
            int count = 0;

            while (true)
            {
                if (count > 6)
                    break;
                count++;
                uid = GQueue1.Dequeue().ToString();
                var json = Sina.API.Dynamic.Friendships.FriendsOnBilateralIDs(uid);
                graph1.Addvertexs(uid);
                if (json.IsDefined("ids"))
                {
                    foreach (var id in json.ids)
                    {

                        if (graph1.Addvertexs(id))
                        {
                            GQueue1.Enqueue(id);
                            graph1.AddEdge(uid, id);
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
                uid = GQueue2.Dequeue().ToString();
                json = Sina.API.Dynamic.Friendships.FriendsOnBilateralIDs(uid);
                graph2.Addvertexs(uid);
                if (json.IsDefined("ids"))
                {
                    foreach (var id in json.ids)
                    {

                        if (graph2.Addvertexs(id))
                        {
                            GQueue2.Enqueue(id);
                            graph2.AddEdge(uid, id);
                        }
                        else
                        {
                            continue;
                        }
                    }

                }

                for (int i = 0; i < graph1.vertexs.Count; i++)
                {
                    for (int j = 0; j < graph2.vertexs.Count; j++)
                    {
                        Vertex v1 = (Vertex)graph1.vertexs[i];
                        Vertex v2 = (Vertex)graph2.vertexs[j];
                        if (v1.Data==v2.Data)
                        {
                            IsFinded = true;
                            break;
                        }

                    }
                    if (IsFinded)
                        break;

                }
                if (IsFinded)
                    break;


            }
            if (IsFinded)
            { 
          //  Response.Write("找到了~~~");
            //foreach (Vertex v in graph1.vertexs)
            //{
            //    Response.Write("v1:"+v.Data + "<br>");
            //}
            //foreach (Vertex v in graph2.vertexs)
            //{
            //    Response.Write("v2:" + v.Data + "<br>");
            //}
            //foreach (float a in graph1.graph)
            //{ 
            //Response.Write("g1:"+a+"   ");
            
            //}
            //Response.Write("<br>");
            //foreach (float a in graph2.graph)
            //{
            //    Response.Write("g2:" + a + "   ");
            //}
           Graph thgraph= Graph.GraphCombine(graph1,graph2);
             foreach(Vertex v in thgraph.vertexs)
            {
                Response.Write("v1:"+v.Data + "<br>");
            }
             for (int i = 0; i < (int)Math.Sqrt(thgraph.graph.Length);i++ )
             {
                 for (int j = 0; j < (int)Math.Sqrt(thgraph.graph.Length); j++)
                 { 
                  Response.Write("["+i+","+j+"]:" + thgraph.graph[i,j]+ "   ");
                 
                 }
                 Response.Write("<br>");
             }
            }
                


        }

       


    }
}