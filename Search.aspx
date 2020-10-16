<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="HDWalls.Search" %>
<%@ Register Src="~/UserControls/PagerToolbarDynamic.ascx" TagName="PagerToolbarDynamic" TagPrefix="Tlb" %>

<asp:Content runat="server" ContentPlaceHolderID="CP1">

    <div class="clearfix"></div>
    <div>
        <ul class="WallPreview">
            <asp:Repeater ID="rptWalls" runat="server">
                <ItemTemplate>
                    <li>
                        <div>
                            <asp:HyperLink NavigateUrl='<%# "~/Wallpapers/"  + Eval("Title") + "-" + Eval("ID") + ".html"%>' runat="server">
                        <asp:Image ImageUrl=<%# "~/Wallpapers/" + Eval("SmallSize")%> runat="server" />
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
    <div class="clearfix"></div>
    <div>
        <Tlb:PagerToolbarDynamic runat="server" ID="pgrToolbar" />
    </div>
</asp:Content>
