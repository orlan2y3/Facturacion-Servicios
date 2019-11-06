Imports System.Data.OleDb
Public Class Seguridad_Anular_Factura
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Trim(txtusuario.Text) = "" Then
            MsgBox("El Nombre de Usuario no Deben Estar en Blanco", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        ElseIf Trim(txtcontraseña.Text) = "" Then
            MsgBox("La Contraseña no Deben Estar en Blanco", MsgBoxStyle.Information)
            txtcontraseña.Focus()
            Return
        End If

        Try

            Dim cmd As New OleDbCommand
            Dim Reader As OleDbDataReader
            Dim StrSql As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" + txtusuario.Text + "' and contrasena = '" + txtcontraseña.Text + "'"
            cmd.CommandText = StrSql
            cmd.CommandType = CommandType.Text
            cmd.Connection = DB.Cnn
            Reader = cmd.ExecuteReader()

            If Reader.Read Then
                DTO.nivel_seguridad = Reader("nivel")
                DTO.usuario_activo_inactivo = Reader("estado")
                Reader.Close()

                If DTO.usuario_activo_inactivo = "Inactivo" Then
                    Me.Close()
                End If

                If DTO.donde_dio_click = "anular_factura" And DTO.nivel_seguridad = 2 Then
                    MsgBox("Acceso negado", MsgBoxStyle.Critical)
                    Return
                End If

                If DTO.donde_dio_click = "anular_factura" And DTO.nivel_seguridad = 3 Then
                    MsgBox("Acceso negado", MsgBoxStyle.Critical)
                    Return
                End If

                If DTO.donde_dio_click = "anular_factura" And DTO.nivel_seguridad = 1 Then
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DTO.usuario_activo_inactivo = ""
        Me.Close()
    End Sub
    Private Sub Seguridad_Anular_Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Focus()
    End Sub
    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
