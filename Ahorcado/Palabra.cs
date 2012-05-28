using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace Ahorcado
{
    class Palabra
    {

        private static String[] es = {"MARAÑA","CALENDARIO","LLAVE","ORDENADOR","ALTAVOZ","COCHE","PELOTA","LAMPARA","PANTALON",
                                   "CAMISETA","TELEFONO","MANZANA","BOLIGRAFO","LAPICERO","BOTON","ALFOMBRA","SABANA","PEZ",
                                   "TORTUGA","ISLA","DICCIONARIO","SILLA","MESA","OTORRINOLARINGOLOGO","ROJO","CHARLATAN",
                                   "CABLE","SORTIJA","ENCHUFE","HIERBA","ARBOL","FLOR","ABEJA","PERRO","GATO","ROBOT","SOL",
                                   "NUBE","CIELO","ESTRELLA","AUTOBUS","OLA","SABOTAJE","PUERTA","MADERA","PARTIDO","CINTA",
                                   "DISCO","ABUELO","MADRE","HERMANA","HIJO","ENTRADA","PASILLO","TERRAZA","AVION","CUNETA",
                                   "CUNA","LUZ","MUSICA","MECHERO","FUEGO","LIBRO","LINTERNA","PERIODICO","TELA","SOPA"};

        public static String getPalabra() {
            String idioma =System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (idioma.ToLower().Equals("es")) return es[new Random().Next(0, es.Length - 1)];
            else return "OJETE";
        }
    }
}
