<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome"  %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  
    <div class="container" id="cont" runat="server">
    
		<!-- treba da prikaze sliki od foldero sliki -- > golemite sliki za carousel sa imenuvani sa sos L na kraj -->
	
    	<!--carousel-->
		<div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="margin-top:30px">
	 
		  <!-- Indicators -->
		  <ol class="carousel-indicators">
		    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
		    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
		    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
		  </ol>
		 
		  <!-- Slider Content (Wrapper for slides )-->
		  <div class="carousel-inner">
		    <div class="item active">
			
			
			
			  <!-- slika igra-->
		      <img src="img/10L.jpg" alt="...">
		    </div>
		    <div class="item">
			
			
			
			  <!-- slika igra-->
		      <img src="img/2L.jpg" alt="...">
		    </div>
		    <div class="item">
			
			
			  <!-- slika igra-->
		      <img src="img/9L.jpg" alt="...">
		    </div>
		    
		  </div>
		 
		  <!-- Controls -->
		  <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
		    <span class="glyphicon glyphicon-chevron-left"></span>
		  </a>
		  <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
		    <span class="glyphicon glyphicon-chevron-right"></span>
		  </a>
		  
		</div>  
        
        <br/> 	

        <asp:Label runat="server" ID="proba"></asp:Label>
    	

		<!-- /carousel -->
		
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
    
