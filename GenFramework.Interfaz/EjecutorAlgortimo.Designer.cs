﻿namespace GenFramework.Interfaz
{
    partial class EjecutorAlgortimo
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
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.grpParametros = new System.Windows.Forms.GroupBox();
            this.lblLimiteVueltas = new System.Windows.Forms.Label();
            this.nudLimiteVueltas = new System.Windows.Forms.NumericUpDown();
            this.nudPesoMaximo = new System.Windows.Forms.NumericUpDown();
            this.lblPesoMax = new System.Windows.Forms.Label();
            this.nudPesoMinimo = new System.Windows.Forms.NumericUpDown();
            this.lblPesoMin = new System.Windows.Forms.Label();
            this.nudAltura = new System.Windows.Forms.NumericUpDown();
            this.lblAlturaSuperar = new System.Windows.Forms.Label();
            this.lblPoblacionInicial = new System.Windows.Forms.Label();
            this.nudPoblacionInicial = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVueltaPeorIndividuo = new System.Windows.Forms.Label();
            this.lblVueltaMejorIndividuo = new System.Windows.Forms.Label();
            this.txtVueltaPeorIndividuo = new System.Windows.Forms.TextBox();
            this.txtVueltaMejorIndividuo = new System.Windows.Forms.TextBox();
            this.txtGlobalPorcentajeExito = new System.Windows.Forms.TextBox();
            this.lblGlobalPorcentajeExito = new System.Windows.Forms.Label();
            this.txtGlobalPeorIndividuo = new System.Windows.Forms.TextBox();
            this.txtGlobalMejorIndividuo = new System.Windows.Forms.TextBox();
            this.lblGlobalPeorIndividuo = new System.Windows.Forms.Label();
            this.lblGlobalMejorIndividuo = new System.Windows.Forms.Label();
            this.nudTiempo = new System.Windows.Forms.NumericUpDown();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.txtNumeroGeneracion = new System.Windows.Forms.TextBox();
            this.lblNumeroGeneracion = new System.Windows.Forms.Label();
            this.grpParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimiteVueltas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoblacionInicial)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(557, 328);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // grpParametros
            // 
            this.grpParametros.Controls.Add(this.lblLimiteVueltas);
            this.grpParametros.Controls.Add(this.nudLimiteVueltas);
            this.grpParametros.Controls.Add(this.nudPesoMaximo);
            this.grpParametros.Controls.Add(this.lblPesoMax);
            this.grpParametros.Controls.Add(this.nudPesoMinimo);
            this.grpParametros.Controls.Add(this.lblPesoMin);
            this.grpParametros.Controls.Add(this.nudAltura);
            this.grpParametros.Controls.Add(this.lblAlturaSuperar);
            this.grpParametros.Controls.Add(this.lblPoblacionInicial);
            this.grpParametros.Controls.Add(this.nudPoblacionInicial);
            this.grpParametros.Location = new System.Drawing.Point(13, 13);
            this.grpParametros.Name = "grpParametros";
            this.grpParametros.Size = new System.Drawing.Size(200, 338);
            this.grpParametros.TabIndex = 1;
            this.grpParametros.TabStop = false;
            this.grpParametros.Text = "Parametros";
            // 
            // lblLimiteVueltas
            // 
            this.lblLimiteVueltas.AutoSize = true;
            this.lblLimiteVueltas.Location = new System.Drawing.Point(6, 125);
            this.lblLimiteVueltas.Name = "lblLimiteVueltas";
            this.lblLimiteVueltas.Size = new System.Drawing.Size(113, 13);
            this.lblLimiteVueltas.TabIndex = 6;
            this.lblLimiteVueltas.Text = "Límite de vueltas máx:";
            // 
            // nudLimiteVueltas
            // 
            this.nudLimiteVueltas.Location = new System.Drawing.Point(126, 123);
            this.nudLimiteVueltas.Name = "nudLimiteVueltas";
            this.nudLimiteVueltas.Size = new System.Drawing.Size(68, 20);
            this.nudLimiteVueltas.TabIndex = 4;
            this.nudLimiteVueltas.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudPesoMaximo
            // 
            this.nudPesoMaximo.Location = new System.Drawing.Point(151, 97);
            this.nudPesoMaximo.Name = "nudPesoMaximo";
            this.nudPesoMaximo.Size = new System.Drawing.Size(43, 20);
            this.nudPesoMaximo.TabIndex = 7;
            this.nudPesoMaximo.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblPesoMax
            // 
            this.lblPesoMax.AutoSize = true;
            this.lblPesoMax.Location = new System.Drawing.Point(6, 99);
            this.lblPesoMax.Name = "lblPesoMax";
            this.lblPesoMax.Size = new System.Drawing.Size(122, 13);
            this.lblPesoMax.TabIndex = 6;
            this.lblPesoMax.Text = "Peso individuo max. (kg)";
            // 
            // nudPesoMinimo
            // 
            this.nudPesoMinimo.Location = new System.Drawing.Point(151, 71);
            this.nudPesoMinimo.Name = "nudPesoMinimo";
            this.nudPesoMinimo.Size = new System.Drawing.Size(43, 20);
            this.nudPesoMinimo.TabIndex = 5;
            this.nudPesoMinimo.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // lblPesoMin
            // 
            this.lblPesoMin.AutoSize = true;
            this.lblPesoMin.Location = new System.Drawing.Point(6, 73);
            this.lblPesoMin.Name = "lblPesoMin";
            this.lblPesoMin.Size = new System.Drawing.Size(121, 13);
            this.lblPesoMin.TabIndex = 4;
            this.lblPesoMin.Text = "Peso individuo mín. (kg)";
            // 
            // nudAltura
            // 
            this.nudAltura.Location = new System.Drawing.Point(151, 45);
            this.nudAltura.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudAltura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAltura.Name = "nudAltura";
            this.nudAltura.Size = new System.Drawing.Size(43, 20);
            this.nudAltura.TabIndex = 3;
            this.nudAltura.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblAlturaSuperar
            // 
            this.lblAlturaSuperar.AutoSize = true;
            this.lblAlturaSuperar.Location = new System.Drawing.Point(6, 48);
            this.lblAlturaSuperar.Name = "lblAlturaSuperar";
            this.lblAlturaSuperar.Size = new System.Drawing.Size(107, 13);
            this.lblAlturaSuperar.TabIndex = 2;
            this.lblAlturaSuperar.Text = "Altura a superar (cm):";
            // 
            // lblPoblacionInicial
            // 
            this.lblPoblacionInicial.AutoSize = true;
            this.lblPoblacionInicial.Location = new System.Drawing.Point(6, 21);
            this.lblPoblacionInicial.Name = "lblPoblacionInicial";
            this.lblPoblacionInicial.Size = new System.Drawing.Size(142, 13);
            this.lblPoblacionInicial.TabIndex = 1;
            this.lblPoblacionInicial.Text = "Población inicial (individuos):";
            // 
            // nudPoblacionInicial
            // 
            this.nudPoblacionInicial.Location = new System.Drawing.Point(151, 19);
            this.nudPoblacionInicial.Name = "nudPoblacionInicial";
            this.nudPoblacionInicial.Size = new System.Drawing.Size(43, 20);
            this.nudPoblacionInicial.TabIndex = 0;
            this.nudPoblacionInicial.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumeroGeneracion);
            this.groupBox1.Controls.Add(this.lblNumeroGeneracion);
            this.groupBox1.Controls.Add(this.lblVueltaPeorIndividuo);
            this.groupBox1.Controls.Add(this.lblVueltaMejorIndividuo);
            this.groupBox1.Controls.Add(this.txtVueltaPeorIndividuo);
            this.groupBox1.Controls.Add(this.txtVueltaMejorIndividuo);
            this.groupBox1.Controls.Add(this.txtGlobalPorcentajeExito);
            this.groupBox1.Controls.Add(this.lblGlobalPorcentajeExito);
            this.groupBox1.Controls.Add(this.txtGlobalPeorIndividuo);
            this.groupBox1.Controls.Add(this.txtGlobalMejorIndividuo);
            this.groupBox1.Controls.Add(this.lblGlobalPeorIndividuo);
            this.groupBox1.Controls.Add(this.lblGlobalMejorIndividuo);
            this.groupBox1.Location = new System.Drawing.Point(220, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 309);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // lblVueltaPeorIndividuo
            // 
            this.lblVueltaPeorIndividuo.AutoSize = true;
            this.lblVueltaPeorIndividuo.Location = new System.Drawing.Point(6, 154);
            this.lblVueltaPeorIndividuo.Name = "lblVueltaPeorIndividuo";
            this.lblVueltaPeorIndividuo.Size = new System.Drawing.Size(182, 13);
            this.lblVueltaPeorIndividuo.TabIndex = 9;
            this.lblVueltaPeorIndividuo.Text = "Vuelta - Peor individuo (salto en cm.):";
            // 
            // lblVueltaMejorIndividuo
            // 
            this.lblVueltaMejorIndividuo.AutoSize = true;
            this.lblVueltaMejorIndividuo.Location = new System.Drawing.Point(6, 128);
            this.lblVueltaMejorIndividuo.Name = "lblVueltaMejorIndividuo";
            this.lblVueltaMejorIndividuo.Size = new System.Drawing.Size(186, 13);
            this.lblVueltaMejorIndividuo.TabIndex = 8;
            this.lblVueltaMejorIndividuo.Text = "Vuelta - Mejor individuo (salto en cm.):";
            // 
            // txtVueltaPeorIndividuo
            // 
            this.txtVueltaPeorIndividuo.Location = new System.Drawing.Point(202, 151);
            this.txtVueltaPeorIndividuo.Name = "txtVueltaPeorIndividuo";
            this.txtVueltaPeorIndividuo.Size = new System.Drawing.Size(100, 20);
            this.txtVueltaPeorIndividuo.TabIndex = 7;
            // 
            // txtVueltaMejorIndividuo
            // 
            this.txtVueltaMejorIndividuo.Location = new System.Drawing.Point(202, 125);
            this.txtVueltaMejorIndividuo.Name = "txtVueltaMejorIndividuo";
            this.txtVueltaMejorIndividuo.Size = new System.Drawing.Size(100, 20);
            this.txtVueltaMejorIndividuo.TabIndex = 6;
            // 
            // txtGlobalPorcentajeExito
            // 
            this.txtGlobalPorcentajeExito.Location = new System.Drawing.Point(202, 96);
            this.txtGlobalPorcentajeExito.Name = "txtGlobalPorcentajeExito";
            this.txtGlobalPorcentajeExito.Size = new System.Drawing.Size(100, 20);
            this.txtGlobalPorcentajeExito.TabIndex = 5;
            // 
            // lblGlobalPorcentajeExito
            // 
            this.lblGlobalPorcentajeExito.AutoSize = true;
            this.lblGlobalPorcentajeExito.Location = new System.Drawing.Point(6, 99);
            this.lblGlobalPorcentajeExito.Name = "lblGlobalPorcentajeExito";
            this.lblGlobalPorcentajeExito.Size = new System.Drawing.Size(133, 13);
            this.lblGlobalPorcentajeExito.TabIndex = 4;
            this.lblGlobalPorcentajeExito.Text = "Porcentaje de éxito (en %):";
            // 
            // txtGlobalPeorIndividuo
            // 
            this.txtGlobalPeorIndividuo.Location = new System.Drawing.Point(202, 70);
            this.txtGlobalPeorIndividuo.Name = "txtGlobalPeorIndividuo";
            this.txtGlobalPeorIndividuo.Size = new System.Drawing.Size(100, 20);
            this.txtGlobalPeorIndividuo.TabIndex = 3;
            // 
            // txtGlobalMejorIndividuo
            // 
            this.txtGlobalMejorIndividuo.Location = new System.Drawing.Point(202, 44);
            this.txtGlobalMejorIndividuo.Name = "txtGlobalMejorIndividuo";
            this.txtGlobalMejorIndividuo.Size = new System.Drawing.Size(100, 20);
            this.txtGlobalMejorIndividuo.TabIndex = 2;
            // 
            // lblGlobalPeorIndividuo
            // 
            this.lblGlobalPeorIndividuo.AutoSize = true;
            this.lblGlobalPeorIndividuo.Location = new System.Drawing.Point(6, 74);
            this.lblGlobalPeorIndividuo.Name = "lblGlobalPeorIndividuo";
            this.lblGlobalPeorIndividuo.Size = new System.Drawing.Size(182, 13);
            this.lblGlobalPeorIndividuo.TabIndex = 1;
            this.lblGlobalPeorIndividuo.Text = "Global - Peor individuo (salto en cm.):";
            // 
            // lblGlobalMejorIndividuo
            // 
            this.lblGlobalMejorIndividuo.AutoSize = true;
            this.lblGlobalMejorIndividuo.Location = new System.Drawing.Point(6, 47);
            this.lblGlobalMejorIndividuo.Name = "lblGlobalMejorIndividuo";
            this.lblGlobalMejorIndividuo.Size = new System.Drawing.Size(186, 13);
            this.lblGlobalMejorIndividuo.TabIndex = 0;
            this.lblGlobalMejorIndividuo.Text = "Global - Mejor individuo (salto en cm.):";
            // 
            // nudTiempo
            // 
            this.nudTiempo.Location = new System.Drawing.Point(473, 330);
            this.nudTiempo.Name = "nudTiempo";
            this.nudTiempo.Size = new System.Drawing.Size(78, 20);
            this.nudTiempo.TabIndex = 2;
            this.nudTiempo.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTiempo.ValueChanged += new System.EventHandler(this.nudTiempo_ValueChanged);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(390, 332);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(77, 13);
            this.lblTiempo.TabIndex = 3;
            this.lblTiempo.Text = "Intervalo (seg):";
            // 
            // txtNumeroGeneracion
            // 
            this.txtNumeroGeneracion.Location = new System.Drawing.Point(202, 19);
            this.txtNumeroGeneracion.Name = "txtNumeroGeneracion";
            this.txtNumeroGeneracion.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroGeneracion.TabIndex = 11;
            // 
            // lblNumeroGeneracion
            // 
            this.lblNumeroGeneracion.AutoSize = true;
            this.lblNumeroGeneracion.Location = new System.Drawing.Point(6, 22);
            this.lblNumeroGeneracion.Name = "lblNumeroGeneracion";
            this.lblNumeroGeneracion.Size = new System.Drawing.Size(118, 13);
            this.lblNumeroGeneracion.TabIndex = 10;
            this.lblNumeroGeneracion.Text = "Número de generación:";
            // 
            // EjecutorAlgortimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 363);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.nudTiempo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpParametros);
            this.Controls.Add(this.btnEjecutar);
            this.Name = "EjecutorAlgortimo";
            this.Text = "Ejecutor de algoritmo genético";
            this.grpParametros.ResumeLayout(false);
            this.grpParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimiteVueltas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoblacionInicial)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiempo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.GroupBox grpParametros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPoblacionInicial;
        private System.Windows.Forms.NumericUpDown nudPoblacionInicial;
        private System.Windows.Forms.NumericUpDown nudTiempo;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.NumericUpDown nudAltura;
        private System.Windows.Forms.Label lblAlturaSuperar;
        private System.Windows.Forms.Label lblPesoMin;
        private System.Windows.Forms.NumericUpDown nudPesoMaximo;
        private System.Windows.Forms.Label lblPesoMax;
        private System.Windows.Forms.NumericUpDown nudPesoMinimo;
        private System.Windows.Forms.Label lblGlobalMejorIndividuo;
        private System.Windows.Forms.Label lblGlobalPeorIndividuo;
        private System.Windows.Forms.TextBox txtGlobalPeorIndividuo;
        private System.Windows.Forms.TextBox txtGlobalMejorIndividuo;
        private System.Windows.Forms.TextBox txtGlobalPorcentajeExito;
        private System.Windows.Forms.Label lblGlobalPorcentajeExito;
        private System.Windows.Forms.Label lblLimiteVueltas;
        private System.Windows.Forms.NumericUpDown nudLimiteVueltas;
        private System.Windows.Forms.TextBox txtVueltaPeorIndividuo;
        private System.Windows.Forms.TextBox txtVueltaMejorIndividuo;
        private System.Windows.Forms.Label lblVueltaPeorIndividuo;
        private System.Windows.Forms.Label lblVueltaMejorIndividuo;
        private System.Windows.Forms.TextBox txtNumeroGeneracion;
        private System.Windows.Forms.Label lblNumeroGeneracion;
    }
}

