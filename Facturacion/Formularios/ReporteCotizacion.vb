Public Class ReporteCotizacion
    Dim fecha1 As Boolean
    Private Sub ReporteCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_reporte_cotizaciones = True
        mc1.Visible = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fecha1 = True

        If mc1.Visible = False Then
            mc1.Visible = True
        Else
            mc1.Visible = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fecha1 = False

        If mc1.Visible = True Then
            mc1.Visible = False
        Else
            mc1.Visible = True
        End If
    End Sub
    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_reporte_cotizaciones = False
        Close()
    End Sub
    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try
            If CheckBox1.Checked = True Then
                Dim Reporte As New Reportes
                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\rptcotizaciones.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{cotizacion.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {cotizacion.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {cotizacion.estado} = 'Anulada'"
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

                Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
                Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
                Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  COTIZACIONES  ANULADAS'"
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()

            Else

                Dim Reporte As New Reportes
                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\rptcotizaciones.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{cotizacion.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {cotizacion.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {cotizacion.estado} = 'Normal'"
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

                Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
                Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
                Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  COTIZACIONES  REGISTRADAS'"
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub mc_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mc1.DateSelected
        mc1.Visible = False
    End Sub
    Private Sub mc_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mc1.DateChanged
        If fecha1 = True Then
            mtbfecha1.Text = mc1.SelectionRange.Start.ToString("dd/MM/yyyy")
        Else
            mtbfecha2.Text = mc1.SelectionRange.Start.ToString("dd/MM/yyyy")
        End If
    End Sub
    Private Sub ReporteCotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_reporte_cotizaciones = False
    End Sub
End Class