<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Parametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Parametros))
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtValida = New System.Windows.Forms.MaskedTextBox()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btguardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtitbis
        '
        Me.txtitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitbis.Location = New System.Drawing.Point(35, 34)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.Size = New System.Drawing.Size(46, 22)
        Me.txtitbis.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "% ITBIS "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(110, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 16)
        Me.Label6.TabIndex = 187
        Me.Label6.Text = "Factura Valida Hasta"
        '
        'txtValida
        '
        Me.txtValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValida.Location = New System.Drawing.Point(135, 33)
        Me.txtValida.Mask = "##/##/####"
        Me.txtValida.Name = "txtValida"
        Me.txtValida.Size = New System.Drawing.Size(75, 22)
        Me.txtValida.TabIndex = 1
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(150, 90)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(88, 38)
        Me.btsalir.TabIndex = 3
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btguardar
        '
        Me.btguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btguardar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btguardar.Location = New System.Drawing.Point(16, 90)
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(88, 38)
        Me.btguardar.TabIndex = 2
        Me.btguardar.Text = "Grabar"
        Me.btguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btguardar.UseVisualStyleBackColor = True
        '
        'Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.ClientSize = New System.Drawing.Size(257, 138)
        Me.Controls.Add(Me.txtValida)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btguardar)
        Me.Controls.Add(Me.txtitbis)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Parametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PARAMETROS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtitbis As System.Windows.Forms.TextBox
    Friend WithEvents btguardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btsalir As System.Windows.Forms.Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtValida As MaskedTextBox
End Class
