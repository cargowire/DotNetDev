<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DotNetDev.WebForms.CSharp.Web._Default" %>
<%@ Register TagPrefix="dnd" TagName="Notes" Src="~/Notes.ascx" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h2>Dot Net Dev</h2>
	
	<asp:Literal ID="message" runat="server"/>

	<dnd:Notes runat="server" />
</asp:Content>
