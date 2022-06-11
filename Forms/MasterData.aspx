<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterData.aspx.cs" Inherits="ElectronicsMS.Forms.MasterData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            width: 100%;
        }

        .style2 {
            height: 23px;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI"
                    Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI"
                    Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI"
                    Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div>
            <h2>Master Data Information</h2>

            <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Width="90%" Height="100%">
                <Items>
                    <telerik:RadPanelItem runat="server" Text="Company" Visible="False">
                        <ContentTemplate>
                            <table class="style1" style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtName" runat="server" Width="280px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="280px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Contact"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtContact" runat="server" Width="200px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtEmail" runat="server" Width="200px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Website"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtWebsite" runat="server" Width="200px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <telerik:RadButton ID="btnCompanyNew" runat="server" Text="New" OnClick="btnCompanyNew_Click">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnSaveCompany" runat="server" Text="Save" OnClick="btnSaveCompany_Click">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnCompanyFind" runat="server" Text="Find" OnClick="btnCompanyFind_Click">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnCompanyEdit" runat="server" Text="Edit" OnClick="btnCompanyEdit_Click">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnCompanyCancel" runat="server" Text="Cancel" OnClick="btnCompanyCancel_Click">
                                        </telerik:RadButton>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblCompany" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Thana">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Thana Code"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtThanaCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblThanaMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="Thana Name"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtThanaName" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnThanaNew" runat="server" Text="New" OnClick="btnThanaNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnThanaSave" runat="server" Text="Save" OnClick="btnThanaSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnThanaFind" runat="server" Text="Find" OnClick="btnThanaFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnThanaEdit" runat="server" Text="Edit" OnClick="btnThanaEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnThanaCancel" runat="server" Text="Cancel" OnClick="btnThanaCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblThana" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Thanas</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgThana" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgThana_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgThana_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="ThanaId" FilterControlAltText="Filter PostId column" HeaderText="Thana Id" SortExpression="ThanaId" UniqueName="ThanaId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Thana Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Village">
                        <ContentTemplate>

                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal3q" runat="server" Text="Village Code"></asp:Literal>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtVillageCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblVillageMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal4" runat="server" Text="Village Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtVillageName" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal55" runat="server" Text="Thana Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadComboBox ID="cmThana" Filter="Contains" runat="server" DataSourceID="dsThana" DataTextField="Name" DataValueField="ThanaId" EmptyMessage="Select Thana">
                                                    </telerik:RadComboBox>
                                                    <asp:SqlDataSource ID="dsThana" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ThanaId], [Name] FROM [tblThanas]"></asp:SqlDataSource>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnVillageNew" runat="server" Text="New" OnClick="btnVillageNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnVillageSave" runat="server" Text="Save" OnClick="btnVillageSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnVillageFind" runat="server" Text="Find" OnClick="btnVillageFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnVillageEdit" runat="server" Text="Edit" OnClick="btnVillageEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnVillageCancel" runat="server" Text="Cancel" OnClick="btnVillageCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">

                                                    <asp:Label ID="lblVillage" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Villages</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgVillage" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgVillage_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgVillage_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="ViId" FilterControlAltText="Filter PI column" HeaderText="Village ID" SortExpression="ViId" UniqueName="ViId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Village Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ThanaId" FilterControlAltText="Filter ThanaId column" SortExpression="ThanaId" UniqueName="ThanaId" Display="False" HeaderText="ThanaId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="District" Visible="False">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Text="District Code"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtDistrictCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDistrictMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" Text="District Name"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtDistrictName" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnDistrictNew" runat="server" Text="New" OnClick="btnDistrictNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDistrictSave" runat="server" Text="Save" OnClick="btnDistrictSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDistrictFind" runat="server" OnClick="btnDistrictFind_Click" Text="Find">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDistrictEdit" runat="server" OnClick="btnDistrictEdit_Click" Text="Edit">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDistrictCancel" runat="server" Text="Cancel" OnClick="btnDistrictCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblDistrict" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Districts</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgDistrict" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgDistrict_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgDistrict_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="DistId" FilterControlAltText="Filter PI column" HeaderText="District Id" SortExpression="DistId" UniqueName="DistId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="District Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Category">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Category Code"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtCategoryCode" runat="server" Width="100px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                    <asp:Label ID="lblCategoryMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Category Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtCategoryName" EmptyMessage="Insectisides,Pesticides etc" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <telerik:RadButton ID="btnCategoryNew" runat="server" Text="New" OnClick="btnCategoryNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCategorySave" runat="server" Text="Save" OnClick="btnCategorySave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCategoryFind" runat="server" Text="Find" OnClick="btnCategoryFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCategoryEdit" runat="server" Text="Edit" OnClick="btnCategoryEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCategoryDelete" runat="server" Text="Delete" OnClick="btnCategoryDelete_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCategoryCancel" runat="server" OnClick="btnCategoryCancel_Click" Text="Cancel">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblCategory" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Categories</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgCategory" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" PageSize="15" OnNeedDataSource="rgCategory_NeedDataSource" OnSelectedIndexChanged="rgCategory_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="CatId" FilterControlAltText="Filter PI column" HeaderText="Category Id" SortExpression="CatId" UniqueName="CatId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Category Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Packing">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal6" runat="server" Text="Packing Code"></asp:Literal>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtPackingCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPackingMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal7" runat="server" Text="Packing Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtPackingName" EmptyMessage="Packet, Bottle etc" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnPackingNew" runat="server" Text="New" OnClick="btnPackingNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnPackingSave" runat="server" Text="Save" OnClick="btnPackingSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnPackingFind" runat="server" Text="Find" OnClick="btnPackingFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnPackingEdit" runat="server" Text="Edit" OnClick="btnPackingEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnPackingDelete" runat="server" OnClick="btnPackingDelete_Click" Text="Delete">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnPackingCancel" runat="server" Text="Cancel" OnClick="btnPackingCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">

                                                    <asp:Label ID="lblPacking" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Packing Types</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgPacking" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgPacking_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgPacking_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter PI column" HeaderText="Packing Code" SortExpression="Id" UniqueName="Id">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Packing Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Product Size">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal3" runat="server" Text="Product Size Code"></asp:Literal>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtItemSizeCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblItemSizeMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal5" runat="server" Text="Product Size Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtItemSizeName" EmptyMessage="5gm, 200ml etc" runat="server" Width="250px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnItemSizeNew" runat="server" Text="New" OnClick="btnItemSizeNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnItemSizeSave" runat="server" Text="Save" OnClick="btnItemSizeSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnItemSizeFind" runat="server" Text="Find" OnClick="btnItemSizeFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnItemSizeEdit" runat="server" Text="Edit" OnClick="btnItemSizeEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnItemSizeDelete" runat="server" OnClick="btnItemSizeDelete_Click" Text="Delete">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnItemSizeCancel" runat="server" Text="Cancel" OnClick="btnItemSizeCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">

                                                    <asp:Label ID="lblItemSize" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Product Sizes</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgItemSize" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgItemSize_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgItemSize_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter PI column" HeaderText="Product Size Id" SortExpression="Id" UniqueName="Id">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Product Size Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Unit/Weight" Visible="False">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td class="auto-style1">
                                                    <asp:Label ID="Label20" runat="server" Text="Weight Code"></asp:Label>
                                                </td>
                                                <td class="auto-style1">
                                                    <telerik:RadTextBox ID="txtWeightCode" runat="server" Enabled="False" Width="100px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td class="auto-style1">
                                                    <asp:Label ID="lblWeightMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="auto-style1"></td>
                                                <td class="auto-style1"></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text="Weight Name"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtWeightName" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Description"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtWeightDesr" runat="server" TextMode="MultiLine">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnWeightNew" runat="server" Text="New" OnClick="btnWeightNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnWeightSave" runat="server" Text="Save" OnClick="btnWeightSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnWeightFind" runat="server" Text="Find" OnClick="btnWeightFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnWeightEdit" runat="server" Text="Edit" OnClick="btnWeightEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnWeightCancel" runat="server" Text="Cancel" OnClick="btnWeightCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblWeight" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Unit/Weights</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgWeight" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" PageSize="15" OnNeedDataSource="rgWeight_NeedDataSource" OnSelectedIndexChanged="rgWeight_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="WgtId" FilterControlAltText="Filter PI column" HeaderText="Weight Id" SortExpression="WgtId" UniqueName="WgtId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Name column" HeaderText="Unit/Weight" SortExpression="Unit" UniqueName="Unit">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter Description column" HeaderText="Description" SortExpression="Description" UniqueName="Description">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Item" Visible="False">
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Owner="RadPanelBarItem"
                        Text="Occupation" Visible="False">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Occupation Code"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtDesignationCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDesignationMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="Occupation Name"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtDesignationName" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnDesignationNew" runat="server" Text="New" OnClick="btnDesignationNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDesignationSave" runat="server" Text="Save" OnClick="btnDesignationSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDesignationFind" runat="server" Text="Find" OnClick="btnDesignationFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDesignationEdit" runat="server" Text="Edit" OnClick="btnDesignationEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDesignationCancel" runat="server" Text="Cancel" OnClick="btnDesignationCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblDesignation" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Occupations</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgOccupation" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgOccupation_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgOccupation_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="DesigId" FilterControlAltText="Filter PI column" HeaderText="Occupation Id" SortExpression="DesigId" UniqueName="DesigId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Occupation Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Department" Visible="False">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Department Code"></asp:Label></td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtDepartmentCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDepartmentMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Department Name"></asp:Label></td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtDepartmentName" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnDepartmentNew" runat="server" Text="New" OnClick="btnDepartmentNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDepartmentSave" runat="server" Text="Save" OnClick="btnDepartmentSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDepartmentFind" runat="server" Text="Find" OnClick="btnDepartmentFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDepartmentEdit" runat="server" Text="Edit" OnClick="btnDepartmentEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDepartmentCancel" runat="server" Text="Cancel" OnClick="btnDepartmentCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblDepartment" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Departments</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgDepartment" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgDepartment_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgDepartment_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />

                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="DeptId" FilterControlAltText="Filter PI column" HeaderText="Department Id" SortExpression="DeptId" UniqueName="DeptId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Department Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="User" Visible="False">
                        <ContentTemplate>
                            <table class="style1" style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="User Code"></asp:Label></td>
                                    <td>
                                        <telerik:RadTextBox ID="txtUserCode" runat="server" Enabled="False" Width="100px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUserMode" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="User Name"></asp:Label></td>
                                    <td colspan="2">
                                        <telerik:RadTextBox ID="txtUserName" runat="server">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td colspan="2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <telerik:RadButton ID="btnUserNew" runat="server" Text="New">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnUserSave" runat="server" Text="Save">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnUserFind" runat="server" Text="Find">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnUserEdit" runat="server" Text="Edit">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnUserCancel" runat="server" Text="Cancel">
                                        </telerik:RadButton>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblUser" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Educational Degree" Visible="False">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="lbldeg" runat="server" Text="Degree Code"></asp:Literal>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtDegreeCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDegreeMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal4dd" runat="server" Text="Degree Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtDegreeName" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnDegreeNew" runat="server" OnClick="btnDegreeNew_Click" Text="New">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDegreeSave" runat="server" OnClick="btnDegreeSave_Click" Text="Save">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDegreeFind" runat="server" OnClick="btnDegreeFind_Click" Text="Find">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDegreeEdit" runat="server" OnClick="btnDegreeEdit_Click" Text="Edit">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnDegreeCancel" runat="server" OnClick="btnDegreeCancel_Click" Text="Cancel">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblDegree" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Degrees</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgDegree" Height="500px" Width="100%" runat="server" AllowFilteringByColumn="True" AllowMultiRowSelection="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" OnNeedDataSource="rgDegree_NeedDataSource" OnSelectedIndexChanged="rgDegree_SelectedIndexChanged" PageSize="15">
                                                    <ClientSettings EnablePostBackOnRowClick="True" Selecting-AllowRowSelect="true">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle BackColor="#F8FFFF" CssClass="commanditem1" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView BorderWidth="0" Width="100%">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="DegreeId" FilterControlAltText="Filter PI column" HeaderText="Degree ID" SortExpression="DegreeId" UniqueName="DegreeId">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Degree Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Cost Center">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal8" runat="server" Text="Cost Center Code"></asp:Literal>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtCostCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCostMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal9" runat="server" Text="Cost Center Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtCostName" EmptyMessage="Entertainment" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnCostNew" runat="server" Text="New" OnClick="btnCostNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostSave" runat="server" Text="Save" OnClick="btnCostSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostFind" runat="server" Text="Find" OnClick="btnCostFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostEdit" runat="server" Text="Edit" OnClick="btnCostEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostDelete" runat="server" OnClick="btnCostDelete_Click" Text="Delete">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostCancel" runat="server" Text="Cancel" OnClick="btnCostCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">

                                                    <asp:Label ID="lblCost" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Cost Centers</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgCostCenter" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="rgCostCenter_NeedDataSource" PageSize="15" OnSelectedIndexChanged="rgCostCenter_SelectedIndexChanged">
                                                    <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="True">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle CssClass="commanditem1" BackColor="#F8FFFF" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView Width="100%" BorderWidth="0">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter PI column" HeaderText="Cost Center Code" SortExpression="Id" UniqueName="Id">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Cost Center Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Cost Element">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="lblCostEle" runat="server" Text="Cost Element Code"></asp:Literal>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtCostElementCode" runat="server" Width="80px" Enabled="False">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCostElementMode" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal559" runat="server" Text="Cost Element Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtCostElementName" EmptyMessage="Tea-Biscuit" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal560" runat="server" Text="Cost Center Name"></asp:Literal>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadComboBox ID="cmCostCenter" Filter="Contains" runat="server" DataSourceID="dsCostCenter" DataTextField="Name" DataValueField="Id" EmptyMessage="Select Cost Center" Width="200px">
                                                    </telerik:RadComboBox>
                                                    <asp:SqlDataSource ID="dsCostCenter" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT * FROM [tblCostCenters]"></asp:SqlDataSource>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <telerik:RadButton ID="btnCostElementNew" runat="server" Text="New" OnClick="btnCostElementNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostElementSave" runat="server" Text="Save" OnClick="btnCostElementSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostElementFind" runat="server" Text="Find" OnClick="btnCostElementFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostElementEdit" runat="server" Text="Edit" OnClick="btnCostElementEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostElementDelete" runat="server" OnClick="btnCostElementDelete_Click" Text="Delete">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCostElementCancel" runat="server" Text="Cancel" OnClick="btnCostElementCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblCostElement" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Cost Elements</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgCostElements" Height="500px" Width="100%" runat="server" AllowFilteringByColumn="True" AllowMultiRowSelection="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" OnNeedDataSource="rgCostElements_NeedDataSource" OnSelectedIndexChanged="rgCostElements_SelectedIndexChanged" PageSize="15">
                                                    <ClientSettings EnablePostBackOnRowClick="True" Selecting-AllowRowSelect="true">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle BackColor="#F8FFFF" CssClass="commanditem1" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView BorderWidth="0" Width="100%">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter PI column" HeaderText="Cost Element Code" SortExpression="Id" UniqueName="Id">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Cost Element Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="CostCenterID" Display="False" FilterControlAltText="Filter CostCenterID column" HeaderText="Cost Center ID" SortExpression="CostCenterID" UniqueName="CostCenterID">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Bank" Visible="False">
                        <ContentTemplate>
                            <table class="style1" style="height: 500px">
                                <tr>
                                    <td>
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label115" runat="server" Text="Bank Code"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtBankCode" Enabled="false" runat="server">
                                                    </telerik:RadTextBox>
                                                    <asp:Label ID="lblBankMode"  runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label114" runat="server" Text="Bank Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtBankName" runat="server" Width="300px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <telerik:RadButton ID="btnBankNew" runat="server" Text="New" OnClick="btnBankNew_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnBankSave" runat="server" Text="Save" OnClick="btnBankSave_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnBankFind" runat="server" Text="Find" OnClick="btnBankFind_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnBankEdit" runat="server" Text="Edit" OnClick="btnBankEdit_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnBankDelete" runat="server" OnClick="btnBankDelete_Click" Text="Delete">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnBankCancel" runat="server" Text="Cancel" OnClick="btnBankCancel_Click">
                                                    </telerik:RadButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblBank" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <fieldset>
                                            <legend>All Banks</legend>
                                            <div style="overflow: scroll; height: 500px; width: auto">
                                                <telerik:RadGrid ID="rgBank" Height="500px" Width="100%" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" GridLines="Both" AllowFilteringByColumn="True" AllowPaging="True" PageSize="15" OnNeedDataSource="rgBank_NeedDataSource" OnSelectedIndexChanged="rgBank_SelectedIndexChanged">
                                                    <ClientSettings EnablePostBackOnRowClick="True" Selecting-AllowRowSelect="true">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <HeaderStyle CssClass="RadGridHeader" />
                                                    <CommandItemStyle BackColor="#F8FFFF" CssClass="commanditem1" />
                                                    <AlternatingItemStyle CssClass="RadGridAlternatingItem" />
                                                    <ItemStyle CssClass="RadGridItem" />
                                                    <MasterTableView BorderWidth="0" Width="100%">
                                                        <CommandItemSettings AddNewRecordImageUrl="AddRecord.gif" ExportToCsvImageUrl="ExportToCsv.gif" ExportToExcelImageUrl="ExportToExcel.gif" ExportToPdfImageUrl="ExportToPdf.gif" ExportToWordImageUrl="ExportToWord.gif" RefreshImageUrl="Refresh.gif" />
                                                        <RowIndicatorColumn FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn CollapseImageUrl="SingleMinus.gif" ExpandImageUrl="SinglePlus.gif" FilterImageUrl="Filter.gif" SortAscImageUrl="SortAsc.gif" SortDescImageUrl="SortDesc.gif">
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="BankCode" FilterControlAltText="Filter PI column" HeaderText="Bank Code" SortExpression="BankCode" UniqueName="BankCode">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Name" AutoPostBackOnFilter="true" FilterControlAltText="Filter Name column" HeaderText="Bank Name" SortExpression="Name" UniqueName="Name">
                                                                <ColumnValidationSettings>
                                                                    <ModelErrorMessage Text="" />
                                                                </ColumnValidationSettings>
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
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>

            &nbsp;
        </div>
    </form>
</body>
</html>
