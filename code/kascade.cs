using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace cascade_calculator
{
    public class Cascade : GroupBox
    {
        public byte number = 1;
        public bool active = true;

        public string name = "";

        public float koefNoise = 0;
        public float koefPower = 0;
        public float IP3 = 0;

        public float dBkoefNoise = 0;
        public float dBkoefPower = 0;
        public float dBIP3 = 0;

        public static Size boxSize = new Size(42, 150);
        public static int hold = 1;

        TextBox tb_name = new TextBox();
        TextBox tb_koefNoise = new TextBox();
        TextBox tb_koefPower = new TextBox();
        TextBox tb_IP3 = new TextBox();

        Button delete = new Button();
        Button live = new Button();

        Panel shield = new Panel();

        public Cascade(byte number, string name, float koefNoise, float koefPower, float IP3, bool active) 
        {
            this.active = active;


            this.number = number;
            this.name = name;


            this.dBkoefNoise = koefNoise; 
            this.dBkoefPower = koefPower;
            this.dBIP3 = IP3;

            this.koefNoise = FS.ToL(dBkoefNoise);
            this.koefPower = FS.ToL(dBkoefPower);
            this.IP3 = FS.ToL(dBIP3);


            Text = number.ToString();
            Size = boxSize;
            Location = new Point(hold + (number-1)*(boxSize.Width + hold),0);

            tb_name.Text = name;
            tb_koefNoise.Text = (dBkoefNoise).ToString();
            tb_koefPower.Text = (dBkoefPower).ToString();
            tb_IP3.Text = (dBIP3).ToString();

            tb_name.Location = new Point(0, 25 * 1-3);
            tb_koefNoise.Location = new Point(0, 25 * 2-3);
            tb_koefPower.Location = new Point(0, 25 * 3-3);
            tb_IP3.Location = new Point(0, 25 * 4-3);

            tb_name.Width = boxSize.Width;
            tb_koefNoise.Width = boxSize.Width;
            tb_koefPower.Width = boxSize.Width;
            tb_IP3.Width = boxSize.Width;

            Controls.Add(tb_name);
            Controls.Add(tb_koefNoise);
            Controls.Add(tb_koefPower);
            Controls.Add(tb_IP3);



            delete.Location = new Point(0, 25 * 5 - 3);
            delete.Size = new Size(boxSize.Width/2, 24);
            delete.Text = "–";

            Controls.Add(delete);

            delete.Click += (sender, e) =>
            {
                MakeUnActive();
            };

            live.Location = new Point(boxSize.Width / 2, 25 * 5 - 3);
            live.Size = new Size(boxSize.Width / 2, 24);
            live.Text = "+";

            live.Visible = false;
            Controls.Add(live);

            live.Click += (sender, e) =>
            {
                MakeActive();
            };

            shield.BackColor = Color.FromArgb(200, 150, 150, 150);
            shield.Size = this.Size;
            shield.Location = new Point(0, 0);
            shield.Visible = false;
            Controls.Add(shield);

            if (!active)
            {
                MakeUnActive();
            }
        }




        public void UpdOne()
        {

            if (!active)
            {
                return;
            }

            this.number = byte.Parse(Text);
            this.name = tb_name.Text;

            this.dBkoefNoise = float.Parse(FS.fldebug(tb_koefNoise.Text));
            this.dBkoefPower = float.Parse(FS.fldebug(tb_koefPower.Text));
            this.dBIP3 = float.Parse(FS.fldebug(tb_IP3.Text));

            this.koefNoise = FS.ToL(dBkoefNoise);
            this.koefPower = FS.ToL(dBkoefPower);
            this.IP3 = FS.ToL(dBIP3);
        } //вносит значения из ячеек

        //public Showcase_Cascade SC_Copy()
        //{
        //    UpdOne();
        //    return new Showcase_Cascade(this.number,this.name,this.dBkoefNoise,this.dBkoefPower,this.dBIP3,0,this.Location);
        //}

        public void KNPlus()
        {
            this.koefNoise += 0.1f;
            this.dBkoefNoise = FS.ToDB(koefNoise);
        }
        public void KNdBPlus()
        {
            this.dBkoefNoise += 0.1f;
            this.koefNoise = FS.ToL(dBkoefNoise);
        }

        public void IP3Plus()
        {
            this.IP3 += 0.1f;
            this.dBIP3 = FS.ToDB(koefNoise);
        }
        public void IP3dBPlus()
        {
            this.dBIP3 += 0.1f;
            this.IP3 = FS.ToL(dBIP3);
        }


        public void MakeActive() 
        {
            active = true;
            live.Visible = false;
            delete.Visible = true;

            shield.Visible = false;
            tb_name.BackColor = SystemColors.Window;
            tb_koefPower.BackColor = SystemColors.Window;
            tb_koefNoise.BackColor = SystemColors.Window;
            tb_IP3.BackColor = SystemColors.Window;

            tb_name.BorderStyle = BorderStyle.Fixed3D;
            tb_koefPower.BorderStyle = BorderStyle.Fixed3D;
            tb_koefNoise.BorderStyle = BorderStyle.Fixed3D;
            tb_IP3.BorderStyle = BorderStyle.Fixed3D;
        }

        public void MakeUnActive()
        {
            active = false;
            delete.Visible = false;
            live.Visible = true;

            shield.Visible = true;
            tb_name.BackColor = SystemColors.ControlDark;
            tb_koefPower.BackColor = SystemColors.ControlDark;
            tb_koefNoise.BackColor = SystemColors.ControlDark;
            tb_IP3.BackColor = SystemColors.ControlDark;

            tb_name.BorderStyle = BorderStyle.None;
            tb_koefPower.BorderStyle = BorderStyle.None;
            tb_koefNoise.BorderStyle = BorderStyle.None;
            tb_IP3.BorderStyle = BorderStyle.None;
        }
    }








    public class Showcase_Cascade : GroupBox
    {
        public byte number = 1;

        public string name = "";
        public float koefNoise = 0;
        public float koefPower = 0;
        public float IP3 = 0;
        public float deltaKN = 0;
        public float deltaIP3 = 0;
        public float power = 0;

        Label out_name = new Label();
        Label out_koefNoise = new Label();
        Label out_koefPower = new Label();
        Label out_IP3 = new Label();

        Label out_deltaKN = new Label();
        Label out_deltaIP3 = new Label();

        Label out_power = new Label();

        public Showcase_Cascade() { }

        public Showcase_Cascade(byte number, string name, float koefNoise, float koefPower, float IP3, float deltaKN, float deltaIP3,float power)
        {
            this.number = number;
            this.name = name;
            this.koefNoise = koefNoise;
            this.koefPower = koefPower;
            this.IP3 = IP3;
            this.deltaKN = deltaKN;
            this.deltaIP3 = deltaIP3;
            this.power = power;

            Text = number.ToString();
            Size = Cascade.boxSize+new Size(0,50);
            Location = new Point(Cascade.hold + (number - 1) * (Cascade.boxSize.Width + Cascade.hold), 0);

            out_name.Text = name;
            out_koefNoise.Text = MathF.Round(koefNoise, Form1.cutter).ToString();
            out_koefPower.Text = MathF.Round(koefPower, Form1.cutter).ToString();
            out_IP3.Text = MathF.Round(IP3, Form1.cutter).ToString();
            out_deltaKN.Text = MathF.Round(deltaKN, Form1.cutter).ToString();
            out_deltaIP3.Text = MathF.Round(deltaIP3, Form1.cutter).ToString();
            out_power.Text = MathF.Round(power, Form1.cutter).ToString();

            out_name.Width = Cascade.boxSize.Width;
            out_koefNoise.Width = Cascade.boxSize.Width;
            out_koefPower.Width = Cascade.boxSize.Width;
            out_IP3.Width = Cascade.boxSize.Width;
            out_deltaKN.Width = Cascade.boxSize.Width;
            out_deltaIP3.Width = Cascade.boxSize.Width;
            out_power.Width = Cascade.boxSize.Width;

            out_name.TextAlign = ContentAlignment.MiddleCenter;
            out_koefNoise.TextAlign = ContentAlignment.MiddleCenter;
            out_koefPower.TextAlign = ContentAlignment.MiddleCenter;
            out_IP3.TextAlign = ContentAlignment.MiddleCenter;
            out_deltaKN.TextAlign = ContentAlignment.MiddleCenter;
            out_deltaIP3.TextAlign = ContentAlignment.MiddleCenter;
            out_power.TextAlign = ContentAlignment.MiddleCenter;

            out_name.Location = new Point(0, 25 * 1 - 3);
            out_koefNoise.Location = new Point(0, 25 * 2 - 3);
            out_koefPower.Location = new Point(0, 25 * 3 - 3);
            out_IP3.Location = new Point(0, 25 * 4 - 3);
            out_deltaKN.Location = new Point(0, 25 * 5 - 3);
            out_deltaIP3.Location = new Point(0, 25 * 6 - 3);
            out_power.Location = new Point(0, 25 * 7 - 3);

            Controls.Add(out_name);
            Controls.Add(out_koefNoise);
            Controls.Add(out_koefPower);
            Controls.Add(out_IP3);
            Controls.Add(out_deltaKN);
            Controls.Add(out_deltaIP3);
            Controls.Add(out_power);

            out_name.MouseHover += (sender, e) =>
            {
                Form1.toolTip1.SetToolTip(out_name, out_name.Text);
            };
        }

        public void MakeTabl()
        {
            out_koefNoise.BackColor = GetDarker(out_koefNoise.BackColor);

            out_IP3.BackColor = GetDarker(out_IP3.BackColor);

            out_deltaIP3.BackColor = GetDarker(out_deltaIP3.BackColor);

            Color GetDarker(Color c)
            {
                Color nc;

                Vector3 temp = new Vector3((float)((float)(c.R) * (230.0 / 255.0)), (float)((float)(c.G) * (230.0 / 255.0)), (float)((float)(c.B) * (230.0 / 255.0)));

                nc = Color.FromArgb(255, (byte)temp.X, (byte)temp.Y, (byte)temp.Z);
                return nc;
            }
        }

        public void MakeGrad(float[] dKNs, float[] dIPs, float[] Ps, byte num)
        {
            float maxdKN = dKNs.Max();
            float maxdIP = dIPs.Max();
            float maxP = Ps.Max();

            float mindKN = dKNs.Min();
            float mindIP = dIPs.Min();
            float minP = Ps.Min();

            float ourkn = (dKNs[num]- mindKN +0.0001f)/(maxdKN- mindKN + 0.0001f);
            float ourip = (dIPs[num]-mindIP +0.0001f)/(maxdIP-mindIP+ 0.0001f);
            float ourp = (Ps[num]-minP + 0.0001f) /( maxP - minP + 0.0001f);

            out_deltaKN.BackColor = GetGraderR(ourkn);
            out_deltaIP3.BackColor = GetGraderB(ourip);
            out_power.BackColor = GetGraderG(ourp);

            Color GetGraderR(float k)
            {
                Color nc = Color.FromArgb(255, (byte)(255), (byte)(255-k*120), (byte)(255 - k * 120));
                return nc;
            }
            Color GetGraderB(float k)
            {
                Color nc = Color.FromArgb(255, (byte)(255 - k * 120), (byte)(255 - k * 120), (byte)255);
                return nc;
            }
            Color GetGraderG(float k)
            {
                Color nc = Color.FromArgb(255,(byte)(255-k*60), (byte)(255 - k * 100), (byte)(255));
                return nc;
            }
        }
    }
}
