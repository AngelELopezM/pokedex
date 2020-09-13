namespace POKEDEX_ITLA
{
    partial class frm_principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_principal));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_mant_pokemon = new System.Windows.Forms.Button();
            this.btn_mant_regiones = new System.Windows.Forms.Button();
            this.btn_mant_tipos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btn_mant_tipos, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_mant_regiones, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_mant_pokemon, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.94574F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.05426F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 498);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_mant_pokemon
            // 
            this.btn_mant_pokemon.AutoSize = true;
            this.btn_mant_pokemon.BackColor = System.Drawing.Color.Red;
            this.btn_mant_pokemon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_mant_pokemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mant_pokemon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_mant_pokemon.Location = new System.Drawing.Point(3, 309);
            this.btn_mant_pokemon.Name = "btn_mant_pokemon";
            this.btn_mant_pokemon.Size = new System.Drawing.Size(336, 56);
            this.btn_mant_pokemon.TabIndex = 1;
            this.btn_mant_pokemon.Text = "Mantenimiento de pokemon";
            this.btn_mant_pokemon.UseVisualStyleBackColor = false;
            this.btn_mant_pokemon.Click += new System.EventHandler(this.btn_mant_pokemon_Click);
            // 
            // btn_mant_regiones
            // 
            this.btn_mant_regiones.AutoSize = true;
            this.btn_mant_regiones.BackColor = System.Drawing.Color.Black;
            this.btn_mant_regiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_mant_regiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mant_regiones.ForeColor = System.Drawing.Color.White;
            this.btn_mant_regiones.Location = new System.Drawing.Point(3, 371);
            this.btn_mant_regiones.Name = "btn_mant_regiones";
            this.btn_mant_regiones.Size = new System.Drawing.Size(336, 59);
            this.btn_mant_regiones.TabIndex = 2;
            this.btn_mant_regiones.Text = "Mantenimiento de regiones";
            this.btn_mant_regiones.UseVisualStyleBackColor = false;
            this.btn_mant_regiones.Click += new System.EventHandler(this.btn_mant_regiones_Click);
            // 
            // btn_mant_tipos
            // 
            this.btn_mant_tipos.AutoSize = true;
            this.btn_mant_tipos.BackColor = System.Drawing.Color.White;
            this.btn_mant_tipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_mant_tipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mant_tipos.ForeColor = System.Drawing.Color.Black;
            this.btn_mant_tipos.Location = new System.Drawing.Point(3, 436);
            this.btn_mant_tipos.Name = "btn_mant_tipos";
            this.btn_mant_tipos.Size = new System.Drawing.Size(336, 59);
            this.btn_mant_tipos.TabIndex = 3;
            this.btn_mant_tipos.Text = "Mantenimiento de tipos";
            this.btn_mant_tipos.UseVisualStyleBackColor = false;
            this.btn_mant_tipos.Click += new System.EventHandler(this.btn_mant_tipos_Click);
            // 
            // frm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(342, 498);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POKEDEX";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_mant_tipos;
        private System.Windows.Forms.Button btn_mant_regiones;
        private System.Windows.Forms.Button btn_mant_pokemon;
    }
}

