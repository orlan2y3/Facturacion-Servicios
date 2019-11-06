Imports System.Data.OleDb

Public Class Form1
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numfactura As Long
    Dim numfacturaanterior As Long
    Dim numcomp As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim NCF_Fijo As String
    Dim ncfsec As Long
    Dim grabando As Boolean
    Dim posicion As Integer

    Public Sub FormatGrid()
        dgvfactura.Rows.Clear()
        dgvfactura.ColumnCount = 6
        dgvfactura.Columns(0).HeaderText = "CANT"
        dgvfactura.Columns(1).HeaderText = "DESCRIPCION"
        dgvfactura.Columns(2).HeaderText = "PRECIO"
        dgvfactura.Columns(3).HeaderText = "IMPORTE"
        dgvfactura.Columns(4).HeaderText = "ITBIS"
        dgvfactura.Columns(5).HeaderText = "VALOR"

        dgvfactura.Columns(0).Width = 50
        dgvfactura.Columns(1).Width = 280
        dgvfactura.Columns(2).Width = 80
        dgvfactura.Columns(3).Width = 90
        dgvfactura.Columns(4).Width = 80
        dgvfactura.Columns(5).Width = 80

        ' desactivar los estilos visuales del sistema
        dgvfactura.EnableHeadersVisualStyles = False
        dgvfactura.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvfactura.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        dgvfactura.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub LlenaTipoComprobantes()
        Try
            cmbComprobantes.Items.Clear()
            cmbIdComprobante.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT id_tipo, descripcion  FROM NCF"
            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    cmbIdComprobante.Items.Add(dr("id_tipo"))
                    cmbComprobantes.Items.Add(dr("descripcion"))
                End While
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Sub CalcularTotal()
        If dgvfactura.Rows.Count > 0 Then
            Dim SubTotal As Double = 0
            Dim Itbis As Double = 0
            Dim Descuento As Double = 0
            Dim Total As Double = 0

            For X = 0 To dgvfactura.Rows.Count - 1
                SubTotal = SubTotal + dgvfactura.Item(3, X).Value
                Itbis = Itbis + dgvfactura.Item(4, X).Value
            Next
            txtitbis.Text = FormatNumber(Itbis, 2)
            txtsubtotal.Text = FormatNumber(SubTotal, 2)

            If IsNumeric(txtdescuento.Text) Then
                Descuento = CDbl(txtdescuento.Text)
            End If

            Total = (SubTotal + Itbis) - Descuento
            txttotal.Text = FormatNumber(Total, 2)

        End If
    End Sub

    Private Sub btagregar_Click(sender As Object, e As EventArgs) Handles btagregar.Click

        Try

            txtporcientodescuento.Enabled = True

            If Len(Trim(txtcliente.Text)) = 0 Then
                MsgBox("Debe Digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            End If

            If Not IsNumeric(txtcantidad.Text) Then
                MsgBox("Debe Digitar una Cantidad numerica", MsgBoxStyle.Information)
                txtcantidad.Focus()
                Return
            Else
                If txtcantidad.Text <= 0 Then
                    MsgBox("La cantidad debe ser un valor mayor que cero ", MsgBoxStyle.Information)
                    txtcantidad.Focus()
                    Return
                End If
            End If
            If Len(Trim(txtproducto.Text)) = 0 Then
                MsgBox("Debe digitar la descripción ", MsgBoxStyle.Information)
                txtproducto.Focus()
                Return
            End If
            If Not IsNumeric(txtprecio.Text) Then
                MsgBox("El precio debe ser numerico ", MsgBoxStyle.Information)
                txtprecio.Focus()
                Return
            Else
                If txtprecio.Text <= 0 Then
                    MsgBox("El precio debe ser un valor mayor que cero ", MsgBoxStyle.Information)
                    txtprecio.Focus()
                    Return
                End If
            End If

            Dim importe As Double = 0
            Dim Valor As Double = 0
            itbis = 0

            importe = txtprecio.Text * txtcantidad.Text
            If cb1.Checked = False Then
                itbis = (importe * DTO.porciento_itebis) / 100
                Valor = importe + itbis
            Else
                Valor = importe
            End If

            If InStr(txtproducto.Text, "'") Then
                txtproducto.Text = Cambiar(txtproducto.Text)
            End If

            If txtcantidad.BackColor = Color.White Then
                dgvfactura.Rows.Add(txtcantidad.Text, txtproducto.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(importe, 2), FormatNumber(itbis, 2), FormatNumber(Valor, 2))
            Else
                dgvfactura.Item(0, posicion).Value = txtcantidad.Text
                dgvfactura.Item(1, posicion).Value = txtproducto.Text
                dgvfactura.Item(2, posicion).Value = FormatNumber(txtprecio.Text, 2)
                dgvfactura.Item(3, posicion).Value = FormatNumber(importe, 2)
                dgvfactura.Item(4, posicion).Value = FormatNumber(itbis, 2)
                dgvfactura.Item(5, posicion).Value = FormatNumber(Valor, 2)

                txtcantidad.BackColor = Color.White
                txtproducto.BackColor = Color.White
                txtprecio.BackColor = Color.White

                bteliminar.Visible = False

            End If

            CalcularTotal()

            txtproducto.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = ""
            txtcantidad.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtprecio_Leave(sender As Object, e As EventArgs) Handles txtprecio.Leave
        If IsNumeric(txtprecio.Text) Then
            FormatNumber(txtprecio.Text, 2)
        End If
    End Sub
    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click

        Try

            grabando = True

            If IsNumeric(txtcliente.Text) Then
                MsgBox("Debe de Digitar o Seleccionar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf txtcliente.Text = "" Then
                MsgBox("Debe de Digitar o Seleccionar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf cmbcondicion.Text = "" Then
                MsgBox("Debe Seleccionar una Condición", MsgBoxStyle.Information)
                cmbcondicion.Focus()
                Return
            ElseIf dgvfactura(0, 0).Value.ToString = "" Then
                MsgBox("Debe agregar un producto a la factura", MsgBoxStyle.Information)
                txtproducto.Focus()
                Return
            End If

            Dim IdComprobante As Integer = 0
            Dim PorcientoItbis As Double = 0
            Dim ValidaHasta As String = ""
            Dim myQuery As String = ""
            Dim cmd3 As OleDbCommand

            If Not IsNumeric(txtitbis.Text) Then
                txtitbis.Text = 0
            End If
            If Not IsNumeric(txtporcientodescuento.Text) Then
                txtporcientodescuento.Text = 0
            End If
            If Not IsNumeric(txtdescuento.Text) Then
                txtdescuento.Text = 0
            End If
            If cb1.Checked = True Then
                PorcientoItbis = 0
            Else
                PorcientoItbis = txtporcientoitbis.Text
            End If

            If rdb1.Checked = True Then
                ValidaHasta = ""
                IdComprobante = 0
            Else
                Dim dr As OleDbDataReader
                myQuery = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE COMPROBANTE ='" & Trim(txtnumcomprobante.Text) & "'"
                cmd3 = New OleDbCommand(myQuery, DB.Cnn)
                cmd3.Connection = DB.Cnn
                dr = cmd3.ExecuteReader
                If dr.HasRows Then
                    Dim IdFactura As Long = 0
                    dr.Read()
                    IdFactura = dr("id_factura")
                    dr.Close()
                    MsgBox("Ese No. de comprobante ya se uso en la factura No. " & IdFactura, vbCritical)
                    txtcantidad.Focus()
                    Return
                Else
                    dr.Close()
                End If

                ValidaHasta = txtValida.Text
                IdComprobante = cmbIdComprobante.Text
            End If

            Dim TipoComprobante As String = ""

            If rdb1.Checked = True Then
                TipoComprobante = "" : ValidaHasta = ""
            Else
                TipoComprobante = cmbComprobantes.Text
                ValidaHasta = txtValida.Text
            End If

            trans = DB.Cnn.BeginTransaction
            TA = True

            myQuery = "INSERT INTO factura (id_factura,cliente,rnc,condicion,comentario,fecha,sub_total,itbis,total," _
            & " porciento_descuento, cantidad_descuento,porciento_itbis,id_usuario,comprobante, id_comprobante, valida_hasta)" _
            & " VALUES (" & txtnumfactura.Text & ",'" & txtcliente.Text & "','" & txtrnccliente.Text & "','" & cmbcondicion.Text _
            & "','" & rtbcomentario.Text & "','" & Efecha(mtbfecha.Text) & "'," & CDec(txtsubtotal.Text) _
            & "," & CDec(txtitbis.Text) & "," & CDec(txttotal.Text) & "," & CDec(txtporcientodescuento.Text) _
            & "," & CDec(txtdescuento.Text) & "," & PorcientoItbis & "," & DTO.id_usuario _
            & ",'" & txtnumcomprobante.Text & "'," & IdComprobante & ",'" & ValidaHasta & "')"

            cmd3 = New OleDbCommand(myQuery, DB.Cnn, trans)
            cmd3.Connection = DB.Cnn
            RA = cmd3.ExecuteNonQuery
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error grabando el encabezado de la factura", MsgBoxStyle.Critical)
                txtcliente.Focus()
                Return
            End If

            Dim X As Integer
            For X = 0 To dgvfactura.Rows.Count - 1
                If IsNumeric(dgvfactura(0, X).Value) Then
                    Dim cmd4 As OleDbCommand

                    Dim myQuery1 As String = "INSERT INTO detalles_factura(id_factura,producto,cantidad,precio,importe,itbis,valor) VALUES (" _
                    & txtnumfactura.Text & ",'" & (dgvfactura(1, X).Value) & "'," & CDec(dgvfactura(0, X).Value) _
                    & "," & CDec(dgvfactura(2, X).Value) & "," & CDec(dgvfactura(3, X).Value) _
                    & "," & CDec(dgvfactura(4, X).Value) & "," & CDec(dgvfactura(5, X).Value) & ")"

                    cmd4 = New OleDbCommand(myQuery1, DB.Cnn, trans)
                    cmd4.Connection = DB.Cnn
                    RA = cmd4.ExecuteNonQuery()
                    If RA <= 0 Then
                        trans.Rollback() : TA = False
                        MsgBox("Error grabando el detalle de la factura", MsgBoxStyle.Critical)
                        txtproducto.Focus()
                        Return
                    End If
                Else
                    Exit For
                End If
            Next X

            numfacturaanterior = txtnumfactura.Text

            Dim queryupdate As String = "UPDATE secuencia Set sec = " & txtnumfactura.Text
            Dim cmb2 As OleDbCommand = New OleDbCommand(queryupdate, DB.Cnn, trans)
            RA = cmb2.ExecuteNonQuery()
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error grabando la secuencia", MsgBoxStyle.Critical)
                Return
            End If

            If rdb2.Checked = True Then
                Dim queryupdate2 As String = "UPDATE ncf Set sec = " & ncfsec & " WHERE id_tipo = " & cmbIdComprobante.Text
                Dim cmb3 As OleDbCommand = New OleDbCommand(queryupdate2, DB.Cnn, trans)
                RA = cmb3.ExecuteNonQuery()
                If RA <= 0 Then
                    trans.Rollback() : TA = False
                    MsgBox("Error actualiazando secuencia del comprobante fiscal", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            trans.Commit() : TA = False


            If MessageBox.Show("FACTURA grabada con éxito, desea imprimirla?", " Importante ",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.Cursor = Cursors.WaitCursor
                Dim Reporte As New Reportes
                Reporte.MdiParent = Me.MdiParent

                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                If rdb1.Checked = True Then
                    Rpt.Load(Application.StartupPath & "\FacturaSin.rpt")
                Else
                    Rpt.Load(Application.StartupPath & "\Factura.rpt")
                End If
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"
                Rpt.RecordSelectionFormula = "{factura.id_factura} =" & numfacturaanterior
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
                Me.Cursor = Cursors.Default
            End If

            btnuevo.PerformClick()

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_factura = False
    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try

            If txtcantidad.BackColor = Color.Yellow Then
                dgvfactura.Rows.RemoveAt(posicion)
                CalcularTotal()
            End If

            txtcantidad.BackColor = Color.White
            txtproducto.BackColor = Color.White
            txtprecio.BackColor = Color.White

            txtproducto.Clear() : txtprecio.Clear() : txtcantidad.Clear()
            txtcantidad.Focus()

            bteliminar.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtporcientodescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientodescuento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btinsertar.Focus()
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

    End Sub

    Private Sub rtbcomentario_Click(sender As Object, e As EventArgs) Handles rtbcomentario.Click
        rtbcomentario.SelectionStart = 0
        rtbcomentario.SelectionLength = rtbcomentario.Text.Length

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If DTO.formulario_abierto_buscar_factura = True Then
            MsgBox("Este formulario ya esta abierto", MsgBoxStyle.Information)
            Return
        End If
        Dim buscar As New Buscar_Factura
        buscar.Show()

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_factura = False
        Ffactura.Hide()

    End Sub

    Private Sub btbuscarCotizacion_Click(sender As Object, e As EventArgs) Handles btbuscarCotizacion.Click
        If DTO.formulario_abierto_buscar_cotizacion_facturacion = True Then
            MsgBox("Este formulario ya esta abierto", MsgBoxStyle.Information)
            Return
        End If
        Dim buscar As New Buscar_Cotizacion_facturacion
        buscar.Show()

    End Sub

    Private Sub txtnumfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumfactura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtrnccliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrnccliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub cmbComprobantes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbComprobantes.SelectedValueChanged
        cmbIdComprobante.SelectedIndex = cmbComprobantes.SelectedIndex
    End Sub

    Private Sub txtporcientodescuento_Leave(sender As Object, e As EventArgs) Handles txtporcientodescuento.Leave
        If IsNumeric(txtporcientodescuento.Text) Then
            If IsNumeric(txttotal.Text) Then
                txtdescuento.Text = (txttotal.Text * txtporcientodescuento.Text) / 100
                CalcularTotal()
            Else
                txtdescuento.Clear()
            End If
        Else
            txtdescuento.Clear()
            CalcularTotal()
        End If

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        Try
            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM secuencia"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb1.ExecuteReader()
            dr.Read()
            numfactura = dr("sec") + 1
            txtnumfactura.Text = numfactura
            dr.Close()

            cmbcondicion.SelectedIndex = 0
            txtporcientoitbis.ReadOnly = True
            txtcliente.Clear() : txtrnccliente.Clear()
            Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
            mtbfecha.Text = fecha
            txtValida.Clear()

            txtproducto.Clear() : txtprecio.Clear() : txtcantidad.Clear() : rtbcomentario.Clear()
            txtsubtotal.Clear() : txtitbis.Clear() : txtporcientodescuento.Clear() : txtdescuento.Clear() : txttotal.Clear()

            rdb1.Checked = True
            cb1.Checked = False
            LlenaTipoComprobantes()
            txtnumcomprobante.Clear()
            ncfsec = 0
            txtporcientoitbis.Text = DTO.porciento_itebis

            GroupBox2.Enabled = False
            Label16.Enabled = False
            txtValida.Enabled = False
            FormatGrid()

            txtcantidad.BackColor = Color.White
            txtproducto.BackColor = Color.White
            txtprecio.BackColor = Color.White
            txtrnccliente.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmbcondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbcondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtproducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtproducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        If cb1.Checked = True Then
            cb1.Font = New Font(cb1.Font, FontStyle.Bold)
        Else
            cb1.Font = New Font(cb1.Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub dgvfactura_DoubleClick(sender As Object, e As EventArgs) Handles dgvfactura.DoubleClick
        Try
            If IsNothing(dgvfactura.CurrentRow.Cells(0).Value) Then
                Return
            End If

            If Not dgvfactura.CurrentRow.IsNewRow Then
                posicion = dgvfactura.CurrentRow.Index
                txtcantidad.Text = dgvfactura.Item(0, dgvfactura.CurrentRow.Index).Value
                txtproducto.Text = dgvfactura.Item(1, dgvfactura.CurrentRow.Index).Value
                txtprecio.Text = dgvfactura.Item(2, dgvfactura.CurrentRow.Index).Value

                txtcantidad.BackColor = Color.Yellow
                txtproducto.BackColor = Color.Yellow
                txtprecio.BackColor = Color.Yellow

                bteliminar.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub rdb1_Click(sender As Object, e As EventArgs) Handles rdb1.Click
        LlenaTipoComprobantes()
        txtnumcomprobante.Text = ""
        GroupBox2.Enabled = False

        Label16.Enabled = False
        txtValida.Clear()
        txtValida.Enabled = False

    End Sub

    Private Sub rdb2_Click(sender As Object, e As EventArgs) Handles rdb2.Click
        txtnumcomprobante.Text = ""
        GroupBox2.Enabled = True

        Label16.Enabled = True
        txtValida.Enabled = True
        txtValida.Text = Valida
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("Por favor dele clic en el botón salir, para cerrar el formulario", vbInformation)
        Return
    End Sub

    Private Sub cmbIdComprobante_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdComprobante.SelectedValueChanged
        Try
            If cmbIdComprobante.Text <> "" Then

                Dim dr As OleDbDataReader
                Dim query As String = "SELECT sec, fijo FROM NCF WHERE id_tipo =" & cmbIdComprobante.Text
                Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
                dr = cmb.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    NCF_Fijo = dr("fijo").ToString
                    ncfsec = dr("sec") + 1
                    txtnumcomprobante.Text = NCF_Fijo & ncfsec
                    dr.Close()
                Else
                    dr.Close()
                    txtnumcomprobante.Text = ""
                End If

            Else
                txtnumcomprobante.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

End Class