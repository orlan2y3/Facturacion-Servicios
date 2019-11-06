Imports System.Data.OleDb
Public Class Buscar_Cotizacion
    Public ds As DataSet = New DataSet
    Public ds1 As DataSet = New DataSet
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try

            Dim myQuery As String = ""

            ds.Clear()

            If txtbuscar.Text = "" And CheckBox1.Checked = True Then
                myQuery = "SELECT id_cotizacion, cliente, fecha, total, estado " &
                "FROM cotizacion WHERE estado = 'Anulada' ORDER BY id_cotizacion DESC"

                Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
                da.Fill(ds, "cotizacion")

                dgvbuscar_cotizacion.DataSource = ds
                dgvbuscar_cotizacion.DataMember = "cotizacion"

                dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

            ElseIf Len(txtbuscar.Text) <> 0 And CheckBox1.Checked = True Then

                myQuery = "SELECT id_cotizacion, cliente, fecha, total, estado " &
                "FROM cotizacion WHERE estado = 'Anulada' and cliente like '" & txtbuscar.Text & "%' ORDER BY id_cotizacion DESC"

                Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
                da.Fill(ds, "cotizacion")

                dgvbuscar_cotizacion.DataSource = ds
                dgvbuscar_cotizacion.DataMember = "cotizacion"

                dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

            ElseIf txtbuscar.Text = "" Then
                myQuery = "SELECT id_cotizacion, cliente, fecha, total, estado " &
                "FROM cotizacion WHERE estado = 'Normal' ORDER BY id_cotizacion DESC"

                Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
                da.Fill(ds, "cotizacion")

                dgvbuscar_cotizacion.DataSource = ds
                dgvbuscar_cotizacion.DataMember = "cotizacion"

                dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

            ElseIf Len(txtbuscar.Text) <> 0 Then
                myQuery = "SELECT id_cotizacion, cliente, fecha, total, estado " &
                "FROM cotizacion WHERE estado = 'Normal' and cliente like '" & txtbuscar.Text & "%' ORDER BY id_cotizacion DESC"

                Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
                da.Fill(ds, "cotizacion")

                dgvbuscar_cotizacion.DataSource = ds
                dgvbuscar_cotizacion.DataMember = "cotizacion"

                dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Buscar_Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_buscar_cotizacion = True
        dgvbuscar_cotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        txtbuscar.Focus()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_buscar_cotizacion = False
        Me.Close()
    End Sub

    Private Sub Buscar_Cotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_buscar_cotizacion = False
        ds.Clear()
    End Sub

    Private Sub dgvbuscar_cotizacion_DoubleClick(sender As Object, e As EventArgs) Handles dgvbuscar_cotizacion.DoubleClick
        Try

            If Not dgvbuscar_cotizacion.CurrentRow.IsNewRow Then
                NC = dgvbuscar_cotizacion.CurrentRow.Cells(0).Value
                FmantCotizacion.txtnumcotizacion.Text = NC
                FmantCotizacion.Show()
                FmantCotizacion.btnBuscar.PerformClick()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class