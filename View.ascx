<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="GIBS.Modules.GIBSMLSImageCleaner.View" %>



<h4>Settings</h4>
<p>Source: <asp:Label ID="LabelSource" runat="server" Text="Setting Needs to be Updated"></asp:Label><br />
Target: <asp:Label ID="LabelTarget" runat="server" Text="Setting Needs to be Updated"></asp:Label>

</p>

<p>
    <asp:Button ID="Button1" runat="server" Text="Run Job" CssClass="btn btn-default" OnClick="Button1_Click" Enabled="false" /></p>
<h4>Results</h4>
<p><asp:Label ID="LabelShowStatus" runat="server" Text=""></asp:Label></p>