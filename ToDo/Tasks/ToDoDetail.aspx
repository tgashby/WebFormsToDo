<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="ToDoDetail.aspx.cs" Inherits="ToDo.Tasks.ToDoDetail" %>
<asp:Content ID="ToDoContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= DetailTitle %></h1>
    <hr />
    <h3>ToDo Update</h3>
        <asp:FormView ID="ToDoForm" runat="server" ItemType="ToDo.Models.ToDoItem" SelectMethod="GetToDo" RenderOuterTable="false" DefaultMode="Insert">
            <EditItemTemplate>
                <table>
                    <tr>
                        <td><label for="todoName">Name:</label></td>
                        <td>
                            <asp:TextBox ID="ToDoName" runat="server" Text='<%# Item.ToDoName %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NameValidator" runat="server" Text="* ToDo name required." ControlToValidate="ToDoName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    <tr/>
                    <tr>
                        <td><label for="toDoDesc">Description:</label></td>
                        <td>
                            <asp:TextBox ID="ToDoDesc" runat="server" Text='<%# Item.ToDoDescription %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DescValidator" runat="server" Text="* ToDo desc required." ControlToValidate="ToDoName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="ToDoTypeLabel" runat="server">Type:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ToDoTypes" runat="server"
                                ItemType="ToDo.Models.ToDoTypeName"
                                SelectMethod="GetToDoTypeNames"
                                DataTextField="Name"
                                DataValueField="Id"
                                SelectedValue="<%# Item.ToDoTypeNameId %>">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="IsCompletedLabel" runat="server">Is Complete:</asp:Label></td>
                        <td><asp:CheckBox ID="IsCompleted" runat="server" Checked="<%# Item.IsCompleted %>" /></td>
                    </tr>
                </table>
                <asp:Button ID="AddToDoButton" runat="server" OnClick="AddToDoButton_Click" CausesValidation="true"/>
                <asp:Button ID="RemoveToDoButton" runat="server" Text="Remove ToDo" OnClick="RemoveToDoButton_Click" CausesValidation="false"/>
                <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table>
                    <tr>
                        <td><label for="todoName">Name:</label></td>
                        <td>
                            <asp:TextBox ID="ToDoName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NameValidator" runat="server" Text="* ToDo name required." ControlToValidate="ToDoName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    <tr/>
                    <tr>
                        <td><label for="toDoDesc">Description:</label></td>
                        <td>
                            <asp:TextBox ID="ToDoDesc" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DescValidator" runat="server" Text="* ToDo desc required." ControlToValidate="ToDoName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="ToDoTypeLabel" runat="server">Type:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ToDoTypes" runat="server"
                                ItemType="ToDo.Models.ToDoTypeName"
                                SelectMethod="GetToDoTypeNames"
                                DataTextField="Name"
                                DataValueField="Id">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="IsCompletedLabel" runat="server">Is Complete:</asp:Label></td>
                        <td><asp:CheckBox ID="IsCompleted" runat="server" Checked="false" /></td>
                    </tr>
                </table>
                <asp:Button ID="AddToDoButton" runat="server" Text="<%= AddButtonText %> ToDo" OnClick="AddToDoButton_Click" CausesValidation="true"/>
                <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
            </InsertItemTemplate>
        </asp:FormView>
</asp:Content>
