using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDWalls
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConcatUrl = "";
            int PageNo = 1;
            int PageSize = 25;

            string strPageNo = Request["PageNo"];
            if (strPageNo != "" && strPageNo != null)
                PageNo = Convert.ToInt32(strPageNo);

            if (!Page.IsPostBack)
            {
                string Keyword = Request["Keyword"];

                BOLWallpapers WallpapersBOL = new BOLWallpapers();
                int PageCount = WallpapersBOL.GetCount(Keyword, "") / PageSize + 1;

                rptWalls.DataSource = WallpapersBOL.GetWallpapers(Keyword, "", PageNo, PageSize);
                rptWalls.DataBind();

                ConcatUrl += "&Keyword=" + Keyword;
                pgrToolbar.PageNo = PageNo;
                pgrToolbar.PageCount = PageCount;
                pgrToolbar.ConcatUrl = ConcatUrl;
                pgrToolbar.PageBind();


            }
        }
    }
}