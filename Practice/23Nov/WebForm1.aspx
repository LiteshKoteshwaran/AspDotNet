<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_21Nov.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="w-100">
        <tr>
            <td style="width: 189px; height: 63px">
                <asp:Label ID="Label1s" runat="server" Text="FirstName"></asp:Label>
            </td>
            <td style="width: 255px; height: 63px">
                <asp:TextBox ID="TextBox1s" runat="server" style="margin-left: 1px"></asp:TextBox>
            </td>
            <td style="width: 151px; height: 63px">
                <asp:Label ID="Label4c" runat="server" Text="CourseName"></asp:Label>
            </td>
            <td style="width: 215px; height: 63px">
                <asp:TextBox ID="TextBox4c" runat="server" Width="156px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 74px">
                <asp:Label ID="Label2s" runat="server" Text="ContactNo"></asp:Label>
            </td>
            <td style="height: 74px; width: 255px">
                <asp:TextBox ID="TextBox2s" runat="server"></asp:TextBox>
            </td>
            <td style="height: 74px; width: 151px">
                <asp:Label ID="Label5c" runat="server" Text="CourseDuration"></asp:Label>
            </td>
            <td style="height: 74px; width: 215px">
                <asp:TextBox ID="TextBox5c" runat="server" Width="156px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 69px">
                <asp:Label ID="Label3s" runat="server" Text="ID"></asp:Label>
            </td>
            <td style="height: 69px; width: 255px">
                <asp:TextBox ID="TextBox3s" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
            </td>
            <td style="height: 69px; width: 151px">
                <asp:Label ID="Label6c" runat="server" Text="CourseFee"></asp:Label>
            </td>
            <td style="height: 69px; width: 215px">
                <asp:TextBox ID="TextBox6c" runat="server" Width="155px"></asp:TextBox>
               <%-- <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save" />--%>
            </td>
        </tr>
    </table>

</asp:Content>
