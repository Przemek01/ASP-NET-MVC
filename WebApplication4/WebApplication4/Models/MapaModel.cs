using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;

namespace WebApplication4.Models
{
    public class MapaModel
    {


       public List<Mapa> punkty = null;
        List<Color> kolor = null;
        public class Mapa
    {
            public float x { get; set; }
            public float y { get; set; }


        }
    public MapaModel()
        {
            //kwadraty = new List<Rectangle>();
            punkty = new List<Mapa>();
            kolor = new List<Color>();
        }
        public void pokaz_wykres_M(WykresModel wykres,UstawieniaModel ustawienia,int c,bool szerokosc)
        {
            UstawieniaModel.Wykres ustaw = new UstawieniaModel.Wykres();
            Mapa newMapa = new Mapa();

            if(szerokosc)
            {
                ustaw = ustawienia.ustawienia[c];
                FWHM_Model.aproksymacja_gaussa gauss = new FWHM_Model.aproksymacja_gaussa();
                double FWHM = gauss.fitting(wykres, ustaw);

                if (FWHM == 0)
                { kolor.Add(Color.Gray); }
                else if (FWHM > 0 && FWHM < 1)
                { kolor.Add(Color.Violet); }
                else if (FWHM > 1 && FWHM < 1.5)
                { kolor.Add(Color.DarkViolet); }
                else if (FWHM > 1.5 && FWHM < 2)
                { kolor.Add(Color.Blue); }
                else if (FWHM > 2 && FWHM < 2.5)
                { kolor.Add(Color.Aquamarine); }
                else if (FWHM > 2.5 && FWHM < 3)
                { kolor.Add(Color.Green); }
                else if (FWHM > 3 && FWHM < 3.5)
                { kolor.Add(Color.Orange); }
                else if (FWHM > 3.5 && FWHM < 4)
                { kolor.Add(Color.Yellow); }
                else if (FWHM > 4 && FWHM < 4.5)
                { kolor.Add(Color.Brown); }
                else if (FWHM > 4.5)
                { kolor.Add(Color.Red); }
            }
            else
            {
                ustaw = ustawienia.ustawienia[c];
                if (wykres.get_x(ustaw.pik_mapa + 1) < 362.3)
                { kolor.Add(Color.Violet); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.3 && wykres.get_x(ustaw.pik_mapa + 1) < 362.4)
                { kolor.Add(Color.DarkViolet); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.4 && wykres.get_x(ustaw.pik_mapa + 1) < 362.5)
                { kolor.Add(Color.Blue); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.5 && wykres.get_x(ustaw.pik_mapa + 1) < 362.6)
                { kolor.Add(Color.Aquamarine); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.6 && wykres.get_x(ustaw.pik_mapa + 1) < 362.7)
                { kolor.Add(Color.Green); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.7 && wykres.get_x(ustaw.pik_mapa + 1) < 362.8)
                { kolor.Add(Color.Orange); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.8 && wykres.get_x(ustaw.pik_mapa + 1) < 362.9)
                { kolor.Add(Color.Yellow); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 362.9 && wykres.get_x(ustaw.pik_mapa + 1) < 363)
                { kolor.Add(Color.Brown); }
                else if (wykres.get_x(ustaw.pik_mapa + 1) > 363)
                { kolor.Add(Color.Red); }
            }

            
                


            newMapa.x = wykres.get_x(wykres.Iterator[c]);
            newMapa.y = wykres.get_y(wykres.Iterator[c]);
                    add_mapa(newMapa);
               
               

     

        }

        public void add_mapa(Mapa map)
        {
          punkty.Add(map);
        }
        public void skaluj(UstawieniaModel ustawienia)
        {
            UstawieniaModel.Wykres_m ustaw = new UstawieniaModel.Wykres_m();
            ustaw = ustawienia.ustawienia_m[0];
            MapaModel mapa = new MapaModel();
            MapaModel skaluj = new MapaModel();
            mapa.punkty = punkty.GetRange(0, punkty.Count);
            punkty.Clear();

            
           int podzialka_y =(int) ustaw.podzialka_y;
            int podzialka_x =(int) ustaw.podzialka_x;
            for (int i = 0; i < mapa.punkty.Count; i++)
            {
                skaluj.Add_p(podzialka_x * (20 + ((int)mapa.get_x(i))), podzialka_y * (20 + ((int)mapa.get_y(i))));
            }
            punkty = skaluj.punkty.GetRange(0, skaluj.punkty.Count);
        }

        public void Add_p(float x, float y)
        {
            Mapa newMapa = new Mapa();

            newMapa.x = x;
            newMapa.y = y;
            punkty.Add(newMapa);
            
        }

        public float get_x(int x)
        {
            Mapa newMapa2 = punkty[x];
            return newMapa2.x;
        }
        public float get_y(int y)
        {
            Mapa newMapa2 = punkty[y];
            return newMapa2.y;
        }

        public Color get_color(int color)
        {
            return kolor[color];
        }


    }


    


}