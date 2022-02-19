using Consola.Models;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Newtonsoft.Json;
using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Consola
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
            palabra = ObterValorWebScraping()+""+
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
        } //V
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorDocTXT()
        {
            string value = "";
            TextReader letraTxt = new StreamReader("letra.txt");
            return value = letraTxt.ReadLine();
        }//i
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorXML()
        {
            XmlTextReader xmlText = new XmlTextReader("letra.xml");
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.ReadNode(xmlText);
            var letra = "";
            foreach (XmlNode chldNode in node.ChildNodes)
            {
                if (chldNode.Name == "palabra")
                    letra = chldNode.Attributes["letra"].Value.Trim();

            }
            return letra;
        }//s
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorJSON()
        {
            Palabra letra;
            string path = @"letra.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                letra = JsonConvert.DeserializeObject<Palabra>(json);
            }
            return letra.texto;
        }//u
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorExcel()
        {
            string path = "letra.xlsx";
            string letra = "";
            SLDocument sl = new SLDocument(path);
            return  letra = sl.GetCellValueAsString(1, 1);
        }//a
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorPDF()
        {
            var pdf = new PdfDocument(new PdfReader("letra.pdf"));
            string text = "";

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                var page = pdf.GetPage(i);
                text = PdfTextExtractor.GetTextFromPage(page);
            }

            return text.ToString();
        }//l
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorDictionary()
        {
            Dictionary<string, string> letraDict = new Dictionary<string, string>();
            letraDict.Add("a"," ");
            letraDict.Add("b", "x");
            letraDict.Add("c", "l");

            return letraDict["a"];
        }//
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
        }//S
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
        }//t
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterLetraString()
        {
            return "u";
        }//u
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char ObterValorChar()
        {
            return 'd';
        }//d
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
        }//i
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorMatriz()
        {
            string[,] matriz = new string[1,1];

            matriz[0,0] = "o";
            return matriz[0, 0];
        }//o
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char ObterValorASCII()
        {
            return Convert.ToChar(44);
        }//,
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

        }//
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObterValorInt()
        {
            return 2;
        }//2
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal ObterValorDecimal()
        {
            return 0;
        }//0
        /// <summary>
        /// 
        /// </summary>
        /// <param name="letra"></param>
        /// <returns></returns>
        public int ObterValorParametro(int letra)
        {
            return letra;
        }//2
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float ObterValorFloat()
        {
            return 2;
        }//2
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObterValorCSV()
        {
            string[] letra = File.ReadAllLines("letra.csv");
            return letra[0];
        }//.


    }
}
