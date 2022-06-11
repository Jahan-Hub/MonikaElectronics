<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriceSetup.aspx.cs" Inherits="ElectronicsMS.Forms.PriceSetup" %>

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
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <h1>Customer Wise Price Setup</h1>
        <div>

            <table class="auto-style1" style="width: 70%">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Customer Name"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cmCustomerName" runat="server" Filter="Contains" Width="100%" EmptyMessage="Select Customer" EnableLoadOnDemand="true" Height="500px" DropDownAutoWidth="Enabled" OnItemsRequested="cmCustomerName_ItemsRequested" AutoPostBack="True" OnSelectedIndexChanged="cmCustomerName_SelectedIndexChanged">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 500px">
                                    <tr>
                                        <td style="font-family: Arial; font-size: 12px; width: 50px;">Code</td>
                                        <td style="font-family: Arial; font-size: 12px; width: 200px;">Name</td>
                                        <td style="font-family: Arial; font-size: 12px; width: 200px;">Address</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 500px">
                                    <tr>
                                        <td style="width: 50px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['CustId']")%></td>
                                        <td style="width: 200px; font-size: 12px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                        <td style="width: 200px; font-size: 12px;"><%# DataBinder.Eval(Container, "Attributes['Address']")%></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                                            </telerik:RadComboBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Item Category" Visible="False"></asp:Label>
                        <asp:Label ID="Label23" runat="server" Text="Item Name" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cmCategory" runat="server" Filter="Contains" DataSourceID="dsCat" DataTextField="Name" DataValueField="CatId" EmptyMessage="Select Category" AutoPostBack="True" OnSelectedIndexChanged="cmCategory_SelectedIndexChanged" Visible="False">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="dsCat" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [Name], [CatId] FROM [tblCategory]"></asp:SqlDataSource>

                        <telerik:RadComboBox ID="cmItemName" runat="server" Width="100%" Filter="Contains" AutoPostBack="True" EmptyMessage="Select Product" OnSelectedIndexChanged="cmItemName_SelectedIndexChanged" EnableLoadOnDemand="true" DropDownAutoWidth="Enabled" Height="400px" OnItemsRequested="cmItemName_ItemsRequested" Visible="False">
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" class="auto-style2">
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  SingleClick="true" SingleClickText="Working...">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <telerik:RadGrid ID="rgMain" runat="server" AutoGenerateColumns="False" AutoGenerateEditColumn="True" GridLines="Both" OnSelectedIndexChanged="rgMain_SelectedIndexChanged" Width="60%" OnNeedDataSource="rgMain_NeedDataSource" OnEditCommand="rgMain_EditCommand" OnItemDataBound="rgMain_ItemDataBound" OnItemUpdated="rgMain_ItemUpdated" OnUpdateCommand="rgMain_UpdateCommand">
            <CommandItemStyle BackColor="#F8FFFF" />
            <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
            <MasterTableView BorderWidth="0" EditMode="InPlace" EnableColumnsViewState="False" Width="100%">
                <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                <Columns>
                    <telerik:GridBoundColumn DataField="rowid" Display="False" FilterControlAltText="Filter rowid column" HeaderText="S/N" SortExpression="rowid" UniqueName="rowid">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CustId" FilterControlAltText="Filter Category column" HeaderText="Customer Id" SortExpression="CustId" UniqueName="CustId" Display="False">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text=""></ModelErrorMessage>
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CustName" FilterControlAltText="Filter CustName column" HeaderText="Customer Name" SortExpression="CustName" UniqueName="CustName" Display="False">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text=""></ModelErrorMessage>
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="ItemCode" FilterControlAltText="Filter TransID column" HeaderText="Item Code" SortExpression="ItemCode" UniqueName="ItemCode">
                        <EditItemTemplate>
                            <asp:TextBox ID="ItemCodeTextBox" runat="server" Text='<%# Bind("ItemCode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ItemCodeLabel" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="ItemName" FilterControlAltText="Filter ItemName column" HeaderText="Item Name" SortExpression="ItemName" UniqueName="ItemName">
                        <EditItemTemplate>
                            <asp:TextBox ID="ItemNameTextBox" runat="server" Text='<%# Bind("ItemName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="Price" FilterControlAltText="Filter UnitPrice column" HeaderText="Unit Price" SortExpression="Price" UniqueName="Price">
                        <EditItemTemplate>
                            <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price", "{0:N0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price", "{0:N0}") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn CancelImageUrl="Cancel.gif" FilterImageUrl="Filter.gif" InsertImageUrl="Update.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif" UpdateImageUrl="Update.gif">
                    </EditColumn>
                </EditFormSettings>
                <PagerStyle FirstPageImageUrl="PagingFirst.gif" LastPageImageUrl="PagingLast.gif" NextPageImageUrl="PagingNext.gif" PrevPageImageUrl="PagingPrev.gif" />
            </MasterTableView>
        </telerik:RadGrid>
    </form>

</body>
</html>
