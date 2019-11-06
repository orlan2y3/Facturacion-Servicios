Imports System.Data.OleDb
Public Class Parametros
    Public ds As DataSet = New DataSet

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtitbis.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If Not IsNumeric(txtitbis.Text) Then
            MsgBox("El ITBIS debe ser un valor numerico", MsgBoxStyle.Information)
            txtitbis.Focus()
            Return
        End If

        Try

            Dim myQuery As String = " UPDATE parametros Set itbis = " & CDbl(txtitbis.Text) & ", valida ='" & txtValida.Text & "'"
            Dim cmd As New OleDbCommand(myQuery, DB.Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                DTO.porciento_itebis = txtitbis.Text
                Valida = txtValida.Text
                MsgBox("O J O : Parametros grabados, Debe cerrar el sistema para que tengan efecto los cambios", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Parametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_parametros = True
        txtitbis.Text = DTO.porciento_itebis
        txtValida.Text = Valida

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_parametros = False
        Me.Close()
    End Sub

    Private Sub Parametros_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_parametros = False
    End Sub

    Private Sub txtValida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class