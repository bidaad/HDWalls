<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ShowWallpaper.aspx.cs" Inherits="HDWalls.ShowWallpaper" %>

<asp:Content runat="server" ContentPlaceHolderID="CP1">
    <div class="clearfix"></div>
    <div>
        <hr />
        <h3 class="Header">
            <asp:Literal ID="ltrHeader" runat="server" Text=""></asp:Literal>
        </h3>
        <hr />
    </div>
    <div>
        <asp:Image ID="imgWallpaper" CssClass="img-fluid" runat="server" />
    </div>
    <div class="clearfix"></div>
    <div class="Toolbar">
        <asp:HyperLink ID="hplDownloadOriginal" Target="_blank" CssClass="ToolbarItem" runat="server"><i class="fa fa-download" aria-hidden="true"></i>
            Download Original Wallpaper</asp:HyperLink>
        <asp:HyperLink ID="hplCategory" CssClass="ToolbarItem" runat="server">
            <i class="fa fa-tag" aria-hidden="true"></i>
            <asp:Literal ID="ltrCategory" runat="server"></asp:Literal>
        </asp:HyperLink>
        <asp:HyperLink ID="hplDownloadTimes" CssClass="ToolbarItem" runat="server">
            <i class="fa fa-sort-amount-asc" aria-hidden="true"></i>
            <asp:Literal ID="ltrDownloadTimes" runat="server"></asp:Literal>
        </asp:HyperLink>
        <asp:HyperLink ID="hplOriginalSize" CssClass="ToolbarItem" runat="server"></asp:HyperLink>
    </div>
    <div>
        <h5 class="Header">
            <asp:Literal ID="ltrOtherWallCats" runat="server" Text=""></asp:Literal>
        </h5>
        <hr />
    </div>
    <div>
        <div>Popular Resolutions:</div>
        <div class="PopularResolutions">
            <asp:Repeater ID="rptResolutions" runat="server">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl=<%#"~/Wallpapers/" + CatName + "/" + TitleName + "-" + ID + "/" + Container.DataItem.ToString() + ".html" %> runat="server"><%#Container.DataItem.ToString() %></asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div>
        <ul class="WallPreview">
            <asp:Repeater ID="rptWalls" runat="server">
                <ItemTemplate>
                    <li>
                        <div>
                            <asp:HyperLink NavigateUrl='<%# "~/Wallpapers/"  + Eval("Title").ToString().Replace(" ", "-") + "-" + Eval("ID") + ".html"%>' runat="server">
                        <asp:Image ImageUrl=<%# "~/Wallpapers/" + Eval("FileFullPath")%> runat="server" />
                            </asp:HyperLink>
                        </div>
                        <div class="title">
                            <%#Eval("Title") %>
                        </div>
                        <div>
                            <div class="cat pull-left"><%#Eval("CatName") %></div>
                        </div>
                </ItemTemplate>

            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
