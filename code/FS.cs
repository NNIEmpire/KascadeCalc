using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cascade_calculator
{
    public class FS
    {
        public static float FindNoise(List<Cascade> ks, byte num) //даёт верный результат
        {
            float noise = ks.ElementAt(0).koefNoise;

            float chisl = 1;
            float znamen = 1;
            for (int i = 1; i <= num; i++)
            {
                chisl = ks.ElementAt(i).koefNoise - 1;
                znamen *= ks.ElementAt(i - 1).koefPower;
                noise += chisl / znamen;
            }
            return noise;
        }

        public static float FindPower(List<Cascade> ks, byte num) //даёт верный результат
        {
            float power = ks.ElementAt(0).koefPower;
            for (int i = 1; i <= num; i++)
            {
                power *= ks.ElementAt(i).koefPower;
            }
            return power;
        }

        public static float FindIP3(List<Cascade> ks, byte num) //https://www.qorvo.com/design-hub/design-tools/interactive/cascade-calculator
        {
            float ip3 = 1f / ks.ElementAt(num).IP3;
            float Gs = 1f;
            float znamen = 1f;
            for (byte i = 1; i <= num; i++)
            {
                Gs *= ks.ElementAt(num - (i - 1)).koefPower;
                znamen = ks.ElementAt(num - i).IP3;
                ip3 += 1f / (znamen * Gs);
            }

            ip3 = 1f / ip3;
            return ip3;
        }

        //public static float FindIP3(List<Cascade> ks, byte num) //https://www.calculatorultra.com/en/tool/cascaded-ip3-calculator.html#gsc.tab=0
        //{
        //    float ip3 = 1f / ks.ElementAt(0).IP3;
        //    float chisl = 1;
        //    float znamen = 1;
        //    for (int i = 1; i <= num; i++)
        //    {
        //        chisl *= ks.ElementAt(i - 1).koefPower;
        //        znamen = ks.ElementAt(i).IP3;
        //        ip3 += chisl / znamen;
        //    }
        //    ip3 = 1 / ip3;
        //    return ip3;
        //}

        public static float GetSfdr(float wide, float T, float OIP3, float kP, float kN) //https://www.everythingrf.com/rf-calculators/spurious-free-dynamic-range
        {
            double P = ToDB(GetP(wide,T));
            return (float)(0.66666d*(OIP3-(P+ kP +kN) - 30));//здесь -30 для перевода между единицами измерений ???

            double GetP(float w, float t)
            {
                return (1.38d*Math.Pow(10,-17)*w*(t+273d));
            }
        }

        public static float GetIM3(float outP, float OIP3)
        {
            return 2 * (outP-OIP3);
        }






        public static float ToDB(float number)
        {
            return 10 * MathF.Log10(number);
        }
        public static double ToDB(double number)
        {
            return 10 * Math.Log10(number);
        }

        public static float ToL(float number)
        {
            return MathF.Pow(10, number / 10);
        }
        public static double ToL(double number)
        {
            return Math.Pow(10, number / 10);
        }

        public static float FinddKN(List<Cascade> ks, byte num)
        {
            float N0 = ToDB(FindNoise(ks, (byte)(ks.Count - 1)));

            List<Cascade> temp = new List<Cascade> { };
            foreach(var k in ks)
            {
                temp.Add(new Cascade(k.number,k.name,k.dBkoefNoise,k.dBkoefPower,k.dBIP3, k.active));
            }

            temp.ElementAt(num).KNdBPlus();

            float N1 = ToDB(FindNoise(temp, (byte)(temp.Count - 1)));
            return (N1-N0)/0.1f;
        }

        public static float FinddIP3(List<Cascade> ks, byte num)//////////
        {
            float N0 = ToDB(FindIP3(ks, (byte)(ks.Count - 1)));

            List<Cascade> temp = new List<Cascade> { };
            foreach (var k in ks)
            {
                temp.Add(new Cascade(k.number, k.name, k.dBkoefNoise, k.dBkoefPower, k.dBIP3, k.active));
            }

            temp.ElementAt(num).IP3dBPlus();

            float N1 = ToDB(FindIP3(temp, (byte)(temp.Count - 1)));
            return (N1-N0) / 0.1f;
        }

        public static float FindP(List<Cascade> ks,byte num,float inP)
        {
            float newP = inP;
            for(int i = 0; i <= num; i++)
            {
                newP += ks.ElementAt(i).dBkoefPower;
            }
            return newP;
        }

        public static string fldebug(string str)
        {
            if (str == "")
            {
                return "0";
            }
            string newstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                char newc = str[i];
                if (newc == '.') { newc = ','; }
                newstr += newc;
            }
            return newstr;
        }
    }
}
