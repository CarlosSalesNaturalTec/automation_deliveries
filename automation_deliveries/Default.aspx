<%@ Page Title="Entregas a Realizar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="automation_deliveries._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <!-- Script para exibição de ícones -->
    <script src="https://use.fontawesome.com/8c3712a1dd.js"></script>

    <br />
    
    <!-- /.painel -->
    <div class="panel panel-default">

        <div class="panel-heading">
            ENTREGAS DO DIA: <asp:label ID="lbl_data" runat="server" Text =""> / </asp:label> <asp:label ID="lbl_id_funcionario" runat="server" Text =""> </asp:label>
        </div>
        
        <div class="panel-body">
            <ul class="timeline">

                <li>
                    <div class="timeline-badge info" > 
                        <i class="fa fa-save"></i> 
                    </div>

                    <div class="timeline-panel">

                        <div class="timeline-heading">
                            <h4 class="timeline-title">Alto de Coutos</h4>
                            <p><small class="text-muted">CARLOS ANTONIO SALES</small></p>
                        </div>

                        <div class="timeline-body">
                            <p>Rua Mesquita, Numero 50E, Alto de Coutos, Salvador-BA, CEP: 40.750-310</p>
                        </div>

                        <br />

                        <div class="btn-group">
                            <button type="button" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown">ATUALIZAR <span class="caret"></span></button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">ENTREGUE</a></li>
                                <li class="divider"></li>
                                <li><a href="#">MUDOU-SE</a></li>
                                <li><a href="#">AUSENTE</a></li>
                                <li><a href="#">NÃO QUIZ RECEBER</a></li>
                                <li class="divider"></li>
                                <li><a href="#">ÁREA DE RISCO</a></li>
                                <li><a href="#">END. INSUFICIENTE</a></li>
                                <li><a href="#">NÚMERO INEXISTENTE</a></li>
                            </ul>
                        </div>          
                        
                        <div class="btn-group">
                            <button type="button" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown">EXIBIR <span class="caret"></span></button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">DETALHES</a></li>
                                <li class="divider"></li>
                                <li><a href="#">MAPA</a></li>
                            </ul>
                        </div> 
                                     
                    </div>
                </li>

                <li class="timeline-inverted">
                    <div class="timeline-badge info"> 
                        <i class="fa fa-save"></i>
                    </div>

                    <div class="timeline-panel">

                        <div class="timeline-heading">
                            <h4 class="timeline-title">BARRA</h4>
                        </div>

                        <div class="timeline-body">
                            <p>Av. Sete de Setembro, 3937, Barra, Salvador-BA, CEP: 40.140-110</p>
                        </div>

                        <br />

                        <div class="btn-group">
                            <button type="button" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown">ATUALIZAR <span class="caret"></span></button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">ENTREGUE</a></li>
                                <li class="divider"></li>
                                <li><a href="#">MUDOU-SE</a></li>
                                <li><a href="#">AUSENTE</a></li>
                                <li><a href="#">NÃO QUIZ RECEBER</a></li>
                                <li class="divider"></li>
                                <li><a href="#">ÁREA DE RISCO</a></li>
                                <li><a href="#">END. INSUFICIENTE</a></li>
                                <li><a href="#">NÚMERO INEXISTENTE</a></li>
                            </ul>
                        </div>          
                        
                        <div class="btn-group">
                            <button type="button" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown">EXIBIR <span class="caret"></span></button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">DETALHES</a></li>
                                <li class="divider"></li>
                                <li><a href="#">MAPA</a></li>
                            </ul>
                        </div> 

                    </div>
                </li>               

            </ul>
        </div>
        <!-- /.panel-body -->
    </div>
    <!-- /.painel -->

</asp:Content>
