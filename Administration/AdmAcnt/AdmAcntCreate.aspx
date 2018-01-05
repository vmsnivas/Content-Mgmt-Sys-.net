<%@ Page language="c#" Codebehind="AdmAcntCreate.aspx.cs" AutoEventWireup="false" Inherits="CMSNET.Administration.AdmAcnt.AdmAcntCreate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>AdmAcntCreate</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="AdmAcntCreate" method="post" runat="server">
            <H2><FONT color="darkslategray">Administrator: Account Create</FONT></H2>
            <P><asp:validationsummary id="ValSum" runat="server" HeaderText="Sorry, cannot create administrator account the following errors occured:"></asp:validationsummary></P>
            <P><asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></P>
            <H3>Account Information:</H3>
            <TABLE cellSpacing="1" cellPadding="3" width="60%" border="1">
                <TR>
                    <TD style="WIDTH: 35%">
                        <P><STRONG>User Name<BR>
                            </STRONG><EM>(optional)</EM></P>
                    </TD>
                    <TD style="WIDTH: 55%" width="80%"><asp:textbox id="tbUserName" runat="server" width="100%" maxlength="256"></asp:textbox></TD>
                    <TD width="10%">&nbsp;</TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 35%"><STRONG>User ID</STRONG></TD>
                    <TD style="WIDTH: 55%"><asp:textbox id="tbUserID" runat="server" width="100%" maxlength="32"></asp:textbox></TD>
                    <TD style="WIDTH: 10%">&nbsp;
                        <asp:requiredfieldvalidator id="rfvUserID" runat="server" ErrorMessage="You must enter a User ID" Display="Dynamic" ControlToValidate="tbUserID">*</asp:requiredfieldvalidator></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 35%"><STRONG>Email Address</STRONG></TD>
                    <TD style="WIDTH: 55%"><asp:textbox id="tbEmail" runat="server" width="100%" maxlength="64"></asp:textbox></TD>
                    <TD style="WIDTH: 10%">&nbsp;
                        <asp:requiredfieldvalidator id="rfvEmail" runat="server" ErrorMessage="You must enter an email address" Display="Dynamic" ControlToValidate="tbEmail">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revEmail" runat="server" ErrorMessage="Invalid email address" Display="Dynamic" ControlToValidate="tbEmail" ValidationExpression="[\w-]+([\+\.][\w-]*)?@([\w-]+\.)+[\w-]+">*</asp:regularexpressionvalidator></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 35%"><STRONG>Password</STRONG></TD>
                    <TD style="WIDTH: 55%"><asp:textbox id="tbPassword" runat="server" TextMode="Password" width="100%" maxlength="16"></asp:textbox></TD>
                    <TD style="WIDTH: 10%">&nbsp;
                        <asp:requiredfieldvalidator id="rfvPassword" runat="server" ErrorMessage="You must enter a password" Display="Dynamic" ControlToValidate="tbPassword">*</asp:requiredfieldvalidator></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 35%"><STRONG>Password</STRONG><BR>
                        <EM>(Confirm)</EM></TD>
                    <TD style="WIDTH: 55%"><asp:textbox id="tbConfirm" runat="server" TextMode="Password" width="100%" maxlength="16"></asp:textbox></TD>
                    <TD style="WIDTH: 10%">&nbsp;
                        <asp:requiredfieldvalidator id="rfvConfirm" runat="server" ErrorMessage="Missing confirmation password" Display="Dynamic" ControlToValidate="tbConfirm">*</asp:requiredfieldvalidator><asp:comparevalidator id="cvConfirm" runat="server" ErrorMessage="Password and Confirm password do not match" Display="Dynamic" ControlToValidate="tbConfirm" ControlToCompare="tbPassword">*</asp:comparevalidator></TD>
                </TR>
            </TABLE>
            <H3>Roles:</H3>
            <FONT size="2">(Select role or ctrl click to select more than one role)<br>
            </FONT>
            <asp:ListBox id="lbRoles" runat="server" Width="40%" SelectionMode="Multiple"></asp:ListBox>
            <P><asp:button id="bnCreate" runat="server" Text="Create Account"></asp:button>&nbsp;&nbsp;
                <INPUT onclick="window.history.back()" type="button" value="Cancel">
            </P>
        </form>
    </body>
</HTML>
