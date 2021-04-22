Imports System.Data.OleDb
Public Class Buscar_Factura
    Public ds As DataSet = New DataSet
    Public ds1 As DataSet = New DataSet

    Private Sub FormatGrid()
        frmMantFacturas.dgvfactura.Rows.Clear()
        frmMantFacturas.dgvfactura.ColumnCount = 6
        frmMantFacturas.dgvfactura.Columns(0).HeaderText = "CANT"
        frmMantFacturas.dgvfactura.Columns(1).HeaderText = "DESCRIPCION"
        frmMantFacturas.dgvfactura.Columns(2).HeaderText = "PRECIO"
        frmMantFacturas.dgvfactura.Columns(3).HeaderText = "IMPORTE"
        frmMantFacturas.dgvfactura.Columns(4).HeaderText = "ITBIS"
        frmMantFacturas.dgvfactura.Columns(5).HeaderText = "VALOR"

        frmMantFacturas.dgvfactura.Columns(0).Width = 50
        frmMantFacturas.dgvfactura.Columns(1).Width = 280
        frmMantFacturas.dgvfactura.Columns(2).Width = 80
        frmMantFacturas.dgvfactura.Columns(3).Width = 90
        frmMantFacturas.dgvfactura.Columns(4).Width = 80
        frmMantFacturas.dgvfactura.Columns(5).Width = 80

        ' desactivar los estilos visuales del sistema
        frmMantFacturas.dgvfactura.EnableHeadersVisualStyles = False
        frmMantFacturas.dgvfactura.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        frmMantFacturas.dgvfactura.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        frmMantFacturas.dgvfactura.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        frmMantFacturas.dgvfactura.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        frmMantFacturas.dgvfactura.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        frmMantFacturas.dgvfactura.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        frmMantFacturas.dgvfactura.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        frmMantFacturas.dgvfactura.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        frmMantFacturas.dgvfactura.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        frmMantFacturas.dgvfactura.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        frmMantFacturas.dgvfactura.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try

            ds.Clear()

            If TextBox1.Text = "" And CheckBox1.Checked = True Then
                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT id_factura, cliente, " &
                "condicion, fecha, total, estado, comprobante FROM factura WHERE estado = 'Anulada' ORDER BY id_factura DESC", DB.Cnn)

                da.Fill(ds, "factura")

                dgvbuscar_factura.DataSource = ds
                dgvbuscar_factura.DataMember = "factura"

                dgvbuscar_factura.Columns(4).DefaultCellStyle.Format = "##,###.00"

            ElseIf Len(TextBox1.Text) <> 0 And CheckBox1.Checked = True Then

                ds.Clear()

                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT id_factura, cliente, condicion, fecha, " &
                "total, estado, comprobante FROM factura WHERE estado = 'Anulada' and cliente Like '" & TextBox1.Text & "%' ORDER BY id_factura DESC", DB.Cnn)

                da.Fill(ds, "factura")

                dgvbuscar_factura.DataSource = ds
                dgvbuscar_factura.DataMember = "factura"

                dgvbuscar_factura.Columns(4).DefaultCellStyle.Format = "##,###.00"

            ElseIf TextBox1.Text = "" Then

                ds.Clear()

                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT id_factura, cliente, condicion, fecha, " &
                "total, estado, comprobante FROM factura WHERE estado = 'Normal' ORDER BY id_factura DESC", DB.Cnn)

                da.Fill(ds, "factura")

                dgvbuscar_factura.DataSource = ds
                dgvbuscar_factura.DataMember = "factura"

                dgvbuscar_factura.Columns(4).DefaultCellStyle.Format = "##,###.00"

            ElseIf Len(TextBox1.Text) <> 0 Then

                ds.Clear()

                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT id_factura, cliente, condicion, fecha, " &
                "total, estado, comprobante FROM factura WHERE estado = 'Normal' and cliente Like '" & TextBox1.Text & "%' ORDER BY id_factura DESC", DB.Cnn)

                da.Fill(ds, "factura")

                dgvbuscar_factura.DataSource = ds
                dgvbuscar_factura.DataMember = "factura"

                dgvbuscar_factura.Columns(4).DefaultCellStyle.Format = "##,###.00"

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Buscar_Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_buscar_factura = True
        dgvbuscar_factura.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        TextBox1.Select()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_buscar_factura = False
        Me.Close()
    End Sub

    Private Sub Buscar_Factura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_buscar_factura = False
        ds.Clear()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub dgvbuscar_factura_DoubleClick(sender As Object, e As EventArgs) Handles dgvbuscar_factura.DoubleClick
        Try
            If Not dgvbuscar_factura.CurrentRow.IsNewRow Then
                NF = dgvbuscar_factura.CurrentRow.Cells(0).Value
                FmantFacturas.txtnumfactura.Text = NF
                FmantFacturas.Show()
                FmantFacturas.btnBuscar.PerformClick()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class