using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDWalls
{
    public partial class Root : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AllCats = @"movies and tv series,travel and world,celebrations,creative and fantasy,anime,games,sports,nature and landscape,architecture,funny,war and army,cars,beach,cute,animals,food,3d and abstract,music,vector and designs,brands and logos,ultimate wallpaper,animals and birds,photography,christmas,creative and graphics,art and paintings,bikes and motorcycles,colorful,man made,aircraft,celebrities,other,3d,flowers,love,girls,military,holidays,space";
            string[] AllCatsArray = AllCats.Split(',');
            rptCats.DataSource = AllCatsArray;
            rptCats.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Keyword = txtKeyword.Text;
            if (!string.IsNullOrEmpty(Keyword))
                Response.Redirect("~/Search.aspx?Keyword=" + Keyword);

        }
    }
}