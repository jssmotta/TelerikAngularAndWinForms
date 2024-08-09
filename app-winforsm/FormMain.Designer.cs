namespace app_winforsm;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        windows11Theme1 = new Telerik.WinControls.Themes.Windows11Theme();
        radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
        splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
        splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
        angularWebControl1 = new AngularWebControl();
        ((System.ComponentModel.ISupportInitialize)radSplitContainer1).BeginInit();
        radSplitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitPanel1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitPanel2).BeginInit();
        splitPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this).BeginInit();
        SuspendLayout();
        // 
        // radSplitContainer1
        // 
        radSplitContainer1.Controls.Add(splitPanel1);
        radSplitContainer1.Controls.Add(splitPanel2);
        radSplitContainer1.Dock = DockStyle.Fill;
        radSplitContainer1.Location = new Point(0, 0);
        radSplitContainer1.Name = "radSplitContainer1";
        radSplitContainer1.Size = new Size(1134, 584);
        radSplitContainer1.SplitterWidth = 20;
        radSplitContainer1.TabIndex = 0;
        radSplitContainer1.TabStop = false;
        radSplitContainer1.ThemeName = "Windows11";
        // 
        // splitPanel1
        // 
        splitPanel1.Location = new Point(0, 0);
        splitPanel1.Name = "splitPanel1";
        splitPanel1.Size = new Size(557, 584);
        splitPanel1.TabIndex = 0;
        splitPanel1.TabStop = false;
        splitPanel1.Text = "splitPanel1";
        splitPanel1.ThemeName = "Windows11";
        // 
        // splitPanel2
        // 
        splitPanel2.Controls.Add(angularWebControl1);
        splitPanel2.Location = new Point(577, 0);
        splitPanel2.Name = "splitPanel2";
        splitPanel2.Size = new Size(557, 584);
        splitPanel2.TabIndex = 1;
        splitPanel2.TabStop = false;
        splitPanel2.Text = "splitPanel2";
        splitPanel2.ThemeName = "Windows11";
        // 
        // angularWebControl1
        // 
        angularWebControl1.Dock = DockStyle.Fill;
        angularWebControl1.Location = new Point(0, 0);
        angularWebControl1.Margin = new Padding(8, 8, 8, 8);
        angularWebControl1.Name = "angularWebControl1";
        angularWebControl1.Size = new Size(557, 584);
        angularWebControl1.TabIndex = 0;
        // 
        // FormMain
        // 
        AutoScaleBaseSize = new Size(8, 20);
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1134, 584);
        Controls.Add(radSplitContainer1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FormMain";
        Text = "Windows Forms and Angular Islands";
        ThemeName = "Windows11";
        ((System.ComponentModel.ISupportInitialize)radSplitContainer1).EndInit();
        radSplitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitPanel1).EndInit();
        ((System.ComponentModel.ISupportInitialize)splitPanel2).EndInit();
        splitPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Telerik.WinControls.Themes.Windows11Theme windows11Theme1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private AngularWebControl angularWebControl1;
}
