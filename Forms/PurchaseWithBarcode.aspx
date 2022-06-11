<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseWithBarcode.aspx.cs" Inherits="ElectronicsMS.Forms.PurchaseWithBarcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <h1>Product Purchase (Scan)</h1>
        <div>
            <table style="width: 99%">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Main Info</legend>
                            <div style="height: 45px;">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Purchase No"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPurchaseNo" runat="server" Width="100px" Enabled="False">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Supplier Name"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmPartyName" runat="server" EmptyMessage="Select Supplier" Width="100%" EnableLoadOnDemand="true" Filter="Contains" Height="500px" DropDownAutoWidth="Enabled" OnItemsRequested="cmPartyName_ItemsRequested" AutoPostBack="True" OnSelectedIndexChanged="cmPartyName_SelectedIndexChanged">
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="0" style="width: 400px">
                                                        <tr>
                                                            <td style="font-family: Arial; font-size: 12px; width: 50px;">Code</td>
                                                            <td style="font-family: Arial; font-size: 12px; width: 250px;">Name</td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" style="width: 450px">
                                                        <tr>
                                                            <td style="width: 50px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['SupplierId']")%></td>
                                                            <td style="width: 250px; font-size: 12px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Bill No"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtBillNo" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Purchase Date"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="dpPurchaseDate" runat="server" Culture="en-US" Width="100px">
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
                                    </tr>
                                    </table>
                            </div>
                        </fieldset>
                    </td>
                    <td>
                        <fieldset>
                            <legend>Pay Details</legend>
                            <div style="height: 45px;">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label24" runat="server" Text="Amount"></asp:Label>
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="lblNetAmount" runat="server" ForeColor="#006666" Text="0.00" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label15" runat="server" Text="Discount"></asp:Label>
                                                    </td>
                                                    <td class="auto-style1">
                                                        <telerik:RadNumericTextBox ID="txtDiscount" runat="server" AutoPostBack="True" Width="80px" OnTextChanged="txtDiscount_TextChanged">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label16" runat="server" Text="Paid Amount"></asp:Label>
                                                    </td>
                                                    <td class="auto-style1">
                                                        <telerik:RadNumericTextBox ID="txtPaidAmount" runat="server" AutoPostBack="True" Width="80px" OnTextChanged="txtPaidAmount_TextChanged">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label17" runat="server" Text="Due Amount"></asp:Label>
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="lblDueAmount" runat="server" ForeColor="#CC0000" Text="0.00"></asp:Label>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                        <td>
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
                            <legend>Add Product</legend>
                            <div style="height: 500px; overflow: scroll">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label36" runat="server" Text="Category"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Product Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="Unit Price"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Text="Stock Qty"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label37" runat="server" Text="Barcode Scan"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmCategory" runat="server" Filter="Contains" DataSourceID="dsCat" DataTextField="Name" DataValueField="CatId" EmptyMessage="Select Category" AutoPostBack="True" OnSelectedIndexChanged="cmCategory_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                            <asp:SqlDataSource ID="dsCat" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [Name], [CatId] FROM [tblCategory]"></asp:SqlDataSource>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmItemName" runat="server" Width="100%" AutoPostBack="True" EmptyMessage="Select Product" OnSelectedIndexChanged="cmItemName_SelectedIndexChanged" EnableLoadOnDemand="true" Filter="Contains" DropDownAutoWidth="Enabled" Height="400px" OnItemsRequested="cmItemName_ItemsRequested">
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="0" style="width: 450px">
                                                        <tr>
                                                            <td style="font-family: Arial; font-size: 12px; width: 50px;">Code</td>
                                                            <td style="font-family: Arial; font-size: 12px; width: 400px;">Name</td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" style="width: 450px">
                                                        <tr>
                                                            <td style="width: 50px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['ItemCode']")%></td>
                                                            <td style="width: 400px; font-size: 12px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="txtUnitPrice" runat="server" AutoPostBack="True" Width="80px">
                                            </telerik:RadNumericTextBox>
                                            </td>
                                        <td>
                                            <asp:Label ID="lblStock" runat="server"></asp:Label>
                                            </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtBarcode" runat="server" AutoPostBack="True" OnTextChanged="txtBarcode_TextChanged">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="7">
                                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="true" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand" OnItemDataBound="RadGrid1_ItemDataBound" ShowFooter="True" Width="100%">
                                                <GroupingSettings CaseSensitive="false" CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="rowid" FilterControlAltText="Filter rowid column" HeaderText="S/N" SortExpression="rowid" UniqueName="rowid">
                                                            <ColumnValidationSettings>
                                                                <ModelErrorMessage Text="" />
                                                            </ColumnValidationSettings>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ItemCode" FilterControlAltText="Filter ItemCode column" HeaderText="Product Code" SortExpression="ItemCode" UniqueName="ItemCode">
                                                            <ColumnValidationSettings>
                                                                <ModelErrorMessage Text="" />
                                                            </ColumnValidationSettings>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ItemName" AutoPostBackOnFilter="true" FilterControlAltText="Filter ItemName column" HeaderText="Product Name" SortExpression="ItemName" UniqueName="ItemName">
                                                            <ColumnValidationSettings>
                                                                <ModelErrorMessage Text="" />
                                                            </ColumnValidationSettings>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CatName" FilterControlAltText="Filter CatName column" HeaderText="Category Name" SortExpression="CatName" UniqueName="CatName">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="UnitRate" DataType="System.Decimal" FilterControlAltText="Filter UnitRate column" HeaderText="Unit Price" SortExpression="UnitRate" UniqueName="UnitRate" DataFormatString="{0:N0}">
                                                            <ColumnValidationSettings>
                                                                <ModelErrorMessage Text="" />
                                                            </ColumnValidationSettings>
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Barcode" FilterControlAltText="Filter Barcode column" HeaderText="Barcode" SortExpression="Barcode" UniqueName="Barcode">
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
                            <legend>Purchase Details</legend>
                            <div style="height: 500px; overflow: scroll">
                                <telerik:RadGrid ID="rgMain" runat="server" AllowFilteringByColumn="true" AllowMultiRowSelection="True" AutoGenerateColumns="False" OnSelectedIndexChanged="rgMain_SelectedIndexChanged" Width="100%">
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
                                            <telerik:GridBoundColumn DataField="PurID" FilterControlAltText="Filter VoucharNo column" HeaderText="Purchase Id" SortExpression="PurID" UniqueName="PurID" Display="False">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text="" />
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="BillNo" FilterControlAltText="Filter ChallanNo column" HeaderText="Bill No" SortExpression="BillNo" UniqueName="BillNo">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text="" />
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PurDate" FilterControlAltText="Filter TransactionDate column" HeaderText="Purchase Date" SortExpression="PurDate" UniqueName="PurDate" DataFormatString="{0:dd/MM/yyyy}">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text="" />
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SupplierName" AutoPostBackOnFilter="true" FilterControlAltText="Filter CustomerName column" HeaderText="Supplier Name" SortExpression="SupplierName" UniqueName="SupplierName">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text="" />
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NetAmount" FilterControlAltText="Filter NetAmount column" HeaderText="Total" SortExpression="NetAmount" UniqueName="NetAmount" DataFormatString="{0:N0}" DataType="System.Decimal">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text="" />
                                                </ColumnValidationSettings>
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Discount" DataFormatString="{0:N0}" HeaderText="Discount" SortExpression="Discount" UniqueName="Discount" DataType="System.Decimal" FilterControlAltText="Filter Discount column">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Paid" DataFormatString="{0:N0}" DataType="System.Decimal" FilterControlAltText="Filter Paid column" HeaderText="Paid" SortExpression="Paid" UniqueName="Paid">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Due" DataFormatString="{0:N0}" DataType="System.Decimal" FilterControlAltText="Filter Due column" HeaderText="Due" SortExpression="Due" UniqueName="Due">
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
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  SingleClick="true" SingleClickText="Working...">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Visible="False">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClicked="OnClientClicked" Text="Delete">
                        </telerik:RadButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
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
