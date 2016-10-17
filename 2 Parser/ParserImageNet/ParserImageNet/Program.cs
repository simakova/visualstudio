using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace ConsApp_HtmlParser
{
    class Program
    {
        public static void GetWordsID(string id, string name, string gloss)
            //функция получения соответствия ID - значение из txt файла,где idStorage - массив из ID, а nameStorage - массиив названий
        {
            //words
            WebRequest reqWords = WebRequest.Create("http://image-net.org/archive/words.txt");

            reqWords.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse resWords = (HttpWebResponse) reqWords.GetResponse();

            // Console.WriteLine(resWords.StatusDescription);

            Stream dataWords = resWords.GetResponseStream();

            StreamReader readerW = new StreamReader(dataWords);

            // glossary
            WebRequest reqGloss = WebRequest.Create("http://image-net.org/archive/gloss.txt");

            reqGloss.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse resGloss = (HttpWebResponse)reqGloss.GetResponse();

            Stream dataGloss = resGloss.GetResponseStream();

            StreamReader readerG = new StreamReader(dataGloss);

            List<string> idStorage = new List<string>();

            List<string> nameStorage = new List<string>();

            List<string> glossStorage = new List<string>();

            string lineWords;

            string lineGloss;
            //заполнение массивов

            while ((lineWords = readerW.ReadLine()) != null && (lineGloss = readerG.ReadLine()) != null)

            {
                string ids = lineWords.Substring(1, 8);
                string names = lineWords.Substring(9);
                string glossary = lineGloss.Substring(9);
                idStorage.Add(ids);
                nameStorage.Add(names);
                glossStorage.Add(glossary);
            }

            readerW.Close();
            readerG.Close();
            dataWords.Close();
            dataGloss.Close();
            resWords.Close();
            resGloss.Close();
            
            /* for (int i=0; i<idStorage.Count; i++)
             Console.WriteLine(idStorage[i]);*/

            /*for (int i=0; i<nameStorage.Count; i++)
            Console.WriteLine(nameStorage[i]);*/

        Console.ReadLine();
            return;
        }

        static void Main(string[] args)
         {
            Console.Clear();
            Console.WriteLine("What do you want to find?:");
            string word = Console.ReadLine();
            
            break;
        }

    }
}