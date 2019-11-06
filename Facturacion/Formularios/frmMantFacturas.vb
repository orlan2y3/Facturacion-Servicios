Imports System.Data.OleDb

Public Class frmMantFacturas
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numfactura As Long
    Dim numfacturaanterior As Long
    Dim numcomp As Long
    Dim Seleccion As Integer
    Dim importeanterior As Double
    Dim NCF_Fijo As String
    Dim ncfsec As Long
    Dim grabando As Boolean
    Dim posicion As Integer
    Dim EstadoFactura As String
    Dim IdComprobante As Integer = 0

    Private Sub FormatGrid()
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
        Try
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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LimpiaCampos()
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
            txtValida.Text = Valida

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

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

    End Sub

    Private Sub frmMantFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            FormatGrid()
            LlenaTipoComprobantes()
            ncfsec = 0

            Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
            mtbfecha.Text = fecha
            txtValida.Text = Valida

            txtporcientodescuento.Text = 0
            txtdescuento.Text = 0.0
            cmbcondicion.SelectedIndex = 0
            rdb1.Checked = True
            GroupBox2.Enabled = False
            txtporcientoitbis.Text = DTO.porciento_itebis

            txtrnccliente.Select()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btagregar_Click(sender As Object, e As EventArgs) Handles btagregar.Click

        Try

            txtporcientodescuento.Enabled = True

            If Len(Trim(txtcliente.Text)) = 0 Then
                MsgBox("Debe Digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
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

    Private Sub Factura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_factura = False
    End Sub

    Private Sub txtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcliente.KeyPress, txtcantidad.KeyPress, txtproducto.KeyPress, cmbcondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
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

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Hide()
    End Sub

    Private Sub txtporcientoitbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientoitbis.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
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

    Private Sub txtnumfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumfactura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mtbfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbfecha.KeyPress
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

    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click

        Try

            grabando = True

            If Len(Trim(txtcliente.Text)) = 0 Then
                MsgBox("Debe de Digitar un Cliente", MsgBoxStyle.Information)
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

            If rdb2.Checked = True Then
                If cmbComprobantes.Text = "" Then
                    MsgBox("Si lleva comprobante, debe seleccionar el tipo", MsgBoxStyle.Information)
                    cmbComprobantes.Focus()
                    Return
                End If
            End If

            Dim PorcientoItbis As Double = 0
            Dim ValidaHasta As String = ""

            If cb1.Checked = True Then
                PorcientoItbis = 0
            Else
                PorcientoItbis = txtporcientoitbis.Text
            End If

            Dim TipoComprobante As String = ""

            If rdb1.Checked = True Then
                IdComprobante = 0
                txtnumcomprobante.Text = ""
                ValidaHasta = ""
            Else
                IdComprobante = cmbIdComprobante.Text
                ValidaHasta = txtValida.Text
            End If

            trans = DB.Cnn.BeginTransaction
            TA = True

            Dim myQuery As String = "UPDATE factura SET cliente = '" & txtcliente.Text & "', rnc = '" & txtrnccliente.Text _
                                        & "', condicion = '" & cmbcondicion.Text & "', comentario = '" & rtbcomentario.Text & "', fecha = '" & Efecha(mtbfecha.Text) _
                                        & "', sub_total = " & CDec(txtsubtotal.Text) & ", itbis = " & CDec(txtitbis.Text) & ", total = " & CDec(txttotal.Text) _
                                        & ", porciento_descuento = " & CDec(txtporcientodescuento.Text) & ", cantidad_descuento = " & CDec(txtdescuento.Text) _
                                        & ", porciento_itbis = " & PorcientoItbis & ", id_usuario = " & DTO.id_usuario & ", comprobante = '" & txtnumcomprobante.Text _
                                        & "', id_comprobante =" & IdComprobante & ",valida_hasta ='" & txtValida.Text & "' WHERE id_factura = " & txtnumfactura.Text & ""

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, DB.Cnn, trans)
            cmd3.Connection = DB.Cnn
            RA = cmd3.ExecuteNonQuery

            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error grabando el encabezado de la factura", MsgBoxStyle.Critical)
                txtcliente.Focus()
                Return
            End If

            Dim cmd5 As OleDbCommand

            Dim myQuery2 As String = "DELETE * FROM detalles_factura WHERE id_factura = " & txtnumfactura.Text & ""

            cmd5 = New OleDbCommand(myQuery2, DB.Cnn, trans)
            cmd5.Connection = DB.Cnn
            RA = cmd5.ExecuteNonQuery()

            Dim X As Integer
            For X = 0 To dgvfactura.Rows.Count
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

            If GroupBox2.Enabled = True Then
                Dim queryupdate2 As String = "UPDATE ncf Set sec = " & ncfsec & " WHERE id_tipo =" & cmbIdComprobante.Text
                Dim cmb3 As OleDbCommand = New OleDbCommand(queryupdate2, DB.Cnn, trans)
                RA = cmb3.ExecuteNonQuery()
                If RA <= 0 Then
                    trans.Rollback() : TA = False
                    MsgBox("Error actualizando la secuencia del comprobante fiscal", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            trans.Commit() : TA = False

            mtbfecha.Text = Date.Today.ToString("dd/MM/yyyy")
            MsgBox("Actualizado Con Éxito", MsgBoxStyle.Information)

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btactualizar_Click(sender As Object, e As EventArgs) Handles btactualizar.Click
        DTO.donde_dio_click = "anular_factura"
        Seguridad_Anular_Factura.txtusuario.Focus()

        Try

            If DTO.nivel = 2 Or DTO.nivel = 3 Then

                Dim seguridad As New Seguridad_Anular_Factura
                seguridad.ShowDialog()

                If DTO.usuario_activo_inactivo = "" Then
                    Return
                End If

                If DTO.usuario_activo_inactivo = "Inactivo" Then
                    MsgBox("Este Usuario Esta Inactivo", MsgBoxStyle.Critical)
                    Return
                End If

                If DTO.nivel_seguridad = 1 Then

                    If MessageBox.Show("Esta seguro que desea anular esta factura", " Importante ",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Dim queryupdate As String = "UPDATE factura SET estado = 'Anulada', usuario_anulo = " & DTO.id_usuario & " WHERE id_factura = " & CLng(txtnumfactura.Text)
                        Dim cmb As OleDbCommand = New OleDbCommand(queryupdate, DB.Cnn)
                        cmb.ExecuteNonQuery()
                        lbestado.Visible = True
                        btactualizar.Enabled = False
                    Else
                        DTO.nivel_seguridad = 0
                        Return
                    End If
                Else
                    Return
                End If

            Else

                If MessageBox.Show("Esta seguro que desea eliminar esta factura", " Importante ",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim queryupdate As String = "UPDATE factura SET estado = 'Anulada', usuario_anulo = " & DTO.id_usuario & " WHERE id_factura = " & CLng(txtnumfactura.Text)
                    Dim cmb As OleDbCommand = New OleDbCommand(queryupdate, DB.Cnn)
                    cmb.ExecuteNonQuery()
                    lbestado.Visible = True
                    btactualizar.Enabled = False
                Else
                    DTO.nivel_seguridad = 0
                    Return
                End If
            End If

            btinsertar.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try
            Dim dr As OleDbDataReader
            Dim Estado As String

            Dim query As String = "SELECT estado FROM factura WHERE id_factura =" & txtnumfactura.Text
            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                Estado = dr("estado").ToString
                dr.Close()
            Else
                Estado = ""
                dr.Close()
            End If

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

            Rpt.RecordSelectionFormula = "{factura.id_factura} =" & txtnumfactura.Text
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"
            Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
            Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
            Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "'" & "Tels: " & TelefonoEmp & "'"

            'If DTO.Estado = "Anulada" Then
            '    Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** FACTURA ANULADA ***** '"
            'End If

            If Estado = "Anulada" Then
                Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** FACTURA ANULADA ***** '"
            End If

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            LimpiaCampos()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT f.id_factura, f.cliente, f.rnc, u.nombre_completo, f.usuario_anulo, " &
                          "f.condicion, f.fecha, f.sub_total, f.itbis, f.porciento_descuento, f.comprobante, " &
                          "f.cantidad_descuento, f.comentario, f.total, f.estado, f.porciento_itbis, " &
                          "f.id_comprobante, f.valida_hasta, f.id_usuario FROM " &
                          "factura f, usuarios u where f.id_usuario = u.id And f.id_factura = " & NF

            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()
            dr.Read()

            Dim ComprobanteFiscal As String = ""
            Dim usuario_anulo As Long = dr("usuario_anulo").ToString
            txtnumfactura.Text = dr("id_factura").ToString
            cmbcondicion.Text = dr("condicion").ToString
            mtbfecha.Text = Lfecha(dr("fecha").ToString)
            txtcliente.Text = dr("cliente").ToString
            txtsubtotal.Text = FormatNumber(dr("sub_total"), 2)
            txtitbis.Text = FormatNumber(dr("itbis"), 2)
            txtporcientodescuento.Text = Format(dr("porciento_descuento").ToString)
            txtdescuento.Text = FormatNumber(dr("cantidad_descuento"), 2)
            txttotal.Text = FormatNumber(dr("total"), 2)
            rtbcomentario.Text = dr("comentario").ToString
            txtporcientoitbis.Text = dr("porciento_itbis").ToString
            If dr("porciento_itbis") = 0 Then
                cb1.Checked = True
                cb1.Font = New Font(cb1.Font, FontStyle.Bold)
            End If
            lbusuarioquefacturo.Text = "Esta Factura fue hecha por: " & dr("nombre_completo").ToString
            txtrnccliente.Text = dr("rnc").ToString

            txtnumcomprobante.Text = dr("comprobante").ToString
            ComprobanteFiscal = dr("comprobante").ToString
            IdComprobante = dr("id_comprobante")
            If Len(Trim(ComprobanteFiscal)) > 0 Then
                txtValida.Text = dr("valida_hasta").ToString
            Else
                txtValida.Text = ""
            End If

            DTO.Estado = dr("estado").ToString
            dr.Close()

            If IdComprobante > 0 Then
                query = "SELECT descripcion FROM NCF WHERE id_tipo =" & IdComprobante
                cmb = New OleDbCommand(query, DB.Cnn)
                dr = cmb.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    cmbComprobantes.Text = dr("descripcion").ToString
                    dr.Close()
                Else
                    dr.Close()
                End If
            End If

            If DTO.Estado = "Anulada" Then

                Dim query2 As String = "SELECT nombre_completo FROM usuarios WHERE id = " & usuario_anulo
                Dim cmb2 As OleDbCommand = New OleDbCommand(query2, DB.Cnn)
                dr = cmb2.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    lbestado.Visible = True
                    btactualizar.Enabled = False
                    btagregar.Enabled = False
                    btinsertar.Enabled = False
                    lbestado.Text = "Esta factura fue anulada por: " & dr("nombre_completo")
                    dr.Close()
                Else
                    dr.Close()
                End If
            Else
                lbestado.Text = ""
                lbestado.Visible = False
                btactualizar.Enabled = True
                btagregar.Enabled = True
                btinsertar.Enabled = True
            End If

            'Llenar datagriview con reader en ves de data source***
            FormatGrid()
            Dim query1 As String = "SELECT cantidad, producto, precio," &
                               "importe, itbis, valor FROM detalles_factura WHERE id_factura = " & NF & " ORDER BY id_detalles_factura ASC"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query1, DB.Cnn)
            dr = cmb1.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    dgvfactura.Rows.Add(dr("cantidad"), dr("producto"), FormatNumber(dr("precio"), 2), FormatNumber(dr("importe"), 2), FormatNumber(dr("itbis"), 2), FormatNumber(dr("valor"), 2))
                End While
                dr.Close()
            Else
                dr.Close()
                Return
            End If

            If txtnumcomprobante.TextLength > 1 Then
                GroupBox1.Enabled = False
                GroupBox2.Enabled = False
                rdb2.Checked = True
                Label16.Enabled = False
                txtValida.Enabled = False
            Else
                GroupBox1.Enabled = True
                rdb1.Checked = True
                Label16.Enabled = True
                txtValida.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

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

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        If cb1.Checked = True Then
            cb1.Font = New Font(cb1.Font, FontStyle.Bold)
        Else
            cb1.Font = New Font(cb1.Font, FontStyle.Regular)
        End If

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