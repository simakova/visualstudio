using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;


namespace ConsApp_HtmlParser
{
    class Program
    {
        static void Main(string[] args)
        //public static void GetWordsID(string id, string name, string gloss)
        //функция получения соответствия ID - значение из txt файла,где idStorage - массив из ID, а nameStorage - массиив названий

        {
            //!!!!!!!!!!!!!!!!Вариант с txt!!!!!!!!!!!!!!!!!


            /*//words.txt

            WebRequest reqWords = WebRequest.Create("http://image-net.org/archive/words.txt");

            reqWords.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse resWords = (HttpWebResponse)reqWords.GetResponse();

            Stream dataWords = resWords.GetResponseStream();

            StreamReader readerW = new StreamReader(dataWords);

            // glossary.txt

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
                string names = lineWords.Substring(10);
                string glossary = lineGloss.Substring(10);
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

            string name = Console.ReadLine();
            int count = 0;
            while (count < idStorage.Count)
                if (nameStorage[count].Contains(name))
                    break;
                else
                    count++;
            string id = idStorage[count];

            Console.WriteLine(glossStorage[count]);
            /*int position = 0;

            foreach (string word in nameStorage)
            {
                if (name == word) break;
                position++;
            }

            string id = idStorage[position];

            string htmlName = "http://www.image-net.org/synset?wnid=n" + id;

            //   WebClient web = new WebClient();
            // web.Encoding = UTF8Encoding.UTF8;
            // string str = web.DownloadString(htmlName);
            HtmlDocument document = new HtmlDocument();
            try
            {
                HtmlWeb web = new HtmlWeb();
                document = web.Load(htmlName);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine("this word doesn't exist");
                Console.WriteLine("press any key to continue");
                Console.ReadLine();
                return;
            }

            Console.WriteLine(glossStorage[count]);
            Console.ReadKey();
            /*HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//span[@class='count']");
            IWebDriver driver = new FirefoxDriver(@"D:\Soft\chromedriver.exe");
            driver.Navigate().GoToUrl("http://www.google.com");
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                
            
            ///Список всех строк
            //HtmlNodeCollection nodes = document.DocumentNode.SelectSingleNode("//*[@id='detailsPanel']").SelectNodes("//table//tbody/tr[1]/td[2]/span");
            //*[@id="detailsPanel"]/table/tbody/tr[1]/td[2]/span
            //< span class="count">1272</span>
            /*foreach (var tr in nodes)
            {
                var tds = tr.ChildNodes;
                if (tds.Count ==4)
                {
                    Console.WriteLine("name: {0}", tds[0].InnerText);
                }
            }*/
            //Теперь для каждой строки tr, получаем все столбцы td
            /* private static string GET(string Url, string Data)
         {
             System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?" + Data);
             System.Net.WebResponse resp = req.GetResponse();
             System.IO.Stream stream = resp.GetResponseStream();
             System.IO.StreamReader sr = new System.IO.StreamReader(stream);
             string Out = sr.ReadToEnd();
             sr.Close();
             return Out;
         }

         // Console.WriteLine(countPic);
         Console.ReadKey();

         }
         */

            /* 

            /*for (int i=0; i<nameStorage.Count; i++)
            Console.WriteLine(nameStorage[i]);*/


            /////////////////////Задача 1. Вывод названия объекта по wnid(уникальный идентификатор 
            ///////////////////////////из словаря WordNet) в формате n********(8 значное число)

            Console.Write("Enter any 8-digits number(wnid): ");

            string id = Console.ReadLine();

            WebRequest req = WebRequest.Create("http://www.image-net.org/api/text/wordnet.synset.getwords?wnid=" + id);

            req.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Stream data = res.GetResponseStream();

            StreamReader reader = new StreamReader(data);

            string line = reader.ReadToEnd();

            Console.WriteLine(line);

           // reader.Close();

          //  data.Close();

            ////////////Вариант 2 с xml файлом
            /* XmlTextReader reader = new XmlTextReader(@"http://www.image-net.org/api/xml/structure_released.xml");
             reader.WhitespaceHandling = WhitespaceHandling.None;

             while (reader.Read())
             {
                 if (reader.MoveToAttribute("wnid")&&reader.Value.Contains(id))
                 {
                     reader.MoveToAttribute("words");
                     Console.WriteLine("Name" + "\t" + "\t" + reader.Value);
                     reader.MoveToAttribute("gloss");
                     Console.WriteLine("Description: " + "\t" + reader.Value);
                     break;
                 }
             }
             */
            /////////////////////////////////////////////////


            /////////////////////Задача 2. Вывод информации по введенному слову

            Console.Write("\n"+"Enter any word: ");
            string word = Console.ReadLine();
                
            XmlTextReader structure = new XmlTextReader(@"http://www.image-net.org/api/xml/structure_released.xml");
            structure.WhitespaceHandling = WhitespaceHandling.None;

            while (structure.Read())
            {
                if (structure.MoveToAttribute("words") && structure.Value.Contains(word))
                {
                    //Console.WriteLine(reader2.Value);
                    structure.MoveToAttribute("wnid");
                    string wnid = structure.Value;
                    Console.WriteLine("WNID= " + "\t" + "\t" + "\t" + wnid);
                    structure.MoveToAttribute("gloss");
                    string gloss = structure.Value;
                    //Console.WriteLine("Description: " + "\t" + gloss);

                    WebClient client = new WebClient();
                    //client.Encoding = Encoding.GetEncoding("utf-8");
                    string details = client.DownloadString("http://image-net.org/__viz/getControlDetails.php?wnid=" + wnid);  

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(details);

                    HtmlNode catName = doc.DocumentNode.SelectSingleNode("//table/tr[1]/td[1]");
                    Console.WriteLine("Word is from category:"  + "\t" + catName.InnerText);

                    HtmlNode description = doc.DocumentNode.SelectSingleNode("//table/tr[2]/td[1]");
                    Console.WriteLine("Description:" + "\t" + "\t" + description.InnerText);

                    HtmlNode count = doc.DocumentNode.SelectSingleNode("//table/tr[1]/td[2]");
                    Console.WriteLine("Count of pictures:" + "\t" + count.InnerText);

                    HtmlNode percent = doc.DocumentNode.SelectSingleNode("//table/tr[1]/td[3]");
                    Console.WriteLine("Popularity Percentile:" + "\t" + percent.InnerText);

                    Console.WriteLine("\n" + "Hyponims: " + "\n");

                    //string reply2 = client.DownloadString("http://image-net.org/api/text/wordnet.structure.hyponym?wnid=" + wnid);

                    WebRequest req2 = WebRequest.Create("http://image-net.org/api/text/wordnet.structure.hyponym?wnid=" + wnid);

                    req2.Credentials = CredentialCache.DefaultCredentials;

                    HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                    Stream dataID = res2.GetResponseStream();

                    StreamReader reader2 = new StreamReader(dataID);

                    List<string> idStorage = new List<string>();

                    string lineID;
                    

                    //заполнение массивов

                    while ((lineID = reader2.ReadLine()) != null)

                    {
                        string ids = lineID.Substring(0);
                        idStorage.Add(ids);
                    }

                    // reader2.Close();

                    // dataID.Close();
                    
                    
                    int i = 1;
                    while (i < idStorage.Count)
                    {
                        id = idStorage[i].Substring(1);

                        WebRequest req3 = WebRequest.Create("http://www.image-net.org/api/text/wordnet.synset.getwords?wnid=" + id);

                    req3.Credentials = CredentialCache.DefaultCredentials;

                    HttpWebResponse res3 = (HttpWebResponse)req3.GetResponse();

                    Stream data3 = res3.GetResponseStream();

                    StreamReader reader3 = new StreamReader(data3);

                    string line3 = reader3.ReadLine();

                        Console.WriteLine(id + "\t" + line3);
                        i++;
                    }


                    Console.ReadKey();
                }
                
            }
            Console.ReadKey();


        }



        }
    }