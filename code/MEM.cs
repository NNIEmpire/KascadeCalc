using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cascade_calculator
{
    class MEM
    {

        public static void Save(List<Cascade> ks, string text)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Cascades Data";
            saveFileDialog.DefaultExt = "SaveName";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.WriteLine(text);
                        writer.WriteLine("zametki");

                        foreach (Cascade k in ks)
                        {
                            writer.WriteLine(k.number);
                            writer.WriteLine(k.name);
                            
                            writer.WriteLine(k.dBkoefNoise);
                            writer.WriteLine(k.dBkoefPower);
                            writer.WriteLine(k.dBIP3);
                            if (k.active){
                                writer.WriteLine(bool.TrueString);
                            }
                            if (!k.active){
                                writer.WriteLine(bool.FalseString);
                            }
                            writer.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void SaveAuto(List<Cascade> ks, string text)
        {

            using (StreamWriter writer = new StreamWriter("tempfile.txt"))
            {
                writer.WriteLine(text);
                writer.WriteLine("zametki");

                foreach (Cascade k in ks)
                {
                    writer.WriteLine(k.number);
                    writer.WriteLine(k.name);
                    writer.WriteLine(k.dBkoefNoise);
                    writer.WriteLine(k.dBkoefPower);
                    writer.WriteLine(k.dBIP3);
                    if (k.active)
                    {
                        writer.WriteLine(bool.TrueString);
                    }
                    if (!k.active)
                    {
                        writer.WriteLine(bool.FalseString);
                    }
                    writer.WriteLine();
                }
            }

        }

        public static Pocket Load(Pocket pO)
        {
            string temppp = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Load Cascade Data";
            openFileDialog.DefaultExt = "LoadName";
            openFileDialog.CheckFileExists = true;

            Pocket p = new Pocket();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                try
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        string line;
                        List<Cascade> newKs = new List<Cascade>();
                        string text = "";

                        while ((line = reader.ReadLine()) != "zametki")
                        {
                            text += line;
                            text += "\r\n";
                        }

                        while ((line = reader.ReadLine()) != null)
                        {
                            byte number = 0;
                            string name = "";
                            if (temppp == ""){
                                number = byte.Parse(line);
                                name = reader.ReadLine();
                            }
                            else{
                                number = byte.Parse(temppp);
                                name = line;
                            }

                            float kN = float.Parse(reader.ReadLine());
                            float kP = float.Parse(reader.ReadLine());
                            float IP3 = float.Parse(reader.ReadLine());
                            bool active = bool.Parse(reader.ReadLine());
                            temppp = reader.ReadLine();

                            newKs.Add(new Cascade(number, name, kN, kP, IP3, active)); //добавить сохраняемость неактивных
                        }
                        p.ks = newKs;
                        p.text = text;
                        return p;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new Pocket();
                }
            }
            else
            {
                return pO; // Если пользователь отменил выбор файла
            }
        }

        public static Pocket LoadAuto(Pocket pO)
        {
            string temppp = "";

            Pocket p = new Pocket();

            using (StreamReader reader = new StreamReader("tempfile.txt"))
            {
                string line;
                List<Cascade> newKs = new List<Cascade>();
                string text = "";

                while ((line = reader.ReadLine()) != "zametki")
                {
                    text += line;
                    text += "\r\n";
                }

                while ((line = reader.ReadLine()) != null)
                {
                    byte number = 0;
                    string name = "";
                    if (temppp == "")
                    {
                        number = byte.Parse(line);
                        name = reader.ReadLine();
                    }
                    else
                    {
                        number = byte.Parse(temppp);
                        name = line;
                    }

                    float kN = float.Parse(reader.ReadLine());
                    float kP = float.Parse(reader.ReadLine());
                    float IP3 = float.Parse(reader.ReadLine());
                    bool active = bool.Parse(reader.ReadLine());
                    temppp = reader.ReadLine();

                    newKs.Add(new Cascade(number, name, kN, kP, IP3, active)); //добавить сохраняемость неактивных
                }
                p.ks = newKs;
                p.text = text;

                return p;
            }
        }
    }

    public class Pocket
    {
        public List<Cascade> ks = new List<Cascade> { };
        public string text = "";

        public Pocket(List<Cascade> cs,string s)
        {
            this.ks = cs;
            this.text = s;
        }
        public Pocket() { }
    }
}
