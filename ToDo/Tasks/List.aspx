<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ToDo.Tasks.List" %>
<asp:Content ID="ToDoContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>ToDos:</h3>
    <asp:ListView ID="todoList"
        ItemType="ToDo.Models.ToDoItem"
        runat="server"
        SelectMethod="GetToDos">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>
                        No ToDos
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="ToDoDetail.aspx">Add a Todo!</a>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table>
                <tr style="visibility:hidden; height:2px;"><td><asp:Label ID="ToDoId" runat="server" Text="<%# Item.Id %>"></asp:Label></td></tr>
                <tr>
                    <td>
                        <a href="ToDoDetail.aspx?id=<%#: Item.Id %>">
                            <%#: Item.ToDoName %>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%#: Item.ToDoDescription %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="isComplete">Is complete:</label>
                        <asp:CheckBox ID="IsCompleted" runat="server" Checked="<%# Item.IsCompleted %>" OnCheckedChanged="IsCompleted_CheckedChanged" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="ToDoDetail.aspx">Add a Todo!</a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
