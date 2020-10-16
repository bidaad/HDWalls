<%@ Page Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Cats.aspx.cs" Inherits="HDWalls.Cats" %>

<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>
<asp:Content ContentPlaceHolderID="CP1" runat="server">
    <div class="clearfix"></div>
    <div>
        <hr />
        <h1 class="Header">
            <asp:Literal ID="lblHeader" runat="server" Text=""></asp:Literal>
        </h1>
        <hr />
    </div>
    <div class="clearfix"></div>
    <div>
        <ul class="WallPreview">
            <asp:Repeater ID="rptWalls" runat="server">
                <ItemTemplate>
                    <li>
                        <div>
                            <asp:HyperLink NavigateUrl='<%# "~/Wallpapers/"  + Eval("Title").ToString().Replace(" ", "-") + "-" + Eval("ID") + ".html"%>' runat="server">
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
    <br />
    <div>
        <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
    </div>
</asp:Content>
