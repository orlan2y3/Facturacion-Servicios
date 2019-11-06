Imports System.Data.OleDb

Public Class frmDatosEmpresa
    Private Sub frmDatosEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Text = Empresa
        txtRnc.Text = RncEmp
        txtEslogan.Text = EsloganEmp
        txtTelefonos.Text = TelefonoEmp
        txtDireccion.Text = DireccionEmp
        txtEmail.Text = EmailEmp

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click

        Try

            Dim myQuery As String = " UPDATE datos_empresa SET NombreEmpresa ='" & txtNombre.Text _
            & "', direccion ='" & txtDireccion.Text & "', telefono ='" & txtTelefonos.Text & "', rnc ='" & txtRnc.Text _
            & "', eslogan ='" & txtEslogan.Text & "', email ='" & txtEmail.Text & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(myQuery, DB.Cnn)
            cmd.Connection = DB.Cnn
            RA = cmd.ExecuteNonQuery
            If RA > 0 Then
                Empresa = Trim(txtNombre.Text)
                DireccionEmp = Trim(txtDireccion.Text)
                EmailEmp = Trim(txtEmail.Text)
                RncEmp = Trim(txtRnc.Text)
                TelefonoEmp = Trim(txtTelefonos.Text)
                EsloganEmp = Trim(txtEslogan.Text)
                MsgBox("Los datos fueron actualizados", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRnc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRnc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEslogan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEslogan.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTelefonos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class