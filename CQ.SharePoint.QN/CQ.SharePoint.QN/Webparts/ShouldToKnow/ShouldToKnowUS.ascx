﻿<%@ Assembly Name="CQ.SharePoint.QN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShouldToKnowUS.ascx.cs"
    Inherits="CQ.SharePoint.QN.Webparts.ShouldToKnowUS" %>
<%@ Assembly Name="Microsoft.SharePoint.Publishing, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<div class="contact_adv"><%= WebpartParent.ShouldToKnowTitle%></div>
<div class="info_more">
    <div class="bg_title_ModNews">
        <div class="title_cate_News">
            <div class="name_title_typ_News">
                <%= WebpartParent.NewsType%></div>
            <div class="link_cate_more">                
                <asp:Repeater ID="rptNewsGroup" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><a href='<%= CategoryUrl%><%#Eval("ID") %>'>
                            <%#Eval("Title")%></a></li>|
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="cleaner">
            </div>
        </div>
        <div class="inner_infoMore">
            <asp:Repeater ID="rptShouldYouKnow" runat="server">
                <ItemTemplate>
                    <div class="P1">
                        <div class="name_P">
                            <a href='<%= NewsUrl%><%#Eval("ID") %>'>
                                <%#Eval("Title") %></a>
                            <div class="link_web_P">
                                <a href='<%#Eval("LinkAdv") %>'>
                                    <%#Eval("LinkAdv") %></a></div>
                        </div>
                        <div class="img_short_content">
                            <div class="img_thumb">
                                <img src='<%#Eval("Thumbnail") %>' />                                
                            </div>
                            <div class="short_info">
                                <%#Eval("ShortContent") %>
                            </div>
                            <div class="cleaner">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="cleaner">
            </div>
        </div>
    </div>
</div>
