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
using CMSNET.DataAccess;

namespace CMSNET.Administration.Approve
{
	public class AppView : CMSNET.Common.AuthorizedPage
	{
        protected System.Web.UI.WebControls.Label lbContentID;
        protected System.Web.UI.WebControls.Label lbVersion;
        protected System.Web.UI.WebControls.Label lbHeadline;
        protected System.Web.UI.WebControls.Label lbSource;
        protected System.Web.UI.WebControls.Label lbByline;
        protected System.Web.UI.WebControls.Label lbTeaser;
        protected System.Web.UI.WebControls.Label lbBody;
        protected System.Web.UI.WebControls.Label lbTagline;
        protected System.Web.UI.WebControls.Label lbStatus;
        protected System.Web.UI.WebControls.Label lbEditor;
        protected System.Web.UI.WebControls.Label lbApprover;
        protected System.Web.UI.WebControls.Label lbUpdateUser;
        protected System.Web.UI.WebControls.Label lbModifiedDate;
        protected System.Web.UI.WebControls.Label lbCreationDate;
        protected System.Web.UI.WebControls.Button bnBack;
        protected System.Web.UI.WebControls.Button bnNext;
        protected System.Web.UI.WebControls.Button bnPrevious;
        protected System.Web.UI.WebControls.Button bnApprove;
        protected System.Web.UI.WebControls.Button bnReturn;
        protected System.Web.UI.WebControls.Button bnCancel;
    
        protected DataTable dt;
        
        private void BuildPage(int cver)
        {
            AccountProperty property = new AccountProperty(appEnv.GetConnection());

            DataRow dr = dt.Rows[cver];

            lbContentID.Text = dr["ContentID"].ToString();
            lbVersion.Text   = dr["Version"].ToString();
            lbHeadline.Text  = dr["Headline"].ToString();
            lbSource.Text    = dr["Source"].ToString() + "&nbsp;";
            lbByline.Text    = property.GetValue(Convert.ToInt32(dr["Byline"]), 
                "UserName").Trim();
            lbTeaser.Text    = dr["Teaser"].ToString() + "&nbsp;";
            lbBody.Text      = dr["Body"].ToString();
            lbTagline.Text   = dr["Tagline"].ToString() + "&nbsp;";
            lbStatus.Text    = StatusCodes.ToString(Convert.ToInt32(dr["Status"]));
            lbEditor.Text    = property.GetValue(Convert.ToInt32(dr["Editor"]), 
                "UserName").Trim();
            lbApprover.Text      = property.GetValue(Convert.ToInt32(dr["Approver"]), 
                "UserName").Trim();
            lbUpdateUser.Text  = property.GetValue(Convert.ToInt32(dr["UpdateUserID"]), 
                "UserName").Trim();
            lbModifiedDate.Text  = dr["ModifiedDate"].ToString();
            lbCreationDate.Text  = dr["CreationDate"].ToString();

            if (cver > 0)
            {
                bnNext.Enabled = true;
                int tmp = cver - 1;
                bnNext.CommandArgument = tmp.ToString();
            }
            else
                bnNext.Enabled = false;

            if (cver < dt.Rows.Count-1)
            {
                bnPrevious.Enabled = true;
                int tmp = cver + 1;
                bnPrevious.CommandArgument = tmp.ToString();
            }
            else
                bnPrevious.Enabled = false;

            bnApprove.Visible = (cver == 0 && StatusCodes.isAwaitingApproval(dr["Status"].ToString()));
            bnReturn.Visible = (cver == 0 && StatusCodes.isAwaitingApproval(dr["Status"].ToString()));
        }

        private void Page_Load(object sender, System.EventArgs e)
		{
            int cid = Convert.ToInt32(Request.QueryString["ContentID"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }
            dt = new Content(appEnv.GetConnection()).GetContentForID(cid);

            if (!IsPostBack)
            {
                BuildPage(0);
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
            this.bnBack.Click += new System.EventHandler(this.bnBack_Click);
            this.bnNext.Command += new System.Web.UI.WebControls.CommandEventHandler(this.bnMove_Click);
            this.bnPrevious.Command += new System.Web.UI.WebControls.CommandEventHandler(this.bnMove_Click);
            this.bnApprove.Click += new System.EventHandler(this.bnApprove_Click);
            this.bnReturn.Click += new System.EventHandler(this.bnReturn_Click);
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void bnBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AppList.aspx");
        }

        private void bnApprove_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AppApprove.aspx?ContentID=" + lbContentID.Text);
        }

        private void bnReturn_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AppReturn.aspx?ContentID=" + lbContentID.Text);
        }

        private void bnCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AppDiscont.aspx?ContentID=" + lbContentID.Text);
        }

        private void bnMove_Click(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            BuildPage(Convert.ToInt16(e.CommandArgument));
        }
	}
}
