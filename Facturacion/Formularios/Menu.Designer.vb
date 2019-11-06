<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculadoraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssfecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsshora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssusuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.FuncionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotizacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UsuariosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeCotizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParámetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosEmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NosotrosToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirDelSistemaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónNCFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'FacturaToolStripMenuItem
        '
        Me.FacturaToolStripMenuItem.Name = "FacturaToolStripMenuItem"
        Me.FacturaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FacturaToolStripMenuItem.Text = "Facturar"
        '
        'CotizaciónToolStripMenuItem
        '
        Me.CotizaciónToolStripMenuItem.Name = "CotizaciónToolStripMenuItem"
        Me.CotizaciónToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CotizaciónToolStripMenuItem.Text = "Cotización"
        '
        'CalculadoraToolStripMenuItem
        '
        Me.CalculadoraToolStripMenuItem.Name = "CalculadoraToolStripMenuItem"
        Me.CalculadoraToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CalculadoraToolStripMenuItem.Text = "Calculadora"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssfecha, Me.tsshora, Me.tssusuario})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 394)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 15, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(603, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssfecha
        '
        Me.tssfecha.Name = "tssfecha"
        Me.tssfecha.Size = New System.Drawing.Size(54, 19)
        Me.tssfecha.Text = "Fecha"
        '
        'tsshora
        '
        Me.tsshora.Name = "tsshora"
        Me.tsshora.Size = New System.Drawing.Size(45, 19)
        Me.tsshora.Text = "Hora"
        '
        'tssusuario
        '
        Me.tssusuario.Name = "tssusuario"
        Me.tssusuario.Size = New System.Drawing.Size(72, 19)
        Me.tssusuario.Text = "Usuario"
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuncionesToolStripMenuItem, Me.ReportesToolStripMenuItem1, Me.ConfiguraciónToolStripMenuItem1, Me.AcercaDeToolStripMenuItem2, Me.SalirToolStripMenuItem})
        Me.MenuStrip3.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(603, 27)
        Me.MenuStrip3.TabIndex = 5
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'FuncionesToolStripMenuItem
        '
        Me.FuncionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturacionToolStripMenuItem, Me.CotizacionToolStripMenuItem, Me.ToolStripMenuItem1, Me.UsuariosToolStripMenuItem1})
        Me.FuncionesToolStripMenuItem.Image = Global.FacturacionServicios.My.Resources.Resources.Invoice
        Me.FuncionesToolStripMenuItem.Name = "FuncionesToolStripMenuItem"
        Me.FuncionesToolStripMenuItem.Size = New System.Drawing.Size(118, 23)
        Me.FuncionesToolStripMenuItem.Text = "Funciones"
        '
        'FacturacionToolStripMenuItem
        '
        Me.FacturacionToolStripMenuItem.Name = "FacturacionToolStripMenuItem"
        Me.FacturacionToolStripMenuItem.Size = New System.Drawing.Size(177, 24)
        Me.FacturacionToolStripMenuItem.Text = "Facturación"
        '
        'CotizacionToolStripMenuItem
        '
        Me.CotizacionToolStripMenuItem.Name = "CotizacionToolStripMenuItem"
        Me.CotizacionToolStripMenuItem.Size = New System.Drawing.Size(177, 24)
        Me.CotizacionToolStripMenuItem.Text = "Cotización"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(174, 6)
        '
        'UsuariosToolStripMenuItem1
        '
        Me.UsuariosToolStripMenuItem1.Name = "UsuariosToolStripMenuItem1"
        Me.UsuariosToolStripMenuItem1.Size = New System.Drawing.Size(177, 24)
        Me.UsuariosToolStripMenuItem1.Text = "Usuarios"
        '
        'ReportesToolStripMenuItem1
        '
        Me.ReportesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteDeFacturasToolStripMenuItem, Me.ReporteDeCotizaciónToolStripMenuItem})
        Me.ReportesToolStripMenuItem1.Image = Global.FacturacionServicios.My.Resources.Resources.Reports
        Me.ReportesToolStripMenuItem1.Name = "ReportesToolStripMenuItem1"
        Me.ReportesToolStripMenuItem1.Size = New System.Drawing.Size(109, 23)
        Me.ReportesToolStripMenuItem1.Text = "Reportes"
        '
        'ReporteDeFacturasToolStripMenuItem
        '
        Me.ReporteDeFacturasToolStripMenuItem.Name = "ReporteDeFacturasToolStripMenuItem"
        Me.ReporteDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.ReporteDeFacturasToolStripMenuItem.Text = "Reporte de Facturas"
        '
        'ReporteDeCotizaciónToolStripMenuItem
        '
        Me.ReporteDeCotizaciónToolStripMenuItem.Name = "ReporteDeCotizaciónToolStripMenuItem"
        Me.ReporteDeCotizaciónToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.ReporteDeCotizaciónToolStripMenuItem.Text = "Reporte de Cotización"
        '
        'ConfiguraciónToolStripMenuItem1
        '
        Me.ConfiguraciónToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParámetrosToolStripMenuItem, Me.DatosEmpresaToolStripMenuItem, Me.ConfiguraciónNCFToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem1.Image = Global.FacturacionServicios.My.Resources.Resources.configuration1
        Me.ConfiguraciónToolStripMenuItem1.Name = "ConfiguraciónToolStripMenuItem1"
        Me.ConfiguraciónToolStripMenuItem1.Size = New System.Drawing.Size(154, 23)
        Me.ConfiguraciónToolStripMenuItem1.Text = "Configuración"
        '
        'ParámetrosToolStripMenuItem
        '
        Me.ParámetrosToolStripMenuItem.Name = "ParámetrosToolStripMenuItem"
        Me.ParámetrosToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
        Me.ParámetrosToolStripMenuItem.Text = "Parámetros"
        '
        'DatosEmpresaToolStripMenuItem
        '
        Me.DatosEmpresaToolStripMenuItem.Name = "DatosEmpresaToolStripMenuItem"
        Me.DatosEmpresaToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
        Me.DatosEmpresaToolStripMenuItem.Text = "Datos empresa"
        '
        'AcercaDeToolStripMenuItem2
        '
        Me.AcercaDeToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NosotrosToolStripMenuItem2})
        Me.AcercaDeToolStripMenuItem2.Image = Global.FacturacionServicios.My.Resources.Resources.About1
        Me.AcercaDeToolStripMenuItem2.Name = "AcercaDeToolStripMenuItem2"
        Me.AcercaDeToolStripMenuItem2.Size = New System.Drawing.Size(118, 23)
        Me.AcercaDeToolStripMenuItem2.Text = "Acerca de"
        '
        'NosotrosToolStripMenuItem2
        '
        Me.NosotrosToolStripMenuItem2.Name = "NosotrosToolStripMenuItem2"
        Me.NosotrosToolStripMenuItem2.Size = New System.Drawing.Size(150, 24)
        Me.NosotrosToolStripMenuItem2.Text = "Nosotros"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirDelSistemaToolStripMenuItem1})
        Me.SalirToolStripMenuItem.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(82, 23)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'SalirDelSistemaToolStripMenuItem1
        '
        Me.SalirDelSistemaToolStripMenuItem1.Name = "SalirDelSistemaToolStripMenuItem1"
        Me.SalirDelSistemaToolStripMenuItem1.Size = New System.Drawing.Size(231, 24)
        Me.SalirDelSistemaToolStripMenuItem1.Text = "Salir del Sistema"
        '
        'ConfiguraciónNCFToolStripMenuItem
        '
        Me.ConfiguraciónNCFToolStripMenuItem.Name = "ConfiguraciónNCFToolStripMenuItem"
        Me.ConfiguraciónNCFToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
        Me.ConfiguraciónNCFToolStripMenuItem.Text = "Configuración NCF"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(603, 418)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CotizaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalculadoraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip3 As MenuStrip
    Friend WithEvents FuncionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CotizacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReporteDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeCotizaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguraciónToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParámetrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NosotrosToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SalirDelSistemaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents tssfecha As ToolStripStatusLabel
    Friend WithEvents tsshora As ToolStripStatusLabel
    Friend WithEvents tssusuario As ToolStripStatusLabel
    Friend WithEvents DatosEmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ConfiguraciónNCFToolStripMenuItem As ToolStripMenuItem
End Class
