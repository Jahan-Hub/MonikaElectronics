<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="ElectronicsMS.Forms.Forms.CustomerInfo" %>

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
        <h1>Customer Information</h1>
        <%--<asp:UpdatePanel ID="upMain" runat="server">
    <ContentTemplate>--%>
    <div>
    <table class="auto-style1" style="width:100%">
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Customer Code"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtCustCode" Runat="server" Width="200px" LabelWidth="40px" Resize="None" EmptyMessage="Auto Generated Id" Enabled="False">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnThana" runat="server" OnClick="btnThana_Click">Thana</asp:LinkButton>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmThana" Filter="Contains" EnableLoadOnDemand="true" Runat="server" Width="200px" AutoPostBack="True" DataSourceID="dsThana" DataTextField="Name" DataValueField="ThanaId" EmptyMessage="Select Thana" OnSelectedIndexChanged="cmThana_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="dsThana" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ThanaId], [Name] FROM [tblThanas] order by [Name]">
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
                            <asp:LinkButton ID="btnVillage" runat="server" OnClick="btnVillage_Click">Village</asp:LinkButton>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmVillage" EnableLoadOnDemand="true" Filter="Contains" Runat="server" Width="200px" DataSourceID="dsVill" DataTextField="Name" DataValueField="ViId" EmptyMessage="Select Village" AutoPostBack="True">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="dsVill" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ViId], [Name] FROM [tblVillages] WHERE ([ThanaId] = @ThanaId) order by [Name]">
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
                        <td>
                            <telerik:RadComboBox ID="cmFather" Runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Father" Value="Father" />
                                    <telerik:RadComboBoxItem runat="server" Text="Husband" Value="Husband" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtFatherName" Runat="server" Width="200px" LabelWidth="80px" Resize="None">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label60" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtAddress" Runat="server" Width="200px" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label110" runat="server" Text="Account No"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtAccountNo" Runat="server" Width="200px" LabelWidth="80px" Resize="None">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label73" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtMobile" Runat="server" Width="200px">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Is Special?"></asp:Label></td>
                        <td>
                            <asp:CheckBox ID="ckSpecial" runat="server" Text="Special" /></td>
                        <td>
                            <asp:Label ID="Label111" runat="server" Text="Is Dealer"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="ckDealer" runat="server" Text="Dealer" /></td>
                        <td>
                            &nbsp;</td>
                        <td>
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
                         <td colspan="4">
                            <telerik:RadButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  SingleClick="true" SingleClickText="Working...">
                            </telerik:RadButton>
                              <telerik:RadButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click">
                            </telerik:RadButton>
                             <telerik:RadButton ID="btnDelete" runat="server" OnClientClicked="OnClientClicked" OnClick="btnDelete_Click" Text="Delete">
                             </telerik:RadButton>
                        <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                        </telerik:RadButton>
                        </td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                    </tr>
                    </table>
    </div>
        <telerik:RadGrid ID="RadGrid1" runat="server" GroupingSettings-CaseSensitive="false" AutoGenerateColumns="False" Width="99%" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource" AllowPaging="True" PageSize="15">
<GroupingSettings CaseSensitive="false" CollapseAllTooltip="Collapse all groups"></GroupingSettings>

             <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                <Selecting AllowRowSelect="True" />
                    <Scrolling UseStaticHeaders="True" />
                </ClientSettings>
            <MasterTableView EditFormSettings-EditColumn-AutoPostBackOnFilter="true">
                <Columns>
                    <telerik:GridBoundColumn DataField="rowid" Display="False" FilterControlAltText="Filter rowid column" HeaderText="rowid" SortExpression="rowid" UniqueName="rowid">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CustId" AutoPostBackOnFilter="true" FilterControlAltText="Filter CustId column" HeaderText="Customer Id" SortExpression="CustId" UniqueName="CustId">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Mobile" AutoPostBackOnFilter="true" FilterControlAltText="Filter Mobile column" HeaderText="Mobile" SortExpression="Mobile" UniqueName="Mobile">
                        <ColumnValidationSettings>
                            <ModelErrorMessage Text="" />
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <%--    </ContentTemplate>
</asp:UpdatePanel>--%>
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
                                    <telerik:RadComboBox ID="cmCommon" runat="server" AutoPostBack="True" EnableLoadOnDemand="True" ErrorMessage="Select District" Filter="Contains" Height="400px" OnItemsRequested="cmCommon_ItemsRequested" TabIndex="25" Width="250px">
                                    </telerik:RadComboBox>
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
    function OnClientClicked(button, args) {
        if (window.confirm("Are you sure you want to delete?")) {
            button.set_autoPostBack(true);
        }
        else {
            button.set_autoPostBack(false);
        }
    }
</script>