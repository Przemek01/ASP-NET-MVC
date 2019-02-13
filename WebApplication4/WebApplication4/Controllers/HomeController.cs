using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using WebApplication4.Models;
using System.Globalization;
namespace WebApplication4.Controllers
{

    public class HomeController : Controller
    {
        static WykresModel DANE = new WykresModel();
        static int numer_wykresu = 1;
        static bool szerokosc_FWHM = false;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string wczytaj)
        {
            DANE = Odczyt_danych_z_pliku(wczytaj);
            return View();
        }

        public ActionResult MapaWidok()
        {
            szerokosc_FWHM = false;
            return View();
        }


        public ActionResult nastepny()
        {
            if(numer_wykresu<DANE.Iterator.Count-1)
            {
                numer_wykresu++;
            }
            return View("WykresWidok");
        }

        public ActionResult poprzedni()
        {
            if (numer_wykresu > 1)
            {
                numer_wykresu--;
            }
            return View("WykresWidok");
        }

        public ActionResult WykresWidok()
        {
            return View();
        }

        public ActionResult MapaFWHMWidok()
        {
            szerokosc_FWHM = true;
            return View();
        }

    

        public ActionResult WykresLiniowy()
        {
            FileContentResult result;
            result = RysujWykresLiniowy(860, 450);
            return result;
        }
        public ActionResult Mapa()
        {
            FileContentResult result;
            result = RysujMape(900, 900);
            return result;
        }

        public ActionResult Legenda()
        {
            FileContentResult result;
            result = RysujLegende(770, 100);
            return result;
        }

        private FileContentResult RysujLegende(int bitMapW, int bitMapH)
        {
            Bitmap bitMap = new Bitmap(bitMapW, bitMapH);
            Graphics g = Graphics.FromImage(bitMap);
            g.Clear(Color.White);
            Font f3 = new Font("Arial", 11);

            if(szerokosc_FWHM)
            {
                Brush brush = new SolidBrush(Color.Violet);
                Rectangle rect = new Rectangle(0, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("<1 [nm]", f3, Brushes.Black, 60, 0);

                brush = new SolidBrush(Color.DarkViolet);
                rect = new Rectangle(0, 40, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("1-1.5 [nm]", f3, Brushes.Black, 60, 40);

                brush = new SolidBrush(Color.Blue);
                rect = new Rectangle(0, 80, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("1.5-2 [nm]", f3, Brushes.Black, 60, 80);

                brush = new SolidBrush(Color.Aquamarine);
                rect = new Rectangle(180, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("2-2.5 [nm]", f3, Brushes.Black, 240, 0);

                brush = new SolidBrush(Color.Green);
                rect = new Rectangle(180, 40, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("2.5-3 [nm]", f3, Brushes.Black, 240, 40);

                brush = new SolidBrush(Color.Orange);
                rect = new Rectangle(180, 80, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("3-3.5 [nm]", f3, Brushes.Black, 240, 80);

                brush = new SolidBrush(Color.Yellow);
                rect = new Rectangle(360, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("3.5-4 [nm]", f3, Brushes.Black, 420, 0);

                brush = new SolidBrush(Color.Brown);
                rect = new Rectangle(360, 40, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("4-4.5 [nm]", f3, Brushes.Black, 420, 40);

                brush = new SolidBrush(Color.Red);
                rect = new Rectangle(360, 80, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString(">4.5 [nm]", f3, Brushes.Black, 420, 80);

                brush = new SolidBrush(Color.Gray);
                rect = new Rectangle(540, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("brak", f3, Brushes.Black, 620, 0);

            }
            else
            {
                Brush brush = new SolidBrush(Color.Violet);
                Rectangle rect = new Rectangle(0, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("<362.3 [nm]", f3, Brushes.Black, 60, 0);

                brush = new SolidBrush(Color.DarkViolet);
                rect = new Rectangle(0, 40, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.3-362.4 [nm]", f3, Brushes.Black, 60, 40);

                brush = new SolidBrush(Color.Blue);
                rect = new Rectangle(0, 80, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.4-362.5 [nm]", f3, Brushes.Black, 60, 80);

                brush = new SolidBrush(Color.Aquamarine);
                rect = new Rectangle(180, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.5-362.6 [nm]", f3, Brushes.Black, 240, 0);

                brush = new SolidBrush(Color.Green);
                rect = new Rectangle(180, 40, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.6-362.7 [nm]", f3, Brushes.Black, 240, 40);

                brush = new SolidBrush(Color.Orange);
                rect = new Rectangle(180, 80, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.7-362.8 [nm]", f3, Brushes.Black, 240, 80);

                brush = new SolidBrush(Color.Yellow);
                rect = new Rectangle(360, 0, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.8-362.9 [nm]", f3, Brushes.Black, 420, 0);

                brush = new SolidBrush(Color.Brown);
                rect = new Rectangle(360, 40, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString("362.9-363 [nm]", f3, Brushes.Black, 420, 40);

                brush = new SolidBrush(Color.Red);
                rect = new Rectangle(360, 80, 60, 20);
                g.FillRectangle(brush, rect);
                g.DrawString(">363 [nm]", f3, Brushes.Black, 420, 80);


            }


            MemoryStream memStream = new MemoryStream();
            bitMap.Save(memStream, ImageFormat.Png);
            return File(memStream.GetBuffer(), "image/png"); ;
        }

        private FileContentResult RysujWykresLiniowy(int bitMapW, int bitMapH)
        {

            WykresModel wykres = DANE.pokaz_wykres_L(numer_wykresu);
            FWHM_Model.aproksymacja_gaussa gauss = new FWHM_Model.aproksymacja_gaussa();
            
            UstawieniaModel Ustawienia_wykresu = new UstawieniaModel();
        
            Ustawienia_wykresu.ustaw(wykres);

            UstawieniaModel.Wykres ustaw = Ustawienia_wykresu.ustawienia[0];
            double q =  gauss.fitting(wykres, ustaw);
            wykres.Skaluj(ustaw);
            
           
            
            string szerokosc = "FWHM =" + q.ToString("0.000") + "[nm]";
            string W = "Wykres" + numer_wykresu + "z" + (DANE.Iterator.Count-1).ToString();





            Bitmap bitMap = new Bitmap(bitMapW, bitMapH);
            Graphics g = Graphics.FromImage(bitMap);
            g.Clear(Color.Black);


            
            Font f3 = new Font("Arial", 9);
            Font f4 = new Font("Arial", 13);

            g.RotateTransform(270);
            g.DrawString("Intensywność PL.", f3, Brushes.White, bitMap.Height * -1 + 150, 4);
            g.ResetTransform();

            g.DrawString(szerokosc, f4, Brushes.Red, 25, 5);
            g.DrawString(W, f4, Brushes.Red, 700, 5);

            g.DrawString("Lambda[nm]", f3, Brushes.White, 400, 430);

            g.DrawLine(Pens.White, new Point(60,40), new Point(60,400));
            g.DrawLine(Pens.White, new Point(60, 400), new Point(820, 400));

            float OD = ustaw.najwieksza_y;
            float DO = ustaw.najmniejsza_y;
            float podzialka = ustaw.podzialka_y;
            for (float y = 0, skala_y = OD; skala_y>=DO-1;y +=20, skala_y -= podzialka)
            {

                g.DrawLine(Pens.White, new Point(60, 40 + (int)y), new Point(50, 40 + (int)y));
                if(skala_y == 0)
                {
                    g.DrawString(((int)skala_y).ToString(), f3, Brushes.Silver, (float)38, 33 + y);
                }
                else if(skala_y > 1000)
                {
                    g.DrawString(((int)skala_y).ToString(), f3, Brushes.Silver, 18, 33 + y);
                }
                else
                {
                    g.DrawString(((int)skala_y).ToString(), f3, Brushes.Silver, 25, 33 + y);
                }
            }

            DO = ustaw.najwieksza_x;
            OD = ustaw.najmniejsza_x;
            podzialka = ustaw.podzialka_x;

            for (float x = 0,skala_x = OD; skala_x <= DO+1;x += (float)47.55, skala_x += podzialka)
            {
                
                g.DrawLine(Pens.White,60 + x,400,60 + x, 410);
                
                  g.DrawString(((int)skala_x).ToString(), f3, Brushes.Silver, 50 + x, 415);
                
            }
            
            for (int i = 0;i<wykres.punkty.Count-1;i++)
            {
                g.DrawLine(Pens.Green,wykres.get_x(i),wykres.get_y(i),wykres.get_x(i+1),wykres.get_y(i+1));
            }
            

            MemoryStream memStream = new MemoryStream();
            bitMap.Save(memStream, ImageFormat.Png);
            return File(memStream.GetBuffer(), "image/png"); ;
        }

        private FileContentResult RysujMape(int bitMapW, int bitMapH)
        {
            
            Bitmap bitMap = new Bitmap(bitMapW, bitMapH);
            Graphics g = Graphics.FromImage(bitMap);
            UstawieniaModel Ustawienia_wykresu = new UstawieniaModel();
            WykresModel wykres = DANE;
            WykresModel wykres2 = new WykresModel();
            MapaModel nowy_wykres = new MapaModel();
            if(szerokosc_FWHM)
            {
                for (int i = 1; i < wykres.Iterator.Count; i++)
                {
                    wykres2 = wykres.pokaz_wykres_L(i);
                    Ustawienia_wykresu.ustaw(wykres2);
                    nowy_wykres.pokaz_wykres_M(wykres, Ustawienia_wykresu, i - 1,szerokosc_FWHM);
                }
            }
            else
            {
            for (int i = 1; i < wykres.Iterator.Count; i++)
               {
                wykres2 = wykres.pokaz_wykres_L(i);
                Ustawienia_wykresu.ustaw(wykres2);
                nowy_wykres.pokaz_wykres_M(wykres, Ustawienia_wykresu, i - 1,szerokosc_FWHM);
               }

            }
            Ustawienia_wykresu.ustaw(nowy_wykres);
            nowy_wykres.skaluj(Ustawienia_wykresu);


            g.Clear(Color.Black);
            Font f3 = new Font("Arial", 9);
            g.DrawLine(Pens.White, new Point(60, 40), new Point(60, 840));
            g.DrawLine(Pens.White, new Point(60, 840), new Point(860, 840));



            for (int i = 0, y = 0, skala_y = 20; i < 41; i++, y += 20, skala_y -= 1)
            {
                g.DrawLine(Pens.White, new Point(60, 40 + y), new Point(50, 40 + y));
                if (skala_y == 0)
                {
                    g.DrawString(skala_y.ToString(), f3, Brushes.Silver, 30, 33 + y);
                }
                else if (skala_y > 1000)
                {
                    g.DrawString(skala_y.ToString(), f3, Brushes.Silver, 18, 33 + y);
                }
                else
                {
                    g.DrawString(skala_y.ToString(), f3, Brushes.Silver, 25, 33 + y);
                }
            }

            for (float i = 0, x = 0, skala_x = -20; i < 41; i++, x += 20, skala_x += 1)
            {

                g.DrawLine(Pens.White, 60 + x, 840, 60 + x, 850);

                g.DrawString(skala_x.ToString(), f3, Brushes.Silver, 50 + x, 855);

            }


            int marginesX = 60;
            int marginesY = 80;
            int bitmapWith = 900;
          
            
            for (int i =0;i<nowy_wykres.punkty.Count ;i++ )
            {
          
            Rectangle rect2 = new Rectangle((marginesX)+ (int)nowy_wykres.get_x(i), (bitmapWith - marginesY)- (int)nowy_wykres.get_y(i), 20, 20);
            Brush brush = new SolidBrush(nowy_wykres.get_color(i));
            g.FillRectangle(brush, rect2);

            }
            


             
            MemoryStream memStream = new MemoryStream();
            bitMap.Save(memStream, ImageFormat.Png);
            return File(memStream.GetBuffer(), "image/png"); ;

        }

  

         private WykresModel Odczyt_danych_z_pliku(string sciezka)
        {

            WykresModel punkty =new WykresModel();
            string[] lines = System.IO.File.ReadAllLines(@"D:\" + sciezka);
            int iterator_L = 0;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.NumberGroupSizes = new int[] { 1 };
            foreach (string line in lines)
            {
                if(line == "#####")
                {
                    continue;
                    
                }
                else if (line == "$$$$$")
                {
                    punkty.Add_L(iterator_L);
                    continue;
                    
                }
                else
                {
                   string[] s = line.Split(';');
                    punkty.Add_p(Convert.ToSingle(s[0],provider), Convert.ToSingle(s[1],provider));
                    iterator_L += 1;
                }
            }

            return punkty;
        }


    }
}