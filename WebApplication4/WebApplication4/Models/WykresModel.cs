using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class WykresModel
    {
        
        public List<Punkty> punkty = null;
        public List<int> Iterator = null;
        public class Punkty
        {
            public float x { get; set; }
            public float y { get; set; }
            
        }

     
        public WykresModel()
        {
            punkty = new List<Punkty>();
           
            Iterator = new List<int>();
            Iterator.Add(0);
        }
        public void Add_p(float x, float y)
        {
            Punkty newPunkty = new Punkty();
 
            newPunkty.x = x;
            newPunkty.y = y;
            punkty.Add(newPunkty);
            
            
        }
      
        public void Add_L(int iterator)
        {
            Iterator.Add(iterator);
        }

        
        public WykresModel pokaz_wykres_L(int numer_wykresu)
        {
            WykresModel wykres = new WykresModel();
            
            int liczbElementow = Iterator[numer_wykresu] - Iterator[numer_wykresu - 1]-1 ;

            wykres.punkty = punkty.GetRange(Iterator[numer_wykresu-1]+1, liczbElementow);

            
            
            return wykres;
        }
        public void Skaluj(UstawieniaModel.Wykres dane)
        {
            WykresModel wykres = new WykresModel();
            WykresModel skaluj = new WykresModel();
            wykres.punkty = punkty.GetRange(0,punkty.Count);
            punkty.Clear();
            float zakres = dane.zakres_wykresuX;
            float zakres2 = dane.zakres_wykresuY;
            float min_y = dane.najmniejsza_y;
            float min_x = dane.najmniejsza_x;
            for (int i = 0; i < wykres.punkty.Count; i++)
            {
                skaluj.Add_p(wykres.get_x(i) * (760 / zakres) - ((760 / zakres) * (min_x- 60) + (min_x - 60)),(400 +(min_y*(360/zakres2)) )- wykres.get_y(i) * (359 / zakres2)-1);

            }
            punkty = skaluj.punkty.GetRange(0,skaluj.punkty.Count);
            

        }
        
      
        public float get_x(int x) {
            Punkty newPunkty = punkty[x];
            return newPunkty.x; }
        public float get_y(int y) {
            Punkty newPunkty = punkty[y];
            return newPunkty.y; }



    }
}