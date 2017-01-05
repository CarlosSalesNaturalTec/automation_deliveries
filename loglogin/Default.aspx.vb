Partial Class Scripts_Default
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()>
    Public Shared Function GetAcesso(ByVal name As String) As String
        Return "Acesso Liberado para:  " & name
    End Function

End Class
