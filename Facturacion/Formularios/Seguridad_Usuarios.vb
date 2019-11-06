Imports System.Data.OleDb
Public Class Seguridad_Usuarios
    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Focus()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DTO.usuario_activo_inactivo = ""
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtusuario.Text = "" Then
            MsgBox("Debe digitar un usuario", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        If txtcontraseña.Text = "" Then
            MsgBox("Debe digitar una contraseña", MsgBoxStyle.Information)
            txtcontraseña.Focus()
            Return
        End If

        Try

            'Dim cmd As New OleDbCommand
            'Dim Reader As OleDbDataReader
            'Dim StrSql As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" + txtusuario.Text + "' and contrasena = '" + txtcontraseña.Text + "'"
            'cmd.CommandText = StrSql
            'cmd.CommandType = CommandType.Text
            'cmd.Connection = DB.Cnn
            'Reader = cmd.ExecuteReader()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" _
            & txtusuario.Text & "' AND contrasena ='" & txtcontraseña.Text & "'"
            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                DTO.nivel_seguridad = dr("nivel")
                DTO.usuario_activo_inactivo = dr("estado")
                dr.Close()

                If DTO.nivel_seguridad = 1 Or DTO.nivel_seguridad = 2 Then

                    If DTO.donde_dio_click = "productos" And DTO.nivel_seguridad = 1 Then
                        Me.Close()
                    End If

                    If DTO.donde_dio_click = "productos" And DTO.nivel_seguridad = 2 Or DTO.nivel_seguridad = 3 Then
                        MsgBox("Acceso negado", MsgBoxStyle.Critical)
                        Return
                    End If

                    If DTO.donde_dio_click = "usuarios" And DTO.nivel_seguridad = 1 Then
                        Me.Close()
                    End If

                    If DTO.donde_dio_click = "usuarios" And DTO.nivel_seguridad = 2 Then
                        MsgBox("Acceso negado", MsgBoxStyle.Critical)
                        Return
                    End If

                    If DTO.donde_dio_click = "parametros" And DTO.nivel_seguridad = 1 Then
                        Me.Close()
                    End If

                    If DTO.donde_dio_click = "parametros" And DTO.nivel_seguridad = 2 Then
                        MsgBox("Acceso negado", MsgBoxStyle.Critical)
                        Return
                    End If
                End If

            Else
                dr.Close()
                MsgBox("Acceso Negado", MsgBoxStyle.Critical)
                txtusuario.Focus()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
