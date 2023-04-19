using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAyment.UI
{
    public partial class PaymentResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Request.Form.Count; i++)
            {
                ltrResult.Text += Request.Form[i];
                ltrResult.Text += "<br/>";
                ltrResult.Text += "<br/>";
            }
        }
    }
}