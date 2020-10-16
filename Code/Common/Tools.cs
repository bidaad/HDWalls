using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Tools
    {
        public static void SetMeta(string MetaID, string MetaVal)
        {
            try
            {
                HtmlMeta metadesc = (HtmlMeta)((Page)(HttpContext.Current.Handler)).Master.FindControl(MetaID);
                metadesc.Attributes["content"] = MetaVal;
                metadesc.Attributes.Remove("id");
            }
            catch
            {
            }
        }

}

