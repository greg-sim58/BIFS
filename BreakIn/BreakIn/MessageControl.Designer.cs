namespace BreakIn
{
  partial class MessageControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.btnMessage = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // btnMessage
        // 
        this.btnMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.btnMessage.AutoSize = true;
        this.btnMessage.BackColor = System.Drawing.Color.Firebrick;
        this.btnMessage.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
        this.btnMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnMessage.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnMessage.ForeColor = System.Drawing.Color.White;
        this.btnMessage.Location = new System.Drawing.Point(0, 0);
        this.btnMessage.Name = "btnMessage";
        this.btnMessage.Size = new System.Drawing.Size(310, 40);
        this.btnMessage.TabIndex = 0;
        this.btnMessage.Text = "button1";
        this.btnMessage.UseVisualStyleBackColor = false;
        this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
        // 
        // MessageControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.btnMessage);
        this.Name = "MessageControl";
        this.Size = new System.Drawing.Size(310, 40);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.Button btnMessage;

  }
}
