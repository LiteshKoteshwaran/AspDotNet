<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="_24Nov.Validation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table class="nav-justified">
            <tr>
                <td style="width: 240px; height: 36px">FirstName</td>
                <td style="height: 36px; width: 257px">
                    <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FirstName"  runat="server" ErrorMessage="Enter the First Name"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FirstName" ValidationExpression="[A-Z][a-z]{3,10}"></asp:RegularExpressionValidator>
                </td>
                <td style="height: 36px">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 240px; height: 34px">LastName</td>
                <td style="height: 34px; width: 257px">
                    <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator3" ControlToValidate="LastName" runat="server" ErrorMessage="Name can't be single Charater"></asp:RangeValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="LastName" ErrorMessage="Name should be only Characters" ValidationExpression="([A-Za-z]){2,10}"></asp:RegularExpressionValidator>
                </td>
                <td style="height: 34px">
                    <asp:Label ID="Label2" runat="server" Text="AccountNo"></asp:Label>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 240px; height: 34px">ID</td>
                <td style="height: 34px; width: 257px">
                    <asp:TextBox ID="ID" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="ID not entered " ControlToValidate="ID"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="ID" ErrorMessage="you doesn't below to the Company" ValidationExpression="[acuvate]+[0-9]{1,3}"></asp:RegularExpressionValidator>
                </td>
                <td style="height: 34px">
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="PassWord" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" ControlToValidate="PassWord" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 240px; height: 35px">ContactNo</td>
                <td style="height: 35px; width: 257px">
                    <asp:TextBox ID="ContactNo" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="not a valid contact No." ValidationExpression="[0-9]{10}" ControlToValidate="ContactNo"></asp:RegularExpressionValidator>
                </td>
                <td style="height: 35px">AccType<asp:CheckBoxList ID="AccountType" runat="server" AutoPostBack="True" >
                    <asp:ListItem Value="Saving "></asp:ListItem>
                    <asp:ListItem Value="Current"></asp:ListItem>
                    <asp:ListItem Value="Fixed"></asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="Required" OnServerValidate="CustomValidator4_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 240px; height: 36px">EmailID</td>
                <td style="width: 257px; height: 36px">
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="Email" ValidationExpression="	^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Email" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 36px"></td>
            </tr>
            <tr>
                <td style="width: 240px; height: 38px">Age</td>
                <td style="height: 38px; width: 257px">
                    <asp:TextBox ID="Age" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="enter a vail age" ControlToValidate="Age" MaximumValue="100" MinimumValue="22" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="height: 38px"></td>
            </tr>
            <tr>
                <td style="width: 240px; height: 34px">Address</td>
                <td style="height: 34px; width: 257px">
                    <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="Address"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                </td>
                <td style="height: 34px"></td>
            </tr>
            <tr>
                <td style="width: 240px; height: 34px">Gender</td>
                <td style="height: 34px; width: 257px">
<%--                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Others" />--%>
<%--                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>--%>

                    <asp:RadioButtonList ID="Gender" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="Male"></asp:ListItem>
                        <asp:ListItem Value="Female"></asp:ListItem>
                        <asp:ListItem Value="Others"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Gender" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 34px"></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" Height="26px" Text="Submit" Width="156px" OnClick="Button1_Click" />
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
