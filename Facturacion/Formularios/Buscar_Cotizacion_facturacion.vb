Imports System.Data.OleDb

Public Class Buscar_Cotizacion_facturacion
    Private ds As DataSet = New DataSet
    Private ds1 As DataSet = New DataSet

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try

            Dim myQuery As String = ""

            ds.Clear()

            If Trim(txtbuscar.Text) = "" Then
                myQuery = "SELECT id_cotizacion, cliente, fecha, total, estado FROM cotizacion where" &
                          " estado = 'Normal' ORDER BY id_cotizacion DESC"

                Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, DB.Cnn)
                da.Fill(ds, "cotizacion")

                dgvbuscar_cotizacion.DataSource = ds
                dgvbuscar_cotizacion.DataMember = "cotizacion"

                dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

            Else
                myQuery = "SELECT id_cotizacion, cliente, fecha, total, estado FROM cotizacion where" &
                          " estado = 'Normal' and cliente like '" & txtbuscar.Text & "%' ORDER BY id_cotizacion DESC"

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

    Private Sub Buscar_Cotizacion_facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_buscar_cotizacion_facturacion = True
        dgvbuscar_cotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        txtbuscar.Focus()

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_buscar_cotizacion_facturacion = False
        Me.Close()
    End Sub

    Private Sub Buscar_Cotizacion_facturacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_buscar_cotizacion_facturacion = False
        ds.Clear()
    End Sub

    Private Sub dgvbuscar_cotizacion_DoubleClick(sender As Object, e As EventArgs) Handles dgvbuscar_cotizacion.DoubleClick
        Try

            NC = dgvbuscar_cotizacion.CurrentRow.Cells(0).Value

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT id_cotizacion, rnc, cliente, estado, porciento_itbis FROM cotizacion where id_cotizacion = " & NC

            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()
            dr.Read()

            Ffactura.txtrnccliente.Text = dr("rnc")
            Ffactura.txtcliente.Text = dr("cliente")
            If dr("porciento_itbis") = 0 Then
                Ffactura.cb1.Checked = True
                Ffactura.cb1.Font = New Font(Ffactura.cb1.Font, FontStyle.Bold)
            End If
            DTO.Estado = dr("estado")

            dr.Close()

            If DTO.Estado = "Anulada" Then
                MsgBox("Las cotizaciones anuladas no se pueden traer para facturar", MsgBoxStyle.Information)
                Return
            End If

            Ffactura.FormatGrid()

            '***** Agrego los productos que traigo de la cotizacion a la factura uno por uno *****

            Dim query1 As String = "SELECT id_cotizacion, producto, cantidad, precio FROM detalles_cotizacion WHERE id_cotizacion = " & NC
            Dim cmb1 As OleDbCommand = New OleDbCommand(query1, DB.Cnn)
            dr = cmb1.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    Ffactura.txtproducto.Text = dr("producto")
                    Ffactura.txtprecio.Text = dr("precio")
                    Ffactura.txtcantidad.Text = dr("cantidad")
                    Ffactura.btagregar.PerformClick()
                End While
                dr.Close()
            Else
                dr.Close()
                Return
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class