<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="Library.viewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card">
          <div class="card-body">
               <div class="row">
                   <div class="col">
                   <center>
                       <h4>Book Inventory List</h4>
                   </center>
                   </div>
               </div>
               <div class="row">
                   <div class="col">
                   <hr>
                   </div>
               </div>
               <div class="row">
                   <div class="col">
                   <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server"></asp:GridView>
                   </div>
               </div>
           </div>
      </div>
</asp:Content>
