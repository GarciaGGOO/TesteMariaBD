namespace TesteMariaDB
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnPopular = new System.Windows.Forms.Button();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.cronometro = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblContador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(78, 119);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(35, 13);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "label1";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(81, 40);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(64, 20);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnPopular
            // 
            this.btnPopular.Location = new System.Drawing.Point(81, 79);
            this.btnPopular.Name = "btnPopular";
            this.btnPopular.Size = new System.Drawing.Size(64, 20);
            this.btnPopular.TabIndex = 2;
            this.btnPopular.Text = "Popular";
            this.btnPopular.UseVisualStyleBackColor = true;
            this.btnPopular.Click += new System.EventHandler(this.btnPopular_Click);
            // 
            // txtResultados
            // 
            this.txtResultados.Location = new System.Drawing.Point(81, 156);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultados.Size = new System.Drawing.Size(258, 87);
            this.txtResultados.TabIndex = 3;
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Location = new System.Drawing.Point(81, 139);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(70, 13);
            this.lblCronometro.TabIndex = 4;
            this.lblCronometro.Text = "00:00:00.000";
            // 
            // cronometro
            // 
            this.cronometro.Interval = 10;
            this.cronometro.Tick += new System.EventHandler(this.cronometro_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(81, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(257, 20);
            this.progressBar.TabIndex = 5;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(81, 283);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(43, 13);
            this.lblContador.TabIndex = 6;
            this.lblContador.Text = "(0 de 0)";
            this.lblContador.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 335);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblCronometro);
            this.Controls.Add(this.txtResultados);
            this.Controls.Add(this.btnPopular);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.lblResultado);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnPopular;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Timer cronometro;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblContador;
    }
}

