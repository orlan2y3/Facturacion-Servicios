<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnumfactura = New System.Windows.Forms.TextBox()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbcondicion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.lbitbis = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.txtproducto = New System.Windows.Forms.TextBox()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtporcientodescuento = New System.Windows.Forms.TextBox()
        Me.rtbcomentario = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtrnccliente = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtValida = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rdb2 = New System.Windows.Forms.RadioButton()
        Me.rdb1 = New System.Windows.Forms.RadioButton()
        Me.txtnumcomprobante = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbestado = New System.Windows.Forms.Label()
        Me.lbusuarioquefacturo = New System.Windows.Forms.Label()
        Me.mtbfecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtporcientoitbis = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btbuscarCotizacion = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btnuevo = New System.Windows.Forms.Button()
        Me.btbuscar = New System.Windows.Forms.Button()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.btagregar = New System.Windows.Forms.Button()
        Me.btinsertar = New System.Windows.Forms.Button()
        Me.cmbComprobantes = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbIdComprobante = New System.Windows.Forms.ComboBox()
        Me.dgvfactura = New System.Windows.Forms.DataGridView()
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "# de Factura"
        '
        'txtnumfactura
        '
        Me.txtnumfactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumfactura.Location = New System.Drawing.Point(7, 22)
        Me.txtnumfactura.Name = "txtnumfactura"
        Me.txtnumfactura.ReadOnly = True
        Me.txtnumfactura.Size = New System.Drawing.Size(122, 22)
        Me.txtnumfactura.TabIndex = 0
        '
        'txtcliente
        '
        Me.txtcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcliente.Location = New System.Drawing.Point(143, 72)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(259, 22)
        Me.txtcliente.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(141, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(141, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Fecha"
        '
        'cmbcondicion
        '
        Me.cmbcondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcondicion.FormattingEnabled = True
        Me.cmbcondicion.Items.AddRange(New Object() {"Contado", "Crédito"})
        Me.cmbcondicion.Location = New System.Drawing.Point(225, 20)
        Me.cmbcondicion.Name = "cmbcondicion"
        Me.cmbcondicion.Size = New System.Drawing.Size(177, 24)
        Me.cmbcondicion.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(222, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Condición"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.Location = New System.Drawing.Point(624, 421)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ReadOnly = True
        Me.txtsubtotal.Size = New System.Drawing.Size(108, 22)
        Me.txtsubtotal.TabIndex = 15
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(553, 424)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Sub-Total"
        '
        'txtitbis
        '
        Me.txtitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitbis.ForeColor = System.Drawing.Color.Red
        Me.txtitbis.Location = New System.Drawing.Point(624, 447)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.ReadOnly = True
        Me.txtitbis.Size = New System.Drawing.Size(108, 22)
        Me.txtitbis.TabIndex = 16
        Me.txtitbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbitbis
        '
        Me.lbitbis.AutoSize = True
        Me.lbitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbitbis.Location = New System.Drawing.Point(501, 448)
        Me.lbitbis.Name = "lbitbis"
        Me.lbitbis.Size = New System.Drawing.Size(41, 16)
        Me.lbitbis.TabIndex = 39
        Me.lbitbis.Text = "ITBIS"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(624, 501)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(108, 22)
        Me.txttotal.TabIndex = 18
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(580, 504)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 16)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Total"
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.Color.White
        Me.txtprecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecio.Location = New System.Drawing.Point(642, 127)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(91, 22)
        Me.txtprecio.TabIndex = 7
        '
        'txtproducto
        '
        Me.txtproducto.BackColor = System.Drawing.Color.White
        Me.txtproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtproducto.Location = New System.Drawing.Point(73, 127)
        Me.txtproducto.Name = "txtproducto"
        Me.txtproducto.Size = New System.Drawing.Size(559, 22)
        Me.txtproducto.TabIndex = 6
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.White
        Me.txtcantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(9, 127)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(54, 22)
        Me.txtcantidad.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(471, 476)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 16)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Descuento"
        '
        'txtdescuento
        '
        Me.txtdescuento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(624, 473)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.ReadOnly = True
        Me.txtdescuento.Size = New System.Drawing.Size(108, 22)
        Me.txtdescuento.TabIndex = 17
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(540, 476)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 16)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "%"
        '
        'txtporcientodescuento
        '
        Me.txtporcientodescuento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtporcientodescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcientodescuento.Location = New System.Drawing.Point(561, 473)
        Me.txtporcientodescuento.Name = "txtporcientodescuento"
        Me.txtporcientodescuento.Size = New System.Drawing.Size(54, 22)
        Me.txtporcientodescuento.TabIndex = 60
        '
        'rtbcomentario
        '
        Me.rtbcomentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbcomentario.Location = New System.Drawing.Point(9, 440)
        Me.rtbcomentario.Name = "rtbcomentario"
        Me.rtbcomentario.Size = New System.Drawing.Size(415, 80)
        Me.rtbcomentario.TabIndex = 19
        Me.rtbcomentario.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "RNC Cliente"
        '
        'txtrnccliente
        '
        Me.txtrnccliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrnccliente.Location = New System.Drawing.Point(8, 72)
        Me.txtrnccliente.Name = "txtrnccliente"
        Me.txtrnccliente.Size = New System.Drawing.Size(122, 22)
        Me.txtrnccliente.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValida)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.rdb2)
        Me.GroupBox1.Controls.Add(Me.rdb1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(411, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 103)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Escoja una opción"
        '
        'txtValida
        '
        Me.txtValida.Enabled = False
        Me.txtValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValida.Location = New System.Drawing.Point(91, 73)
        Me.txtValida.Mask = "##/##/####"
        Me.txtValida.Name = "txtValida"
        Me.txtValida.Size = New System.Drawing.Size(74, 22)
        Me.txtValida.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Válida hasta"
        '
        'rdb2
        '
        Me.rdb2.AutoSize = True
        Me.rdb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb2.Location = New System.Drawing.Point(8, 48)
        Me.rdb2.Name = "rdb2"
        Me.rdb2.Size = New System.Drawing.Size(174, 20)
        Me.rdb2.TabIndex = 1
        Me.rdb2.TabStop = True
        Me.rdb2.Text = "Con Comprobante Fiscal"
        Me.rdb2.UseVisualStyleBackColor = True
        '
        'rdb1
        '
        Me.rdb1.AutoSize = True
        Me.rdb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb1.Location = New System.Drawing.Point(8, 19)
        Me.rdb1.Name = "rdb1"
        Me.rdb1.Size = New System.Drawing.Size(178, 20)
        Me.rdb1.TabIndex = 0
        Me.rdb1.TabStop = True
        Me.rdb1.Text = "Factura Sin Comprobante"
        Me.rdb1.UseVisualStyleBackColor = True
        '
        'txtnumcomprobante
        '
        Me.txtnumcomprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumcomprobante.Location = New System.Drawing.Point(36, 55)
        Me.txtnumcomprobante.Name = "txtnumcomprobante"
        Me.txtnumcomprobante.ReadOnly = True
        Me.txtnumcomprobante.Size = New System.Drawing.Size(192, 22)
        Me.txtnumcomprobante.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 16)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "No."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(70, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Descripción"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(639, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Precio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 421)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 16)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Comentarios"
        '
        'lbestado
        '
        Me.lbestado.AutoSize = True
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.Red
        Me.lbestado.Location = New System.Drawing.Point(9, 381)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 29)
        Me.lbestado.TabIndex = 104
        Me.lbestado.Text = "A n u l a d a"
        Me.lbestado.Visible = False
        '
        'lbusuarioquefacturo
        '
        Me.lbusuarioquefacturo.AutoSize = True
        Me.lbusuarioquefacturo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbusuarioquefacturo.ForeColor = System.Drawing.Color.Red
        Me.lbusuarioquefacturo.Location = New System.Drawing.Point(101, 421)
        Me.lbusuarioquefacturo.Name = "lbusuarioquefacturo"
        Me.lbusuarioquefacturo.Size = New System.Drawing.Size(173, 16)
        Me.lbusuarioquefacturo.TabIndex = 111
        Me.lbusuarioquefacturo.Text = "Esta Factura fue hecha por: "
        Me.lbusuarioquefacturo.Visible = False
        '
        'mtbfecha
        '
        Me.mtbfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbfecha.Location = New System.Drawing.Point(143, 22)
        Me.mtbfecha.Mask = "00/00/0000"
        Me.mtbfecha.Name = "mtbfecha"
        Me.mtbfecha.Size = New System.Drawing.Size(69, 22)
        Me.mtbfecha.TabIndex = 1
        Me.mtbfecha.ValidatingType = GetType(Date)
        '
        'txtporcientoitbis
        '
        Me.txtporcientoitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtporcientoitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcientoitbis.Location = New System.Drawing.Point(561, 446)
        Me.txtporcientoitbis.Name = "txtporcientoitbis"
        Me.txtporcientoitbis.ReadOnly = True
        Me.txtporcientoitbis.Size = New System.Drawing.Size(54, 22)
        Me.txtporcientoitbis.TabIndex = 156
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(540, 448)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 16)
        Me.Label12.TabIndex = 157
        Me.Label12.Text = "%"
        '
        'btbuscarCotizacion
        '
        Me.btbuscarCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbuscarCotizacion.Image = CType(resources.GetObject("btbuscarCotizacion.Image"), System.Drawing.Image)
        Me.btbuscarCotizacion.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btbuscarCotizacion.Location = New System.Drawing.Point(745, 332)
        Me.btbuscarCotizacion.Name = "btbuscarCotizacion"
        Me.btbuscarCotizacion.Size = New System.Drawing.Size(109, 66)
        Me.btbuscarCotizacion.TabIndex = 12
        Me.btbuscarCotizacion.Text = "Buscar Cotización para Factura"
        Me.btbuscarCotizacion.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btbuscarCotizacion.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(745, 482)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(109, 41)
        Me.btsalir.TabIndex = 14
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btnuevo
        '
        Me.btnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnuevo.Image = Global.FacturacionServicios.My.Resources.Resources._New
        Me.btnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnuevo.Location = New System.Drawing.Point(745, 212)
        Me.btnuevo.Name = "btnuevo"
        Me.btnuevo.Size = New System.Drawing.Size(109, 38)
        Me.btnuevo.TabIndex = 10
        Me.btnuevo.Text = "Nueva"
        Me.btnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnuevo.UseVisualStyleBackColor = True
        '
        'btbuscar
        '
        Me.btbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Search
        Me.btbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btbuscar.Location = New System.Drawing.Point(745, 265)
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(109, 52)
        Me.btbuscar.TabIndex = 11
        Me.btbuscar.Text = "Buscar Factura"
        Me.btbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btbuscar.UseVisualStyleBackColor = True
        '
        'bteliminar
        '
        Me.bteliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bteliminar.Image = Global.FacturacionServicios.My.Resources.Resources.Delete
        Me.bteliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bteliminar.Location = New System.Drawing.Point(745, 161)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(109, 38)
        Me.bteliminar.TabIndex = 9
        Me.bteliminar.Text = "Eliminar"
        Me.bteliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bteliminar.UseVisualStyleBackColor = True
        Me.bteliminar.Visible = False
        '
        'btagregar
        '
        Me.btagregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btagregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btagregar.Image = Global.FacturacionServicios.My.Resources.Resources.Plus
        Me.btagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btagregar.Location = New System.Drawing.Point(745, 108)
        Me.btagregar.Name = "btagregar"
        Me.btagregar.Size = New System.Drawing.Size(109, 41)
        Me.btagregar.TabIndex = 8
        Me.btagregar.Text = "Agregar"
        Me.btagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btagregar.UseVisualStyleBackColor = True
        '
        'btinsertar
        '
        Me.btinsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btinsertar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btinsertar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btinsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btinsertar.Location = New System.Drawing.Point(745, 420)
        Me.btinsertar.Name = "btinsertar"
        Me.btinsertar.Size = New System.Drawing.Size(109, 48)
        Me.btinsertar.TabIndex = 13
        Me.btinsertar.Text = "Grabar"
        Me.btinsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btinsertar.UseVisualStyleBackColor = True
        '
        'cmbComprobantes
        '
        Me.cmbComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobantes.FormattingEnabled = True
        Me.cmbComprobantes.Location = New System.Drawing.Point(10, 20)
        Me.cmbComprobantes.Name = "cmbComprobantes"
        Me.cmbComprobantes.Size = New System.Drawing.Size(218, 23)
        Me.cmbComprobantes.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbIdComprobante)
        Me.GroupBox2.Controls.Add(Me.cmbComprobantes)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtnumcomprobante)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(615, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(237, 87)
        Me.GroupBox2.TabIndex = 180
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione Tipo de Comprobante"
        '
        'cmbIdComprobante
        '
        Me.cmbIdComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdComprobante.FormattingEnabled = True
        Me.cmbIdComprobante.Location = New System.Drawing.Point(44, 16)
        Me.cmbIdComprobante.Name = "cmbIdComprobante"
        Me.cmbIdComprobante.Size = New System.Drawing.Size(73, 24)
        Me.cmbIdComprobante.TabIndex = 181
        Me.cmbIdComprobante.Visible = False
        '
        'dgvfactura
        '
        Me.dgvfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvfactura.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvfactura.Location = New System.Drawing.Point(10, 154)
        Me.dgvfactura.Name = "dgvfactura"
        Me.dgvfactura.ReadOnly = True
        Me.dgvfactura.Size = New System.Drawing.Size(723, 256)
        Me.dgvfactura.TabIndex = 20
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb1.Location = New System.Drawing.Point(463, 424)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(82, 20)
        Me.cb1.TabIndex = 182
        Me.cb1.Text = "Sin ITBIS"
        Me.cb1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(863, 528)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btbuscarCotizacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtporcientoitbis)
        Me.Controls.Add(Me.mtbfecha)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.btnuevo)
        Me.Controls.Add(Me.lbusuarioquefacturo)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.btbuscar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtrnccliente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rtbcomentario)
        Me.Controls.Add(Me.cmbcondicion)
        Me.Controls.Add(Me.txtporcientodescuento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.bteliminar)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtproducto)
        Me.Controls.Add(Me.btagregar)
        Me.Controls.Add(Me.btinsertar)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lbitbis)
        Me.Controls.Add(Me.txtitbis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.txtnumfactura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvfactura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear Factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvfactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnumfactura As System.Windows.Forms.TextBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbcondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtitbis As System.Windows.Forms.TextBox
    Friend WithEvents lbitbis As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents btinsertar As System.Windows.Forms.Button
    Friend WithEvents btagregar As System.Windows.Forms.Button
    Friend WithEvents txtproducto As System.Windows.Forms.TextBox
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents bteliminar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtporcientodescuento As System.Windows.Forms.TextBox
    Friend WithEvents rtbcomentario As System.Windows.Forms.RichTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtrnccliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtnumcomprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btbuscar As System.Windows.Forms.Button

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbusuarioquefacturo As System.Windows.Forms.Label
    Friend WithEvents btnuevo As System.Windows.Forms.Button
    Friend WithEvents btsalir As System.Windows.Forms.Button
    Friend WithEvents mtbfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtporcientoitbis As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btbuscarCotizacion As Button
    Friend WithEvents rdb2 As RadioButton
    Friend WithEvents cmbComprobantes As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvfactura As DataGridView
    Friend WithEvents cb1 As CheckBox
    Friend WithEvents txtValida As MaskedTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbIdComprobante As ComboBox
End Class
