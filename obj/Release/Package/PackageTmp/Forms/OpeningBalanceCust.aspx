﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpeningBalanceCust.aspx.cs" Inherits="ElectronicsMS.Forms.OpeningBalanceCust" %>

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
        <h1>Customer Opening Balance Entry</h1>
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <div>
        <table style="width:40%">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="cmPartyName" Runat="server" Width="100%" EnableLoadOnDemand="true" EmptyMessage="Select Customer" OnItemsRequested="cmPartyName_ItemsRequested" AutoPostBack="True"  Filter="Contains" Height="500px" DropDownAutoWidth="Enabled" OnSelectedIndexChanged="cmPartyName_SelectedIndexChanged">
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" style="width:450px">
                                <tr>
                                    <td style="font-family: Arial; font-size: 8px; width: 50px;">Code</td>
                                    <td style="font-family: Arial; font-size: 8px; width: 200px;">Name</td>
                                    <td style="font-family: Arial; font-size: 8px; width: 50px;">Account No</td>
                                    <td style="font-family: Arial; font-size: 8px; width: 150px;">Mobile</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" style="width: 450px">
                                <tr>
                                    <td style="width: 50px; font-size: 10px;"><%# DataBinder.Eval(Container, "Attributes['CustId']")%></td>
                                    <td style="width: 200px; font-size: 10px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                    <td style="width: 50px; font-size: 10px;"><%# DataBinder.Eval(Container, "Attributes['AccountNo']")%></td>
                                    <td style="width: 150px; font-size: 10px;"><%# DataBinder.Eval(Container, "Attributes['Mobile']")%></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </telerik:RadComboBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Voucher No"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtInvoiceNo" Runat="server" LabelWidth="64px" Resize="None" Width="160px">
                    </telerik:RadTextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Voucher  Date"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="dpVoucherDate" Runat="server" Width="100px">
                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="100%">
                            <EmptyMessageStyle Resize="None" />
                            <ReadOnlyStyle Resize="None" />
                            <FocusedStyle Resize="None" />
                            <DisabledStyle Resize="None" />
                            <InvalidStyle Resize="None" />
                            <HoveredStyle Resize="None" />
                            <EnabledStyle Resize="None" />
                        </DateInput>
                    </telerik:RadDatePicker>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Due Amount"></asp:Label>
                </td>
                <td>
                    <telerik:RadNumericTextBox ID="txtDueAmt" Runat="server">
                        <NegativeStyle Resize="None" />
                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                        <EmptyMessageStyle Resize="None" />
                        <ReadOnlyStyle Resize="None" />
                        <FocusedStyle Resize="None" />
                        <DisabledStyle Resize="None" />
                        <InvalidStyle Resize="None" />
                        <HoveredStyle Resize="None" />
                        <EnabledStyle Resize="None" />
                    </telerik:RadNumericTextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Remarks"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtRemarks" Runat="server" TextMode="MultiLine" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="3">
                    &nbsp;&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <telerik:RadButton ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"  SingleClick="true" SingleClickText="Working...">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnPrintPreview" runat="server" Text="Print Preview" Visible="False">
                    </telerik:RadButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="visibility:hidden">
                        <fieldset>
                        <legend>Received Amount as per</legend>
                        <telerik:RadGrid ID="RadGrid1" Width="100%" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource" ShowFooter="True">
                            <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                <Selecting AllowRowSelect="True" />
                                    <Scrolling UseStaticHeaders="True" />
                                </ClientSettings>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="rowid" Display="False" FilterControlAltText="Filter rowid column" HeaderText="rowid" SortExpression="rowid" UniqueName="rowid">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TrackId" Display="False" FilterControlAltText="Filter TrackId column" HeaderText="TrackId" SortExpression="TrackId" UniqueName="TrackId">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PayMode" FilterControlAltText="Filter PayMode column" HeaderText="Receive Mode" SortExpression="PayMode" UniqueName="PayMode">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ReceivedDate" FilterControlAltText="Filter PayDate column" HeaderText="Receive Date" SortExpression="ReceivedDate" UniqueName="ReceivedDate" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PayAmount" FilterControlAltText="Filter PayAmount column" HeaderText="Need to Receive" SortExpression="PayAmount" UniqueName="PayAmount" Display="False">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ReceiveAmount" FilterControlAltText="Filter PaidAmount column" HeaderText="Receive Amount" SortExpression="ReceiveAmount" UniqueName="ReceiveAmount">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DueAmount" FilterControlAltText="Filter DueAmount column" HeaderText="Due Amount" SortExpression="DueAmount" UniqueName="DueAmount" Display="False">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ChequeNo" FilterControlAltText="Filter ChequeNo column" HeaderText="Cheque No" SortExpression="ChequeNo" UniqueName="ChequeNo">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ChequeDt" FilterControlAltText="Filter ChequeDate column" HeaderText="Cheque Date" SortExpression="ChequeDt" UniqueName="ChequeDt" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DepositBank" FilterControlAltText="Filter DepositBank column" HeaderText="Deposit Bank" SortExpression="DepositBank" UniqueName="DepositBank" Visible="False">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BankName" FilterControlAltText="Filter BankName column" HeaderText="Bank Name" SortExpression="BankName" UniqueName="BankName">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ChequeDetails" FilterControlAltText="Filter ChequeDetails column" HeaderText="Cheque Details" SortExpression="ChequeDetails" UniqueName="ChequeDetails">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </fieldset>
                    </div>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </form>
</body>
</html>
<script>
    function OnClientClicked(button, args) {
        if (window.confirm("Are you sure you want to delete?")) {
            button.set_autoPostBack(true);
        }
        else {
            button.set_autoPostBack(false);
        }
    }
</script>