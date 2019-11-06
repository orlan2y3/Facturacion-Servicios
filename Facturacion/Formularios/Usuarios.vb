Imports System.Data.OleDb
Public Class Usuarios
    Dim QuerySelect As String = "SELECT id, nombre_completo, usuario, nivel, estado FROM usuarios  order by id desc"
    Public ds As DataSet = New DataSet
    Public ds1 As DataSet = New DataSet
    Public Sub cargardatagrid(myQuery As String)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
        da.Fill(ds, "usuarios")
    End Sub
    Public Sub Buscar(myQuery As String)
        Dim da1 As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
        da1.Fill(ds1, "usuarios")
    End Sub
    Public Sub Activar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = DB.Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Activado Con Éxito", MsgBoxStyle.Information)
    End Sub
    Public Sub Desactivar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = DB.Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Desactivado Con Éxito", MsgBoxStyle.Information)
    End Sub
    Public Sub Actualizar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = DB.Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)
    End Sub
    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click
        If txtnombre.Text = "" Then
            MsgBox("Debe Digitar un Nombre", MsgBoxStyle.Information)
            txtnombre.Focus()
            Return
            txtnombre.Focus()
        End If

        If txtusuario.Text = "" Then
            MsgBox("Debe Debe Digitar un Apellido", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        If txtcontrasena.Text = "" Then
            MsgBox("Debe Debe Digitar una Contraseña", MsgBoxStyle.Information)
            txtcontrasena.Focus()
            Return
        End If

        If IsNumeric(txtnombre.Text) Then
            MsgBox("El nombre no debe contener numeros", MsgBoxStyle.Information)
            txtnombre.Focus()
            Return
        ElseIf IsNumeric(txtusuario.Text) Then
            MsgBox("El apellido no debe contener numeros", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        If rdbadministrador.Checked = False And rdbsupervisor.Checked = False And rdbcajero.Checked = False Then
            MsgBox("Debe elegir el nivel del nuevo usuario", MsgBoxStyle.Information)
            Return
        End If

        If IsNumeric(txtid.Text) Then

            Try

                Dim myQuery As String = "UPDATE usuarios SET nombre_completo = '" & txtnombre.Text & "', usuario = '" & txtusuario.Text & "', contrasena = '" & txtcontrasena.Text & "', nivel = " & txtnivel.Text & " where id = " & txtid.Text & ""
                Actualizar(myQuery)
                ds.Clear()
                cargardatagrid(QuerySelect)
                txtid.Text = ""
                txtnombre.Text = ""
                txtusuario.Text = ""
                txtcontrasena.Text = ""
                txtnivel.Text = ""
                rdbadministrador.Checked = False
                rdbsupervisor.Checked = False
                rdbcajero.Checked = False

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else

            Try

                Dim myQuery As String = "INSERT INTO usuarios (nombre_completo,usuario,contrasena,nivel) VALUES ('" _
                                        & txtnombre.Text & "','" & txtusuario.Text _
                                        & "','" & txtcontrasena.Text & "', " & txtnivel.Text & ")"
                insertar(myQuery)
                ds.Clear()
                cargardatagrid(QuerySelect)
                txtid.Text = ""
                txtnombre.Text = ""
                txtusuario.Text = ""
                txtcontrasena.Text = ""
                txtnivel.Text = ""
                rdbadministrador.Checked = False
                rdbsupervisor.Checked = False
                rdbcajero.Checked = False

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_usuarios = False
        Me.Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DTO.formulario_abierto_usuarios = True
            dgvclientes.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
            ds.Clear()
            ds.Tables.Clear()
            rdbnombre.Checked = True
            cargardatagrid(QuerySelect)
            dgvclientes.DataSource = ds
            dgvclientes.DataMember = "usuarios"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvclientesCellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvclientes.CellContentDoubleClick
        txtid.Text = Convert.ToString(dgvclientes.CurrentRow.Cells(0).Value)
        txtnombre.Text = Convert.ToString(dgvclientes.CurrentRow.Cells(1).Value)
        txtusuario.Text = Convert.ToString(dgvclientes.CurrentRow.Cells(2).Value)
        txtnivel.Text = Convert.ToString(dgvclientes.CurrentRow.Cells(3).Value)
    End Sub
    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        If txtid.Text = "" Then
            MsgBox("Debe Hacer Doble Clic en el Usuario que Desea Desactivar", MsgBoxStyle.Information)
            Return
        End If

        If DTO.nombrelogueado = txtnombre.Text Then
            MsgBox("Este Usuario tiene el sistema abierto en estos instantes", MsgBoxStyle.Information)
            Return
        End If

        Try

            Select Case MsgBox("Esta Seguro que Desea Desactivar Este Usuario", MsgBoxStyle.YesNo, MsgBoxStyle.DefaultButton2)

                Case MsgBoxResult.Yes

                    Dim myQuery As String = "UPDATE usuarios SET estado = 'Inactivo' Where id = " & txtid.Text
                    Desactivar(myQuery)
                    ds.Clear()
                    cargardatagrid(QuerySelect)
                    txtid.Text = ""
                    txtnombre.Text = ""
                    txtusuario.Text = ""
                    txtcontrasena.Text = ""
                    txtnivel.Text = ""
                    rdbadministrador.Checked = False
                    rdbsupervisor.Checked = False
                    rdbcajero.Checked = False

                Case MsgBoxResult.No
                    Return
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If rdbnombre.Checked = True And IsNumeric(txtbuscar.Text) Then
            MsgBox("Debe Digitar un Nombre", MsgBoxStyle.Information)
            Return
            txtbuscar.Focus()
        ElseIf rdbid.Checked = True And Not IsNumeric(txtbuscar.Text) Then
            MsgBox("Debe Digitar un Codigo", MsgBoxStyle.Information)
            Return
            txtbuscar.Focus()
        End If

        Try

            Dim myQuery As String = ""

            If (rdbid.Checked = True) Then
                myQuery = "select id, nombre_completo, usuario, nivel FROM usuarios where id = " & txtbuscar.Text & " "
            End If

            If (rdbnombre.Checked = True) Then
                myQuery = "select id, nombre_completo, usuario, nivel FROM usuarios where nombre_completo like '%" & txtbuscar.Text & "%'"
            End If

            ds1.Clear()
            Buscar(myQuery)
            dgvclientes.DataSource = ds1
            dgvclientes.DataMember = "usuarios"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btlimpiar_Click(sender As Object, e As EventArgs) Handles btlimpiar.Click
        txtusuario.Text = ""
        txtbuscar.Text = ""
        txtid.Text = ""
        txtnombre.Text = ""
        txtcontrasena.Text = ""
        txtnivel.Text = ""
        rdbadministrador.Checked = False
        rdbsupervisor.Checked = False
        rdbcajero.Checked = False
    End Sub
    Private Sub clientesFormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_usuarios = False
        ds.Clear()
        ds.Tables.Clear()
        ds1.Clear()
        ds1.Tables.Clear()
    End Sub
    Private Sub txtnombre_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtnombre.KeyPress, txtcontrasena.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rdbadministrador_Click(sender As Object, e As EventArgs) Handles rdbadministrador.Click
        If rdbadministrador.Checked = True Then
            txtnivel.Text = 1
        End If
    End Sub
    Private Sub rdbsupervisor_Click(sender As Object, e As EventArgs) Handles rdbsupervisor.Click
        If rdbsupervisor.Checked = True Then
            txtnivel.Text = 2
        End If
    End Sub
    Private Sub rdbcajero_Click(sender As Object, e As EventArgs) Handles rdbcajero.Click
        If rdbcajero.Checked = True Then
            txtnivel.Text = 3
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btactivar.Click
        If txtid.Text = "" Then
            MsgBox("Debe Hacer Doble Clic en el Usuario que Desea Activar", MsgBoxStyle.Information)
            Return
        End If

        Try

            Select Case MsgBox("Esta Seguro que Desea Activar Este Usuario", MsgBoxStyle.YesNo, MsgBoxStyle.DefaultButton2)
                Case MsgBoxResult.Yes

                    Dim myQuery As String = "UPDATE usuarios SET estado = 'Activo' Where id = " & txtid.Text
                    Activar(myQuery)
                    ds.Clear()
                    cargardatagrid(QuerySelect)
                    txtid.Text = ""
                    txtnombre.Text = ""
                    txtusuario.Text = ""
                    txtcontrasena.Text = ""
                    txtnivel.Text = ""
                    rdbadministrador.Checked = False
                    rdbsupervisor.Checked = False
                    rdbcajero.Checked = False

                Case MsgBoxResult.No
                    Return
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
