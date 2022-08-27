<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="ElectronicsMS.Forms.Forms.Sales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

<%--        <asp:UpdatePanel runat="server" ID="up123">
            <ContentTemplate>--%>

                <h1>Product Sales (Scan)</h1>

                <div>
                    <table class="auto-style1" style="width: 99%">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>Main Info</legend>
                                    <div style="height: 140px;">
                                        <table class="auto-style1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Sales/Invoice No"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtSalesID" runat="server" Width="120px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                    <asp:Label ID="Label4" runat="server" Text="Sales Date"></asp:Label>
                                                    <telerik:RadDatePicker ID="dpSalesDt" runat="server" Culture="en-US" Width="100px">
                                                        <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"></Calendar>

                                                        <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                            <FocusedStyle Resize="None"></FocusedStyle>

                                                            <DisabledStyle Resize="None"></DisabledStyle>

                                                            <InvalidStyle Resize="None"></InvalidStyle>

                                                            <HoveredStyle Resize="None"></HoveredStyle>

                                                            <EnabledStyle Resize="None"></EnabledStyle>
                                                        </DateInput>

                                                        <DatePopupButton></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label109" runat="server" Text="Instalment"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadComboBox ID="cmInstallment" runat="server" EnableLoadOnDemand="true" Filter="Contains" Width="120px" EmptyMessage="Select" OnItemsRequested="cmInstallment_ItemsRequested" AutoPostBack="True" OnSelectedIndexChanged="cmInstallment_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:Label ID="lblDidFee" runat="server" Text="Deed Fee"></asp:Label>
                                                    <telerik:RadNumericTextBox ID="txtDeedFee" runat="server" AutoPostBack="True" Width="80px" OnTextChanged="txtDiscount_TextChanged">
                                                    </telerik:RadNumericTextBox>
                                                    <telerik:RadButton ID="btnCalculateInstallment" runat="server" OnClick="btnCalculateInstallment_Click" Text="Calculate Installment">
                                                    </telerik:RadButton>
                                                </td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:LinkButton ID="btnCustomerName" runat="server" OnClick="btnCustomerName_Click">Customer Name</asp:LinkButton>
                                                </td>
                                                <td class="auto-style2" colspan="4">
                                                    <telerik:RadComboBox ID="cmCustomerName" runat="server" Filter="Contains" Width="100%" EmptyMessage="Select Customer" EnableLoadOnDemand="true" Height="500px" DropDownAutoWidth="Enabled" OnItemsRequested="cmCustomerName_ItemsRequested" AutoPostBack="True" OnSelectedIndexChanged="cmCustomerName_SelectedIndexChanged">
                                                        <HeaderTemplate>
                                                            <table cellpadding="0" cellspacing="0" style="width: 750px">
                                                                <tr>
                                                                    <td style="font-family: Arial; font-size: 12px; width: 50px;">Code</td>
                                                                    <td style="font-family: Arial; font-size: 12px; width: 200px;">Name</td>
                                                                    <td style="font-family: Arial; font-size: 12px; width: 200px;">Address</td>
                                                                    <td style="font-family: Arial; font-size: 12px; width: 150px;">Mobile</td>
                                                                    <td style="font-family: Arial; font-size: 12px; width: 100px;">Balance</td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" style="width: 750px">
                                                                <tr>
                                                                    <td style="width: 50px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['CustId']")%></td>
                                                                    <td style="width: 200px; font-size: 12px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                                                    <td style="width: 200px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['Address']")%></td>
                                                                    <td style="width: 150px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['Mobile']")%></td>
                                                                    <td style="width: 100px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['Balance']")%></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style2">&nbsp;</td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </fieldset>

                            </td>
                            <td>
                                <fieldset>
                                    <legend>Pay Details</legend>
                                    <div style="height: 140px;">
                                        <table class="auto-style1">
                                            <tr>
                                                <td>
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td>
                                                                <table class="auto-style1">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label24" runat="server" Text="Amount"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNetAmount" runat="server" ForeColor="#006666" Text="0.00" Font-Bold="True"></asp:Label>
                                                                        </td>
                                                                        <td rowspan="4">
                                                                            <fieldset>
                                                                                <legend>Granter Information</legend>

                                                                                <table class="auto-style1">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label111" runat="server" Text="Name"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <telerik:RadTextBox ID="txtGranterName" runat="server" Width="100%" Enabled="False">
                                                                                            </telerik:RadTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label112" runat="server" Text="Father Name"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <telerik:RadTextBox ID="txtGranterFatherName" runat="server" Width="100%" Enabled="False">
                                                                                            </telerik:RadTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label113" runat="server" Text="Mobile"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <telerik:RadTextBox ID="txtGranterMobile" runat="server" Width="100%" Enabled="False">
                                                                                            </telerik:RadTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label114" runat="server" Text="Address"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <telerik:RadTextBox ID="txtGranterAddress" runat="server" Width="100%" Enabled="False">
                                                                                            </telerik:RadTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </fieldset>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label15" runat="server" Text="Discount"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <telerik:RadNumericTextBox ID="txtDiscount" runat="server" AutoPostBack="True" Width="80px" OnTextChanged="txtDiscount_TextChanged">
                                                                            </telerik:RadNumericTextBox>
                                                                            <asp:Label ID="Label110" runat="server" Text="Percent"></asp:Label>
                                                                            <telerik:RadNumericTextBox ID="txtPercent" runat="server" AutoPostBack="True" Width="50px" OnTextChanged="txtPercent_TextChanged">
                                                                            </telerik:RadNumericTextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label16" runat="server" Text="Paid Amount"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <telerik:RadNumericTextBox ID="txtPaidAmount" runat="server" AutoPostBack="True" Width="80px" OnTextChanged="txtPaidAmount_TextChanged">
                                                                            </telerik:RadNumericTextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label17" runat="server" Text="Due Amount"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblDueAmount" runat="server" ForeColor="#CC0000" Text="0.00"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>Scan Product</legend>
                                    <div style="height: 500px; overflow: scroll">
                                        <table class="auto-style1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label36" runat="server" Text="Scan Barcode"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtBarcode" runat="server" AutoPostBack="True" OnTextChanged="txtBarcode_TextChanged">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand" OnItemDataBound="RadGrid1_ItemDataBound" ShowFooter="True" Width="100%">
                                                        <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="rowid" Display="True" FilterControlAltText="Filter rowid column" HeaderText="S/N" SortExpression="rowid" UniqueName="rowid">
                                                                    <ColumnValidationSettings>
                                                                        <ModelErrorMessage Text="" />
                                                                    </ColumnValidationSettings>
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ItemCode" FilterControlAltText="Filter ItemCode column" HeaderText="Code" SortExpression="ItemCode" UniqueName="ItemCode">
                                                                    <ColumnValidationSettings>
                                                                        <ModelErrorMessage Text="" />
                                                                    </ColumnValidationSettings>
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="CatName" FilterControlAltText="Filter CatName column" HeaderText="Category Name" SortExpression="CatName" UniqueName="CatName">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter ItemName column" HeaderText="Product Name" SortExpression="ItemName" UniqueName="ItemName">
                                                                    <ColumnValidationSettings>
                                                                        <ModelErrorMessage Text="" />
                                                                    </ColumnValidationSettings>
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="UnitPrice" DataType="System.Decimal" FilterControlAltText="Filter UnitRate column" HeaderText="Unit Price" SortExpression="UnitPrice" UniqueName="UnitPrice" DataFormatString="{0:N0}">
                                                                    <ColumnValidationSettings>
                                                                        <ModelErrorMessage Text="" />
                                                                    </ColumnValidationSettings>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="Barcode" FilterControlAltText="Filter YardQty column" HeaderText="Barcode" SortExpression="Barcode" UniqueName="Barcode">
                                                                    <ColumnValidationSettings>
                                                                        <ModelErrorMessage Text="" />
                                                                    </ColumnValidationSettings>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn DataField="Delete" FilterControlAltText="Filter Delete column" HeaderText="Delete" SortExpression="Delete" UniqueName="Delete">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="DeleteTextBox" runat="server" Text='<%# Bind("Delete") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="rbtDeleteGrid" runat="server" ImageUrl="~/Images/Delete.png" OnClick="rbtDeleteGrid_Click" TabIndex="5" ToolTip="Delete" CommandName="GridDelete" />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </fieldset>
                            </td>
                            <td>
                                <fieldset>
                                    <legend>Sales Details</legend>
                                    <div style="height: 500px; overflow: scroll">
                                        <telerik:RadGrid ID="rgMain" runat="server" AllowFilteringByColumn="true" AllowMultiRowSelection="True" AutoGenerateColumns="False" OnSelectedIndexChanged="rgMain_SelectedIndexChanged" Width="100%" OnNeedDataSource="rgMain_NeedDataSource">
                                            <GroupingSettings CaseSensitive="false" CollapseAllTooltip="Collapse all groups"></GroupingSettings>

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
                                                    <telerik:GridBoundColumn DataField="SalesId" AutoPostBackOnFilter="true" FilterControlAltText="Filter VoucharNo column" HeaderText="Sales Id" SortExpression="SalesId" UniqueName="SalesId">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text="" />
                                                        </ColumnValidationSettings>
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="SalesDate" AutoPostBackOnFilter="true" FilterControlAltText="Filter TransactionDate column" HeaderText="Sales Date" SortExpression="SalesDate" UniqueName="SalesDate" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text="" />
                                                        </ColumnValidationSettings>
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CustomerName" AutoPostBackOnFilter="true" FilterControlAltText="Filter CustomerName column" HeaderText="Customer Name" SortExpression="CustomerName" UniqueName="CustomerName">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text="" />
                                                        </ColumnValidationSettings>
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="NetAmount" AutoPostBackOnFilter="true" FilterControlAltText="Filter NetAmount column" HeaderText="Total" SortExpression="NetAmount" UniqueName="NetAmount" DataFormatString="{0:N0}" DataType="System.Decimal">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text="" />
                                                        </ColumnValidationSettings>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Discount" AutoPostBackOnFilter="true" DataFormatString="{0:N0}" HeaderText="Discount" SortExpression="Discount" UniqueName="Discount" DataType="System.Decimal" FilterControlAltText="Filter Discount column">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                                        </ColumnValidationSettings>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="LabourCost" AutoPostBackOnFilter="true" FilterControlAltText="Filter LabourCost column" HeaderText="Labour Cost" SortExpression="LabourCost" UniqueName="LabourCost" DataFormatString="{0:N0}" DataType="System.Decimal" Display="False">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text="" />
                                                        </ColumnValidationSettings>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Paid" AutoPostBackOnFilter="true" DataFormatString="{0:N0}" DataType="System.Decimal" FilterControlAltText="Filter Paid column" HeaderText="Paid" SortExpression="Paid" UniqueName="Paid">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                                        </ColumnValidationSettings>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Due" AutoPostBackOnFilter="true" DataFormatString="{0:N0}" DataType="System.Decimal" FilterControlAltText="Filter Due column" HeaderText="Due" SortExpression="Due" UniqueName="Due">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                                        </ColumnValidationSettings>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </div>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label></td>
                            <td>
                                <asp:HiddenField ID="hfOnlyPrint" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadButton ID="btnPrintPreview" SingleClick="true" SingleClickText="Working..." runat="server" Text="Print Preview" OnClick="btnPrintPreview_Click">
                                </telerik:RadButton>
                                <asp:CheckBox ID="ckDiscountYN" runat="server" Text="With Discount" />
                                <telerik:RadButton ID="btnDelete" runat="server" SingleClick="true" SingleClickText="Working..." OnClick="btnDelete_Click" OnClientClicked="OnClientClicked" Text="Delete">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>

                <%# DataBinder.Eval(Container, "Attributes['CustId']")%>

                <telerik:RadWindow ID="RadWindow1" runat="server" Height="200px" Width="500px" ShowOnTopWhenMaximized="false" VisibleTitlebar="False">
                    <ContentTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:Label ID="Label106" runat="server" Text="Code"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtCodeMaster" runat="server" Enabled="False">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblInsertType" runat="server" ForeColor="#CC0000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label107" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <telerik:RadTextBox ID="txtNameMaster" Width="250px" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTypeName" runat="server"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <telerik:RadTextBox ID="txtMobileNo" runat="server" Width="250px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAddress" runat="server">Address</asp:Label>
                                </td>
                                <td colspan="2">
                                    <telerik:RadTextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="250px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <telerik:RadButton ID="btnSaveMaster" runat="server" OnClick="btnSaveMaster_Click" Text="Save">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCancelMaster" runat="server" OnClick="btnCancelMaster_Click" Text="Cancel">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblMessagePopup" runat="server" ForeColor="#CC0000"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadWindow>

                <telerik:RadWindow ID="rwInstallment" runat="server" Height="500px" Width="700px" ShowOnTopWhenMaximized="false" VisibleTitlebar="False">
                    <ContentTemplate>
                        <telerik:RadGrid ID="rgInstallment" runat="server" AutoGenerateColumns="False" GridLines="Both" OnEditCommand="rgInstallment_EditCommand" OnItemDataBound="rgInstallment_ItemDataBound" OnItemUpdated="rgInstallment_ItemUpdated" OnNeedDataSource="rgInstallment_NeedDataSource" OnUpdateCommand="rgInstallment_UpdateCommand" ShowFooter="True" Width="600px">
                            <CommandItemStyle BackColor="#F8FFFF" />
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                            <MasterTableView BorderWidth="0" EditMode="InPlace" EnableColumnsViewState="False" Width="100%">
                                <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="rowid" FilterControlAltText="Filter rowid column" HeaderText="S/L" SortExpression="rowid" UniqueName="rowid" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustId" FilterControlAltText="Filter CustId column" HeaderText="CustId" SortExpression="CustId" UniqueName="CustId" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TotalAmount" FilterControlAltText="Filter TotalAmount column" HeaderText="TotalAmount" SortExpression="TotalAmount" UniqueName="TotalAmount" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InstallNo" FilterControlAltText="Filter InstallNo column" HeaderText="Installment No" SortExpression="InstallNo" UniqueName="InstallNo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InstallDate" DataFormatString="{0: dd-MM-yyyy}" FilterControlAltText="Filter InstallDate column" HeaderText="Installment Date" SortExpression="InstallDate" UniqueName="InstallDate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InstallAmt" FilterControlAltText="Filter InstallAmt column" HeaderText="Installment Amount" SortExpression="InstallAmt" UniqueName="InstallAmt" DataFormatString="{0:#.##}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="track_id" Display="False" FilterControlAltText="Filter track_id column" HeaderText="track_id" SortExpression="track_id" UniqueName="track_id">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn CancelImageUrl="Cancel.gif" FilterImageUrl="Filter.gif" InsertImageUrl="Update.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif" UpdateImageUrl="Update.gif">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle FirstPageImageUrl="PagingFirst.gif" LastPageImageUrl="PagingLast.gif" NextPageImageUrl="PagingNext.gif" PrevPageImageUrl="PagingPrev.gif" />
                            </MasterTableView>
                            <PagerStyle FirstPageImageUrl="PagingFirst.gif" LastPageImageUrl="PagingLast.gif" NextPageImageUrl="PagingNext.gif" PrevPageImageUrl="PagingPrev.gif" />
                            <FilterMenu EnableEmbeddedSkins="False">
                            </FilterMenu>
                            <HeaderContextMenu EnableEmbeddedSkins="False">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        <asp:Label ID="lblMessageInstallment" runat="server" ForeColor="#CC0066"></asp:Label>
                        <br />
                        <telerik:RadButton ID="btnSaveInstallment" runat="server" OnClick="btnSaveInstallment_Click" Text="Save Installment" SingleClick="true" SingleClickText="Working...">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancel">
                        </telerik:RadButton>
                        <br />

                    </ContentTemplate>
                </telerik:RadWindow>

<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>

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

