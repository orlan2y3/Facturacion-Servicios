Public Class frmMenu
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FmantFacturas.MdiParent = Me
            FmantCotizacion.MdiParent = Me

            tssusuario.Text = "Bienvenido" & " " & DTO.nombrelogueado

            Dim fecha As String
            fecha = Format(Date.Today, "short Date")
            tssfecha.Text = fecha

            If DTO.nivel = 3 Then
                ConfiguraciónToolStripMenuItem1.Enabled = False
                UsuariosToolStripMenuItem1.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tsshora.Text = Date.Now.ToLongTimeString
    End Sub
    Private Sub CotizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotizaciónToolStripMenuItem.Click
        Try

            Dim cotizacion As New Cotizacion
            cotizacion.Show()

            Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
            cotizacion.mtbfecha.Text = fecha

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub NosotrosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If DTO.formulario_abierto_nosotros = True Then
            MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
            Return
        End If
        Dim nosotros As New Nosotros
        nosotros.MdiParent = Me
        nosotros.Show()
    End Sub
    Private Sub frmMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.nombrelogueado = Nothing
    End Sub
    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        If DTO.formulario_abierto_factura = True Then
            MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
            Return
        End If

        Try

            Ffactura.MdiParent = Me
            Ffactura.Show()
            Ffactura.btnuevo.PerformClick()

            Ffactura.cmbcondicion.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CotizacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotizacionToolStripMenuItem.Click
        If DTO.formulario_abierto_cotizacion = True Then
            MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
            Return
        End If

        Try

            Dim cotizacion As New Cotizacion
            cotizacion.MdiParent = Me
            cotizacion.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UsuariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem1.Click
        Try
            If DTO.formulario_abierto_usuarios = True Then
                MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
                Return
            End If

            If DTO.nivel = 1 Then
                Dim usuarios As New Usuarios
                usuarios.MdiParent = Me
                usuarios.Show()
            Else
                DTO.donde_dio_click = "productos"
                Dim seguridad_usuario As New Seguridad_Usuarios
                seguridad_usuario.ShowDialog()

                If DTO.usuario_activo_inactivo = "" Then
                    Return
                End If

                If DTO.usuario_activo_inactivo = "Inactivo" Then
                    MsgBox("Este Usuario Esta Inactivo", MsgBoxStyle.Critical)
                    Return
                End If

                If DTO.nivel_seguridad = 1 Then
                    DTO.nivel_seguridad = 0
                    Dim usuarios As New Usuarios
                    usuarios.Show()
                Else
                    DTO.nivel_seguridad = 0
                    Return
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReporteDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeFacturasToolStripMenuItem.Click
        If DTO.formulario_abierto_reporte_facturas = True Then
            MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
            Return
        End If

        Dim reportefacturas As New ReporteFacturas
        reportefacturas.MdiParent = Me
        reportefacturas.Show()
    End Sub

    Private Sub ReporteDeCotizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCotizaciónToolStripMenuItem.Click
        If DTO.formulario_abierto_reporte_cotizaciones = True Then
            MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
            Return
        End If

        Dim reportecotizacion As New ReporteCotizacion
        reportecotizacion.MdiParent = Me
        reportecotizacion.Show()
    End Sub

    Private Sub ParámetrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParámetrosToolStripMenuItem.Click
        Try
            If DTO.formulario_abierto_parametros = True Then
                MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
                Return
            End If

            If DTO.nivel = 1 Then
                Dim parametros As New Parametros
                parametros.Show()
            Else
                DTO.donde_dio_click = "parametros"
                Dim seguridad_usuario As New Seguridad_Usuarios
                seguridad_usuario.ShowDialog()

                If DTO.usuario_activo_inactivo = "" Then
                    Return
                End If

                If DTO.usuario_activo_inactivo = "Inactivo" Then
                    MsgBox("Este Usuario Esta Inactivo", MsgBoxStyle.Critical)
                    Return
                End If

                If DTO.nivel_seguridad = 1 Then
                    DTO.nivel_seguridad = 0
                    Dim parametros As New Parametros
                    parametros.MdiParent = Me
                    parametros.Show()
                Else
                    DTO.nivel_seguridad = 0
                    Return
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NosotrosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NosotrosToolStripMenuItem2.Click
        If DTO.formulario_abierto_nosotros = True Then
            MsgBox("Este Formulario ya esta Abierto", MsgBoxStyle.Information)
            Return
        End If
        Dim nosotros As New Nosotros
        nosotros.MdiParent = Me
        nosotros.Show()
    End Sub

    Private Sub SalirDelSistemaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalirDelSistemaToolStripMenuItem1.Click
        DB.Desconectar()
        End
    End Sub

    Private Sub DatosEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosEmpresaToolStripMenuItem.Click
        Dim DatosEmpresa As New frmDatosEmpresa
        DatosEmpresa.MdiParent = Me
        DatosEmpresa.Show()
    End Sub

    Private Sub ConfiguraciónNCFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónNCFToolStripMenuItem.Click
        Dim formNCF As New frmNCF
        formNCF.MdiParent = Me
        formNCF.Show()
    End Sub
End Class