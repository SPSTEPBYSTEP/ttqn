﻿<%@ Assembly Name="CQ.SharePoint.QN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostViewNewsUS.ascx.cs"
    Inherits="CQ.SharePoint.QN.Webparts.MostViewNewsUS" %>
<div class="pos_MOD">
    <div class="bg_title_mod">
        <%= WebpartParent.MostViews %>
    </div>
    <div class="inner_pos_Mod">
        <div class="inner_news_Readmore">
            <asp:Repeater ID="rptTopViews" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href='<%= ItemUrl%><%#Eval("ID") %>&CategoryId=<%#Eval("CategoryId") %>'>
                        <%#Eval("Title")%></a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lblItemsNotFound" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</div>
