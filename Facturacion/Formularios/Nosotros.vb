Public Class Nosotros

    Private Sub Nosotros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_nosotros = True
    End Sub

    Private Sub Nosotros_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_nosotros = False
    End Sub
End Class