namespace approx_visualization
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kresGórnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obszarNegatywnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obszarPozytywnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kresDolnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kresGórnyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1000, 1000);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kresGórnyToolStripMenuItem,
            this.obszarNegatywnyToolStripMenuItem,
            this.obszarPozytywnyToolStripMenuItem,
            this.kresDolnyToolStripMenuItem,
            this.kresGórnyToolStripMenuItem1});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.functionToolStripMenuItem.Text = "Function";
            // 
            // kresGórnyToolStripMenuItem
            // 
            this.kresGórnyToolStripMenuItem.Name = "kresGórnyToolStripMenuItem";
            this.kresGórnyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kresGórnyToolStripMenuItem.Text = "Obszar Brzegowy";
            this.kresGórnyToolStripMenuItem.Click += new System.EventHandler(this.EdgeArea);
            // 
            // obszarNegatywnyToolStripMenuItem
            // 
            this.obszarNegatywnyToolStripMenuItem.Name = "obszarNegatywnyToolStripMenuItem";
            this.obszarNegatywnyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.obszarNegatywnyToolStripMenuItem.Text = "Obszar Negatywny";
            this.obszarNegatywnyToolStripMenuItem.Click += new System.EventHandler(this.NegativeArea);
            // 
            // obszarPozytywnyToolStripMenuItem
            // 
            this.obszarPozytywnyToolStripMenuItem.Name = "obszarPozytywnyToolStripMenuItem";
            this.obszarPozytywnyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.obszarPozytywnyToolStripMenuItem.Text = "Obszar Pozytywny";
            this.obszarPozytywnyToolStripMenuItem.Click += new System.EventHandler(this.positiveArea);
            // 
            // kresDolnyToolStripMenuItem
            // 
            this.kresDolnyToolStripMenuItem.Name = "kresDolnyToolStripMenuItem";
            this.kresDolnyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kresDolnyToolStripMenuItem.Text = "Kres Dolny";
            this.kresDolnyToolStripMenuItem.Click += new System.EventHandler(this.infArea);
            // 
            // kresGórnyToolStripMenuItem1
            // 
            this.kresGórnyToolStripMenuItem1.Name = "kresGórnyToolStripMenuItem1";
            this.kresGórnyToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.kresGórnyToolStripMenuItem1.Text = "Kres Górny";
            this.kresGórnyToolStripMenuItem1.Click += new System.EventHandler(this.supArea);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 1024);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approximation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kresGórnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obszarNegatywnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obszarPozytywnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kresDolnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kresGórnyToolStripMenuItem1;
    }
}

