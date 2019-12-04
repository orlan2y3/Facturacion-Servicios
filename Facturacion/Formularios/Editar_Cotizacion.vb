Imports System.Data.OleDb
Public Class Editar_Cotizacion
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numcotizacion As Long
    Dim numcotizacionanterior As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim grabando As Boolean
    Dim posicion As Integer
    Private Sub Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            DTO.formulario_abierto_cotizacion = True
            dgvcotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
            Dim importe As Double

            If txtporcientodescuento.Text = "" Then
                txtdescuento.Focus()
                Return
            Else

                For X = 0 To dgvcotizacion.Rows.Count
                    If IsNumeric(dgvcotizacion(0, X).Value) Then
                        importe = importe + CDec(dgvcotizacion(3, X).Value)
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
    Private Sub btsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub Editar_Cotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Buscar_Cotizacion.ds1.Clear()
    End Sub
    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try

            dgvcotizacion.Rows.Remove(dgvcotizacion.CurrentRow)

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

            txtproductos.BackColor = Color.White

            txtproductos.Text = ""
            txtprecio.Text = ""
            txtcantidad.Text = ""

            bteliminar.Visible = False

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
            ElseIf txtproductos.Text = "" Then
                MsgBox("Debe digitar un producto", MsgBoxStyle.Information)
                txtproductos.Focus()
                Return
            ElseIf txtprecio.Text = "" Then
                MsgBox("Debe digitar un precio", MsgBoxStyle.Information)
                txtproductos.Focus()
                Return
            ElseIf Not IsNumeric(txtcantidad.Text) Then
                MsgBox("Debe digitar una Cantidad", MsgBoxStyle.Information)
                txtcantidad.Focus()
                Return
            End If

            Dim importe As Double

            If txtproductos.BackColor = Color.White Then

                importe = txtprecio.Text * txtcantidad.Text
                subtotal = subtotal + importe
                itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
                total = subtotal + itbis

                dgvcotizacion.Rows.Add(txtcantidad.Text, txtproductos.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(importe, 2))

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

                dgvcotizacion.Item(0, posicion).Value = txtcantidad.Text
                dgvcotizacion.Item(1, posicion).Value = txtproductos.Text
                dgvcotizacion.Item(2, posicion).Value = FormatNumber(txtprecio.Text, 2)
                dgvcotizacion.Item(3, posicion).Value = FormatNumber(importe, 2)

                txtitbis.Text = FormatNumber(itbis, 2)
                txtsubtotal.Text = FormatNumber(subtotal, 2)
                txttotal.Text = FormatNumber(total, 2)

                txtproductos.BackColor = Color.White

                bteliminar.Visible = False

            End If

            txtproductos.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = ""
            txtproductos.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btprint_Click_1(sender As Object, e As EventArgs) Handles btprint.Click
        Try

            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\CrystalReport1.rpt")
            Rpt.RecordSelectionFormula = "{cotizacion.id_cotizacion} =" & CLng(txtnumcotizacion.Text)
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            For x = 0 To Rpt.Database.Tables.Count - 1
                Rpt.Database.Tables(x).Location = Application.StartupPath & "\Database.mdb"
            Next

            If DTO.Estado = "Anulada" Then
                Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** COTIZACIÓN ANULADA ***** '"
            End If
            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
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
            ElseIf dgvcotizacion(0, 0).Value.ToString = "" Then
                MsgBox("Debe agregar un producto a la cotización", MsgBoxStyle.Information)
                txtproductos.Focus()
                Return
            End If

            Dim trans As OleDbTransaction
            trans = DB.Cnn.BeginTransaction

            Dim myQuery As String = "UPDATE cotizacion SET cliente = '" & txtcliente.Text & "', condicion = '" & cmbcondicion.Text _
                                        & "', comentario = '" & rtbcomentario.Text & "', fecha = '" & Efecha(mtbfecha.Text) _
                                        & "', sub_total = " & CDec(txtsubtotal.Text) & ", itbis = " & CDec(txtitbis.Text) & ", total = " & CDec(txttotal.Text) _
                                        & ", porciento_descuento = " & CDec(txtporcientodescuento.Text) & ", cantidad_descuento = " & CDec(txtdescuento.Text) _
                                        & ", porciento_itbis = " & CDbl(txtporcientoitbis.Text) & ", id_usuario = " & DTO.id_usuario _
                                        & " WHERE id_cotizacion = " & txtnumcotizacion.Text & ""

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, DB.Cnn, trans)
            cmd3.Connection = DB.Cnn
            RA = cmd3.ExecuteNonQuery

            If RA <= 0 Then
                trans.Rollback()
                MsgBox("Error grabando el encabezado de la cotizacion", MsgBoxStyle.Critical)
                txtcliente.Focus()
                Return
            End If

            Dim cmd5 As OleDbCommand

            Dim myQuery2 As String = "DELETE * FROM detalles_cotizacion WHERE id_cotizacion = " & txtnumcotizacion.Text & ""

            cmd5 = New OleDbCommand(myQuery2, DB.Cnn, trans)
            cmd5.Connection = DB.Cnn
            RA = cmd5.ExecuteNonQuery()

            Dim X As Integer
            For X = 0 To dgvcotizacion.Rows.Count
                If IsNumeric(dgvcotizacion(0, X).Value) Then
                    Dim cmd4 As OleDbCommand
                    Dim myQuery1 As String = "INSERT INTO detalles_cotizacion(id_cotizacion,producto,cantidad,precio,importe) VALUES (" _
                                            & txtnumcotizacion.Text & ",' " & (dgvcotizacion(1, X).Value) & " ', " & CDec(dgvcotizacion(0, X).Value) _
                                            & ", " & CDec(dgvcotizacion(2, X).Value) & "," & CDec(dgvcotizacion(3, X).Value) & ")"

                    cmd4 = New OleDbCommand(myQuery1, DB.Cnn, trans)
                    cmd4.Connection = DB.Cnn
                    RA = cmd4.ExecuteNonQuery()

                    If RA <= 0 Then
                        trans.Rollback()
                        MsgBox("Error grabando el detalle de la cotizacion", MsgBoxStyle.Critical)
                        txtproductos.Focus()
                        Return
                    End If

                Else
                    Exit For
                End If
            Next X

            trans.Commit()

            mtbfecha.Text = Date.Today.ToString("dd/MM/yyyy")

            MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btsalir_Click_1(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_factura = False
        Me.Close()
    End Sub
    Private Sub btactualizar_Click_1(sender As Object, e As EventArgs) Handles btactualizar.Click
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

                    If MessageBox.Show("Esta seguro que desea anular esta cotizacion", " Importante ",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Dim queryupdate As String = "UPDATE cotizacion SET estado = 'Anulada', usuario_anulo = " & DTO.id_usuario & " WHERE id_cotizacion = " & CLng(txtnumcotizacion.Text)
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

                If MessageBox.Show("Esta seguro que desea anular esta cotizacion", " Importante ",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim queryupdate As String = "UPDATE cotizacion SET estado = 'Anulada', usuario_anulo = " & DTO.id_usuario & " WHERE id_cotizacion = " & CLng(txtnumcotizacion.Text)
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
    Private Sub dgvcotizacion_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcotizacion.CellContentDoubleClick
        Try

            If dgvcotizacion.CurrentRow.IsNewRow Then
                Return
            End If

            bteliminar.Visible = True
            txtproductos.BackColor = Color.Yellow

            txtproductos.Text = Convert.ToString(dgvcotizacion.CurrentRow.Cells(1).Value)
            txtprecio.Text = Convert.ToString(dgvcotizacion.CurrentRow.Cells(2).Value)
            txtcantidad.Text = Convert.ToString(dgvcotizacion.CurrentRow.Cells(0).Value)
            importeanterior = Convert.ToString(dgvcotizacion.CurrentRow.Cells(3).Value)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

                For X = 0 To dgvcotizacion.Rows.Count
                    If IsNumeric(dgvcotizacion(0, X).Value) Then
                        importe = importe + CDec(dgvcotizacion(3, X).Value)
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
    Private Sub txtporcientoitbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientoitbis.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub txtporcientoitbis_Leave(sender As Object, e As EventArgs)
        Try

            Dim importe As Double

            If txtporcientoitbis.Text = "" Then
                txtitbis.Focus()
                txtporcientoitbis.Text = 0
                txtitbis.Text = 0
                Return
            Else

                For X = 0 To dgvcotizacion.Rows.Count
                    If IsNumeric(dgvcotizacion(0, X).Value) Then
                        importe = importe + CDec(dgvcotizacion(3, X).Value)
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
    Private Sub txtporcientoitbis_TextChanged(sender As Object, e As EventArgs) Handles txtporcientoitbis.TextChanged
        Try

            Dim importe As Double

            If txtporcientoitbis.Text = "" Then
                txtitbis.Focus()
                txtporcientoitbis.Text = 0
                txtitbis.Text = 0
                Return
            Else

                For X = 0 To dgvcotizacion.Rows.Count
                    If IsNumeric(dgvcotizacion(0, X).Value) Then
                        importe = importe + CDec(dgvcotizacion(3, X).Value)
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

    Private Sub lbusuarioquefacturo_Click(sender As Object, e As EventArgs) Handles lbusuarioquefacturo.Click

    End Sub
End Class