Public Class ReporteFacturas
    Dim fecha1 As Boolean

    Private Sub ReporteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTO.formulario_abierto_reporte_facturas = True
        mc.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fecha1 = True

        If mc.Visible = False Then
            mc.Visible = True
        Else
            mc.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fecha1 = False

        If mc.Visible = True Then
            mc.Visible = False
        Else
            mc.Visible = True
        End If

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        DTO.formulario_abierto_reporte_facturas = False
        Close()
    End Sub

    Private Sub mc_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mc.DateChanged
        If fecha1 = True Then
            mtbfecha1.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        Else
            mtbfecha2.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub mc_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mc.DateSelected
        mc.Visible = False
    End Sub

    Private Sub ReporteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        DTO.formulario_abierto_reporte_facturas = False
    End Sub

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try
            If CheckBox1.Checked = True Then
                Dim Reporte As New Reportes
                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\rptfacturas.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} = 'Anulada'"
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

                Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
                Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
                Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  FACTURAS  ANULADAS'"
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()

            Else

                Dim Reporte As New Reportes
                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\rptfacturas.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} = 'Normal'"
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

                Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
                Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
                Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  FACTURAS  REGISTRADAS'"
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class