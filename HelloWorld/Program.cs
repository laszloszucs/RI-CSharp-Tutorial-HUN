using MyLibrary;
using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace HelloWorld
{
    internal class Program
    {
        #region Stuff

        private enum Animal { Cat = 1, Dog = 2, Tiger, Wolf, Returned }

        public static IEnumerable EnumerableMethod(int max)
        {
            for (var i = 0; i < max; ++i)
            {
                yield return i;
            }
        }

        static async Task<string> DoOperations()
        {
            var result = await Task<string>.Factory.StartNew(
            () => ReallyLongOperation()
            );
            Console.WriteLine("Az eredmény: {0}", result);

            return result;
        }

        static string ReallyLongOperation()
        {
            Thread.Sleep(2000);
            return "Siker";
        }


        #endregion

        private static void Main()
        {

            #region ALL

            #region Old

            /*
            const string message = "Hello World!";
            const string message2 = "Hello World!";

            System.Object asd = new object();
            System.Object asd2 = asd;
            var hashCode = asd.GetHashCode();
            Console.WriteLine(asd.ToString());
            Console.WriteLine(asd.Equals(asd2));
            Console.WriteLine(asd.GetType());
            Console.WriteLine(hashCode);
            */

            #endregion

            #region boxing / unboxing (explicit)
            /*
            int x = 3;
            object boxObject = x;
            Console.WriteLine($"x értéke: {x}");

            int y = (int)boxObject;
            Console.WriteLine($"y értéke: {y}");
            */
            #endregion

            #region Enum Stringől -> ENUM


            string s1 = "1";
            string s2 = "Dog";
            Animal a1, a2;
            Enum.TryParse(s1, true, out a1);
            Enum.TryParse(s2, true, out a2);
            a1 = Animal.Returned;
            var booool = (Animal)5 == Animal.Returned;

            ;


            #endregion

            #region Old

            //int y = 10;
            //int? x = y; // implicit konverzió
            //y = (int)x; // explicit konverzió 

            #endregion

            #region - unáris operátor int-el tér vissza NEM BYTE!!

            //byte x = 10;
            //int foo = -x;
            //byte y = -x;

            #endregion

            // Console.WriteLine(sizeof(int)); // Az értéktípus méretét adja vissza byte-ban

            #region Switch-case break; nem hiányozhat, kivéve ha nincs utasítása az ágnak

            //Animal animal = Animal.Dog;
            //switch (animal)
            //{
            //    case Animal.Tiger:
            //    case Animal.Dog:
            //        Console.WriteLine("Tigris");
            //        break;
            //    default:
            //        Console.WriteLine("Nem ismerem ezt az állatot!");
            //        break;
            //}

            #endregion

            #region EnumerableMethod

            //foreach (int i in EnumerableMethod(10))
            //{
            //    Console.Write(i);
            //}

            #endregion

            #region checked block, checked funcition, unchecked

            //checked
            //{
            //    int x = 300;
            //    byte y = (byte)x;
            //}

            //int x = 300;
            //byte y = checked((byte)x);

            //int x = 300;
            //byte y = unchecked((byte)x);

            #endregion

            #region Char to Unicode (implicit convert)

            // A kis ’a’ betű hexadecimális Unicode száma 0061h, ami a 97 decimális számnak felel meg, tehát a konverzió a
            // tízes számrendszerbeli értéket adja vissza.
            //Console.WriteLine((int)'a');

            #endregion

            #region GC

            //Console.WriteLine("Foglalt memória: {0}",
            //    GC.GetTotalMemory(false));
            //for (int i = 0; i < 10; ++i)
            //{
            //    int[] x = new int[1000];
            //}
            //Console.WriteLine("Foglalt memória: {0}",
            //    GC.GetTotalMemory(false));
            //GC.Collect(); // meghívjuk a szemétgyűjtőt
            //Console.WriteLine("Foglalt memória: {0}",
            //    GC.GetTotalMemory(false));

            #endregion

            #region Reference from other Assembly, and call a static method

            //ClassLib.PrintHello();

            #endregion

            #region Öröklődés

            //new Oroklodes();

            #endregion

            #region Delegate

            //new Delegate();

            #endregion

            #region Eventek

            //new Eventek();

            #endregion

            #region Task

            //string[] array = new string[]
            //{
            // "Én egy Task vagyok!",
            // "Én is egy Task vagyok!",
            // "Én nem vagyok egy Task!"
            //};
            //foreach (string item in array)
            //{
            //    Task task = new Task(
            //    (obj) => Console.WriteLine(obj), // ide lehet közvetlenül az item-et is írni így nem kell szórakozni a Task input paraméterrel [lambda expression rulz]
            //    item); // Task input paraméter
            //    task.Start();
            //}

            #endregion

            #region ASYNC/AWAIT

            //Console.WriteLine("A művelet előtt...");
            //var result = DoOperations().GetAwaiter().GetResult(); // Esetleg DoOperations().Result; (bár ekkor nem keletkeznek a megfelelő exception-ök, a legjobb mégis az await használata. Main függvényben nem lehet használni await-et.
            //// The Async Main Method cikk: https://blogs.msdn.microsoft.com/mazhou/2017/05/30/c-7-series-part-2-async-main/
            //Console.WriteLine("A művelet után...");
            //Console.ReadKey();

            #endregion

            #endregion

            #region XML

            //XmlReader reader = XmlReader.Create("test.xml");

            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element:
            //            Console.WriteLine("<{0}>", reader.Name);
            //            break;
            //        case XmlNodeType.EndElement:
            //            Console.WriteLine("</{0}>", reader.Name);
            //            break;
            //        case XmlNodeType.Text:
            //            Console.WriteLine(reader.Value);
            //            break;
            //        default:
            //            break;
            //    };
            //}

            //XmlTextWriter writer = new XmlTextWriter("newxml.xml", Encoding.UTF8)
            //{
            //    Formatting = Formatting.Indented
            //};

            //writer.WriteStartDocument();
            //writer.WriteComment(DateTime.Now.ToString());
            //writer.WriteStartElement("PersonsList");
            //writer.WriteStartElement("Person");
            //writer.WriteElementString("Name", "Reiter Istvan");
            //writer.WriteElementString("Age", "26");
            //writer.WriteEndElement();

            //XmlDocument xdoc = new XmlDocument();

            //XmlNodeChangedEventHandler handler = (sender, e) => {
            //    Console.WriteLine("Chaaanged!");
            //    Console.WriteLine(e.Node.Value);
            //};

            //xdoc.NodeInserting += handler;

            //XmlElement element = xdoc.CreateElement("Test");
            //XmlText text = xdoc.CreateTextNode("Hello XML DOM!");
            //XmlNode node = xdoc.AppendChild(element);
            //node.AppendChild(text);
            //xdoc.Save("domtest.xml");



            #endregion

            Console.ReadKey();
        }
    }
}
