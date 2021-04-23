Imports System.Data.OleDb

Public Class Cotizacion
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numcotizacion As Long
    Dim numcotizacionanterior As Long
    Dim idcliente As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim posicion As Integer

    Private Sub FormatGrid()
        dgvcotizacion.Rows.Clear()
        dgvcotizacion.ColumnCount = 6
        dgvcotizacion.Columns(0).HeaderText = "CANT"
        dgvcotizacion.Columns(1).HeaderText = "DESCRIPCION"
        dgvcotizacion.Columns(2).HeaderText = "PRECIO"
        dgvcotizacion.Columns(3).HeaderText = "IMPORTE"
        dgvcotizacion.Columns(4).HeaderText = "ITBIS"
        dgvcotizacion.Columns(5).HeaderText = "VALOR"

        dgvcotizacion.Columns(0).Width = 50
        dgvcotizacion.Columns(1).Width = 280
        dgvcotizacion.Columns(2).Width = 80
        dgvcotizacion.Columns(3).Width = 90
        dgvcotizacion.Columns(4).Width = 80
        dgvcotizacion.Columns(5).Width = 80

        ' desactivar los estilos visuales del sistema
        dgvcotizacion.EnableHeadersVisualStyles = False
        dgvcotizacion.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvcotizacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        dgvcotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub CalcularTotal()
        If dgvcotizacion.Rows.Count > 0 Then
            Dim SubTotal As Double = 0
            Dim Itbis As Double = 0
            Dim Descuento As Double = 0
            Dim Total As Double = 0

            For X = 0 To dgvcotizacion.Rows.Count - 1
                SubTotal = SubTotal + dgvcotizacion.Item(3, X).Value
                Itbis = Itbis + dgvcotizacion.Item(4, X).Value
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

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub mtbfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbfecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcantidad.BackColor = Color.White
        txtproductos.BackColor = Color.White
        txtprecio.BackColor = Color.White

        FormatGrid()

        DTO.formulario_abierto_cotizacion = True
        txtporcientodescuento.Text = 0
        txtdescuento.Text = 0.0

        Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
        mtbfecha.Text = fecha

        txtporcientoitbis.Text = DTO.porciento_itebis

        Try

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM secuencia_cotizacion WHERE sec = (select max(sec) from secuencia_cotizacion)"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb1.ExecuteReader()

            dr.Read()
            numcotizacion = dr("sec") + 1
            txtnumcotizacion.Text = numcotizacion

            dr.Close()
            txtrnccliente.Select()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_cotizacion = False
        Me.Close()
    End Sub

    Private Sub btagregar_Click(sender As Object, e As EventArgs) Handles btagregar.Click
        Try

            txtporcientodescuento.Enabled = True

            If txtcliente.Text = "" Then
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
            If Len(Trim(txtproductos.Text)) = 0 Then
                MsgBox("Debe digitar la descripción ", MsgBoxStyle.Information)
                txtproductos.Focus()
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

            If InStr(txtproductos.Text, "'") Then
                txtproductos.Text = Cambiar(txtproductos.Text)
            End If

            If txtcantidad.BackColor = Color.White Then
                dgvcotizacion.Rows.Add(txtcantidad.Text, txtproductos.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(importe, 2), FormatNumber(itbis, 2), FormatNumber(Valor, 2))
            Else
                dgvcotizacion.Item(0, posicion).Value = txtcantidad.Text
                dgvcotizacion.Item(1, posicion).Value = txtproductos.Text
                dgvcotizacion.Item(2, posicion).Value = FormatNumber(txtprecio.Text, 2)
                dgvcotizacion.Item(3, posicion).Value = FormatNumber(importe, 2)
                dgvcotizacion.Item(4, posicion).Value = FormatNumber(itbis, 2)
                dgvcotizacion.Item(5, posicion).Value = FormatNumber(Valor, 2)

                txtcantidad.BackColor = Color.White
                txtproductos.BackColor = Color.White
                txtprecio.BackColor = Color.White

                bteliminar.Visible = False

            End If

            CalcularTotal()

            txtproductos.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = ""
            txtcantidad.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtprecio_Leave(sender As Object, e As EventArgs) Handles txtprecio.Leave
        FormatNumber(txtprecio.Text, 2)
    End Sub

    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click
        Try

            If IsNumeric(txtcliente.Text) Then
                MsgBox("Debe de Digitar o Seleccionar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf txtcliente.Text = "" Then
                MsgBox("Debe de Digitar o Seleccionar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf dgvcotizacion(0, 0).Value.ToString = "" Then
                MsgBox("Debe agregar un producto a la cotización", MsgBoxStyle.Information)
                txtproductos.Focus()
                Return
            End If

            If Not FechaValida(mtbfecha.Text) Then
                MsgBox("Esta fecha de cotizacion no es valida", MsgBoxStyle.Information)
                mtbfecha.Focus()
                Return
            End If

            Dim dr As OleDbDataReader
            Dim PorcientoItbis As Double = 0

            trans = DB.Cnn.BeginTransaction
            TA = True

            If cb1.Checked = True Then
                PorcientoItbis = 0
            Else
                PorcientoItbis = txtporcientoitbis.Text
            End If

            Dim myQuery As String = "INSERT INTO cotizacion (id_cotizacion, rnc, cliente,comentario,fecha,sub_total,itbis,total,porciento_descuento,cantidad_descuento,porciento_itbis,id_usuario) VALUES (" _
                                    & CInt(txtnumcotizacion.Text) & ",'" & txtrnccliente.Text & "','" & txtcliente.Text & "','" & rtbcomentario.Text _
                                    & "','" & Efecha(mtbfecha.Text) & "'," & CDec(txtsubtotal.Text) & "," & CDec(txtitbis.Text) _
                                    & ", " & CDec(txttotal.Text) & "," & CDec(txtporcientodescuento.Text) & "," & CDec(txtdescuento.Text) _
                                    & ", " & PorcientoItbis & "," & DTO.id_usuario & ")"

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, DB.Cnn, trans)
            cmd3.Connection = DB.Cnn
            RA = cmd3.ExecuteNonQuery

            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error grabando el encabezado de la cotización", MsgBoxStyle.Critical)
                txtcliente.Focus()
                Return
            End If

            Dim X As Integer
            For X = 0 To dgvcotizacion.Rows.Count - 1
                If IsNumeric(dgvcotizacion(0, X).Value) Then
                    Dim cmd4 As OleDbCommand
                    Dim myQuery1 As String = "INSERT INTO detalles_cotizacion(id_cotizacion,cantidad,producto,precio,importe, itbis, valor) VALUES (" _
                                                & CInt(txtnumcotizacion.Text) & "," & CDec(dgvcotizacion(0, X).Value) & ",'" & (dgvcotizacion(1, X).Value) _
                                                & "'," & CDec(dgvcotizacion(2, X).Value) & "," & CDec(dgvcotizacion(3, X).Value) & "," _
                                                & CDec(dgvcotizacion(4, X).Value) & "," & CDec(dgvcotizacion(5, X).Value) & ")"

                    cmd4 = New OleDbCommand(myQuery1, DB.Cnn, trans)
                    cmd4.Connection = DB.Cnn
                    RA = cmd4.ExecuteNonQuery()

                    If RA <= 0 Then
                        trans.Rollback() : TA = False
                        MsgBox("Error grabando el detalle de la cotizacion", MsgBoxStyle.Critical)
                        txtproductos.Focus()
                        Return
                    End If

                Else
                    Exit For
                End If
            Next X

            Dim queryupdate As String = "UPDATE secuencia_cotizacion SET sec = " & txtnumcotizacion.Text
            Dim cmb2 As OleDbCommand = New OleDbCommand(queryupdate, DB.Cnn, trans)
            RA = cmb2.ExecuteNonQuery()
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error actualizando la secuencia de la cotizacion", MsgBoxStyle.Critical)
                Return
            End If


            trans.Commit() : TA = False

            numcotizacionanterior = txtnumcotizacion.Text

            Dim query As String = "SELECT sec FROM secuencia_cotizacion"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb1.ExecuteReader()

            dr.Read()
            txtnumcotizacion.Text = dr("sec") + 1

            dr.Close()

            If MessageBox.Show("COTIZACIÓN grabada con éxito, desea imprimirla?", " Importante ",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                btnuevo.PerformClick()

                Me.Cursor = Cursors.WaitCursor
                Dim Reporte As New Reportes
                Reporte.MdiParent = Me.MdiParent

                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\CrystalReport1.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{cotizacion.id_cotizacion} =" & numcotizacionanterior
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("empresa").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"

                Rpt.DataDefinition.FormulaFields("direccion").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("telefono").Text = "'" & TelefonoEmp & "'"
                Rpt.DataDefinition.FormulaFields("rnc").Text = "'" & RncEmp & "'"

                If DTO.Estado = "Anulada" Then
                    Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** COTIZACIÓN ANULADA ***** '"
                End If

                Reporte.Refresh()
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
                Me.Cursor = Cursors.Default
            Else
                btnuevo.PerformClick()
                Return
            End If

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Cotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_cotizacion = False
    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try

            If txtcantidad.BackColor = Color.Yellow Then
                dgvcotizacion.Rows.Remove(dgvcotizacion.CurrentRow)
                CalcularTotal()
            End If

            txtcantidad.BackColor = Color.White
            txtproductos.BackColor = Color.White
            txtprecio.BackColor = Color.White

            txtproductos.Clear() : txtprecio.Clear() : txtcantidad.Clear()
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

    Private Sub txtporcientodescuento_Leave(sender As Object, e As EventArgs) Handles txtporcientodescuento.Leave

        Try

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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub rtbcomentario_Click(sender As Object, e As EventArgs) Handles rtbcomentario.Click
        rtbcomentario.SelectionStart = 0
        rtbcomentario.SelectionLength = rtbcomentario.Text.Length
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If DTO.formulario_abierto_buscar_cotizacion = True Then
            MsgBox("Este formulario ya esta abierto", MsgBoxStyle.Information)
            Return
        End If
        Dim buscar As New Buscar_Cotizacion
        buscar.Show()

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        txtsubtotal.Clear()
        txtitbis.Clear()
        txtdescuento.Clear()
        txttotal.Clear()
        txtporcientodescuento.Text = 0
        txtdescuento.Text = 0.0
        cb1.Checked = False
        txtcantidad.BackColor = Color.White
        txtproductos.BackColor = Color.White
        txtprecio.BackColor = Color.White

        Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
        mtbfecha.Text = fecha

        txtporcientoitbis.Text = DTO.porciento_itebis

        Try

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM secuencia_cotizacion WHERE sec = (select max(sec) from secuencia_cotizacion)"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb1.ExecuteReader()

            dr.Read()
            numcotizacion = dr("sec") + 1
            txtnumcotizacion.Text = numcotizacion

            dr.Close()
            txtrnccliente.Clear()
            txtcliente.Clear()
            txtcantidad.Clear()
            txtproductos.Clear()
            txtprecio.Clear()
            FormatGrid()
            txtcliente.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtporcientoitbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientoitbis.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtnumcotizacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumcotizacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtproductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtproductos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtrnccliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrnccliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dgvcotizacion_DoubleClick(sender As Object, e As EventArgs) Handles dgvcotizacion.DoubleClick
        Try
            If IsNothing(dgvcotizacion.CurrentRow.Cells(0).Value) Then
                Return
            End If


            If Not dgvcotizacion.CurrentRow.IsNewRow Then
                posicion = dgvcotizacion.CurrentRow.Index
                txtcantidad.Text = dgvcotizacion.Item(0, dgvcotizacion.CurrentRow.Index).Value
                txtproductos.Text = dgvcotizacion.Item(1, dgvcotizacion.CurrentRow.Index).Value
                txtprecio.Text = dgvcotizacion.Item(2, dgvcotizacion.CurrentRow.Index).Value

                txtcantidad.BackColor = Color.Yellow
                txtproductos.BackColor = Color.Yellow
                txtprecio.BackColor = Color.Yellow

                bteliminar.Visible = True
            End If

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

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        If cb1.Checked = True Then
            cb1.Font = New Font(cb1.Font, FontStyle.Bold)
        Else
            cb1.Font = New Font(cb1.Font, FontStyle.Regular)
        End If
    End Sub

End Class