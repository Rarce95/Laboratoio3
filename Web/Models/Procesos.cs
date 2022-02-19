using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Xml;
using iText.Kernel.Pdf.Canvas.Parser;
using SpreadsheetLight;
using iText.Kernel.Pdf;
using Newtonsoft.Json;

namespace Web.Models
{
    public class Procesos
    {

        /// <summary>
        ///     Metodo principal que reune la informacion de los diferentes metdos para construir la palabra
        /// </summary>
        /// <returns>palabra</returns>
        public string CrearPalabra()
        {
            string palabra = "";
            palabra = ObterValorWebScraping() + "" +
                      ObterValorDocTXT() + "" +
                      ObterValorXML() + "" +
                      ObterValorJSON() + "" +
                      ObterValorExcel() + "" +
                      ObterValorPDF() + "" +
                      ObterValorDictionary() + "" +
                      ObterValorListaString() + "" +
                      ObterLetraQueue() + "" +
                      ObterLetraString() + "" +
                      ObterValorChar() + "" +
                      ObterValorObjeto() + "" +
                      ObterValorMatriz() + "" +
                      ObterValorASCII() + "" +
                      ObterValorVector() + "" +
                      ObterValorInt() + "" +
                      ObterValorDecimal() + "" +
                      ObterValorParametro(2) + "" +
                      ObterValorFloat() + "" +
                      ObterValorCSV();
            return palabra;
        }
        /// <summary>
        ///     Metodo de WebScraping que retorna un string directo del valor de un componente en una pagina web
        /// </summary>
        /// <returns>value</returns>
        public string ObterValorWebScraping()
        {
            string value = "";
            List<string> lista = new List<string>();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://drama.fandom.com/es/wiki/V");
            var c = doc.DocumentNode.SelectNodes("//h1[@class='page-header__title']").ToList();
            foreach (var item in c)
            {
                lista.Add(item.InnerText.Trim());
            }
            value = lista.FirstOrDefault(x => x.Length > 0);
            return value;
        }
        /// <summary>
        ///     Retorna el valor almacenado en un TXT dentro del App_Data, se debe cambiar el path
        /// </summary>
        /// <returns>value</returns>
        public string ObterValorDocTXT()
        {
            string value = "";
            TextReader letraTxt = new StreamReader(@"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.txt");
            return value = letraTxt.ReadLine();
        }
        /// <summary>
        ///     Retorna el valor almacenado en un XML dentro del App_Data, se debe cambiar el path
        /// </summary>
        /// <returns>letra</returns>
        public string ObterValorXML()
        {
            XmlTextReader xmlText = new XmlTextReader(@"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.xml");
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.ReadNode(xmlText);
            var letra = "";
            foreach (XmlNode chldNode in node.ChildNodes)
            {
                if (chldNode.Name == "palabra")
                    letra = chldNode.Attributes["letra"].Value.Trim();

            }
            return letra;
        }
        /// <summary>
        ///     Retorna el valor almacenado en un JSON dentro del App_Data, se debe cambiar el path
        /// </summary>
        /// <returns>letra</returns>
        public string ObterValorJSON()
        {
            Palabra letra = new Palabra() ;
            string path = @"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                letra = JsonConvert.DeserializeObject<Palabra>(json);
            }
            return letra.texto;
        }
        /// <summary>
        ///     Retorna el valor almacenado en un XLSX dentro del App_Data, se debe cambiar el path
        /// </summary>
        /// <returns></returns>
        public string ObterValorExcel()
        {
            string path = @"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.xlsx";
            string letra = "";
            SLDocument sl = new SLDocument(path);
            return letra = sl.GetCellValueAsString(1, 1);
        }
        /// <summary>
        ///     Retorna el valor almacenado en un PDF dentro del App_Data, se debe cambiar el path
        /// </summary>
        /// <returns></returns>
        public string ObterValorPDF()
        {
            var pdf = new PdfDocument(new PdfReader(@"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.pdf"));
            string text = "";

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                var page = pdf.GetPage(i);
                text = PdfTextExtractor.GetTextFromPage(page);
            }

            return text.ToString();
        }
        /// <summary>
        ///     Retorna un valor almacenado dentro de una variable de tipo Dictionary
        /// </summary>
        /// <returns>letraDict</returns>
        public string ObterValorDictionary()
        {
            Dictionary<string, string> letraDict = new Dictionary<string, string>();
            letraDict.Add("a", " ");
            letraDict.Add("b", "x");
            letraDict.Add("c", "l");

            return letraDict["a"];
        }
        /// <summary>
        ///     Retorna un valor de una lista de string
        /// </summary>
        /// <returns>listChar</returns>
        public string ObterValorListaString()
        {
            List<string> listChar = new List<string>();
            listChar.Add("S");
            listChar.Add("R");
            listChar.Add("G");
            listChar.Add("H");

            return listChar[0];
        }
        /// <summary>
        ///     Retorna un valor de una cola de prioridad 
        /// </summary>
        /// <returns>value</returns>
        public string ObterLetraQueue()
        {
            var value = "";
            Queue valorQueue = new Queue();
            valorQueue.Enqueue("t");

            value = valorQueue.Peek().ToString();
            return value;
        }
        /// <summary>
        ///     Retorna un string
        /// </summary>
        /// <returns>string</returns>
        public string ObterLetraString()
        {
            return "u";
        }
        /// <summary>
        ///     Retorna un char
        /// </summary>
        /// <returns>char</returns>
        public char ObterValorChar()
        {
            return 'd';
        }
        /// <summary>
        ///     Retorna el valor almacenado en un objeto
        /// </summary>
        /// <returns>palabra.texto</returns>
        public string ObterValorObjeto()
        {
            Palabra palabra = new Palabra();
            palabra.texto = "i";
            palabra.cantidadLetras = palabra.texto.Length;

            return palabra.texto;
        }
        /// <summary>
        ///     Retorna un valor concreto dentro de una matriz
        /// </summary>
        /// <returns>matriz</returns>
        public string ObterValorMatriz()
        {
            string[,] matriz = new string[1, 1];

            matriz[0, 0] = "o";
            return matriz[0, 0];
        }
        /// <summary>
        ///     Retorna un char precedente de codigo ASCII
        /// </summary>
        /// <returns>char</returns>
        public char ObterValorASCII()
        {
            return Convert.ToChar(44);
        }
        /// <summary>
        ///     Retorna el valor de una posicion concreta dentro de un vector
        /// </summary>
        /// <returns>letras</returns>
        public string ObterValorVector()
        {
            string[] letras = new string[5];
            letras[0] = "a";
            letras[1] = "b";
            letras[2] = "c";
            letras[3] = " ";
            letras[4] = "e";

            return letras[3];

        }
        /// <summary>
        ///     Retorna un valor entero
        /// </summary>
        /// <returns>int</returns>
        public int ObterValorInt()
        {
            return 2;
        }
        /// <summary>
        ///     Retorna un valor decimal
        /// </summary>
        /// <returns>decimal</returns>
        public decimal ObterValorDecimal()
        {
            return 0;
        }
        /// <summary>
        ///     Retorna el valor de la variable que ingresa por parametros
        /// </summary>
        /// <param name="letra"></param>
        /// <returns>int</returns>
        public int ObterValorParametro(int letra)
        {
            return letra;
        }
        /// <summary>
        ///     Retorna un valor flotante
        /// </summary>
        /// <returns>float</returns>
        public float ObterValorFloat()
        {
            return 2;
        }
        /// <summary>
        ///     Retorna el valor almacenado en un CSV dentro del App_Data, se debe cambiar el path
        /// </summary>
        /// <returns></returns>
        public string ObterValorCSV()
        {
            string[] letra = File.ReadAllLines(@"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.csv");
            return letra[0];
        }
    }
}