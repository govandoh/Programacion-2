﻿namespace practica1
{
    partial class Bitacora
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
            this.lts_empleados = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lts_empleados
            // 
            this.lts_empleados.FormattingEnabled = true;
            this.lts_empleados.Location = new System.Drawing.Point(38, 12);
            this.lts_empleados.Name = "lts_empleados";
            this.lts_empleados.Size = new System.Drawing.Size(609, 212);
            this.lts_empleados.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lts_empleados);
            this.Name = "Bitacora";
            this.Text = "Bitacora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bitacora_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lts_empleados;
        private System.Windows.Forms.Button button1;
    }
}