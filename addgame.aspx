<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="addgame.aspx.cs" Inherits="addgame" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-0 col-md-offset-0">
                <form>
                <h2>
                    Внес на нова игра<small> во база на податоци</small></h2>
                <hr class="colorgraph">

                <div class="form-group">
                    <asp:TextBox ID="txtName" class="form-control input-lg" placeholder="име на играта"
                        TabIndex="1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                        Display="None" ErrorMessage="Внесете име играта!"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:TextBox ID="txtEmail" class="form-control input-lg" runat="server" placeholder="опис на играта"
                        TabIndex="3" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                        Display="None" ErrorMessage="Внесете опис!"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:TextBox ID="txtPassword" class="form-control input-lg" placeholder="цена на играта"
                        TabIndex="3" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                        Display="None" ErrorMessage="Внесете цена!"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:TextBox ID="txtUserName" class="form-control input-lg" placeholder="тип на игра"
                        TabIndex="7" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName"
                        Display="None" ErrorMessage="Внесете тип на игра!"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:TextBox ID="txtConfirm" class="form-control input-lg" placeholder="залиха на игра"
                        TabIndex="7" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirm"
                        Display="None" ErrorMessage="Внесете залиха!"></asp:RequiredFieldValidator>
                </div>


                <!--todo apply css -->

                <div class="form-group">
                    <h2>
                        <small>прикачи слика од играта</small></h2>
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                    <asp:Button runat="server" ID="UploadButton" Text="Аплоадирај!" OnClick="UploadButton_Click" />
                    <br />
                    <br />
                    <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />

                    <asp:Label ID="lblPicName" runat="server"></asp:Label>
                    <asp:Image ID="Image1" runat="server" />
                </div>

                <!-- todo check backend -->

                <hr class="colorgraph">
                <div class="row">
                    <div class="col-xs-6 col-md-6">
                        <asp:Label ID="lblPoraka" runat="server"></asp:Label>
                        <asp:Button ID="btnRegister" class="btn btn-primary btn-block btn-lg" TabIndex="6"
                            runat="server" OnClick="btnRegister_Click" Text="Додај игра!" style="margin-bottom: 20px;" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"
                            style="margin-bottom: 50px;" DisplayMode="List" />
                    </div>
                </div>


                </form>
            </div>
        </div>
    </div>
</asp:Content>
