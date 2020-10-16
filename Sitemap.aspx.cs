using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDWalls
{
    public partial class Sitemap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int StartIndex = 0;
            int PageSize = 500;

            if (!string.IsNullOrEmpty(Request["SI"]))
                StartIndex = Convert.ToInt32(Request["SI"]);
            if (!string.IsNullOrEmpty(Request["PS"]))
                PageSize = Convert.ToInt32(Request["PS"]);


            BOLWallpapers WallpapersBOL = new BOLWallpapers();
            rptWalls.DataSource = WallpapersBOL.GetAll(StartIndex, PageSize);
            rptWalls.DataBind();

        }
    }
}