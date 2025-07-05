using Microsoft.VisualBasic.Devices;
using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cascade_calculator
{
    public partial class Form1 : Form
    {
        public static byte cutter = 2;

        public static ToolTip toolTip1 = new ToolTip();


        float inP = 0;

        float HzWide = 0;
        float Temp = 0;
        float outKN = 0;
        float outKP = 0;
        float outIP3 = 0;
        float outPower = 0;

        List<Cascade> Cascades = new List<Cascade> { };
        List<Cascade> ActiveCascades = new List<Cascade> { };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UI_Load();
        }



        private void UI_Load()
        {
            this.Size = new Size(1025, 745);
            this.Text = "Cascade Calculator";

            toolTip1.ReshowDelay = 0;
            toolTip1.InitialDelay = 0;

            MTB_CascadesValue.Maximum = 20;

            panelOld.BorderStyle = BorderStyle.Fixed3D;
            panelNew.BorderStyle = BorderStyle.Fixed3D;

            lab_name.Text = "Имя: ";
            lab_koefNoise.Text = "Коэф. шума (дБ): ";
            lab_koefPower.Text = "Коэф. усиления (дБ): ";
            lab_IP3.Text = "OIP3 (дБм): ";

            lab_name2.Text = "Имя: ";
            lab_koefNoise2.Text = "Коэф. шума (дБ): ";
            lab_koefPower2.Text = "Коэф. усиления (дБ): ";
            lab_IP32.Text = "OIP3 (дБм): ";
            lab_deltaKN.Text = "dKnS / dKn: ";
            lab_deltaIP3.Text = "dOIP3S / dOIP3: ";
            lab_power.Text = "Мощность (дБм): ";

            btn_load.Text = "Загрузить";
            btn_save.Text = "Сохранить";
        }



        private void spawn_Click(object sender, EventArgs e)
        {
            if (Cascades.Count > 0)
            {
                Warning("Вы уверены, что хотите задать новые данные?");
            }

            panelOld.Controls.Clear();
            panelNew.Controls.Clear();
            Cascades.Clear();

            for (int i = 0; i < MTB_CascadesValue.Value; i++)
            {
                Cascades.Add(new Cascade((byte)(i + 1), "имя", 0, 0, 0, true));
            }

            UpdSwappers();

            foreach (var k in Cascades)
            {
                panelOld.Controls.Add(k);
            }
        }

        private void play_Click(object sender, EventArgs e)
        {
            UpdCascades();

            HzWide = float.Parse(FS.fldebug(tb_wide.Text));
            Temp = float.Parse(FS.fldebug(tb_temp.Text));

            panelNew.Controls.Clear();
            for (byte k = 0; k < ActiveCascades.Count; k++)
            {
                float noise = FS.ToDB(FS.FindNoise(ActiveCascades, k));
                float power = FS.ToDB(FS.FindPower(ActiveCascades, k));
                float ip3 = FS.ToDB(FS.FindIP3(ActiveCascades, k));

                float dKN = FS.FinddKN(ActiveCascades, k);
                float dIP3 = FS.FinddIP3(ActiveCascades, k);

                inP = float.Parse(FS.fldebug(tb_powin.Text));
                float pow = FS.FindP(ActiveCascades, k, inP);

                Showcase_Cascade newSC = new Showcase_Cascade(ActiveCascades.ElementAt(k).number, ActiveCascades.ElementAt(k).name, noise, power, ip3, dKN, dIP3, pow);
                panelNew.Controls.Add(newSC);

                if (k == 0)
                {
                    newSC.BackColor = Color.LightYellow;
                }
                if (k == ActiveCascades.Count - 1)
                {
                    newSC.BackColor = Color.FromArgb(255, 205, 245, 205);

                    outKN = noise;
                    outKP = power;
                    outIP3 = ip3;
                    outPower = pow;
                }
            }

            lab_sfdr.Text = "-";
            if (ActiveCascades.Count > 0) { lab_sfdr.Text = MathF.Round(FS.GetSfdr(HzWide, Temp, outIP3, outKP, outKN), cutter).ToString(); }

            lab_im3.Text = "-";
            if (ActiveCascades.Count > 0) { lab_im3.Text = MathF.Round(FS.GetIM3(outPower, outIP3), cutter).ToString(); }

            Oformlenie();


            void Oformlenie()
            {
                float[] dKNs = new float[Cascades.Count];
                float[] dIPs = new float[Cascades.Count];
                float[] Ps = new float[Cascades.Count];

                byte i = 0;
                foreach (Showcase_Cascade sc in panelNew.Controls)
                {
                    sc.MakeTabl();
                    dKNs[i] = sc.deltaKN;
                    dIPs[i] = sc.deltaIP3;
                    Ps[i] = sc.power;
                    i++;
                }

                byte j = 0;
                foreach (Showcase_Cascade sc in panelNew.Controls)
                {
                    sc.MakeGrad(dKNs, dIPs, Ps, j);
                    j++;
                }
            }
        }

        private void UpdCascades()
        {
            Cascades.Clear();
            ActiveCascades.Clear();

            foreach (Cascade k in panelOld.Controls)
            {
                k.UpdOne();
                Cascades.Add(k);

                if (k.active){
                    ActiveCascades.Add(k);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            UpdCascades();
            MEM.Save(Cascades, zametki.Text);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            Pocket temp = MEM.Load(new Pocket(Cascades, zametki.Text));
            Cascades = temp.ks;
            zametki.Text = temp.text;

            panelOld.Controls.Clear();
            panelNew.Controls.Clear();
            panelSwaps.Controls.Clear();

            foreach (var k in Cascades)
            {
                panelOld.Controls.Add(k);
            }

            UpdSwappers();
            play.PerformClick();
        }

        private void R_btn_Click(object sender, EventArgs e)
        {
            Warning("Будет получен набор случайных каскадов");

            Random r = new Random();
            byte newKC = (byte)r.Next(1, 20);
            List<Cascade> randCs = new List<Cascade> { };
            for (int i = 0; i < newKC; i++)
            {
                randCs.Add(new Cascade((byte)(i + 1), "имя", r.Next(0, 20), r.Next(-20, 20), r.Next(-20, 20), true));
            }
            UpdateAppearance(randCs);

            play.PerformClick();
        }

        private void Warning(string text)
        {
            DialogResult result = MessageBox.Show(
                text,
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }
        }

        private void plus_btn_Click(object sender, EventArgs e)
        {
            if (panelOld.Controls.Count == 20){
                return;
            }
            
            UpdCascades();

            Cascade newC = new Cascade((byte)(GetMaxNum() + 1), "имя", 0, 0, 0, true);
            Cascades.Add(newC);

            panelOld.Controls.Add(newC);

            UpdateAppearance(Cascades);

            play.PerformClick();
        }

        private byte GetMaxNum()
        {
            byte m = 0;
            foreach(Cascade c in panelOld.Controls)
            {
                if (m < c.number) { m = c.number; }
            }
            return m;
        }

        public void Swap(List<Cascade> Cs, byte n1, byte n2)
        {
            UpdCascades();
            if(Cs.Count<=n1 || Cs.Count <= n2){
                return;
            }
            Cascade temp = Cs.ElementAt(n2);
            List<Cascade> tempCs = new List<Cascade>{ };
            for (int i = 0; i < Cs.Count; i++)
            {
                if (i == n1){
                    tempCs.Add(new Cascade((byte)(n1+1), temp.name, temp.dBkoefNoise, temp.dBkoefPower, temp.dBIP3, temp.active));
                }
                else if (i == n2){
                    tempCs.Add(new Cascade((byte)(n2+1), Cs.ElementAt(n1).name, Cs.ElementAt(n1).dBkoefNoise, Cs.ElementAt(n1).dBkoefPower, Cs.ElementAt(n1).dBIP3, Cs.ElementAt(n1).active));
                }
                else{
                    tempCs.Add(Cs.ElementAt(i));
                }
            }
            Cs = tempCs;

            UpdateAppearance(Cs);
            play.PerformClick();
        }

        private void UpdateAppearance(List<Cascade> Cs)
        {
            MEM.SaveAuto(Cs, zametki.Text);

            Pocket temp = MEM.LoadAuto(new Pocket(Cascades, zametki.Text));
            Cascades = temp.ks;
            zametki.Text = temp.text;

            panelOld.Controls.Clear();
            panelNew.Controls.Clear();
            panelSwaps.Controls.Clear();
            foreach (var k in Cascades)
            {
                panelOld.Controls.Add(k);
            }
            UpdSwappers();

            File.Delete("tempfile.txt");
        }

        private void UpdSwappers()
        {
            for (int i = 0; i < Cascades.Count - 1; i++)
            {
                swapper ns = new swapper((byte)(i + 1));
                panelSwaps.Controls.Add(ns);
                ns.Click += (sender, e) =>
                {
                    Swap(Cascades, (byte)(ns.number - 1), (byte)(ns.number));
                };
            }
        }
    }
}
