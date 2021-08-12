
namespace LevelTool
{
    partial class Form1
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.GroundButton = new System.Windows.Forms.Button();
            this.WallButton = new System.Windows.Forms.Button();
            this.WaterButton = new System.Windows.Forms.Button();
            this.SpikeButton = new System.Windows.Forms.Button();
            this.EraseButton = new System.Windows.Forms.Button();
            this.DisplayButton = new System.Windows.Forms.Button();
            this.DisplayTileNameTextBox = new System.Windows.Forms.TextBox();
            this.RatButton = new System.Windows.Forms.Button();
            this.BatButton = new System.Windows.Forms.Button();
            this.ReverseSpikeButton = new System.Windows.Forms.Button();
            this.RespawnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(43, 378);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(175, 60);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(43, 303);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(175, 60);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // GroundButton
            // 
            this.GroundButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroundButton.Location = new System.Drawing.Point(64, 74);
            this.GroundButton.Name = "GroundButton";
            this.GroundButton.Size = new System.Drawing.Size(40, 40);
            this.GroundButton.TabIndex = 2;
            this.GroundButton.UseVisualStyleBackColor = false;
            this.GroundButton.Click += new System.EventHandler(this.GroundButton_Click);
            // 
            // WallButton
            // 
            this.WallButton.BackColor = System.Drawing.Color.Gray;
            this.WallButton.Location = new System.Drawing.Point(111, 74);
            this.WallButton.Name = "WallButton";
            this.WallButton.Size = new System.Drawing.Size(40, 40);
            this.WallButton.TabIndex = 3;
            this.WallButton.UseVisualStyleBackColor = false;
            this.WallButton.Click += new System.EventHandler(this.WallButton_Click);
            // 
            // WaterButton
            // 
            this.WaterButton.BackColor = System.Drawing.Color.SkyBlue;
            this.WaterButton.Location = new System.Drawing.Point(64, 116);
            this.WaterButton.Name = "WaterButton";
            this.WaterButton.Size = new System.Drawing.Size(40, 40);
            this.WaterButton.TabIndex = 4;
            this.WaterButton.UseVisualStyleBackColor = false;
            this.WaterButton.Click += new System.EventHandler(this.WaterButton_Click);
            // 
            // SpikeButton
            // 
            this.SpikeButton.BackColor = System.Drawing.Color.Maroon;
            this.SpikeButton.Location = new System.Drawing.Point(111, 116);
            this.SpikeButton.Name = "SpikeButton";
            this.SpikeButton.Size = new System.Drawing.Size(40, 40);
            this.SpikeButton.TabIndex = 5;
            this.SpikeButton.UseVisualStyleBackColor = false;
            this.SpikeButton.Click += new System.EventHandler(this.SpikeButton_Click);
            // 
            // EraseButton
            // 
            this.EraseButton.BackColor = System.Drawing.Color.White;
            this.EraseButton.Location = new System.Drawing.Point(157, 74);
            this.EraseButton.Name = "EraseButton";
            this.EraseButton.Size = new System.Drawing.Size(40, 40);
            this.EraseButton.TabIndex = 6;
            this.EraseButton.UseVisualStyleBackColor = false;
            this.EraseButton.Click += new System.EventHandler(this.EraseButton_Click);
            // 
            // DisplayButton
            // 
            this.DisplayButton.Location = new System.Drawing.Point(87, 191);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(85, 58);
            this.DisplayButton.TabIndex = 7;
            this.DisplayButton.UseVisualStyleBackColor = true;
            // 
            // DisplayTileNameTextBox
            // 
            this.DisplayTileNameTextBox.Location = new System.Drawing.Point(79, 255);
            this.DisplayTileNameTextBox.Name = "DisplayTileNameTextBox";
            this.DisplayTileNameTextBox.ReadOnly = true;
            this.DisplayTileNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.DisplayTileNameTextBox.TabIndex = 8;
            // 
            // RatButton
            // 
            this.RatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RatButton.Location = new System.Drawing.Point(64, 31);
            this.RatButton.Margin = new System.Windows.Forms.Padding(2);
            this.RatButton.Name = "RatButton";
            this.RatButton.Size = new System.Drawing.Size(40, 40);
            this.RatButton.TabIndex = 9;
            this.RatButton.UseVisualStyleBackColor = false;
            this.RatButton.Click += new System.EventHandler(this.RatButton_Click);
            // 
            // BatButton
            // 
            this.BatButton.BackColor = System.Drawing.Color.Black;
            this.BatButton.Location = new System.Drawing.Point(111, 31);
            this.BatButton.Margin = new System.Windows.Forms.Padding(2);
            this.BatButton.Name = "BatButton";
            this.BatButton.Size = new System.Drawing.Size(40, 40);
            this.BatButton.TabIndex = 10;
            this.BatButton.UseVisualStyleBackColor = false;
            this.BatButton.Click += new System.EventHandler(this.BatButton_Click);
            // 
            // ReverseSpikeButton
            // 
            this.ReverseSpikeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ReverseSpikeButton.Location = new System.Drawing.Point(157, 116);
            this.ReverseSpikeButton.Name = "ReverseSpikeButton";
            this.ReverseSpikeButton.Size = new System.Drawing.Size(40, 40);
            this.ReverseSpikeButton.TabIndex = 11;
            this.ReverseSpikeButton.UseVisualStyleBackColor = false;
            this.ReverseSpikeButton.Click += new System.EventHandler(this.ReverseSpikeButton_Click);
            // 
            // RespawnButton
            // 
            this.RespawnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RespawnButton.Location = new System.Drawing.Point(157, 31);
            this.RespawnButton.Name = "RespawnButton";
            this.RespawnButton.Size = new System.Drawing.Size(40, 40);
            this.RespawnButton.TabIndex = 12;
            this.RespawnButton.UseVisualStyleBackColor = false;
            this.RespawnButton.Click += new System.EventHandler(this.RespawnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 491);
            this.Controls.Add(this.RespawnButton);
            this.Controls.Add(this.ReverseSpikeButton);
            this.Controls.Add(this.BatButton);
            this.Controls.Add(this.RatButton);
            this.Controls.Add(this.DisplayTileNameTextBox);
            this.Controls.Add(this.DisplayButton);
            this.Controls.Add(this.EraseButton);
            this.Controls.Add(this.SpikeButton);
            this.Controls.Add(this.WaterButton);
            this.Controls.Add(this.WallButton);
            this.Controls.Add(this.GroundButton);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.LoadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button GroundButton;
        private System.Windows.Forms.Button WallButton;
        private System.Windows.Forms.Button WaterButton;
        private System.Windows.Forms.Button SpikeButton;
        private System.Windows.Forms.Button EraseButton;
        private System.Windows.Forms.Button DisplayButton;
        private System.Windows.Forms.TextBox DisplayTileNameTextBox;
        private System.Windows.Forms.Button RatButton;
        private System.Windows.Forms.Button BatButton;
        private System.Windows.Forms.Button ReverseSpikeButton;
        private System.Windows.Forms.Button RespawnButton;
    }
}

