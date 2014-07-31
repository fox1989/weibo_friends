using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weiboWebApp.test
{
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Response.Write("{"+
            //    "name:'"
            //    +Request["name"]+"' "
       
            //+"}");

            string name = Request["name"];
            string age = Request["age"];
            string str = "{\"name\":\"" + name + "\",\"age\":\"" + age + "\"}";
           // Response.Write("user:" + Request["user"] + "age:" + Request["age"]);
           // string str = "{\"ursername\":\"Sam\",\"age\":\"30\",\"level\":\"4\"}";
            Response.Write(str);
        }
    }
}