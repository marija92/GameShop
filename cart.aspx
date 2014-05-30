<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="cart.aspx.cs" Inherits="cart" EnableEventValidation="false" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  
    <div style="margin-top:100px;" class="container">
  
	<div class="container">
	<div class="row">
		<div class="col-xs-8">
			<form >
			<div class="panel panel-info">
				<div class="panel-heading">
					<div class="panel-title">
						<div class="row">
							<div class="col-xs-6">
								<h5><span class="glyphicon glyphicon-shopping-cart"></span> Купувачка кошничка</h5>
							</div>
							<div class="col-xs-6">
							
								<!--redirect do welcome-->
								<a href="Welcome.aspx" class="btn btn-primary btn-sm btn-block">
									 <span class="glyphicon glyphicon-share-alt"></span>Продолжи со купување
								</a>
							</div>
						</div>
					</div>
				</div>
				
				<div class="panel-body" runat="server" id="div">
				
					<!-- red/igra-->
							
					
					<hr>
				</div>
				
				
				<div class="panel-footer">
					<div class="row text-center">
						<div class="col-xs-9">
						
						
							<!-- suma na cenite na igrite -->
							<h4 class="text-right"><p id="total">Вкупно: <asp:Label ID="lblVkupno" runat="server"></asp:Label> ден.</p></h4>							
						</div>
						<div class="col-xs-3">
						
						
							<!-- da gi brise site igri od sesija i da izvesti oti e izvrsena simulacija na kupuvanje -->
							<asp:Button ID="btnKupi" runat="server"  Text="Купи" type="submit" class="btn btn-success btn-block" OnClick="btnKupi_Click">
								
							</asp:Button>
						</div>
					</div>
				</div>
			</div>
			</form>
		</div>
	</div>
	
	
	</div>
	
    <!-- /.container -->
	</div>
</asp:Content> 
    

