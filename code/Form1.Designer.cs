namespace cascade_calculator
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
            lab_kascadesValue = new Label();
            play = new Button();
            panelOld = new Panel();
            panelNew = new Panel();
            spawn = new Button();
            MTB_CascadesValue = new NumericUpDown();
            lab_name = new Label();
            lab_koefNoise = new Label();
            lab_koefPower = new Label();
            lab_IP3 = new Label();
            btn_save = new Button();
            btn_load = new Button();
            panel1 = new Panel();
            lab_IP32 = new Label();
            lab_deltaKN = new Label();
            lab_koefPower2 = new Label();
            lab_koefNoise2 = new Label();
            lab_name2 = new Label();
            lab_deltaIP3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            plus_btn = new Button();
            lab_power = new Label();
            label1 = new Label();
            panel4 = new Panel();
            tb_powin = new TextBox();
            panel5 = new Panel();
            lab_im3 = new Label();
            lab_sfdr = new Label();
            label4 = new Label();
            label3 = new Label();
            panel6 = new Panel();
            tb_wide = new TextBox();
            label2 = new Label();
            panel7 = new Panel();
            tb_temp = new TextBox();
            label5 = new Label();
            zametki = new TextBox();
            R_btn = new Button();
            panelSwaps = new Panel();
            ((System.ComponentModel.ISupportInitialize)MTB_CascadesValue).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // lab_kascadesValue
            // 
            lab_kascadesValue.AutoSize = true;
            lab_kascadesValue.BackColor = SystemColors.Control;
            lab_kascadesValue.Font = new Font("Segoe UI", 9F);
            lab_kascadesValue.Location = new Point(4, 10);
            lab_kascadesValue.Name = "lab_kascadesValue";
            lab_kascadesValue.Size = new Size(130, 15);
            lab_kascadesValue.TabIndex = 0;
            lab_kascadesValue.Text = "Количество каскадов: ";
            // 
            // play
            // 
            play.BackColor = Color.ForestGreen;
            play.Cursor = Cursors.Hand;
            play.FlatAppearance.BorderColor = Color.White;
            play.FlatStyle = FlatStyle.Popup;
            play.ForeColor = SystemColors.Control;
            play.Location = new Point(3, 37);
            play.Name = "play";
            play.Size = new Size(123, 30);
            play.TabIndex = 2;
            play.Text = "Рассчитать";
            play.UseVisualStyleBackColor = false;
            play.Click += play_Click;
            // 
            // panelOld
            // 
            panelOld.BorderStyle = BorderStyle.Fixed3D;
            panelOld.Location = new Point(138, 88);
            panelOld.Name = "panelOld";
            panelOld.Size = new Size(865, 179);
            panelOld.TabIndex = 3;
            // 
            // panelNew
            // 
            panelNew.BorderStyle = BorderStyle.Fixed3D;
            panelNew.Location = new Point(138, 275);
            panelNew.Name = "panelNew";
            panelNew.Size = new Size(865, 205);
            panelNew.TabIndex = 4;
            // 
            // spawn
            // 
            spawn.BackColor = Color.PeachPuff;
            spawn.FlatStyle = FlatStyle.Popup;
            spawn.Location = new Point(3, 3);
            spawn.Name = "spawn";
            spawn.Size = new Size(123, 30);
            spawn.TabIndex = 5;
            spawn.Text = "Установить";
            spawn.UseVisualStyleBackColor = false;
            spawn.Click += spawn_Click;
            // 
            // MTB_CascadesValue
            // 
            MTB_CascadesValue.BorderStyle = BorderStyle.FixedSingle;
            MTB_CascadesValue.Location = new Point(177, 5);
            MTB_CascadesValue.Name = "MTB_CascadesValue";
            MTB_CascadesValue.Size = new Size(36, 23);
            MTB_CascadesValue.TabIndex = 0;
            // 
            // lab_name
            // 
            lab_name.AutoSize = true;
            lab_name.Location = new Point(9, 108);
            lab_name.Name = "lab_name";
            lab_name.Size = new Size(38, 15);
            lab_name.TabIndex = 7;
            lab_name.Text = "label2";
            // 
            // lab_koefNoise
            // 
            lab_koefNoise.AutoSize = true;
            lab_koefNoise.Location = new Point(9, 138);
            lab_koefNoise.Name = "lab_koefNoise";
            lab_koefNoise.Size = new Size(38, 15);
            lab_koefNoise.TabIndex = 7;
            lab_koefNoise.Text = "label2";
            // 
            // lab_koefPower
            // 
            lab_koefPower.AutoSize = true;
            lab_koefPower.Location = new Point(9, 168);
            lab_koefPower.Name = "lab_koefPower";
            lab_koefPower.Size = new Size(38, 15);
            lab_koefPower.TabIndex = 7;
            lab_koefPower.Text = "label2";
            // 
            // lab_IP3
            // 
            lab_IP3.AutoSize = true;
            lab_IP3.Location = new Point(9, 198);
            lab_IP3.Name = "lab_IP3";
            lab_IP3.Size = new Size(38, 15);
            lab_IP3.TabIndex = 7;
            lab_IP3.Text = "label2";
            // 
            // btn_save
            // 
            btn_save.BackColor = SystemColors.ActiveCaption;
            btn_save.FlatStyle = FlatStyle.Popup;
            btn_save.Location = new Point(3, 3);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(124, 30);
            btn_save.TabIndex = 9;
            btn_save.Text = "Сохранить";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // btn_load
            // 
            btn_load.BackColor = SystemColors.ActiveCaption;
            btn_load.FlatStyle = FlatStyle.Popup;
            btn_load.Location = new Point(3, 37);
            btn_load.Name = "btn_load";
            btn_load.Size = new Size(124, 30);
            btn_load.TabIndex = 9;
            btn_load.Text = "Загрузить";
            btn_load.UseVisualStyleBackColor = false;
            btn_load.Click += btn_load_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btn_load);
            panel1.Controls.Add(btn_save);
            panel1.Location = new Point(868, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(134, 74);
            panel1.TabIndex = 10;
            // 
            // lab_IP32
            // 
            lab_IP32.AutoSize = true;
            lab_IP32.Location = new Point(12, 374);
            lab_IP32.Name = "lab_IP32";
            lab_IP32.Size = new Size(38, 15);
            lab_IP32.TabIndex = 7;
            lab_IP32.Text = "label2";
            // 
            // lab_deltaKN
            // 
            lab_deltaKN.AutoSize = true;
            lab_deltaKN.Location = new Point(12, 399);
            lab_deltaKN.Name = "lab_deltaKN";
            lab_deltaKN.Size = new Size(38, 15);
            lab_deltaKN.TabIndex = 8;
            lab_deltaKN.Text = "label2";
            // 
            // lab_koefPower2
            // 
            lab_koefPower2.AutoSize = true;
            lab_koefPower2.Location = new Point(12, 349);
            lab_koefPower2.Name = "lab_koefPower2";
            lab_koefPower2.Size = new Size(38, 15);
            lab_koefPower2.TabIndex = 7;
            lab_koefPower2.Text = "label2";
            // 
            // lab_koefNoise2
            // 
            lab_koefNoise2.AutoSize = true;
            lab_koefNoise2.Location = new Point(12, 324);
            lab_koefNoise2.Name = "lab_koefNoise2";
            lab_koefNoise2.Size = new Size(38, 15);
            lab_koefNoise2.TabIndex = 7;
            lab_koefNoise2.Text = "label2";
            // 
            // lab_name2
            // 
            lab_name2.AutoSize = true;
            lab_name2.Location = new Point(12, 299);
            lab_name2.Name = "lab_name2";
            lab_name2.Size = new Size(38, 15);
            lab_name2.TabIndex = 7;
            lab_name2.Text = "label2";
            // 
            // lab_deltaIP3
            // 
            lab_deltaIP3.AutoSize = true;
            lab_deltaIP3.Location = new Point(12, 424);
            lab_deltaIP3.Name = "lab_deltaIP3";
            lab_deltaIP3.Size = new Size(38, 15);
            lab_deltaIP3.TabIndex = 8;
            lab_deltaIP3.Text = "label2";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(spawn);
            panel2.Controls.Add(play);
            panel2.Location = new Point(138, 8);
            panel2.Name = "panel2";
            panel2.Size = new Size(133, 74);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(plus_btn);
            panel3.Controls.Add(lab_kascadesValue);
            panel3.Controls.Add(MTB_CascadesValue);
            panel3.Location = new Point(277, 8);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 35);
            panel3.TabIndex = 12;
            // 
            // plus_btn
            // 
            plus_btn.Location = new Point(149, 5);
            plus_btn.Name = "plus_btn";
            plus_btn.Size = new Size(22, 23);
            plus_btn.TabIndex = 19;
            plus_btn.Text = "+";
            plus_btn.UseVisualStyleBackColor = true;
            plus_btn.Click += plus_btn_Click;
            // 
            // lab_power
            // 
            lab_power.AutoSize = true;
            lab_power.Location = new Point(12, 449);
            lab_power.Name = "lab_power";
            lab_power.Size = new Size(38, 15);
            lab_power.TabIndex = 8;
            lab_power.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 9);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 13;
            label1.Text = "Вх. мощность (дБм):";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(tb_powin);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(277, 47);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 35);
            panel4.TabIndex = 14;
            // 
            // tb_powin
            // 
            tb_powin.BackColor = SystemColors.Window;
            tb_powin.BorderStyle = BorderStyle.FixedSingle;
            tb_powin.Location = new Point(177, 5);
            tb_powin.Name = "tb_powin";
            tb_powin.Size = new Size(36, 23);
            tb_powin.TabIndex = 15;
            tb_powin.Text = "0";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(lab_im3);
            panel5.Controls.Add(lab_sfdr);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(729, 8);
            panel5.Name = "panel5";
            panel5.Size = new Size(133, 74);
            panel5.TabIndex = 15;
            // 
            // lab_im3
            // 
            lab_im3.AutoSize = true;
            lab_im3.Location = new Point(61, 7);
            lab_im3.Name = "lab_im3";
            lab_im3.Size = new Size(12, 15);
            lab_im3.TabIndex = 1;
            lab_im3.Text = "-";
            // 
            // lab_sfdr
            // 
            lab_sfdr.AutoSize = true;
            lab_sfdr.Location = new Point(62, 45);
            lab_sfdr.Name = "lab_sfdr";
            lab_sfdr.Size = new Size(12, 15);
            lab_sfdr.TabIndex = 1;
            lab_sfdr.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 0;
            label4.Text = "IM3 (dBc): ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 44);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 0;
            label3.Text = "SFDR (dB): ";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(tb_wide);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(503, 8);
            panel6.Name = "panel6";
            panel6.Size = new Size(220, 35);
            panel6.TabIndex = 16;
            // 
            // tb_wide
            // 
            tb_wide.BorderStyle = BorderStyle.FixedSingle;
            tb_wide.Location = new Point(177, 5);
            tb_wide.Name = "tb_wide";
            tb_wide.Size = new Size(36, 23);
            tb_wide.TabIndex = 15;
            tb_wide.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 9);
            label2.Name = "label2";
            label2.Size = new Size(162, 15);
            label2.TabIndex = 0;
            label2.Text = "Полоса пропускания (МГц):";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Control;
            panel7.BorderStyle = BorderStyle.Fixed3D;
            panel7.Controls.Add(tb_temp);
            panel7.Controls.Add(label5);
            panel7.Location = new Point(503, 47);
            panel7.Name = "panel7";
            panel7.Size = new Size(220, 35);
            panel7.TabIndex = 16;
            // 
            // tb_temp
            // 
            tb_temp.BorderStyle = BorderStyle.FixedSingle;
            tb_temp.Location = new Point(177, 5);
            tb_temp.Name = "tb_temp";
            tb_temp.Size = new Size(36, 23);
            tb_temp.TabIndex = 15;
            tb_temp.Text = "25";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 9);
            label5.Name = "label5";
            label5.Size = new Size(104, 15);
            label5.TabIndex = 0;
            label5.Text = "Температура (C): ";
            // 
            // zametki
            // 
            zametki.BackColor = SystemColors.ControlLight;
            zametki.Location = new Point(138, 488);
            zametki.Multiline = true;
            zametki.Name = "zametki";
            zametki.ScrollBars = ScrollBars.Vertical;
            zametki.Size = new Size(865, 210);
            zametki.TabIndex = 17;
            zametki.Text = "Заметки";
            // 
            // R_btn
            // 
            R_btn.Location = new Point(9, 8);
            R_btn.Name = "R_btn";
            R_btn.Size = new Size(22, 23);
            R_btn.TabIndex = 18;
            R_btn.Text = "R";
            R_btn.UseVisualStyleBackColor = true;
            R_btn.Click += R_btn_Click;
            // 
            // panelSwaps
            // 
            panelSwaps.Location = new Point(140, 237);
            panelSwaps.Name = "panelSwaps";
            panelSwaps.Size = new Size(860, 28);
            panelSwaps.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 710);
            Controls.Add(panelSwaps);
            Controls.Add(R_btn);
            Controls.Add(zametki);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(lab_power);
            Controls.Add(lab_deltaIP3);
            Controls.Add(lab_name2);
            Controls.Add(lab_koefNoise2);
            Controls.Add(lab_koefPower2);
            Controls.Add(lab_deltaKN);
            Controls.Add(panel1);
            Controls.Add(lab_IP32);
            Controls.Add(lab_IP3);
            Controls.Add(lab_koefPower);
            Controls.Add(lab_koefNoise);
            Controls.Add(lab_name);
            Controls.Add(panelNew);
            Controls.Add(panelOld);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)MTB_CascadesValue).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lab_kascadesValue;
        private Button play;
        private Panel panelOld;
        private Panel panelNew;
        private Button spawn;
        private NumericUpDown MTB_CascadesValue;
        private Label lab_name;
        private Label lab_koefNoise;
        private Label lab_koefPower;
        private Label lab_IP3;
        private Button btn_save;
        private Button btn_load;
        private Panel panel1;
        private Label lab_IP32;
        private Label lab_deltaKN;
        private Label lab_koefPower2;
        private Label lab_koefNoise2;
        private Label lab_name2;
        private Label lab_deltaIP3;
        private Panel panel2;
        private Panel panel3;
        private Label lab_power;
        private Label label1;
        private Panel panel4;
        private TextBox tb_powin;
        private Panel panel5;
        private Panel panel6;
        private TextBox tb_wide;
        private Label label2;
        private Label lab_sfdr;
        private Label label4;
        private Label label3;
        private Label lab_im3;
        private Panel panel7;
        private TextBox tb_temp;
        private Label label5;
        private TextBox zametki;
        private Button plus_btn;
        private Button R_btn;
        private Panel panelSwaps;
    }
}
