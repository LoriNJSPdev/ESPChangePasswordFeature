using System;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.DirectoryServices.AccountManagement;
using Microsoft.SharePoint.Administration.Claims;
using Microsoft.SharePoint.Utilities; 

namespace ChangePassword.Layouts.ChangePassword
{
   
    public partial class ChangePassword : LayoutsPageBase
    {
        string usrname = "";
        string usrDomain = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SPClaimProviderManager clmProvider = SPClaimProviderManager.Local;

            if (clmProvider != null)
            {
                usrname = clmProvider.DecodeClaim(SPContext.Current.Web.CurrentUser.LoginName).Value;
                int index = usrname.IndexOf('\\');
                usrDomain = usrname.Substring(0, index);
                
            }
            inpUserName.Value = usrname.ToString();
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (inpOldPassword.Value.Trim() == "" || inpNewPassword.Value.Trim() == "" || inpConfirmPassword.Value.Trim() == "")
                {
                    divValidation.InnerHtml = "<br/><font color=red>You cannot leave any blank values.</font>";
                }
                else if (inpNewPassword.Value != inpConfirmPassword.Value)
                {
                    divValidation.InnerHtml = "<br/><font color=red>The passwords that you entered did not match.</font>";
                }
                else
                {
                    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain,usrDomain, usrname, inpOldPassword.Value))
                    {
                        UserPrincipal user = new UserPrincipal(ctx);
                        user = UserPrincipal.FindByIdentity(ctx, usrname);
                        //Change the password
                        user.ChangePassword(inpOldPassword.Value, inpNewPassword.Value);
                        user.Save();
                        pnlMain.Visible = false;
                        pnlSuccessfull.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string stroPError = "The user name or password is incorrect.";
                string stroPError2 = "Logon failure: unknown user name or bad password.";
                string stroPError3 = "System.UnauthorizedAccessException: Access is denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED))";
                string strErrType = ex.GetType().ToString();
                string errMsg = ex.Message.Trim();
                string errMsgInner = "";
                if (ex.InnerException != null)
                {
                    errMsgInner = ex.InnerException.ToString().Trim();
                }

                if (errMsg == stroPError)
                {
                    divValidation.InnerHtml = "<br/><font color=red>The old password is incorrect.</font>";
                    divError.InnerHtml = "";
                }
                else if (errMsg == stroPError2)
                {
                    divValidation.InnerHtml = "<br/><font color=red>The old password is incorrect.</font>";
                    divError.InnerHtml = "";
                }
                else if (errMsgInner == stroPError3)
                {
                    divValidation.InnerHtml = "<br/><font color=red>Access is Denied. You cannot change your password.</font>";
                    divError.InnerHtml = "";
                }
                else if (strErrType.Trim() == "System.DirectoryServices.AccountManagement.PasswordException")
                {
                    divValidation.InnerHtml = "<br/><font color=red>The password does not meet the password policy requirements. Minimum password length is 8 characters. Password history requirements - the last 6 passwords are remembered and cannot be reused.</font>";
                    divError.InnerHtml = "";
                }
                else
                {
                    divValidation.InnerHtml = "";
                    divError.InnerHtml = "<br/>" + ex.Message;
                    divError.InnerHtml += "<br/>" + ex.GetType();
                    divError.InnerHtml += "<br/>" + ex.InnerException;
                    divError.InnerHtml += "<br/>Domain: " + usrDomain;
                }
            }
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (HttpContext.Current.Request.QueryString["IsDlg"] != null)
            {
                context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup()</script>");
                context.Response.Flush();
                context.Response.End();
            }
        }

        protected void Close2_Click(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (HttpContext.Current.Request.QueryString["IsDlg"] != null)
            {
                context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup()</script>");
                context.Response.Flush();
                context.Response.End();
            }
        }
        
            
    }
    

}
