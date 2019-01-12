﻿namespace Engine.WinForms
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.raster = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zBufforCheckBox = new System.Windows.Forms.CheckBox();
            this.textureFaces = new System.Windows.Forms.RadioButton();
            this.solidFaces = new System.Windows.Forms.RadioButton();
            this.drawFacesCheckBox = new System.Windows.Forms.CheckBox();
            this.drawPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.drawEdgesCheckBox = new System.Windows.Forms.CheckBox();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backfaceCullingCheckBox = new System.Windows.Forms.CheckBox();
            this.loadTextureButton = new System.Windows.Forms.Button();
            this.textureView = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raster)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.raster, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // raster
            // 
            this.raster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.raster.Location = new System.Drawing.Point(3, 3);
            this.raster.Name = "raster";
            this.raster.Size = new System.Drawing.Size(594, 444);
            this.raster.TabIndex = 0;
            this.raster.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.FPSLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(603, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 444);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadLabel);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load File";
            // 
            // loadLabel
            // 
            this.loadLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadLabel.AutoSize = true;
            this.loadLabel.Location = new System.Drawing.Point(9, 45);
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Size = new System.Drawing.Size(72, 13);
            this.loadLabel.TabIndex = 1;
            this.loadLabel.Text = "No file loaded";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(6, 19);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load .off file";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rotationLabel);
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 63);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object rotation";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(7, 20);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(47, 13);
            this.rotationLabel.TabIndex = 0;
            this.rotationLabel.Text = "Rotation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.drawPointsCheckBox);
            this.groupBox3.Controls.Add(this.drawEdgesCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 210);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "What to draw";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textureView);
            this.groupBox4.Controls.Add(this.loadTextureButton);
            this.groupBox4.Controls.Add(this.backfaceCullingCheckBox);
            this.groupBox4.Controls.Add(this.zBufforCheckBox);
            this.groupBox4.Controls.Add(this.textureFaces);
            this.groupBox4.Controls.Add(this.solidFaces);
            this.groupBox4.Controls.Add(this.drawFacesCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 129);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Drawing Faces";
            // 
            // zBufforCheckBox
            // 
            this.zBufforCheckBox.AutoSize = true;
            this.zBufforCheckBox.Location = new System.Drawing.Point(89, 20);
            this.zBufforCheckBox.Name = "zBufforCheckBox";
            this.zBufforCheckBox.Size = new System.Drawing.Size(64, 17);
            this.zBufforCheckBox.TabIndex = 9;
            this.zBufforCheckBox.Text = "Z Buffor";
            this.zBufforCheckBox.UseVisualStyleBackColor = true;
            this.zBufforCheckBox.CheckedChanged += new System.EventHandler(this.refreshScreenEvent);
            // 
            // textureFaces
            // 
            this.textureFaces.AutoSize = true;
            this.textureFaces.Location = new System.Drawing.Point(3, 103);
            this.textureFaces.Name = "textureFaces";
            this.textureFaces.Size = new System.Drawing.Size(61, 17);
            this.textureFaces.TabIndex = 8;
            this.textureFaces.Text = "Texture";
            this.textureFaces.UseVisualStyleBackColor = true;
            // 
            // solidFaces
            // 
            this.solidFaces.AutoSize = true;
            this.solidFaces.Checked = true;
            this.solidFaces.Location = new System.Drawing.Point(3, 80);
            this.solidFaces.Name = "solidFaces";
            this.solidFaces.Size = new System.Drawing.Size(74, 17);
            this.solidFaces.TabIndex = 7;
            this.solidFaces.TabStop = true;
            this.solidFaces.Text = "Solid color";
            this.solidFaces.UseVisualStyleBackColor = true;
            this.solidFaces.CheckedChanged += new System.EventHandler(this.refreshScreenEvent);
            // 
            // drawFacesCheckBox
            // 
            this.drawFacesCheckBox.AutoSize = true;
            this.drawFacesCheckBox.Location = new System.Drawing.Point(3, 19);
            this.drawFacesCheckBox.Name = "drawFacesCheckBox";
            this.drawFacesCheckBox.Size = new System.Drawing.Size(83, 17);
            this.drawFacesCheckBox.TabIndex = 6;
            this.drawFacesCheckBox.Text = "Draw Faces";
            this.drawFacesCheckBox.UseVisualStyleBackColor = true;
            this.drawFacesCheckBox.CheckedChanged += new System.EventHandler(this.refreshScreenEvent);
            // 
            // drawPointsCheckBox
            // 
            this.drawPointsCheckBox.AutoSize = true;
            this.drawPointsCheckBox.Checked = true;
            this.drawPointsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawPointsCheckBox.Location = new System.Drawing.Point(3, 19);
            this.drawPointsCheckBox.Name = "drawPointsCheckBox";
            this.drawPointsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.drawPointsCheckBox.TabIndex = 4;
            this.drawPointsCheckBox.Text = "Draw Points";
            this.drawPointsCheckBox.UseVisualStyleBackColor = true;
            this.drawPointsCheckBox.CheckedChanged += new System.EventHandler(this.refreshScreenEvent);
            // 
            // drawEdgesCheckBox
            // 
            this.drawEdgesCheckBox.AutoSize = true;
            this.drawEdgesCheckBox.Location = new System.Drawing.Point(92, 19);
            this.drawEdgesCheckBox.Name = "drawEdgesCheckBox";
            this.drawEdgesCheckBox.Size = new System.Drawing.Size(84, 17);
            this.drawEdgesCheckBox.TabIndex = 5;
            this.drawEdgesCheckBox.Text = "Draw Edges";
            this.drawEdgesCheckBox.UseVisualStyleBackColor = true;
            this.drawEdgesCheckBox.CheckedChanged += new System.EventHandler(this.refreshScreenEvent);
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Location = new System.Drawing.Point(3, 391);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(53, 13);
            this.FPSLabel.TabIndex = 3;
            this.FPSLabel.Text = "FPSLabel";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backfaceCullingCheckBox
            // 
            this.backfaceCullingCheckBox.AutoSize = true;
            this.backfaceCullingCheckBox.Location = new System.Drawing.Point(3, 42);
            this.backfaceCullingCheckBox.Name = "backfaceCullingCheckBox";
            this.backfaceCullingCheckBox.Size = new System.Drawing.Size(105, 17);
            this.backfaceCullingCheckBox.TabIndex = 10;
            this.backfaceCullingCheckBox.Text = "Backface culling";
            this.backfaceCullingCheckBox.UseVisualStyleBackColor = true;
            // 
            // loadTextureButton
            // 
            this.loadTextureButton.Location = new System.Drawing.Point(60, 100);
            this.loadTextureButton.Name = "loadTextureButton";
            this.loadTextureButton.Size = new System.Drawing.Size(78, 23);
            this.loadTextureButton.TabIndex = 11;
            this.loadTextureButton.Text = "Load Texture";
            this.loadTextureButton.UseVisualStyleBackColor = true;
            this.loadTextureButton.Click += new System.EventHandler(this.loadTextureButton_Click);
            // 
            // textureView
            // 
            this.textureView.Location = new System.Drawing.Point(145, 100);
            this.textureView.Name = "textureView";
            this.textureView.Size = new System.Drawing.Size(22, 23);
            this.textureView.TabIndex = 12;
            this.textureView.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "3D Engine";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.refreshScreenEvent);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raster)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox raster;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.CheckBox drawPointsCheckBox;
        private System.Windows.Forms.CheckBox drawFacesCheckBox;
        private System.Windows.Forms.CheckBox drawEdgesCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton textureFaces;
        private System.Windows.Forms.RadioButton solidFaces;
        private System.Windows.Forms.CheckBox zBufforCheckBox;
        private System.Windows.Forms.PictureBox textureView;
        private System.Windows.Forms.Button loadTextureButton;
        private System.Windows.Forms.CheckBox backfaceCullingCheckBox;
    }
}

