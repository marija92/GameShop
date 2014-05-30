<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="register.aspx.cs" Inherits="register" EnableEventValidation="false"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container" style="padding-top: 50px">
        <!-- Register -->
        <div class="container">
            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-0 col-md-offset-0">
                <form>
                <h2>
                    Регистрирај се<small> бесплатна регистрација</small>
                </h2>
                <hr class="colorgraph">
                <div class="row">
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group" ng-class="{ 'has-error' : userForm.first_name.$invalid && !userForm.first_name.$pristine }">
                            <asp:TextBox class="form-control input-lg" placeholder="име" TabIndex="1" ID="txtName"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                Display="None" ErrorMessage="Внесете име!"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group" ng-class="{ 'has-error' : userForm.last_name.$invalid && !userForm.last_name.$pristine }">
                            <asp:TextBox ID="txtLastName" class="form-control input-lg " placeholder="презиме"
                                TabIndex="2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                Display="None" ErrorMessage="Внесете презиме!"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group" ng-class="{ 'has-error' : userForm.usernameF.$invalid && !userForm.usernameF.$pristine }">
                    <asp:TextBox ID="txtUserName" class="form-control input-lg" placeholder="корисничко име"
                        TabIndex="3" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName"
                        Display="None" ErrorMessage="Внесете корисничко име!"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group" ng-class="{ 'has-error' : userForm.email.$invalid && !userForm.email.$pristine }">
                    <asp:TextBox ID="txtEmail" class="form-control input-lg" placeholder="email" TabIndex="4"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                        Display="None" ErrorMessage="Внесете e-mail адреса!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtEmail"
                        Display="None" ErrorMessage="Внесете валидна e-mail адреса!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <div class="row">
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group" ng-class="{ 'has-error' : userForm.passwd.$invalid && !userForm.passwd.$pristine }">
                            <asp:TextBox ID="txtPassword" class="form-control input-lg" placeholder="лозинка"
                                TabIndex="5" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                                Display="None" ErrorMessage="Внесете лозинка!"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group" ng-class="{ 'has-error' : userForm.password_confirmation.$invalid && !userForm.password_confirmation.$pristine }">
                            <asp:TextBox ID="txtConfirm" class="form-control input-lg" placeholder="потврди ја лозинката"
                                TabIndex="6" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirm"
                                Display="None" ErrorMessage="Внесете потврдна лозинка!"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                                ControlToValidate="txtConfirm" Display="None" ErrorMessage="Лозинките мора да бидат исти!"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group" ng-class="{ 'has-error' : userForm.usernameF.$invalid && !userForm.usernameF.$pristine }">
                    <asp:TextBox ID="txtType" class="form-control input-lg" placeholder="омилен тип на игра"
                        TabIndex="7" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtType"
                        Display="None" ErrorMessage="Внесете тип на игра!"></asp:RequiredFieldValidator>
                </div>
                <!-- dropdown list


							<div class="form-group" ng-class="{ 'has-error' : addgameForm.gameType.$invalid && !addgameForm.gameType.$pristine }">					
								<select type="text" name="gameType" id="gameType" class="form-control input-lg"
									 placeholder="тип на игра" tabindex="7" data-ng-model="gameType" required>
									    
									<c:forEach items="${gameTypes}" var="item">
										<option value="${item.name}">${item.name}</option>
									</c:forEach>							
								
								</select> 								
							</div>
                -->
                <hr class="colorgraph">
                <div class="row">
                    <div class="col-xs-6 col-md-6">
                        <asp:Button ID="btnRegister" class="btn btn-primary btn-block btn-lg" TabIndex="7"
                            runat="server" OnClick="btnRegister_Click" Text="Регистрирај се" />
                    </div>
                    <div class="col-xs-6 col-md-6">
                        <asp:Label runat="server" ID="lblPoraka" Font-Bold="True">
                        </asp:Label>
                    </div>
                </div>
                <asp:ValidationSummary Style="margin-top: 20px;" ID="ValidationSummary1" runat="server"
                    ForeColor="Red" DisplayMode="List" />
                </form>
            </div>
        </div>
    </div>
    <!-- /.container -->
</asp:Content>
