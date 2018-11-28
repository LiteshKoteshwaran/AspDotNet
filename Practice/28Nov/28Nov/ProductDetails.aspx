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
     <p>
         <asp:TextBox ID="TextBoxForSelect" runat="server" ></asp:TextBox>
     </p>
     <p>
         <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="GetDetails" />
         <asp:Label ID="Output" runat="server"></asp:Label>
     </p>
     <p>
         &nbsp;</p>
     <p>
         <asp:Button ID="Output1" runat="server" OnClick="Output1_Click" Text="Proc Exe Button" />
         <asp:TextBox ID="TextBoxForProc" runat="server"></asp:TextBox>
         <asp:Label ID="LabelForProc" runat="server"></asp:Label>
     </p>
     <p>
         <asp:Label ID="Label8" runat="server" Text="InsertByDataSet"></asp:Label>
     </p>
     <p>
         <asp:Label ID="Label5" runat="server" Text="Product Name"></asp:Label>
         <asp:TextBox ID="TextBoxForProductName" runat="server"></asp:TextBox>
         <asp:Label ID="Label6" runat="server" Text="Product ID"></asp:Label>
         <asp:TextBox ID="TextBoxForID" runat="server"></asp:TextBox>
         <asp:Label ID="Label7" runat="server" Text="Location"></asp:Label>
         <asp:TextBox ID="TextBoxForLocation" runat="server"></asp:TextBox>
         <asp:Button ID="ButtonForDataSetOp" runat="server" OnClick="ButtonForDataSetOp_Click" Text="Button" />
     </p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating"  >
         <Columns>
             <asp:TemplateField HeaderText="ID">
                 <EditItemTemplate>
                     <asp:Label ID="Label12" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label11" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Name">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label9" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Location">
                 <EditItemTemplate>
                     <asp:Label ID="Label14" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label13" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
         </Columns>
     </asp:GridView>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>

</asp:Content>
