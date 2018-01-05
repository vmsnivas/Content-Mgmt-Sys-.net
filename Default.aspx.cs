using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CMSNET.Common;

namespace CMSNET
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Next;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
            string ready = new AppEnv(Context).GetAppSetting("ready");

			if(ready.Equals("true"))
			{
				if (Request.IsAuthenticated)
					Response.Redirect("CDA/Protected/myHomePg.aspx");	
				else
					Response.Redirect("CDA/HomePg.aspx");	
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Next.Click += new System.EventHandler(this.Next_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Next_Click(object sender, System.EventArgs e)
		{
			Response.Redirect ("login.aspx");
		}
	}
}