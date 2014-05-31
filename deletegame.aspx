<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="deletegame.aspx.cs" Inherits="deletegame" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
<script type="text/javascript">
    function deleteConfirm(pubid) {
        var result = confirm('Do you want to delete ' + name + ' ?');
        if (result) {
            return true;
        }
        else {
            return false;
        }
    }
</script>
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <br />
<div>
<asp:GridView ID="gridView" DataKeyNames="id" runat="server"        
        AutoGenerateColumns="False" ShowFooter="True" HeaderStyle-Font-Bold="true"
        onrowcancelingedit="gridView_RowCancelingEdit"
        onrowdeleting="gridView_RowDeleting"
        onrowediting="gridView_RowEditing"
        onrowupdating="gridView_RowUpdating"
        
        OnRowDataBound="gridView_RowDataBound" BackColor="White" 
        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
<Columns>
<asp:TemplateField HeaderText="ID">
    <ItemTemplate>
        <asp:Label ID="txtid" runat="server" Text='<%#Eval("id") %>'/>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lblid" runat="server" width="40px" Text='<%#Eval("id") %>'/>
    </EditItemTemplate>
    
</asp:TemplateField>
 <asp:TemplateField HeaderText="Име на игра">
      <ItemTemplate>
         <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtname" width="70px"  runat="server" Text='<%#Eval("name") %>'/>
     </EditItemTemplate>
     
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Локација на сликата">
     <ItemTemplate>
         <asp:Label ID="lbllocation" runat="server" Text='<%#Eval("pic_location") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtlocation" width="70px"  runat="server" Text='<%#Eval("pic_location") %>'/>
     </EditItemTemplate>
   
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Тип на игра">
       <ItemTemplate>
         <asp:Label ID="lbltype" runat="server" Text='<%#Eval("game_type") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txttype" width="50px"   runat="server" Text='<%#Eval("game_type") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
   <asp:TemplateField HeaderText="Опис за играта">
     <ItemTemplate>
         <asp:Label ID="lbldes" runat="server" Text='<%#Eval("description") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtdes" width="30px"  runat="server" Text='<%#Eval("description") %>'/>
     </EditItemTemplate>
   
 </asp:TemplateField>
    <asp:TemplateField HeaderText="Цена">
     <ItemTemplate>
         <asp:Label ID="lblprice" runat="server" Text='<%#Eval("price") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtprice" width="30px"  runat="server" Text='<%#Eval("price") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Број на достапни">
     <ItemTemplate>
         <asp:Label ID="lblnum" runat="server" Text='<%#Eval("num_avail") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtnum" width="30px"  runat="server" Text='<%#Eval("num_avail") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 <asp:TemplateField>
    <EditItemTemplate>
        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel"  Text="Cancel" />
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit"  Text="Edit"  />
        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
    </ItemTemplate>
    
 </asp:TemplateField>
 </Columns>

    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />

<HeaderStyle Font-Bold="True" BackColor="#003399" ForeColor="#CCCCFF"></HeaderStyle>
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SortedAscendingCellStyle BackColor="#EDF6F6" />
    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
    <SortedDescendingCellStyle BackColor="#D6DFDF" />
    <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
    </div>
<div >
<br />&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblmsg" runat="server"></asp:Label>
</div>


</asp:Content>
