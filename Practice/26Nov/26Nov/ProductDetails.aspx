<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="_26Nov.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>authorised</h1>
     <p>&nbsp;</p>
     <p>
         <asp:Label ID="Label1" runat="server" Text="Product"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     </p>
     <p>
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Save Product " />
     </p>
     <p>
         <asp:Label ID="Label2" runat="server" Text="Update Table"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label4" runat="server" Text="SetName"></asp:Label>
         <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
     </p>
     <p>
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update Data" />
     </p>
     <p>
         <asp:Label ID="Label3" runat="server" Text="Delete "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
     </p>
     <p>
         <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
     </p>

</asp:Content>
