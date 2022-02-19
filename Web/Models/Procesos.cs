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
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorDocTXT()
        {
            string value = "";
            TextReader letraTxt = new StreamReader(@"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.txt");
            return value = letraTxt.ReadLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorDictionary()
        {
            Dictionary<string, string> letraDict = new Dictionary<string, string>();
            letraDict.Add("a", " ");
            letraDict.Add("b", "x");
            letraDict.Add("c", "l");

            return letraDict["a"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterLetraQueue()
        {
            var value = "";
            Queue valorQueue = new Queue();
            valorQueue.Enqueue("t");

            value = valorQueue.Peek().ToString();
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterLetraString()
        {
            return "u";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char ObterValorChar()
        {
            return 'd';
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorObjeto()
        {
            Palabra palabra = new Palabra();
            palabra.texto = "i";
            palabra.cantidadLetras = palabra.texto.Length;

            return palabra.texto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorMatriz()
        {
            string[,] matriz = new string[1, 1];

            matriz[0, 0] = "o";
            return matriz[0, 0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char ObterValorASCII()
        {
            return Convert.ToChar(44);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObterValorInt()
        {
            return 2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal ObterValorDecimal()
        {
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="letra"></param>
        /// <returns></returns>
        public int ObterValorParametro(int letra)
        {
            return letra;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float ObterValorFloat()
        {
            return 2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorCSV()
        {
            string[] letra = File.ReadAllLines(@"C:\Users\rarce\Documents\CENFOTEC\RogerArceCastro_Lab3\Laboratoio3\Web\App_Data\letra.csv");
            return letra[0];
        }
    }
}