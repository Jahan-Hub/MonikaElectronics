﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptBankTransactions.aspx.cs" Inherits="ElectronicsMS.Forms.ReportForms.rptBankTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <h1>Bank Transfer</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Bank Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="cmCommon" Filter="Contains" Runat="server" EnableLoadOnDemand="true" EmptyMessage="Select A Bank" OnItemsRequested="cmCommon_ItemsRequested" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cmCommon_SelectedIndexChanged" Enabled="False">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label20" runat="server" Text="Transaction Type"></asp:Label>
                </td>
                <td class="auto-style1">
                    <telerik:RadComboBox ID="cmTransactionType" EnableLoadOnDemand="true" Runat="server" AutoPostBack="True" EmptyMessage="Select Transaction Type">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Withdraw" Value="Withdraw" />
                            <telerik:RadComboBoxItem runat="server" Text="Deposit" Value="Deposit" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label19" runat="server" Text="Report Type"></asp:Label>
                </td>
                <td class="auto-style1">
                    <telerik:RadComboBox ID="cmReportType" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmReportType_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Custom Date" Value="Custom Date" />
                            <telerik:RadComboBoxItem runat="server" Text="As on Date" Value="As on Date" />
                            <telerik:RadComboBoxItem runat="server" Text="Monthly" Value="Monthly" Visible="False" />
                            <telerik:RadComboBoxItem runat="server" Text="Yearly" Value="Yearly" Visible="False" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="dpStartDate" Runat="server">
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                    <FocusedStyle Resize="None"></FocusedStyle>

                                                    <DisabledStyle Resize="None"></DisabledStyle>

                                                    <InvalidStyle Resize="None"></InvalidStyle>

                                                    <HoveredStyle Resize="None"></HoveredStyle>

                                                    <EnabledStyle Resize="None"></EnabledStyle>
                                                </DateInput>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="To Date"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="dpEndDate" Runat="server">
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                    <FocusedStyle Resize="None"></FocusedStyle>

                                                    <DisabledStyle Resize="None"></DisabledStyle>

                                                    <InvalidStyle Resize="None"></InvalidStyle>

                                                    <HoveredStyle Resize="None"></HoveredStyle>

                                                    <EnabledStyle Resize="None"></EnabledStyle>
                                                </DateInput>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RadioButton ID="rbSingle" runat="server" GroupName="a" Text="Single" AutoPostBack="True" OnCheckedChanged="rbSingle_CheckedChanged" />
                    <asp:RadioButton ID="rbAll" runat="server" GroupName="a" Text="All" AutoPostBack="True" OnCheckedChanged="rbAll_CheckedChanged" Checked="True" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <telerik:RadButton ID="btnGenerate" runat="server" Text="Generate Report" OnClick="btnGenerate_Click">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label17" runat="server" class="menuitembold" ForeColor="Blue" Text="Report Format"></asp:Label></td>
                <td>
                    <asp:RadioButton ID="rbtnPdf" runat="server" Text="Pdf" GroupName="b" ForeColor="Blue" Checked="True"/>
                    <asp:RadioButton ID="rbtnCrystal" runat="server" Text="Crystal" GroupName="b" ForeColor="Blue" Visible="False"/>
                    <asp:RadioButton ID="rbtnWord" runat="server" Text="Word" GroupName="b" ForeColor="Blue" Visible="False"/>
                    <asp:RadioButton ID="rbtnExcel" runat="server" Text="Excel" GroupName="b" ForeColor="Blue" Visible="False"  />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    <div>
    
        <asp:Label ID="lblMessage" runat="server" ForeColor="#990033"></asp:Label>
    
    </div>
    </form>
</body>
</html>
