using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConf
{
    class TplConfigcs
    {
        public void Test()
        {
            //BEGIN_TPL
            {
                double sumF = 99;
                for (int i = 0; i < 99999; i++)
                {
                    int a = 999;
                    float b = 999.99f;
                    float c = a * b + 99999;
                    sumF += c;
                }
            }
            //END_TPL

            //BEGIN_TPL
            {
                double sumF = 99;
                do
                {
                    sumF = (sumF * 9 + 99) / 9;
                } while (sumF < 999999);
            }
            //END_TPL

            //BEGIN_TPL
            {
                double sumF = 999;
                while (sumF < 999999)
                {
                    sumF = (sumF * 99 + 99) / 9 + sumF;
                }
            }
            //END_TPL

            //BEGIN_TPL
            {
                float sumF = 999;
                Random rnd = new Random();
                int ca = rnd.Next() % 9;
                switch (ca)
                {
                    case 1:
                        sumF += 9;
                        break;
                    case 2:
                        sumF -= 9;
                        break;
                    case 3:
                        sumF *= 9;
                        break;
                    case 4:
                        sumF /= 9;
                        break;
                    default:
                        break;
                }
                sumF = (sumF + 99) * 9;
            }
            //END_TPL

            //BEGIN_TPL
            {
                float cpn = 999.99f;
                float sumF = 99999.99f;
                int a = 99;
                int b = 999;
                int c = 9999;
                int d = 99999;
                if (cpn > 999.99)
                {
                    sumF = (((sumF - cpn) * cpn) - sumF) / 99;
                }
                else if (cpn < 999.99)
                {
                    sumF = (((sumF * cpn) - cpn) * sumF) / 99 + a / b * c / d;
                }
                else
                {
                    sumF = (((sumF + cpn) * cpn) / sumF) / 99 - a * b / c / d;
                }

            }
            //END_TPL

            //BEGIN_TPL
            {
                int[] arr = new int[] { 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999,
                9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999,
                9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999};
                arr[9] = arr[19] + arr[19];
                arr[9] = arr[19] * arr[19];
                arr[9] = arr[19] / arr[19];
                arr[9] = arr[19] - arr[19];
                arr[9] = arr[19] + arr[19];
                arr[9] = arr[19] * arr[19];
                arr[9] = arr[19] / arr[19];
                arr[9] = arr[19] - arr[19];
                arr[9] = arr[19] + arr[19];
                arr[9] = arr[19] * arr[19];
                arr[9] = arr[19] / arr[19];
                arr[9] = arr[19] - arr[19];
            }
            //END_TPL

            //BEGIN_TPL
            {
                int[] arr = new int[] { 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999,
                9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999,
                9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999};
                arr[9] = (arr[19] + arr[19] - arr[19]) * arr[19];
                arr[9] = (arr[19] + arr[19] - arr[19]) * arr[19];
                arr[9] = (arr[19] + arr[19] - arr[19]) * arr[19];
                arr[9] = (arr[19] + arr[19] - arr[19]) * arr[19];
                arr[9] = (arr[19] + arr[19] - arr[19]) * arr[19];
                arr[9] = (arr[19] + arr[19] - arr[19]) * arr[19];
            }
            //END_TPL
        }
    }
}
