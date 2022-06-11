<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trnMoneyReceive.aspx.cs" Inherits="ElectronicsMS.Forms.trnMoneyReceive" %>

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
        <h1>Money Receive</h1>
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <div>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmPartyName" Filter="Contains" runat="server" Width="100%" EnableLoadOnDemand="true" EmptyMessage="Select Customer" OnItemsRequested="cmPartyName_ItemsRequested" AutoPostBack="True" Height="500px" DropDownAutoWidth="Enabled">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" style="width: 600px">
                                            <tr>
                                                <td style="font-family: Arial; font-size: 12px; width: 50px;">Code</td>
                                                <td style="font-family: Arial; font-size: 12px; width: 200px;">Name</td>
<%--                                                <td style="font-family: Arial; font-size: 12px; width: 200px;">Address</td--%>
                                                <td style="font-family: Arial; font-size: 12px; width: 150px;">Mobile</td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" style="width: 600px">
                                            <tr>
                                                <td style="width: 50px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['CustCode']")%></td>
                                                <td style="width: 200px; font-size: 12px;"><%# DataBinder.Eval(Container, "Text")%></td>
<%--                                                <td style="width: 200px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['Address']")%></td>--%>
                                                <td style="width: 150px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['Mobile']")%></td>
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
                                <asp:Label ID="Label13" runat="server" Text="Receive Mode"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmReceiveMode" Filter="Contains" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmReceiveMode_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Cash" Value="Cash" />
                                        <telerik:RadComboBoxItem runat="server" Text="BKash" Value="BKash" />
                                        <telerik:RadComboBoxItem runat="server" Text="Nagad" Value="Nagad" />
                                        <telerik:RadComboBoxItem runat="server" Text="Rocket" Value="Rocket" />
                                        <telerik:RadComboBoxItem runat="server" Text="Cheque" Value="Cheque" />
                                        <telerik:RadComboBoxItem runat="server" Text="Bank Transfer" Value="Bank Transfer" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td colspan="2" rowspan="6">
                                <fieldset>
                                    <legend>Cheque Details &amp; Others</legend>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="Cheque No"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtChequeNo" runat="server" LabelWidth="64px" Resize="None" Width="160px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="Cheque Date"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="dpCheckDate" DateInput-DateFormat="dd/MM/yyyy" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="Issue Bank"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <telerik:RadTextBox ID="txtIssueBank" runat="server" Width="100%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text="Deposit Bank"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <telerik:RadTextBox ID="txtDepositBank" runat="server" Width="100%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="Check Details"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <telerik:RadTextBox ID="txtCheckDetails" runat="server" Width="100%">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>&nbsp;</td>
                            <td style="margin-left: 40px">&nbsp;</td>
                            <td style="margin-left: 40px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Receive Date"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dpReceiveDate" runat="server" DateInput-DateFormat="dd/MM/yyyy">
                                </telerik:RadDatePicker>
                            </td>
                            <td style="margin-left: 40px">&nbsp;</td>
                            <td style="margin-left: 40px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Invoice No"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmSalesNo" runat="server" AutoPostBack="True" EmptyMessage="Select Voucher No" EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="cmSalesNo_ItemsRequested" OnSelectedIndexChanged="cmSalesNo_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td style="margin-left: 40px">&nbsp;</td>
                            <td style="margin-left: 40px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Need to Receive"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtNeedToReceive" runat="server" Enabled="False">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td rowspan="3">&nbsp;</td>
                            <td rowspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Receive Amount"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtReceiveAmt" runat="server" AutoPostBack="True" OnTextChanged="txtReceiveAmt_TextChanged">
                                </telerik:RadNumericTextBox>
                                <telerik:RadCheckBox ID="ckDiscount" runat="server" Text="Discount?">
                                </telerik:RadCheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Due"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDue" runat="server" ForeColor="#CC0066"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Particulars"></asp:Label>
                            </td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="txtRemarks" runat="server" Width="100%">
                                </telerik:RadTextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
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
                                <telerik:RadButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnPrintPreview" runat="server" Text="Print Preview">
                                </telerik:RadButton>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <fieldset>
                                    <legend>Received Amount as per</legend>
                                    <telerik:RadGrid ID="RadGrid1" Width="100%" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource" ShowFooter="True" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
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
                                                <telerik:GridBoundColumn DataField="track_id" Display="False" FilterControlAltText="Filter TrackId column" HeaderText="TrackId" SortExpression="track_id" UniqueName="track_id">
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
                                                <telerik:GridBoundColumn DataField="PayAmount" FilterControlAltText="Filter PayAmount column" HeaderText="Need to Receive" SortExpression="PayAmount" UniqueName="PayAmount" Display="False" DataFormatString="{0:N0}">
                                                    <ColumnValidationSettings>
                                                        <ModelErrorMessage Text="" />
                                                    </ColumnValidationSettings>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <FooterStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ReceiveAmount" FilterControlAltText="Filter PaidAmount column" HeaderText="Receive Amount" SortExpression="ReceiveAmount" UniqueName="ReceiveAmount" DataFormatString="{0:N0}">
                                                    <ColumnValidationSettings>
                                                        <ModelErrorMessage Text="" />
                                                    </ColumnValidationSettings>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <FooterStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DueAmount" FilterControlAltText="Filter DueAmount column" HeaderText="Due Amount" SortExpression="DueAmount" UniqueName="DueAmount" Display="False" DataFormatString="{0:N0}">
                                                    <ColumnValidationSettings>
                                                        <ModelErrorMessage Text="" />
                                                    </ColumnValidationSettings>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <FooterStyle HorizontalAlign="Right" />
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
                                                <telerik:GridBoundColumn DataField="IssueBank" FilterControlAltText="Filter BankName column" HeaderText="Issue Bank" SortExpression="IssueBank" UniqueName="IssueBank">
                                                    <ColumnValidationSettings>
                                                        <ModelErrorMessage Text="" />
                                                    </ColumnValidationSettings>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DepositBank" FilterControlAltText="Filter DepositBank column" HeaderText="Deposit Bank" SortExpression="DepositBank" UniqueName="DepositBank">
                                                    <ColumnValidationSettings>
                                                        <ModelErrorMessage Text="" />
                                                    </ColumnValidationSettings>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="IsDiscount" FilterControlAltText="Filter IsDiscount column" HeaderText="Is Discount?	" SortExpression="IsDiscount" UniqueName="IsDiscount">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </fieldset>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:HiddenField ID="hfTrackId" runat="server" />
                                <asp:HiddenField ID="hfPreviousDue" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
