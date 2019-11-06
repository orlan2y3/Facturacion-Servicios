Imports System.Data.OleDb
Public Class Editar_Factura
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numfactura As Long
    Dim numfacturaanterior As Long
    Dim numcomp As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim ncfsec As Long
    Dim ncfseleccion As String
    Dim grabando As Boolean
    Dim dr As OleDbDataReader
    Dim posicion As Integer

    Sub LlenaTipoComprobantes()
        cmbComprobantes.Items.Clear()
        cmbFijo.Items.Clear()

        Dim dr As OleDbDataReader
        Dim query As String = "SELECT descripcion, fijo FROM NCF"
        Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
        dr = cmb.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()
                cmbComprobantes.Items.Add(dr("descripcion"))
                cmbFijo.Items.Add(dr("fijo"))
            End While
            dr.Close()
        Else
            dr.Close()
        End If

    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub mtbfecha_KeyPress(sender As Object, e As KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Editar_Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DTO.formulario_abierto_factura = True
            dgvfactura.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
            Dim importe As Double

            LlenaTipoComprobantes()

            'If tipordb = "sin" Then
            '    rdb1.Checked = True
            'ElseIf tipordb = "con" Then
            '    rdb2.Checked = True
            'End If

            If txtporcientodescuento.Text = "" Then
                txtdescuento.Focus()
                Return
            Else

                For X = 0 To dgvfactura.Rows.Count
                    If IsNumeric(dgvfactura(0, X).Value) Then
                        importe = importe + CDec(dgvfactura(3, X).Value)
                    Else
                        Exit For
                    End If
                Next X

                If importe > 0 Then

                    txtdescuento.Text = CDbl(txtporcientodescuento.Text) * importe / 100
                    subtotal = importe
                    itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
                    total = (subtotal + itbis) - CDbl(txtdescuento.Text)

                    txtitbis.Text = FormatNumber(itbis, 2)
                    txtsubtotal.Text = FormatNumber(subtotal, 2)
                    txttotal.Text = FormatNumber(total, 2)
                    txtdescuento.Text = FormatNumber(txtdescuento.Text, 2)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btagregar_Click(sender As Object, e As EventArgs) Handles btagregar.Click

        Try

            txtporcientodescuento.Enabled = True

            If txtcliente.Text = "" Then
                MsgBox("Debe digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf txtproducto.Text = "" Then
                MsgBox("Debe digitar un producto", MsgBoxStyle.Information)
                txtproducto.Focus()
                Return
            ElseIf txtprecio.Text = "" Then
                MsgBox("Debe digitar un precio", MsgBoxStyle.Information)
                txtproducto.Focus()
                Return
            ElseIf Not IsNumeric(txtcantidad.Text) Then
                MsgBox("Debe digitar una Cantidad", MsgBoxStyle.Information)
                txtcantidad.Focus()
                Return
            End If

            Dim importe As Double

            If txtproducto.BackColor = Color.White Then

                importe = txtprecio.Text * txtcantidad.Text
                subtotal = subtotal + importe
                itbis = subtotal * (CDbl(txtporcientoitbis.Text) / 100)
                total = subtotal + itbis

                dgvfactura.Rows.Add(txtcantidad.Text, txtproducto.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(importe, 2))

                If IsNumeric(txtporcientodescuento.Text) Then
                    txtdescuento.Text = CDbl(txtporcientodescuento.Text) * subtotal / 100
                    total = (subtotal + itbis) - CDbl(txtdescuento.Text)
                End If

                txtitbis.Text = FormatNumber(itbis, 2)
                txtsubtotal.Text = FormatNumber(subtotal, 2)
                txttotal.Text = FormatNumber(total, 2)
                txtdescuento.Text = FormatNumber(txtdescuento.Text, 2)

                bteliminar.Visible = False

            Else

                importe = txtprecio.Text * txtcantidad.Text
                subtotal = subtotal - importeanterior
                subtotal = subtotal + importe
                itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
                total = subtotal + itbis

                dgvfactura.Item(0, posicion).Value = txtcantidad.Text
                dgvfactura.Item(1, posicion).Value = txtproducto.Text
                dgvfactura.Item(2, posicion).Value = FormatNumber(txtprecio.Text, 2)
                dgvfactura.Item(3, posicion).Value = FormatNumber(importe, 2)

                txtitbis.Text = FormatNumber(itbis, 2)
                txtsubtotal.Text = FormatNumber(subtotal, 2)
                txttotal.Text = FormatNumber(total, 2)

                txtproducto.BackColor = Color.White

                bteliminar.Visible = False

            End If

            txtproducto.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = ""
            txtproducto.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtprecio_Leave(sender As Object, e As EventArgs) Handles txtprecio.Leave
        Me.Text = FormatNumber(txtprecio.Text, 2)
    End Sub
    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click

        Try

            grabando = True

            If IsNumeric(txtcliente.Text) Then
                MsgBox("Debe de Digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf txtcliente.Text = "" Then
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

            'If rdb1.Checked = True Then
            '    tipordb = "sin"
            'ElseIf rdb2.Checked = True Then
            '    tipordb = "con"
            'End If

            Dim trans As OleDbTransaction
            trans = DB.Cnn.BeginTransaction

            Dim myQuery As String = "UPDATE factura SET cliente = '" & txtcliente.Text & "', rnc = '" & txtrnccliente.Text _
                                        & "', condicion = '" & cmbcondicion.Text & "', comentario = '" & rtbcomentario.Text & "', fecha = '" & Efecha(mtbfecha.Text) _
                                        & "', sub_total = " & CDec(txtsubtotal.Text) & ", itbis = " & CDec(txtitbis.Text) & ", total = " & CDec(txttotal.Text) _
                                        & ", porciento_descuento = " & CDec(txtporcientodescuento.Text) & ", cantidad_descuento = " & CDec(txtdescuento.Text) _
                                        & ", porciento_itbis = " & CDbl(txtporcientoitbis.Text) & ", id_usuario = " & DTO.id_usuario & ", comprobante = '" & txtnumcomprobante.Text _
                                        & "' WHERE id_factura = " & txtnumfactura.Text & ""

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, DB.Cnn, trans)
            cmd3.Connection = DB.Cnn
            RA = cmd3.ExecuteNonQuery

            If RA <= 0 Then
                trans.Rollback()
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
            For X = 0 To dgvfactura.Rows.Count - 1
                If IsNumeric(dgvfactura(0, X).Value) Then
                    Dim cmd4 As OleDbCommand
                    Dim myQuery1 As String = "INSERT INTO detalles_factura(id_factura,producto,cantidad,precio,importe) VALUES (" _
                                            & txtnumfactura.Text & ",' " & (dgvfactura(1, X).Value) & " ', " & CDec(dgvfactura(0, X).Value) _
                                            & ", " & CDec(dgvfactura(2, X).Value) & "," & CDec(dgvfactura(3, X).Value) & ")"

                    cmd4 = New OleDbCommand(myQuery1, DB.Cnn, trans)
                    cmd4.Connection = DB.Cnn
                    RA = cmd4.ExecuteNonQuery()

                    If RA <= 0 Then
                        trans.Rollback()
                        MsgBox("Error grabando el detalle de la factura", MsgBoxStyle.Critical)
                        txtproducto.Focus()
                        Return
                    End If

                Else
                    Exit For
                End If
            Next X

            trans.Commit()

            If rdb2.Checked = True Then
                Dim queryupdate2 As String = "UPDATE ncf Set sec = " & ncfsec & " WHERE fijo = '" & cmbFijo.Text & "'"
                Dim cmb3 As OleDbCommand = New OleDbCommand(queryupdate2, DB.Cnn)
                cmb3.ExecuteNonQuery()
            End If

            'If rdb2.Checked = True Then
            '    Dim dr2 As OleDbDataReader
            '    Dim query As String = "SELECT fijo,sec FROM NCF WHERE tipo = " & "'NCF'"
            '    Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            '    dr2 = cmb.ExecuteReader()

            '    While dr2.Read()
            '        ncfsec = dr2("sec")
            '    End While
            '    dr2.Close()
            'End If

            mtbfecha.Text = Date.Today.ToString("dd/MM/yyyy")

            MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)

            Form1.btnuevo.PerformClick()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Factura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_factura = False
    End Sub
    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try

            dgvfactura.Rows.Remove(dgvfactura.CurrentRow)

            Dim importe As Double
            subtotal = subtotal - importeanterior
            subtotal = subtotal + importe
            itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
            total = subtotal + itbis

            If IsNumeric(txtporcientodescuento.Text) Then
                txtdescuento.Text = CDbl(txtporcientodescuento.Text) * subtotal / 100
                total = (subtotal + itbis) - CDbl(txtdescuento.Text)
            End If

            txtitbis.Text = FormatNumber(itbis, 2)
            txtsubtotal.Text = FormatNumber(subtotal, 2)
            txttotal.Text = FormatNumber(total, 2)

            txtproducto.BackColor = Color.White

            txtproducto.Text = ""
            txtprecio.Text = ""
            txtcantidad.Text = ""

            bteliminar.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvfactura_DoubleClick(sender As Object, e As EventArgs)
        Seleccion = dgvfactura.CurrentRow.Index
    End Sub
    Private Sub txtporcientodescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientodescuento.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub txtporcientodescuento_Leave(sender As Object, e As EventArgs) Handles txtporcientodescuento.Leave

        Try

            Dim importe As Double

            If txtporcientodescuento.Text = "" Then
                txtdescuento.Focus()
                txtporcientodescuento.Text = 0
                txtdescuento.Text = 0
                Return
            Else

                For X = 0 To dgvfactura.Rows.Count
                    If IsNumeric(dgvfactura(0, X).Value) Then
                        importe = importe + CDec(dgvfactura(3, X).Value)
                    Else
                        Exit For
                    End If
                Next X

                If importe > 0 Then

                    txtdescuento.Text = CDbl(txtporcientodescuento.Text) * importe / 100
                    subtotal = importe
                    itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
                    total = (subtotal + itbis) - CDbl(txtdescuento.Text)

                    txtitbis.Text = FormatNumber(itbis, 2)
                    txtsubtotal.Text = FormatNumber(subtotal, 2)
                    txttotal.Text = FormatNumber(total, 2)
                    txtdescuento.Text = FormatNumber(txtdescuento.Text, 2)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub rtbcomentario_Click(sender As Object, e As EventArgs) Handles rtbcomentario.Click
        rtbcomentario.SelectionStart = 0
        rtbcomentario.SelectionLength = rtbcomentario.Text.Length
    End Sub
    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try

            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\Factura.rpt")
            Rpt.RecordSelectionFormula = "{factura.id_factura} =" & CLng(txtnumfactura.Text)
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            For x = 0 To Rpt.Database.Tables.Count - 1
                Rpt.Database.Tables(x).Location = Application.StartupPath & "\Database.mdb"
            Next

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
            Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
            Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

            'If tipordb = "sin" Then
            '    Rpt.DataDefinition.FormulaFields("CF").Text = "'FACTURA VALIDA PARA CONSUMIDOR FINAL'"
            'ElseIf tipordb = "con" Then
            '    Rpt.DataDefinition.FormulaFields("CF").Text = "'" & UCase(cmbComprobantes.Text) & "'"
            'End If

            If DTO.Estado = "Anulada" Then
                Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** FACTURA ANULADA ***** '"
            End If
            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
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
    Private Sub btsalir_Click_1(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_factura = False
        Me.Close()
    End Sub
    Private Sub dgvfactura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvfactura.CellDoubleClick
        Try

            If dgvfactura.CurrentRow.IsNewRow Then
                Return
            End If

            posicion = dgvfactura.CurrentRow.Index

            bteliminar.Visible = True
            txtproducto.BackColor = Color.Yellow

            txtproducto.Text = Convert.ToString(dgvfactura.CurrentRow.Cells(1).Value)
            txtprecio.Text = Convert.ToString(dgvfactura.CurrentRow.Cells(2).Value)
            txtcantidad.Text = Convert.ToString(dgvfactura.CurrentRow.Cells(0).Value)
            importeanterior = Convert.ToString(dgvfactura.CurrentRow.Cells(3).Value)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtporcientoitbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientoitbis.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub rdb1_CheckedChanged(sender As Object, e As EventArgs)
        txtporcientoitbis.ReadOnly = False
        txtnumcomprobante.Text = ""
    End Sub
    Private Sub txtporcientoitbis_TextChanged(sender As Object, e As EventArgs) Handles txtporcientoitbis.TextChanged
        Try

            Dim importe As Double

            If txtporcientoitbis.Text = "" Then
                txtitbis.Focus()
                txtporcientoitbis.Text = 0
                txtitbis.Text = 0
                Return
            Else

                For X = 0 To dgvfactura.Rows.Count
                    If IsNumeric(dgvfactura(0, X).Value) Then
                        importe = importe + CDec(dgvfactura(3, X).Value)
                    Else
                        Exit For
                    End If
                Next X

                If importe > 0 Then

                    txtdescuento.Text = CDbl(txtporcientodescuento.Text) * importe / 100
                    subtotal = importe
                    itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
                    total = (subtotal + itbis) - CDbl(txtdescuento.Text)

                    txtitbis.Text = FormatNumber(itbis, 2)
                    txtsubtotal.Text = FormatNumber(subtotal, 2)
                    txttotal.Text = FormatNumber(total, 2)
                    txtdescuento.Text = FormatNumber(txtdescuento.Text, 2)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub rdb2_Click(sender As Object, e As EventArgs)
        Try

            txtporcientoitbis.ReadOnly = True
            txtporcientoitbis.Text = DTO.porciento_itebis

            If grabando = True Then
                Return
            End If

            If rdb2.Checked = True Then

                Dim dr As OleDbDataReader
                Dim query As String = "SELECT fijo,sec FROM NCF WHERE tipo = " & "'NCF'"
                Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
                dr = cmb.ExecuteReader()

                While dr.Read()
                    ncfsec = dr("sec") + 1
                    txtnumcomprobante.Text = Comprobante(dr("fijo"), ncfsec)
                End While
                dr.Close()


            Else
                txtnumcomprobante.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub rdb3_Click(sender As Object, e As EventArgs)
        Try
            txtporcientoitbis.ReadOnly = True
            txtporcientoitbis.Focus()

            If grabando = True Then
                Return
            End If

            Dim cero As String
            cero = 0.0

            txtporcientoitbis.Text = cero

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub rdb1_Click(sender As Object, e As EventArgs) Handles rdb1.Click
        txtporcientoitbis.ReadOnly = False
        txtporcientoitbis.Text = DTO.porciento_itebis
        txtnumcomprobante.Text = ""
        GroupBox2.Enabled = False
    End Sub

    Private Sub rdb2_Click_1(sender As Object, e As EventArgs) Handles rdb2.Click
        GroupBox2.Enabled = True
    End Sub

    Private Sub txtrnccliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrnccliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mtbfecha_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles mtbfecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbcondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbcondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtproducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtproducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcantidad_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbComprobantes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbComprobantes.SelectedValueChanged
        cmbFijo.SelectedIndex = cmbComprobantes.SelectedIndex
    End Sub

    Private Sub cmbFijo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFijo.SelectedValueChanged
        If cmbFijo.Text <> "" Then

            'Para poner el ncf original cuando seleccione el mismo tipo de comprobante
            If txtFijo.Text = cmbFijo.Text Then
                txtnumcomprobante.Text = txtnumcomprobanteAnt.Text
                Return
            End If
            '*****************************************************************************

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM NCF WHERE FIJO ='" & cmbFijo.Text & "'"
            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                ncfsec = dr("sec") + 1
                txtnumcomprobante.Text = cmbFijo.Text & ncfsec
                dr.Close()
            Else
                dr.Close()
                txtnumcomprobante.Text = ""
            End If

        Else
            txtnumcomprobante.Text = ""
        End If
    End Sub
End Class