using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDWalls
{
    public partial class Cats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CatName = Request["CatName"];
            string ConcatUrl = "";
            int PageNo = 1;
            int PageSize = 25;

            CatName = CatName.Replace("-", " ");
            string strPageNo = Request["PageNo"];
            if (strPageNo != "" && strPageNo != null)
                PageNo = Convert.ToInt32(strPageNo);

            if (!Page.IsPostBack)
            {
                lblHeader.Text = CatName.Replace("-", " ");
                BOLWallpapers WallpapersBOL = new BOLWallpapers();
                int PageCount = WallpapersBOL.GetCount("", CatName) / PageSize + 1;

                rptWalls.DataSource = WallpapersBOL.GetWallpapers("", CatName, PageNo, PageSize);
                rptWalls.DataBind();

                CatName = CatName.Replace(" ", "-");
                ConcatUrl += "";
                pgrToolbar.PageName = "~/Cats/" + CatName;
                pgrToolbar.PageNo = PageNo;
                pgrToolbar.PageCount = PageCount;
                pgrToolbar.ConcatUrl = ConcatUrl;
                pgrToolbar.PageBind();
            }
        }
    }
}