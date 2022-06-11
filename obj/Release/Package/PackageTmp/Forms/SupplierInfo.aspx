<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierInfo.aspx.cs" Inherits="ElectronicsMS.Forms.SupplierInfo" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css"> 
        .auto-style1 {
            height: 26px;
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
        <h1>Supplier Information</h1>
        <%--<asp:UpdatePanel ID="upMain" runat="server">
    <ContentTemplate>--%>
    <div>
    <table class="auto-style1" style="width:100%">
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Supplier Code"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtCustCode" Runat="server" Width="200px" LabelWidth="40px" Resize="None" EmptyMessage="Auto Generated Id" Enabled="False">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label80" runat="server" Text="Thana"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmThana" Filter="Contains" Runat="server" Width="200px" AutoPostBack="True" DataSourceID="dsThana" DataTextField="Name" DataValueField="ThanaId" EmptyMessage="Select Thana" OnSelectedIndexChanged="cmThana_SelectedIndexChanged" AppendDataBoundItems="True">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="dsThana" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ThanaId], [Name] FROM [tblThanas]">
                            </asp:SqlDataSource>   
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtName" Runat="server" Width="200px" LabelWidth="80px" Resize="None">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label78" runat="server" Text="Village"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmVillage" Filter="Contains" Runat="server" Width="200px" DataSourceID="dsVill" DataTextField="Name" DataValueField="ViId" EmptyMessage="Select Village" AutoPostBack="True" AppendDataBoundItems="True">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="dsVill" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ViId], [Name] FROM [tblVillages] WHERE ([ThanaId] = @ThanaId)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmThana" Name="ThanaId" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource> 
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label73" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <telerik:RadTextBox ID="txtMobile" Runat="server" Width="200px" MaxLength="14">
                            </telerik:RadTextBox>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label60" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <telerik:RadTextBox ID="txtAddress" Runat="server" Width="200px" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </td>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="auto-style1">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                         <td colspan="6">
                            <telerik:RadButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  SingleClick="true" SingleClickText="Working...">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click">
                            </telerik:RadButton>
                             <telerik:RadButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClicked="OnClientClicked" Text="Delete">
                             </telerik:RadButton>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    </table>
    </div>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" Width="99%" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource" AllowPaging="True" PageSize="15">
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
                    <telerik:GridBoundColumn DataField="SupplierId" FilterControlAltText="Filter CustId column" HeaderText="Supplier Id" SortExpression="SupplierId" UniqueName="SupplierId">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Mobile" FilterControlAltText="Filter Mobile column" HeaderText="Mobile" SortExpression="Mobile" UniqueName="Mobile">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <%--    </ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
<script type="text/javascript">
    function OnClientClicked(button, args) {
        if (window.confirm("Are you sure you want to delete?")) {
            button.set_autoPostBack(true);
        }
        else {
            button.set_autoPostBack(false);
        }
    }
</script>
