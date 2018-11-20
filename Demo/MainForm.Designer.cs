namespace Demo
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._zoomUpButton = new System.Windows.Forms.ToolStripButton();
            this._zoomDownButton = new System.Windows.Forms.ToolStripButton();
            this._usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            this._reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Users";
            reportDataSource1.Value = this._usersBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "Demo.UsersReport.rdlc";
            this._reportViewer.Location = new System.Drawing.Point(0, 25);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.ServerReport.BearerToken = null;
            this._reportViewer.ShowRefreshButton = false;
            this._reportViewer.ShowZoomControl = false;
            this._reportViewer.Size = new System.Drawing.Size(284, 236);
            this._reportViewer.TabIndex = 0;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._zoomUpButton,
            this._zoomDownButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(284, 25);
            this._toolStrip.TabIndex = 1;
            // 
            // _zoomUpButton
            // 
            this._zoomUpButton.Name = "_zoomUpButton";
            this._zoomUpButton.Size = new System.Drawing.Size(23, 22);
            this._zoomUpButton.Text = "+";
            this._zoomUpButton.ToolTipText = "Zoom In";
            this._zoomUpButton.Click += new System.EventHandler(this._zoomUpButton_Click);
            // 
            // _zoomDownButton
            // 
            this._zoomDownButton.Name = "_zoomDownButton";
            this._zoomDownButton.Size = new System.Drawing.Size(23, 22);
            this._zoomDownButton.Text = "-";
            this._zoomDownButton.ToolTipText = "Zoom Out";
            this._zoomDownButton.Click += new System.EventHandler(this._zoomDownButton_Click);
            // 
            // _usersBindingSource
            // 
            this._usersBindingSource.DataSource = typeof(Demo.User);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._reportViewer);
            this.Controls.Add(this._toolStrip);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _zoomDownButton;
        private System.Windows.Forms.BindingSource _usersBindingSource;
        private System.Windows.Forms.ToolStripButton _zoomUpButton;
    }
}

