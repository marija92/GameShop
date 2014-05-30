<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="gametype.aspx.cs" Inherits="gametype" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  
    <div class="container" id="cont" runat="server">
    
		
        
        <br/> 	

        
    	
		
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

						<div class="modal-body">Мора да бидете најавени за ка купите игра!</div>

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
    
