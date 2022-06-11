<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptCustomerDueList.aspx.cs" Inherits="ElectronicsMS.Forms.ReportForms.rptCustomerDueList" %>

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
          <h1>Customer Due List</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="cmCustomer" Filter="Contains" Runat="server" EnableLoadOnDemand="true" EmptyMessage="Select A Customer" Width="300px" OnItemsRequested="cmCustomer_ItemsRequested">
                    </telerik:RadComboBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label20" runat="server" Text="Thana"></asp:Label>
                </td>
                <td class="auto-style1">
                <telerik:RadComboBox ID="cmThana" Filter="Contains" Runat="server" EnableLoadOnDemand="true" Width="180px" AutoPostBack="True" DataSourceID="dsThana" DataTextField="Name" DataValueField="ThanaId" EmptyMessage="Select Thana" OnSelectedIndexChanged="cmThana_SelectedIndexChanged">
                </telerik:RadComboBox>
                <asp:SqlDataSource ID="dsThana" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ThanaId], [Name] FROM [tblThanas]">
                </asp:SqlDataSource>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label21" runat="server" Text="Village"></asp:Label>
                </td>
                <td class="auto-style1">
                    <telerik:RadComboBox ID="cmVillage" Filter="Contains" EnableLoadOnDemand="true" Runat="server" Width="200px" DataSourceID="dsVill" DataTextField="Name" DataValueField="ViId" EmptyMessage="Select Village" AutoPostBack="True">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="dsVill" runat="server" ConnectionString="<%$ ConnectionStrings:ElectronicsCon %>" SelectCommand="SELECT [ViId], [Name] FROM [tblVillages] WHERE ([ThanaId] = @ThanaId)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmThana" Name="ThanaId" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblStartDate" runat="server" Text="Date Option"></asp:Label>
                </td>
                <td class="auto-style1">
                    <telerik:RadDatePicker ID="dpStartDate" Runat="server" Width="100px">
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                    <FocusedStyle Resize="None"></FocusedStyle>

                                                    <DisabledStyle Resize="None"></DisabledStyle>

                                                    <InvalidStyle Resize="None"></InvalidStyle>

                                                    <HoveredStyle Resize="None"></HoveredStyle>

                                                    <EnabledStyle Resize="None"></EnabledStyle>
                                                </DateInput>
                    </telerik:RadDatePicker>
                    <telerik:RadDatePicker ID="dpEndDate" Runat="server" Width="100px">
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                    <FocusedStyle Resize="None"></FocusedStyle>

                                                    <DisabledStyle Resize="None"></DisabledStyle>

                                                    <InvalidStyle Resize="None"></InvalidStyle>

                                                    <HoveredStyle Resize="None"></HoveredStyle>

                                                    <EnabledStyle Resize="None"></EnabledStyle>
                                                </DateInput>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label19" runat="server" Text="Report Type" Visible="False"></asp:Label>
                </td>
                <td class="auto-style1">
                    <telerik:RadComboBox ID="cmReportType" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmReportType_SelectedIndexChanged" Visible="False">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Custom Date" Value="Custom Date" />
                            <telerik:RadComboBoxItem runat="server" Text="As on Date" Value="As on Date" />
                            <telerik:RadComboBoxItem runat="server" Text="Monthly" Value="Monthly" Visible="False" />
                            <telerik:RadComboBoxItem runat="server" Text="Yearly" Value="Yearly" Visible="False" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <telerik:RadButton ID="btnGenerate" runat="server" Text="Generate Report" OnClick="btnGenerate_Click">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label17" runat="server" class="menuitembold" ForeColor="Blue" Text="Report Format"></asp:Label></td>
                <td>
                    <asp:RadioButton ID="rbtnPdf" runat="server" Text="Pdf" GroupName="b" ForeColor="Blue" Checked="True"/>
                    <asp:RadioButton ID="rbtnCrystal" runat="server" Text="Crystal" GroupName="b" ForeColor="Blue" Visible="False"/>
                    <asp:RadioButton ID="rbtnWord" runat="server" Text="Word" GroupName="b" ForeColor="Blue" Visible="False"/>
                    <asp:RadioButton ID="rbtnExcel" runat="server" Text="Excel" GroupName="b" ForeColor="Blue"  />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    <div>
    
        <asp:Label ID="lblMessage" runat="server" ForeColor="#990033"></asp:Label>
    
    </div>
    </form>
</body>
</html>
