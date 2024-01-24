namespace csv2xml_converter
{
    partial class converter
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
            this.csv2xml = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // csv2xml
            // 
            this.csv2xml.AllowDrop = true;
            this.csv2xml.AutoSize = true;
            this.csv2xml.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csv2xml.Location = new System.Drawing.Point(218, 190);
            this.csv2xml.Name = "csv2xml";
            this.csv2xml.Size = new System.Drawing.Size(312, 17);
            this.csv2xml.TabIndex = 0;
            this.csv2xml.Text = "Drag and drop .csv file to convert .xml file";
            // 
            // converter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.csv2xml);
            this.Name = "converter";
            this.Text = "CSV2XML Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label csv2xml;
    }
}

