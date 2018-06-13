<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ChangePassword.Layouts.ChangePassword.ChangePassword" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link type="text/css" rel="stylesheet" href="/_layouts/15/1033/styles/ChangePassword/ChangePassword.css" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlMain" runat="server">
    <div id="divTable" style="width:350px;" runat="server">
        <table style="width: 100%; text-align:center">
            <tr>
                <td>Username</td>
                <td>
                    <input id="inpUserName" type="text"  runat="server" readonly="readonly" value="Domain\UserName" tabindex="-1" disabled="disabled" style="width:133px" />
                </td>
            </tr>
            <tr>
                <td>Old Password</td>
                <td>
                    <input id="inpOldPassword" type="password" runat="server" style="width:140px" />
                    
                </td>
                
            </tr>
            <tr>
                <td>New Password</td>
                <td><input id="inpNewPassword" type="password" runat="server" style="width:140px"/></td>
                
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td><input id="inpConfirmPassword" type="password" runat="server" style="width:140px" /></td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <div id="divValidation" runat="server" style="width:343px">
                        
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
                    <asp:Button ID="Close" runat="server" Text="Close" OnClick="Close_Click" />
                </td>
            </tr>
        </table>
    </div>
     </asp:Panel>
    <asp:Panel ID="pnlSuccessfull" runat="server" Visible="False">
    <div id="divSuccesfull" runat="server" style="text-align:center; width:350px;">
        Your password has been changed successfully
        <br />
        <br />
        <asp:Button ID="Close2" runat="server" Text="Close" OnClick="Close2_Click" />
    </div>
        </asp:Panel>
    <div id="divOldPassword" runat="server">

    </div>
    <div id="divNewPassword" runat="server">

    </div>
    <div id="divConfirmPassword" runat="server">

    </div>
    <div id="divError" runat="server" style="width:343px;max-width:343px;word-wrap: break-word">

    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Change Password
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Change Password
</asp:Content>
