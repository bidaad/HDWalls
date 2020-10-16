using HDWalls.Code.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDWalls
{
    public partial class ShowWallpaper : System.Web.UI.Page
    {
        public string CatName;
        public string TitleName;
        public string ID;
        protected string ConvertToBase64(string ImageFilePath)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(ImageFilePath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Request["ID"];

            string NewSize = Request["NewSize"];
            BOLWallpapers WallpapersBOL = new BOLWallpapers();

            Wallpaper CurWallpaper = WallpapersBOL.GetDetailsByID(ID);
            if (CurWallpaper != null)
            {
                Page.Title = CurWallpaper.Title;
                ltrHeader.Text = CurWallpaper.Title;

                CatName = CurWallpaper.CatName.Replace(" ", "-");
                TitleName = CurWallpaper.Title.Replace(" ", "-");

                if (string.IsNullOrEmpty(NewSize))
                {
                    imgWallpaper.ImageUrl = "~/Wallpapers/" + CurWallpaper.FileFullPath;
                    hplDownloadOriginal.NavigateUrl = "~/Wallpapers/" + CurWallpaper.OrgFile;
                }
                else
                {
                    try
                    {
                        string[] NewSizeArray = NewSize.Split('x');
                        int NewWidth = Convert.ToInt32( NewSizeArray[0]);
                        int NewHeight = Convert.ToInt32(NewSizeArray[1]);

                        System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath("~/Wallpapers/" + CurWallpaper.FileFullPath));
                        Bitmap ResizeBM = ResizeImage(image, NewWidth, NewHeight);
                        System.IO.MemoryStream ms = new MemoryStream();
                        ResizeBM.Save(ms, ImageFormat.Jpeg);
                        byte[] byteImage = ms.ToArray();
                        var SigBase64 = Convert.ToBase64String(byteImage); // Get Base64

                        imgWallpaper.ImageUrl = "data:image/jpeg;base64," + SigBase64;
                        hplDownloadOriginal.NavigateUrl = "data:image/jpeg;base64," + SigBase64;
                    }
                    catch
                    {

                    }
                }

                string AllResolutions = @"1366x768,1920x1080,360x640,1024x768,1600x900,1280x800,1440x900,1280x1024,800x600,1680x1050,2560x1440,320x480,1920x1200,480x800,720x1280,1080x1920";
                string[] AllResArray = AllResolutions.Split(',');
                rptResolutions.DataSource = AllResArray;
                rptResolutions.DataBind();


                ltrCategory.Text = "Category: " + CurWallpaper.CatName;
                hplCategory.NavigateUrl = "~/Cats/" + CurWallpaper.CatName.Replace(" ", "-") + "-1.html";

                ltrDownloadTimes.Text = "Download Time: " + CurWallpaper.DownloadTime;
                hplOriginalSize.Text = "Original Size: " + CurWallpaper.OriginalSize;

                rptWalls.DataSource = WallpapersBOL.GetOthers(ID, CurWallpaper.CatName, 3);
                rptWalls.DataBind();

                ltrOtherWallCats.Text = "Other wallpapers of " + CurWallpaper.CatName + " category";

                Tools.SetMeta("description", CurWallpaper.Title);

            }
        }
    }
}