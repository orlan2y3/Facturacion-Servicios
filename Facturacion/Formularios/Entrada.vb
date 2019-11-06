Imports System.Data.OleDb
Public Class Entrada
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress, txtusuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btentrar.Click
        If Trim(txtusuario.Text) = "" Then
            MsgBox("Debe digitar un usuario", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        If Trim(txtcontraseña.Text) = "" Then
            MsgBox("Debe digitar una contraseña", MsgBoxStyle.Information)
            txtcontraseña.Focus()
            Return
        End If

        Try

            DB.Conectar()

            Dim Reader As OleDbDataReader
            Dim objCmb As OleDbCommand

            Dim StrSql As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" + txtusuario.Text + "' and contrasena = '" + txtcontraseña.Text + "'"
            objCmb = New OleDbCommand(StrSql, DB.Cnn)
            Reader = objCmb.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                DTO.nombrelogueado = Reader("nombre_completo").ToString
                DTO.nivel = Reader("nivel").ToString
                DTO.id_usuario = Reader("id")
                DTO.usuario_activo_inactivo = Reader("estado").ToString
                Reader.Close()
            Else
                Reader.Close()
                DB.Desconectar()
                MsgBox("Acceso Negado ** Nombre de Usuario y/o Contraseña Incorrectos **", MsgBoxStyle.Critical)
                txtusuario.Focus()
                Return
            End If

            If DTO.usuario_activo_inactivo = "Inactivo" Then
                MsgBox("Este Usuario Esta Inactivo", MsgBoxStyle.Critical)
                txtusuario.Focus()
                DB.Desconectar()
                Return
            End If

            StrSql = "SELECT NombreEmpresa, Eslogan, Direccion, Telefono, Rnc, email FROM datos_empresa"
            objCmb = New OleDbCommand(StrSql, DB.Cnn)
            Reader = objCmb.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                Empresa = Reader("NombreEmpresa").ToString
                EsloganEmp = Reader("eslogan").ToString
                DireccionEmp = Reader("direccion").ToString
                TelefonoEmp = Reader("telefono").ToString
                RncEmp = Reader("rnc").ToString
                EmailEmp = Reader("email").ToString
                Reader.Close()
            Else
                Reader.Close()
            End If

            StrSql = "SELECT itbis, valida FROM parametros"
            objCmb = New OleDbCommand(StrSql, DB.Cnn)
            Reader = objCmb.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                DTO.porciento_itebis = Reader("itbis")
                Valida = Reader("valida").ToString
                Reader.Close()
            Else
                Reader.Close()
            End If

            Dim Menu As New frmMenu
            Menu.Show()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DB.Desconectar()
        End
    End Sub

End Class