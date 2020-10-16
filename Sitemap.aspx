<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sitemap.aspx.cs" Inherits="HDWalls.Sitemap" %><?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
    <asp:Repeater id="rptWalls" runat="server">
        <ItemTemplate>
           <url>
              <loc><%# "https://www.HDWalls.net/Wallpapers/"  + Eval("Title").ToString().Replace(" ", "-") + "-" + Eval("ID") + ".html"%></loc>
              <lastmod>2019-01-25</lastmod>
              <changefreq>monthly</changefreq>
              <priority>0.8</priority>
           </url>
        </ItemTemplate>
    </asp:Repeater>

</urlset> 
