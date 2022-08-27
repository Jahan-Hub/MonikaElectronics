<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemInfo.aspx.cs" Inherits="ElectronicsMS.Forms.Forms.ItemInfo" %>

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
            <scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </scripts>
        </telerik:RadScriptManager>
        <h1>Product Information</h1>
        <%--        <asp:UpdatePanel runat="server" ID="hhhhhhh">
            <ContentTemplate>--%>
        <div>

            <table class="auto-style1" style="width: 95%">
                <tr>
                    <td>
                            <asp:LinkButton ID="btnCategory" runat="server" OnClick="btnCategory_Click">Category</asp:LinkButton>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cmCategory" runat="server" Filter="Contains" DataSourceID="dsCat" DataTextField="Name" DataValueField="CatId" EmptyMessage="Select Category" AutoPostBack="True" OnSelectedIndexChanged="cmCategory_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="dsCat" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [Name], [CatId] FROM [tblCategory]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="Photo" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" Visible="False" />
                        <asp:FileUpload ID="FileUpload2" runat="server" onchange="previewFile()" OnDataBinding="FileUpload2_DataBinding" ValidateRequestMode="Inherit" Visible="False" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Item Code"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadNumericTextBox ID="txtItemCode" runat="server" Enabled="False">
                            <NegativeStyle Resize="None"></NegativeStyle>

                            <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>

                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                            <FocusedStyle Resize="None"></FocusedStyle>

                            <DisabledStyle Resize="None"></DisabledStyle>

                            <InvalidStyle Resize="None"></InvalidStyle>

                            <HoveredStyle Resize="None"></HoveredStyle>

                            <EnabledStyle Resize="None"></EnabledStyle>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Purchase Rate"></asp:Label>
                    </td>
                    <td colspan="3">
                        <telerik:RadNumericTextBox ID="txtPurchaseRate" runat="server">
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="txtItemName" runat="server" Width="350px" LabelWidth="140px" Resize="None">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Sales Rate"></asp:Label>
                    </td>
                    <td colspan="3">
                        <telerik:RadNumericTextBox ID="txtSalesRate" runat="server">
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label108" runat="server" Text="Supplier"></asp:Label>
                    </td>
                    <td>
                                            <telerik:RadComboBox ID="cmPartyName"  runat="server" EmptyMessage="Select Supplier" Width="350px" EnableLoadOnDemand="true" Filter="Contains" Height="500px" DropDownAutoWidth="Enabled" OnItemsRequested="cmPartyName_ItemsRequested" AutoPostBack="True">
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
                    <td>
                        <asp:Label ID="Label109" runat="server" Text="Min Stock"></asp:Label>
                    </td>
                    <td colspan="3">
                        <telerik:RadNumericTextBox ID="txtMinStock" runat="server">
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                            &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <telerik:RadButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  SingleClick="true" SingleClickText="Working...">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnDelete" runat="server" Text="Delete" OnClientClicked="OnClientClicked" OnClick="btnDelete_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                        </telerik:RadButton>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
        <div style="width: 100%;">
            <telerik:RadGrid ID="rgMain" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" OnSelectedIndexChanged="rgMain_SelectedIndexChanged" Width="99%" AllowPaging="True" OnNeedDataSource="rgMain_NeedDataSource" PageSize="15" AllowFilteringByColumn="True">
<GroupingSettings CaseSensitive="false" CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                    <Selecting AllowRowSelect="True" />

                </ClientSettings>
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="rowid" Display="False" FilterControlAltText="Filter rowid column" HeaderText="rowid" SortExpression="rowid" UniqueName="rowid">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ItemCode" AutoPostBackOnFilter="true" FilterControlAltText="Filter TransID column" HeaderText="Item Code" SortExpression="ItemCode" UniqueName="ItemCode">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ItemName" AutoPostBackOnFilter="true" FilterControlAltText="Filter ItemName column" HeaderText="Item Name" SortExpression="ItemName" UniqueName="ItemName">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ItemCatId" FilterControlAltText="Filter ItemCatId column" HeaderText="ItemCatId" SortExpression="ItemCatId" UniqueName="ItemCatId" Display="False">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CategoryName" AutoPostBackOnFilter="true" FilterControlAltText="Filter ChallanNo column" HeaderText="Item Category" SortExpression="CategoryName" UniqueName="CategoryName">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text=""></ModelErrorMessage>
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PurRate" FilterControlAltText="Filter Paid column" HeaderText="Purchase Rate" SortExpression="PurRate" UniqueName="PurRate" DataFormatString="{0:F2}">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                            <FooterStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SalesRate" DataFormatString="{0:F2}" DataType="System.Decimal" FilterControlAltText="Filter Due column" HeaderText="Sales Rate" SortExpression="SalesRate" UniqueName="SalesRate">
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
        <%# DataBinder.Eval(Container, "Attributes['SupplierId']")%>
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
    </form>
</body>
</html>
<script type="text/javascript">
    function previewFile() {
        var preview = document.querySelector('#<%=Image1.ClientID %>');
        var file = document.querySelector('#<%=FileUpload2.ClientID %>').files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            preview.src = reader.result;
        }

        if (file) {
            reader.readAsDataURL(file);
        } else {
            preview.src = "";
        }
    }
    function OnClientClicked(button, args) {
        if (window.confirm("Are you sure you want to delete?")) {
            button.set_autoPostBack(true);
        }
        else {
            button.set_autoPostBack(false);
        }
    }
</script>
