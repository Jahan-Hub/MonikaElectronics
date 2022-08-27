<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpeningStock.aspx.cs" Inherits="ElectronicsMS.Forms.Forms.OpeningStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        </style>
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
        <h1>Opening Stock</h1>
    <div>
    <table class="auto-style1" style="width:80%">
            <tr>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>
                    <asp:Label ID="Label1" runat="server" Text="Product Category"></asp:Label>
                            </td>
                            <td>
                                                    <telerik:RadComboBox ID="cmCategory" Runat="server" Filter="Contains" DataSourceID="dsCat" DataTextField="Name" DataValueField="CatId" EmptyMessage="Select Category" AutoPostBack="True" OnSelectedIndexChanged="cmCategory_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:SqlDataSource ID="dsCat" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [Name], [CatId] FROM [tblCategory]"></asp:SqlDataSource>
                            </td>
                            <td>
                    <asp:Label ID="Label99" runat="server" Text="Entry Date"></asp:Label>
                            </td>
                            <td>
                    <telerik:RadDatePicker ID="dpEntryDate" Runat="server" Culture="en-US" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                            </td>
                            <td>
                    <asp:Label ID="lblOperationMode" runat="server" ForeColor="#CC0000"></asp:Label>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Label ID="Label9" runat="server" Text="Product Name"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmItemName" Runat="server" Width="100%" Filter="Contains" AutoPostBack="True" EmptyMessage="Select Product" EnableLoadOnDemand="true" DropDownAutoWidth="Enabled" Height="400px">
                                    <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 450px">
                                        <tr>
                                            <td style="font-family: Arial; font-size: 12px; width: 50px;">Code</td>
                                            <td style="font-family: Arial; font-size: 12px; width: 150px;">Alias</td>
                                            <td style="font-family: Arial; font-size: 12px; width: 250px;">Name</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 450px">
                                        <tr>
                                            <td style="width: 50px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['ItemCode']")%></td>
                                            <td style="width: 150px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['ItemAlias']")%></td>
                                           <td style="width: 250px; font-size: 12px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                </telerik:RadComboBox>
                            </td>
                            <td>
                    <asp:Label ID="Label35" runat="server" Text="Lot Number"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtLotNumber" Runat="server">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Label ID="Label2" runat="server" Text="Stock Qty"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtStockQty" Runat="server">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                    <asp:Label ID="Label97" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td>
                    <telerik:RadTextBox ID="txtRemarks" Runat="server" TextMode="MultiLine" Width="100%" LabelWidth="100px" Resize="None">
                        <EmptyMessageStyle Resize="None" />
                        <ReadOnlyStyle Resize="None" />
                        <FocusedStyle Resize="None" />
                        <DisabledStyle Resize="None" />
                        <InvalidStyle Resize="None" />
                        <HoveredStyle Resize="None" />
                        <EnabledStyle Resize="None" />
                    </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="6">
                                <asp:HiddenField ID="hfTrackId" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label></td>
            </tr>
            <tr>
                <td><telerik:RadButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  SingleClick="true" SingleClickText="Working...">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                            </telerik:RadButton>
                            </td></td>
            </tr>
        </table>
    </div>
        <div style="width:80%;">
        <telerik:RadGrid ID="rgMain" runat="server" AllowPaging="True" AllowMultiRowSelection="True" AutoGenerateColumns="False" OnSelectedIndexChanged="rgMain_SelectedIndexChanged" OnNeedDataSource="rgMain_NeedDataSource">
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
                    <telerik:GridBoundColumn DataField="SrlNo" FilterControlAltText="Filter VoucharNo column" HeaderText="Srl No" SortExpression="SrlNo" UniqueName="SrlNo">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Category Name" SortExpression="Name" UniqueName="Name">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LotNumber" FilterControlAltText="Filter ChallanNo column" HeaderText="Lot Number" SortExpression="LotNumber" UniqueName="LotNumber">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter ItemName column" HeaderText="Item Name" SortExpression="ItemName" UniqueName="ItemName">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EntryDate" FilterControlAltText="Filter TransactionDate column" HeaderText="Entry Date" SortExpression="EntryDate" UniqueName="EntryDate" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ItemCode" FilterControlAltText="Filter CostHeadName column" HeaderText="Item Code" SortExpression="ItemCode" UniqueName="ItemCode" Display="False">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OpeningStockQty" FilterControlAltText="Filter Due column" HeaderText="Stock Qty" SortExpression="OpeningStockQty" UniqueName="OpeningStockQty" DataFormatString="{0:F2}" DataType="System.Decimal">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Remarks" FilterControlAltText="Filter CostElementName column" HeaderText="Remarks" SortExpression="Remarks" UniqueName="Remarks">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    </form>

</body>

</html>
