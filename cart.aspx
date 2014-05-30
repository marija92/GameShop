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
								<a href="welcome.aspx" class="btn btn-primary btn-sm btn-block">
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
							
                            <asp:Button runat="server" ID="buyButton" Text="Купи" 
                                class="btn btn-success btn-block" onclick="buyButton_Click"/>

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


     <!-- Modal -->            
			<div class="modal fade" id="modal" tabindex="-1" role="dialog"
				aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header" style="background-color: #101010;">
							<button type="button" class="close" data-dismiss="modal"
								aria-hidden="true"">&times;</button>
							<h4 class="modal-title" id="myModalLabel" style="color: #999;">Порака</h4>
						</div>

						<div class="modal-body">Изврешена е симулација на купување на игрите!</div>

						<div class="modal-footer">
							<button id="close" type="button" class="btn btn-primary"
								data-dismiss="modal">Затвори</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- /.modal -->



</asp:Content> 
    

