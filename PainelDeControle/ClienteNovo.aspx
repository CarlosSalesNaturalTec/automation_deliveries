<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClienteNovo.aspx.cs" Inherits="ClienteNovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function SalvarRegistro() {

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/SalvarEntregador",
                data: '{param1: "JEOVA", param2: "JIREH"  }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d)
        }
    </script>

</head>
<body>
    <div>
        <input type="button" value="ENTRAR" onclick="SalvarRegistro()" class="btn btn-default" />
    </div>

</body>
</html>
