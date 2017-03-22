<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contratos.aspx.cs" Inherits="Contratos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">

    <link rel="stylesheet" href="custom/StyleTAB.css">

    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>
<body>

    <h1>CADASTRO DE CONTRATOS</h1>

<main>
  
  <input id="tab1" type="radio" name="tabs" checked>
  <label for="tab1">Cliente</label>
    
  <input id="tab2" type="radio" name="tabs">
  <label for="tab2">Funcionários</label>
    
  <input id="tab3" type="radio" name="tabs">
  <label for="tab3">Custos</label>
    
  <input id="tab4" type="radio" name="tabs">
  <label for="tab4">Status</label>
    
  <section id="content1">
    <p>
      Dados do Cliente</p>
  </section>
    
  <section id="content2">
   <p>
      Funcionarios alocados ao contrato</p>
  </section>
    
  <section id="content3">
    <p>
      Custos do Contrato</p>
  </section>
    
  <section id="content4">
    <p>
      Status GEral</p>
  </section>
    
</main>

</body>
</html>
