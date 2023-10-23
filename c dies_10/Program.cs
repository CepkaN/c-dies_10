using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Xml.XPath;
using System.Xml.Linq;

namespace c_dies_10
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Person em = new Person("bbb", 89, "uuu");
            string json = JsonSerializer.Serialize(em);
            Console.WriteLine(json);
            string path = "C:\\Users\\C - 6\\Documents\\Чепурина\\c dies_10\\aaa.json";
            /*using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(json);
            }
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                AllowTrailingCommas = true,
                IgnoreReadOnlyProperties = true
                };
            Console.WriteLine(JsonSerializer.Serialize(em,options));*/

            /*var emloy = new List<Person>
            {
                new Person("hd",87,"Yandex"),
                new Person("Bo",8,"Yahoo")
            };
            XmlSerializer xml = new XmlSerializer(typeof(Person));
           
            using (var fileStream = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fileStream, em);
               
                Console.WriteLine("serrrrr");
            }*/
            Tovar tovar1 = new Tovar("aaaaa",100,"Russia");
            Tovar tovar2 = new Tovar("bbbbb", 770, "Chine");
            Tovar tovar3 = new Tovar("ccccc", 555, "Italy");
            Zakaz zak = new Zakaz();
            zak.Zap(tovar1);
            //zak.Zap(tovar2);
            //zak.Zap(tovar3);
            zak.Vivid();
        }
    }
    public class Zakaz
    {
        public List<Tovar> ZaTo = new List<Tovar>();
        public string via = "C:\\Users\\C - 6\\Documents\\Чепурина\\c dies_10\\aaa.json";
        public string via2 = "Zakaz.xml";
        public XmlSerializer xml1 = new XmlSerializer(typeof(Tovar));
        public Zakaz() { }
        public void Zap(Tovar tov)
        {
            ZaTo.Add(tov);
            string json1 = JsonSerializer.Serialize(tov);
            using (var streamWriter1 = new StreamWriter(via))
            {
                streamWriter1.WriteLine(json1);
            }
            using (var fileStream1 = new FileStream(via2, FileMode.OpenOrCreate))
            {
                xml1.Serialize(fileStream1, tov);

                Console.WriteLine("запись");
            }
        }
        public void Vivid()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                IgnoreReadOnlyProperties = true
            };
            foreach(var za in ZaTo)
            {
                Console.WriteLine(JsonSerializer.Serialize(za, option));
            }
            /*using (var fstream2 = XmlReader.Create("C:\\Users\\C - 6\\Documents\\Чепурина\\c dies_10\\c dies_10\\bin\\Debug\\net6.0\\Zakaz.xml"))
            {               
                Console.WriteLine(fstream2);
            }*/
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Zakaz.xml");
            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // получаем атрибут name
                    XmlNode? attr = xnode.Attributes.GetNamedItem("Tovar");
                    Console.WriteLine(attr?.Value);

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {

                        Console.WriteLine(childnode.InnerText);
                    }
                       
                    
                }
            }

        }

    }
    public class Tovar
    {
        public string _name { get; set; }
        public int _mass { get; set; }
        public string _place { get; set; }
        public Tovar(string name, int mass, string place)
        {
            _name = name;
            _mass = mass;
            _place = place;
        }
        public Tovar() { }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [JsonIgnore]
        public string Company { get; set; }
        public Person(string name, int age, string company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
        public Person() { }
    }
}