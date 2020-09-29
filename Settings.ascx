<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.GIBSMLSImageCleaner.Settings" %>


<!-- uncomment the code below to start using the DNN Form pattern to create and update settings -->


<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

	<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="#" class="dnnSectionExpanded">Basic Settings</a></h2>
	<fieldset>
        	<div class="dnnFormItem">
        <dnn:Label runat="server" ID="lblSourcePath" ControlName="txtSourcePath" ResourceKey="lblSourcePath" Suffix=":" />
        <asp:Textbox ID="txtSourcePath" runat="server" />
           
     </div>	
	 
	 
	 	<div class="dnnFormItem">
        <dnn:Label runat="server" ID="lblTargetPath" ControlName="txtTargetPath" ResourceKey="lblTargetPath" Suffix=":" />
        <asp:Textbox ID="txtTargetPath" runat="server" />
           
     </div>	
    </fieldset>


