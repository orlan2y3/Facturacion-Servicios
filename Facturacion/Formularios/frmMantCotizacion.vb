Imports System.Data.OleDb

Public Class frmMantCotizacion
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numcotizacion As Long
    Dim numcotizacionanterior As Long
    Dim idcliente As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim posicion As Integer
    Dim grabando As Boolean

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

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
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

    Private Sub frmMantCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcantidad.BackColor = Color.White
        txtproductos.BackColor = Color.White
        txtprecio.BackColor = Color.White
        cb1.Checked = False
        txtporcientodescuento.Text = 0
        txtdescuento.Text = 0.0

        'Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
        'mtbfecha.Text = fecha

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

            FormatGrid()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_cotizacion = False
        Me.Hide()
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

            grabando = True

            If txtcliente.Text = "" Then
                MsgBox("Debe Digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            End If
            If dgvcotizacion(0, 0).Value.ToString = "" Then
                MsgBox("Debe agregar un producto a la cotización", MsgBoxStyle.Information)
                txtcantidad.Focus()
                Return
            End If

            If Not FechaValida(mtbfecha.Text) Then
                MsgBox("Esta fecha de cotizacion no es valida", MsgBoxStyle.Information)
                mtbfecha.Focus()
                Return
            End If

            Dim PorcientoItbis As Double = 0
            If cb1.Checked = True Then
                PorcientoItbis = 0
            Else
                PorcientoItbis = txtporcientoitbis.Text
            End If

            trans = DB.Cnn.BeginTransaction
            TA = True

            Dim myQuery As String = "UPDATE cotizacion SET cliente = '" & txtcliente.Text _
                                        & "', comentario = '" & rtbcomentario.Text & "', fecha = '" & Efecha(mtbfecha.Text) _
                                        & "', sub_total = " & CDec(txtsubtotal.Text) & ", itbis = " & CDec(txtitbis.Text) & ", total = " & CDec(txttotal.Text) _
                                        & ", porciento_descuento = " & CDec(txtporcientodescuento.Text) & ", cantidad_descuento = " & CDec(txtdescuento.Text) _
                                        & ", porciento_itbis = " & PorcientoItbis & ", id_usuario = " & DTO.id_usuario _
                                        & " WHERE id_cotizacion = " & txtnumcotizacion.Text & ""

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, DB.Cnn, trans)
            cmd3.Connection = DB.Cnn
            RA = cmd3.ExecuteNonQuery

            If RA <= 0 Then
                trans.Rollback() : TA = False
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
            For X = 0 To dgvcotizacion.Rows.Count - 1
                If IsNumeric(dgvcotizacion(0, X).Value) Then
                    Dim cmd4 As OleDbCommand
                    Dim myQuery1 As String = "INSERT INTO detalles_cotizacion(id_cotizacion,producto,cantidad,precio,importe, itbis, valor) VALUES (" _
                                            & txtnumcotizacion.Text & ",'" & (dgvcotizacion(1, X).Value) & "'," & CDec(dgvcotizacion(0, X).Value) _
                                            & "," & CDec(dgvcotizacion(2, X).Value) & "," & CDec(dgvcotizacion(3, X).Value) & "," _
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

            trans.Commit() : TA = False

            'mtbfecha.Text = Date.Today.ToString("dd/MM/yyyy")

            MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dgvfactura_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try

            If dgvcotizacion.CurrentRow.IsNewRow Then
                Return
            End If

            bteliminar.Visible = True

            txtproductos.BackColor = Color.Yellow

            txtcantidad.Text = Convert.ToString(dgvcotizacion.CurrentRow.Cells(0).Value)
            txtproductos.Text = Convert.ToString(dgvcotizacion.CurrentRow.Cells(1).Value)
            txtprecio.Text = Convert.ToString(dgvcotizacion.CurrentRow.Cells(2).Value)
            importeanterior = Convert.ToString(dgvcotizacion.CurrentRow.Cells(3).Value)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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

    Private Sub dgvfactura_DoubleClick(sender As Object, e As EventArgs)
        Seleccion = dgvcotizacion.CurrentRow.Index
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

    Private Sub btnuevo_Click(sender As Object, e As EventArgs)
        txtsubtotal.Clear()
        txtitbis.Clear()
        txtdescuento.Clear()
        txttotal.Clear()
        txtporcientodescuento.Text = 0
        txtdescuento.Text = 0.0

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

    Private Sub txtporcientoitbis_TextChanged(sender As Object, e As EventArgs) Handles txtporcientoitbis.TextChanged
        'Try

        '    Dim importe As Double

        '    If txtporcientoitbis.Text = "" Then
        '        txtitbis.Focus()
        '        txtporcientoitbis.Text = 0
        '        txtitbis.Text = 0
        '        Return
        '    Else

        '        For X = 0 To dgvcotizacion.Rows.Count
        '            If IsNumeric(dgvcotizacion(0, X).Value) Then
        '                importe = importe + CDec(dgvcotizacion(3, X).Value)
        '            Else
        '                Exit For
        '            End If
        '        Next X

        '        If importe > 0 Then

        '            txtdescuento.Text = CDbl(txtporcientodescuento.Text) * importe / 100
        '            subtotal = importe
        '            itbis = subtotal * CDbl(txtporcientoitbis.Text) / 100
        '            total = (subtotal + itbis) - CDbl(txtdescuento.Text)

        '            txtitbis.Text = FormatNumber(itbis, 2)
        '            txtsubtotal.Text = FormatNumber(subtotal, 2)
        '            txttotal.Text = FormatNumber(total, 2)
        '            txtdescuento.Text = FormatNumber(txtdescuento.Text, 2)

        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

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

    Private Sub txtcantidad_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtproductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtproductos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT cz.id_cotizacion,cz.cliente,u.nombre_completo,cz.usuario_anulo, " &
                          "cz.fecha,cz.sub_total,cz.itbis,cz.porciento_descuento, " &
                          "cz.cantidad_descuento,cz.comentario,cz.total,cz.estado,cz.porciento_itbis,cz.id_usuario FROM " &
                          "cotizacion cz,usuarios u where cz.id_usuario = u.id and cz.id_cotizacion = " & NC

            Dim cmb As OleDbCommand = New OleDbCommand(query, DB.Cnn)
            dr = cmb.ExecuteReader()

            dr.Read()
            Dim usuario_anulo As Long = dr("usuario_anulo")
            txtnumcotizacion.Text = dr("id_cotizacion")
            mtbfecha.Text = Lfecha(dr("fecha").ToString)
            txtcliente.Text = dr("cliente").ToString
            txtsubtotal.Text = FormatNumber(dr("sub_total"), 2)
            txtitbis.Text = FormatNumber(dr("itbis"), 2)
            txtporcientodescuento.Text = Format(dr("porciento_descuento"))
            txtdescuento.Text = FormatNumber(dr("cantidad_descuento"), 2)
            txttotal.Text = FormatNumber(dr("total"), 2)
            rtbcomentario.Text = dr("comentario").ToString
            txtporcientoitbis.Text = dr("porciento_itbis")
            If dr("porciento_itbis") = 0 Then
                cb1.Checked = True
                cb1.Font = New Font(cb1.Font, FontStyle.Bold)
            End If
            lbusuarioquefacturo.Text = "Esta Cotización fue hecha por: " & dr("nombre_completo").ToString
            DTO.Estado = dr("estado").ToString

            dr.Close()

            If DTO.Estado = "Anulada" Then

                Dim query2 As String = "SELECT nombre_completo FROM usuarios WHERE id = " & usuario_anulo
                Dim cmb2 As OleDbCommand = New OleDbCommand(query2, DB.Cnn)
                dr = cmb2.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    lbestado.Visible = True
                    btagregar.Enabled = False
                    btinsertar.Enabled = False
                    lbestado.Text = "Esta cotizacion fue anulada por: " & (dr("nombre_completo"))
                    dr.Close()
                Else
                    dr.Close()
                End If

            Else
                lbestado.Text = ""
                Form1.lbestado.Visible = False
            End If

            'Llenar datagriview con reader en ves de data source***
            FormatGrid()
            Dim query1 As String = "SELECT cantidad, producto, precio," &
                                   "importe, itbis, valor FROM detalles_cotizacion WHERE id_cotizacion = " & NC & " ORDER BY id_detalles_cotizacion ASC"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query1, DB.Cnn)
            dr = cmb1.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    dgvcotizacion.Rows.Add(dr("cantidad"), dr("producto"), FormatNumber(dr("precio"), 2), FormatNumber(dr("importe"), 2),
                                                              FormatNumber(dr("itbis"), 2), FormatNumber(dr("valor"), 2))
                End While
                dr.Close()
            Else
                dr.Close()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        If cb1.Checked = True Then
            cb1.Font = New Font(cb1.Font, FontStyle.Bold)
        Else
            cb1.Font = New Font(cb1.Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
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
                        'btactualizar.Enabled = False
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

                    Dim queryupdate As String = "UPDATE cotizacion SET estado = 'Anulada', usuario_anulo = " & DTO.id_usuario _
                                                               & " WHERE id_cotizacion = " & CLng(txtnumcotizacion.Text)
                    Dim cmb As OleDbCommand = New OleDbCommand(queryupdate, DB.Cnn)
                    cmb.ExecuteNonQuery()
                    lbestado.Visible = True
                    'btactualizar.Enabled = False
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

            Dim query As String = "SELECT estado FROM cotizacion WHERE id_cotizacion =" & txtnumcotizacion.Text
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
            Rpt.Load(Application.StartupPath & "\CrystalReport1.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{cotizacion.id_cotizacion} =" & CLng(txtnumcotizacion.Text)
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("empresa").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"

            Rpt.DataDefinition.FormulaFields("direccion").Text = "'" & DireccionEmp & "'"
            Rpt.DataDefinition.FormulaFields("telefono").Text = "'" & TelefonoEmp & "'"
            Rpt.DataDefinition.FormulaFields("rnc").Text = "'" & RncEmp & "'"

            If Estado = "Anulada" Then
                Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** COTIZACION ANULADA ***** '"
            End If

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub
End Class