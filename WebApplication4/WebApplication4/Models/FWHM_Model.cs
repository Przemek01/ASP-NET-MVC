using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{



    public class FWHM_Model
    {
        public class aproksymacja_gaussa
        {
            public double Ey2 { get; set; }
            public double Exy2 { get; set; }
            public double Ex2y2 { get; set; }
            public double Ex3y2 { get; set; }
            public double Ex4y2 { get; set; }
            public double Elny2 { get; set; }
            public double Exlny2 { get; set; }
            public double Ex2lny2 { get; set; }
            public double detA { get; set; }
            public double detA1 { get; set; }
            public double detA2 { get; set; }
            public double detA3 { get; set; }
            public double a { get; set; }
            public double b { get; set; }
            public double c { get; set; }

            public double mikro { get; set; }
            public double kond { get; set; }
            public double A { get; set; }

            public double FWHM { get; set; }

            public aproksymacja_gaussa()
            {
                Ey2 = Exy2 = Ex2y2 = Ex3y2 = Ex4y2 = Elny2 = Exlny2 =
                Ex2lny2 = detA = detA1 = detA2 = detA3 = a = b = c= FWHM = 0;
            }
            public double fitting(WykresModel dane, UstawieniaModel.Wykres ustawienia)
            {

                Macierz macierz = new Macierz();
                
                int index = ustawienia.pik_mapa;
                bool _1000_p = false;
                bool _1000_m = false;

                for (int i = 0; i < dane.punkty.Count - 1; i++)
                {
                    
                    double y = (double)dane.get_y(index);
                    double y2 = Math.Pow((double)dane.get_y(index) , 2);

                    if (i == 0)
                    {
                        Ey2 += y2;
                        Elny2 += y2 * Math.Log(y);

                    }
                    else
                    {
                        double yminus = (double)dane.get_y(index - i);
                        double yplus = (double)dane.get_y(index + i);
                        double y2minus = Math.Pow((double)dane.get_y(index - i) , 2);
                        double y2plus = Math.Pow((double)dane.get_y(index + i) , 2);
                        double xminus = (double)dane.get_x(index - i) - dane.get_x(index);
                        double xplus = (double)dane.get_x(index + i) - dane.get_x(index);
                        if (yminus > 1000)
                        {
                            Ey2 += y2minus;
                            Exy2 += xminus * y2minus;
                            Ex2y2 += Math.Pow(xminus, 2) * y2minus;
                            Ex3y2 += Math.Pow(xminus, 3) * y2minus;
                            Ex4y2 += Math.Pow(xminus, 4) * y2minus;
                            Elny2 += Math.Log(yminus) * y2minus;
                            Exlny2 += xminus * Math.Log(yminus) * y2minus;
                            Ex2lny2 += Math.Pow(xminus, 2) * Math.Log(yminus) * y2minus;
                        }
                        else { _1000_m = true; }

                        if (yplus > 1000)
                        {
                            Ey2 += y2plus;
                            Exy2 += xplus * y2plus;
                            Ex2y2 += Math.Pow(xplus, 2) * y2plus;
                            Ex3y2 += Math.Pow(xplus, 3) * y2plus;
                            Ex4y2 += Math.Pow(xplus, 4) * y2plus;
                            Elny2 += Math.Log(yplus) * y2plus;
                            Exlny2 += xplus * Math.Log(yplus) * y2plus;
                            Ex2lny2 += Math.Pow(xplus, 2) * Math.Log(yplus) * y2plus;
                        }
                        else { _1000_p = true; }


                    }

                    if (_1000_m == true && _1000_p == true)
                        break;
                }
                double[,] nowa_macierz = new double[,] { { Ey2,  Exy2,  Ex2y2 },
                                                         { Exy2, Ex2y2, Ex3y2 },
                                                         { Ex2y2,Ex3y2, Ex4y2 } };

                detA = macierz.oblicz(nowa_macierz);

                double[,] nowa_macierz1 = new double[,] { { Elny2,  Exy2,  Ex2y2 },
                                                          { Exlny2, Ex2y2, Ex3y2 },
                                                          { Ex2lny2,Ex3y2, Ex4y2 } };

                detA1 = macierz.oblicz(nowa_macierz1);

                nowa_macierz = new double[,] { { Ey2,  Elny2,  Ex2y2 },
                                               { Exy2, Exlny2, Ex3y2 },
                                               { Ex2y2,Ex2lny2, Ex4y2 } };

                detA2 = macierz.oblicz(nowa_macierz);

                nowa_macierz = new double[,] { { Ey2,  Exy2,  Elny2 },
                                               { Exy2, Ex2y2, Exlny2 },
                                               { Ex2y2,Ex3y2, Ex2lny2 } };

                detA3 = macierz.oblicz(nowa_macierz);

                a = detA1 / detA;
                b = detA2 / detA;
                c = detA3 / detA;
                mikro = -b / (2 * c);
                kond = Math.Sqrt(-1 / (2 * c));
                A = Math.Exp(a - (b * b) / (4 * c));
                FWHM = 2 * Math.Sqrt(2 * Math.Log(2)) * kond;
                if(c<0 && c> -2)
                return A;

                return 0;
            }


        }
        public class Macierz
        {
            double[,] tmacierz;



            double wyznacznik;


            public double oblicz(double[,] macierz)
            {
                tmacierz = macierz;

                wyznacznik = tmacierz[0, 0] * tmacierz[1, 1] * tmacierz[2, 2]
                           + tmacierz[0, 1] * tmacierz[1, 2] * tmacierz[2, 0]
                           + tmacierz[0, 2] * tmacierz[1, 0] * tmacierz[2, 1]
                           - tmacierz[2, 0] * tmacierz[1, 1] * tmacierz[0, 2]
                           - tmacierz[2, 1] * tmacierz[1, 2] * tmacierz[0, 0]
                           - tmacierz[2, 2] * tmacierz[1, 0] * tmacierz[0, 1];
                

                return wyznacznik;
            }

            public Macierz()
            {
                tmacierz = new double[3, 3];
                wyznacznik = 0;
            }
            
        }

    }



}