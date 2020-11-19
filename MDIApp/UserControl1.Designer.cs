
namespace MDIApp
{
    partial class CategoryControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoryPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.categoryPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryPictureBox
            // 
            this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.criminal;
            this.categoryPictureBox.Location = new System.Drawing.Point(0, 3);
            this.categoryPictureBox.Name = "categoryPictureBox";
            this.categoryPictureBox.Size = new System.Drawing.Size(132, 62);
            this.categoryPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.categoryPictureBox.TabIndex = 0;
            this.categoryPictureBox.TabStop = false;
            this.categoryPictureBox.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // CategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.categoryPictureBox);
            this.Name = "CategoryControl";
            this.Size = new System.Drawing.Size(132, 66);
            this.Load += new System.EventHandler(this.CategoryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox categoryPictureBox;
    }
}
