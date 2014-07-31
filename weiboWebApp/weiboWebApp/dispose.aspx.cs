using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetDimension.Weibo;
using System.Configuration;
using System.Collections;

namespace weiboWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
         Client Sina = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string accessToken = Request.Cookies["AccessToken"].Value;
            // Response.Cookies["AccessToken"].Value;

            Sina = new Client(new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], accessToken, null));
            string name1 = Request["strname1"];
           string name2 = Request["strname2"]; 
       // string    name1 = "福克斯1989";
          // string name2 = "_____xi_s";
            //Response.Write(Sina.API.Dynamic.Account.GetUID());
            string uid1, uid2;

            var varuid1 = Sina.API.Dynamic.Users.Show(screenName: name1);


            uid1 = varuid1.id;

            var varuid2 = Sina.API.Dynamic.Users.Show(screenName: name2);

            uid2 = varuid2.id;


            Graph Ngraph = SCGraph(uid1, uid2);
            if (Ngraph != null)
            {
                Response.Write("{\"nodes\":[");
                foreach (Vertex ver in Ngraph.vertexs)
                {
                    int count = Ngraph.vertexs.Count - 1;
                    Vertex vvv = (Vertex)Ngraph.vertexs[count];
                    Random random = new Random();
                    string node = "{\"count\": \"" + random.Next(10) + "\",\"group\": \"" + random.Next(5) + "\",\"name\": \"" + ver.Name + "\"}";
                    Response.Write(node);

                    if (ver.Data != vvv.Data)
                    {
                        Response.Write(",");

                    }

                }
                Response.Write("],\"links\":[");
                bool isfrist = false;
                for (int i = 0; i < (int)Math.Sqrt(Ngraph.graph.Length); i++)
                {
                    for (int n = 0; n < (int)Math.Sqrt(Ngraph.graph.Length); n++)
                    {
                        if (Ngraph.graph[i, n] != 0)
                        {      
                            if (isfrist)
                            {
                                Response.Write(",");
                                
                            }
                            isfrist = true;
                            string link = "{ \"source\": \"" + i + "\", \"target\": \"" + n + "\",\"value\": \"" + Ngraph.graph[i, n] + "\"}";
                            Response.Write(link);

                        }
 

                    }


                }



                Response.Write("]}");






            }
            

           //string str = "{\"ursername\":\"Sam\",\"age\":\"30\",\"level\":\"4\"}";
           //Response.Write(str);
        }



        public void ShowUserFList(string uid)
        {
            int co = 1;

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
            //   Response.Write("_________________________<br>");
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

        //public void SCGraph(string uid1, string uid2)//找两个人的关系图
        //{
        //    bool IsFinded = false;
        //  Graph  graph1 = new Graph();
        //  Graph  graph2 = new Graph();
        //    Queue GQueue1 = new Queue();
        //    Queue GQueue2 = new Queue();
        //    GQueue1.Enqueue(uid1);
        //    GQueue2.Enqueue(uid2);
        //    string uid;
        //    int count = 0;

        //    while (true)
        //    {
        //        if (count > 6)
        //            break;
        //        count++;
        //        uid = GQueue1.Dequeue().ToString();
        //        var json = Sina.API.Dynamic.Friendships.FriendsOnBilateralIDs(uid);
        //        graph1.Addvertexs(uid);
        //        if (json.IsDefined("ids"))
        //        {
        //            foreach (var id in json.ids)
        //            {

        //                if (graph1.Addvertexs(id))
        //                {
        //                    GQueue1.Enqueue(id);
        //                    graph1.AddEdge(uid, id);
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }

        //        }
        //        uid = GQueue2.Dequeue().ToString();
        //        json = Sina.API.Dynamic.Friendships.FriendsOnBilateralIDs(uid);
        //        graph2.Addvertexs(uid);
        //        if (json.IsDefined("ids"))
        //        {
        //            foreach (var id in json.ids)
        //            {

        //                if (graph2.Addvertexs(id))
        //                {
        //                    GQueue2.Enqueue(id);
        //                    graph2.AddEdge(uid, id);
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }

        //        }

        //        for (int i = 0; i < graph1.vertexs.Count; i++)
        //        {
        //            for (int j = 0; j < graph2.vertexs.Count; j++)
        //            {
        //                Vertex v1 = (Vertex)graph1.vertexs[i];
        //                Vertex v2 = (Vertex)graph2.vertexs[j];
        //                if (v1.Data == v2.Data)
        //                {
        //                    IsFinded = true;
        //                    break;
        //                }

        //            }
        //            if (IsFinded)
        //                break;

        //        }
        //        if (IsFinded)
        //            break;


        //    }
        //    if (IsFinded)
        //    {
        //        //Response.Write("找到了~~~");
        //        //foreach (Vertex v in graph1.vertexs)
        //        //{
        //        //    Response.Write("v1:" + v.Data + "<br>");
        //        //}
        //        //foreach (Vertex v in graph2.vertexs)
        //        //{
        //        //    Response.Write("v2:" + v.Data + "<br>");
        //        //}
              
        //        Graph thgraph = Graph.GraphCombine(graph1, graph2);
        //        //foreach (Vertex v in thgraph.vertexs)
        //        //{
        //        //    Response.Write("v1:" + v.Data + "<br>");
        //        //}
        //        //for (int i = 0; i < (int)Math.Sqrt(thgraph.graph.Length); i++)
        //        //{
        //        //    for (int j = 0; j < (int)Math.Sqrt(thgraph.graph.Length); j++)
        //        //    {
        //        //        Response.Write("[" + i + "," + j + "]:" + thgraph.graph[i, j] + "   ");

        //        //    }
        //        //    Response.Write("<br>");
        //        //}
        //    }



        //}


        public Graph SCGraph(string uid1, string uid2)//找两个人的关系图
        {
            bool IsFinded = false;
            Graph graph1 = new Graph();
            Graph graph2 = new Graph();
            Queue GQueue1 = new Queue();
            Queue GQueue2 = new Queue();
            GQueue1.Enqueue(uid1);
            GQueue2.Enqueue(uid2);
            string uid;
            int count = 0;

            while (true)
            {
                if (count > 3)
                    break;
                count++;
                uid = GQueue1.Dequeue().ToString();
                var json = Sina.API.Dynamic.Friendships.FriendsOnBilateral(uid);
                graph1.Addvertexs(uid);
                if (json.IsDefined("users"))
                {
                    foreach (var user in json.users)
                    {

                        if (graph1.Addvertexs(user.id,user.name))
                        {
                            GQueue1.Enqueue(user.id);
                            graph1.AddEdge(uid, user.id);
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
                uid = GQueue2.Dequeue().ToString();
                json = Sina.API.Dynamic.Friendships.FriendsOnBilateral(uid);
                graph2.Addvertexs(uid);
                if (json.IsDefined("users"))
                {
                    foreach (var user in json.users)
                    {

                        if (graph2.Addvertexs(user.id,user.name))
                        {
                            GQueue2.Enqueue(user.id);
                            graph2.AddEdge(uid, user.id);
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
                        if (v1.Data == v2.Data)
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
                //Response.Write("找到了~~~");
                //foreach (Vertex v in graph1.vertexs)
                //{
                //    Response.Write("v1:" + v.Data + "<br>");
                //}
                //foreach (Vertex v in graph2.vertexs)
                //{
                //    Response.Write("v2:" + v.Data + "<br>");
                //}

                Graph thgraph = Graph.GraphCombine(graph1, graph2);
                return thgraph;
                //foreach (Vertex v in thgraph.vertexs)
                //{
                //    Response.Write("v1:" + v.Data + "<br>");
                //}
                //for (int i = 0; i < (int)Math.Sqrt(thgraph.graph.Length); i++)
                //{
                //    for (int j = 0; j < (int)Math.Sqrt(thgraph.graph.Length); j++)
                //    {
                //        Response.Write("[" + i + "," + j + "]:" + thgraph.graph[i, j] + "   ");

                //    }
                //    Response.Write("<br>");
                //}
            }
            else
            {
                return null;
            }



        }

    }
}