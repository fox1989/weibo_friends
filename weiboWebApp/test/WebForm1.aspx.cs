using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int a = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.Text = "ture";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            a++;
           
          
            Button1.Text = (Convert.ToInt32(Session["a"])+1).ToString();
        }
    }
}