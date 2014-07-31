using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace weiboWebApp
{
    public class Vertex//结点的定义
    {
        public string Data;
        public string Name;
        public bool IsVisited;
        public Vertex(string Vertexdata)
        {
            Data = Vertexdata;
            Name = "";
            IsVisited = false;
        }
        public Vertex(string ver, string name)
        {
            Data = ver;
            Name = name;
            IsVisited = false;
        }
    
    }
    public class Graph
    {
      public  ArrayList vertexs = new ArrayList();
       public float [,] graph;




       public bool Addvertexs(string data)//增加一个结点
       {

           Vertex v1 = new Vertex(data);
           if (vertexs.IndexOf(data) < 0)
           {
               vertexs.Add(v1);
               if (graph != null)
               {
                   int x = graph.GetLength(0);

                   float[,] t = new float[x + 1, x + 1];

                   Array.Copy(graph, t, graph.Length);
                   graph = null;
                   graph = t;

               }
               else
               {
                   graph = new float[1, 1];


               }
               return true;
           }
           return false;



       }


       public bool Addvertexs(string data,string name)//增加一个结点
       {

           Vertex v1 = new Vertex(data,name);
           if (vertexs.IndexOf(data) < 0)
           {
               vertexs.Add(v1);
               if (graph != null)
               {
                   int x = graph.GetLength(0);

                   float[,] t = new float[x + 1, x + 1];

                   Array.Copy(graph, t, graph.Length);
                   graph = null;
                   graph = t;

               }
               else
               {
                   graph = new float[1, 1];


               }
               return true;
           }
           return false;



       }

        public void AddEdge(string uid1, string uid2)//增加边，
        { 
            Vertex v1=new Vertex(uid1);
            Vertex v2=new Vertex(uid2);

            int edge1 = ReIndexOf(v1, vertexs);
            int edge2 = ReIndexOf(v2, vertexs);
            Random random=new Random();
            graph[edge1, edge2] = 1.0f*random.Next(10);


        }

        public static int ReIndexOf(Vertex v,ArrayList arraylis)//找到对象在数组的索引
        {
            foreach (Vertex x in arraylis)
            {
                if (x.Data == v.Data)
                {
                    return arraylis.IndexOf(x);
                }
               
            }

       return -1;
        
        }

        public void Ergodic()//遍历....
        { 
        
        
        
        }


  static  public float[,] AtRemove(float[,] array, int i)//移除二维数组中指定行列
        {
            int max = (int)Math.Sqrt(array.Length);

            float[,] reArray = new float[max - 1, max - 1];
            int x = 0, y = 0;
            for (int n = 0; n < max; n++)
            {
                y = 0;
                if (n == i)
                    continue;

                for (int m = 0; m < max; m++)
                {
                    if (m == i)
                        continue;
                    reArray[x, y] = array[n, m];
                    y++;

                }
                x++;

            }
            return reArray;

        }


        public static Graph GraphCombine(Graph graph1,Graph graph2)//两个图实列的合并
  {
     

            Graph tempGraph2 = graph2;
           foreach(Vertex i in graph1.vertexs)
           {
               
               for (int n = 0; n < graph2.vertexs.Count;n++ )
               
               {
                   Vertex j =(Vertex) graph2.vertexs[n];
                   if (i.Data == j.Data)
                   {
                       int index = ReIndexOf(j, tempGraph2.vertexs);
                       tempGraph2.vertexs.RemoveAt(index);
                       float[,] temp = AtRemove(tempGraph2.graph, index);
                       tempGraph2.graph = null;
                       tempGraph2.graph = temp;
                   }

               }
           
           
           }
           graph2 = tempGraph2;
            int max=graph1.vertexs.Count+graph2.vertexs.Count;

            Graph newGraph=new Graph();
            newGraph.graph=new float[max,max];
        foreach(Vertex te in graph2.vertexs)
        {
        graph1.vertexs.Add(te);
        }
            newGraph.vertexs=graph1.vertexs;
          
            //开始创建返回对象 
            float[,] Tgraph=new float[newGraph.vertexs.Count,newGraph.vertexs.Count];
         Array.Copy(graph1.graph,newGraph.graph,graph1.graph.Length);
            int x=(int)Math.Sqrt(graph1.graph.Length),y=(int)Math.Sqrt(graph1.graph.Length);
            for(int i=0;i<(int)Math.Sqrt(graph2.graph.Length);i++)
            {  y=(int)Math.Sqrt(graph1.graph.Length);
                for(int j=0;j<(int)Math.Sqrt(graph2.graph.Length);j++)
                {
                    newGraph.graph[x,y]=graph2.graph[i,j];
                y++;
                }
            x++;
            }

            return newGraph;
        
        }

      

    }
}