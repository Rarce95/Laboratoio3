using Consola.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace Consola
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Palabra palabra = new Palabra();
            string[] letra = File.ReadAllLines("letra.csv");

            string path = "letra.xlsx";
            string x = "";
            SLDocument sl = new SLDocument(path);
            x = sl.GetCellValueAsString(1, 1);
        }
    }
}
