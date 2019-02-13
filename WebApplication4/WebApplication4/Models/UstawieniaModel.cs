using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;

namespace WebApplication4.Models
{
    public class UstawieniaModel
    {

      public  List<Wykres> ustawienia = null;
      public List<Wykres_m> ustawienia_m = null;
        public class Wykres
        {
          
         
          public float podzialka_x { get; set; }
          public float podzialka_y { get; set; }
          public float zakres_wykresuX { get; set; }
          public float zakres_wykresuY { get; set; }
          public float najwieksza_x { get; set; }
          public float najmniejsza_x { get; set; }
          public float najwieksza_y { get; set; }
          public float najmniejsza_y { get; set; }
          public int pik_mapa { get; set; }
        }

        public class Wykres_m
        {
            public float podzialka_x { get; set; }
            public float podzialka_y { get; set; }
        }

       

        public UstawieniaModel()
        {
            ustawienia = new List<Wykres>();
            ustawienia_m = new List<Wykres_m>();
            
        }
       
       

        public void ustaw(WykresModel wykres)
        {
            Wykres ustawienia_wykresu = new Wykres();
            

            float najmniejszaWartosc_y = wykres.get_y(0);
            float najwiekszaWartosc_y = wykres.get_y(0);

            float najmniejszaWartosc_x = wykres.get_x(0);
            float najwiekszaWartosc_x = wykres.get_x(0);
           
           
            for(int i = 0;i<wykres.punkty.Count ;i++ )
               {
                if (wykres.get_y(i) > najwiekszaWartosc_y)
                { najwiekszaWartosc_y = wykres.get_y(i);
                   ustawienia_wykresu.pik_mapa = i;
                }

                if (wykres.get_y(i) < najmniejszaWartosc_y)
                { najmniejszaWartosc_y = wykres.get_y(i);
                }
                
                }
              

                for (int i = 0; i < wykres.punkty.Count; i++)
                {
                    if (wykres.get_x(i) > najwiekszaWartosc_x)
                {najwiekszaWartosc_x = wykres.get_x(i); }
                        

                    if (wykres.get_x(i) < najmniejszaWartosc_x)
                { najmniejszaWartosc_x = wykres.get_x(i);}
                        
                }
                ustawienia_wykresu.najmniejsza_x = najmniejszaWartosc_x;
                ustawienia_wykresu.najwieksza_x = najwiekszaWartosc_x;
                ustawienia_wykresu.podzialka_x = (najwiekszaWartosc_x - najmniejszaWartosc_x) / 16;
                ustawienia_wykresu.zakres_wykresuX = najwiekszaWartosc_x - najmniejszaWartosc_x;

            ustawienia_wykresu.zakres_wykresuY = najwiekszaWartosc_y - najmniejszaWartosc_y;
            ustawienia_wykresu.najmniejsza_y = najmniejszaWartosc_y;
            ustawienia_wykresu.najwieksza_y = najwiekszaWartosc_y;
            ustawienia_wykresu.podzialka_y = (najwiekszaWartosc_y - najmniejszaWartosc_y) / 18;


            ustawienia.Add(ustawienia_wykresu);


        }
        public void ustaw(MapaModel mapa)
        {
            Wykres_m ustawienia_wykresu = new Wykres_m();


            for (int i = 0; i < mapa.punkty.Count; i++)
            {
                if (mapa.get_y(i) > mapa.get_y(0))
                {
                ustawienia_wykresu.podzialka_y = Math.Abs(20 * (Math.Abs(mapa.get_y(i)) - Math.Abs(mapa.get_y(0))));
                break;}


                if (mapa.get_y(i) < mapa.get_y(0))
                {
                ustawienia_wykresu.podzialka_y = Math.Abs(20 * (Math.Abs(mapa.get_y(0)) - Math.Abs(mapa.get_y(i))));
                break;
                }

            }

            for (int i = 0; i < mapa.punkty.Count; i++)
            {
                if (mapa.get_x(i) > mapa.get_x(0))
                {
                    ustawienia_wykresu.podzialka_x = Math.Abs(20 * (Math.Abs(mapa.get_x(i)) - Math.Abs(mapa.get_x(0))));
                    break;
                }


                if (mapa.get_x(i) < mapa.get_x(0))
                {
                    ustawienia_wykresu.podzialka_x = Math.Abs(20 * (Math.Abs(mapa.get_x(0)) - Math.Abs(mapa.get_x(i))));
                    break;
                }

            }


            ustawienia_m.Add(ustawienia_wykresu);

        }

     

    }
}