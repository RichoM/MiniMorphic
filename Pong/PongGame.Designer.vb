<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PongGame
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Morphic = New MiniMorphic.Morphic
        Me.LeftScoreLabel = New System.Windows.Forms.Label
        Me.RightScoreLabel = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Morphic
        '
        Me.Morphic.BackColor = System.Drawing.SystemColors.Control
        Me.Morphic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Morphic.Location = New System.Drawing.Point(0, 70)
        Me.Morphic.Name = "Morphic"
        Me.Morphic.Size = New System.Drawing.Size(752, 571)
        Me.Morphic.TabIndex = 0
        '
        'LeftScoreLabel
        '
        Me.LeftScoreLabel.BackColor = System.Drawing.Color.Black
        Me.LeftScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeftScoreLabel.ForeColor = System.Drawing.Color.White
        Me.LeftScoreLabel.Location = New System.Drawing.Point(13, 13)
        Me.LeftScoreLabel.Name = "LeftScoreLabel"
        Me.LeftScoreLabel.Size = New System.Drawing.Size(330, 40)
        Me.LeftScoreLabel.TabIndex = 1
        Me.LeftScoreLabel.Text = "0"
        Me.LeftScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RightScoreLabel
        '
        Me.RightScoreLabel.BackColor = System.Drawing.Color.Black
        Me.RightScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RightScoreLabel.ForeColor = System.Drawing.Color.White
        Me.RightScoreLabel.Location = New System.Drawing.Point(410, 13)
        Me.RightScoreLabel.Name = "RightScoreLabel"
        Me.RightScoreLabel.Size = New System.Drawing.Size(330, 40)
        Me.RightScoreLabel.TabIndex = 2
        Me.RightScoreLabel.Text = "0"
        Me.RightScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PongGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(752, 641)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RightScoreLabel)
        Me.Controls.Add(Me.LeftScoreLabel)
        Me.Controls.Add(Me.Morphic)
        Me.Name = "PongGame"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Morphic As MiniMorphic.Morphic
    Friend WithEvents LeftScoreLabel As System.Windows.Forms.Label
    Friend WithEvents RightScoreLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
