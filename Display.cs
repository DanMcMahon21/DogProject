using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Dog
{
    public class Display
    {
        WebClient client = new WebClient();
        Dictionary<string, string[]> Breed = new Dictionary<string, string[]>();
        List<dynamic> picLink = new List<dynamic>();

        public void PrintSelectionScreen(int p)
        {

            Console.Clear();

            string[] selection = { "Print list of dog breeds",
                                   "Save an image of a random dog",
                                   "Enter breed to display sub-breed of dog",
                                   "Enter breed to save image of dog",
                                   "Enter breed to save image of dog and open file"};
            Console.WriteLine("Select an option:");
            Console.WriteLine();

            for (int f = 0; f <= 4; f++)
            {
                if (f == p)
                {
                    Console.ForegroundColor = (ConsoleColor)0;
                    Console.BackgroundColor = (ConsoleColor)3;
                    Console.WriteLine(selection[f]);
                    Console.ForegroundColor = (ConsoleColor)7;
                    Console.BackgroundColor = (ConsoleColor)0;
                }
                else
                {
                    Console.WriteLine(selection[f]);
                }
            }

            Console.SetCursorPosition(0, 10);
            Console.Write("<Up-arrow> to go up a line, <Down-arrow> to go down a line, <Enter> to select, <Escape> to quit ");
        }
        public void PrintDogList()
        {
            Console.Clear();

            string jsonString = client.DownloadString("https://dog.ceo/api/breeds/list/all");
            // Parse all of the JSON.

            JsonNode forecastNode = JsonNode.Parse(jsonString);

            // Get a single value
            JsonObject msgObj = forecastNode["message"].AsObject();

            MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            msgObj.WriteTo(writer);
            writer.Flush();

            Breed = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string[]>>(stream.ToArray());

            foreach (var breed in Breed)
            {
                Console.WriteLine(breed.Key);

                foreach (string subBreed in breed.Value)
                {
                    Console.WriteLine(subBreed.ToString() + " " + breed.Key.ToString());
                }
            }

            Console.WriteLine();
            Console.Write("Press any key to return to option selection ");
            Console.ReadKey();
        }

        public void DownloadImage()
        {
            Console.Clear();

            string DS = client.DownloadString("https://dog.ceo/api/breeds/image/random");
            dynamic myObject = JValue.Parse(DS);
            foreach (dynamic m in myObject)
            {
                string trim = m.ToString().Remove(0, 12);
                trim = trim.Remove(trim.Length - 1, 1);
                picLink.Add(trim);
            }

            byte[] dataArr = client.DownloadData(picLink[0]);
            string path;

            try
            {
                path = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
            }
            catch
            {
                path = Directory.GetCurrentDirectory();
            }

            path += "\\dogPic.jpg";

            File.WriteAllBytes(@path, dataArr);

            Console.WriteLine();
            Console.WriteLine("File Downloaded");
            Console.WriteLine();
            Console.WriteLine("Location: {0}", path);

            Console.WriteLine();
            Console.Write("Press any key to return to option selection ");
            Console.ReadKey();
            picLink.Clear();
        }

        public void PrintSubList()
        {
            Console.Clear();
            string dogInput;

            Console.Write("Enter name of dog breed: ");
            dogInput = Console.ReadLine();
           
            var responseStr = "https://dog.ceo/api/breed/" + dogInput + "/list";

            try
            {
                string DS = client.DownloadString(responseStr);
                dynamic myObject = JValue.Parse(DS);
                Console.WriteLine();
                Console.WriteLine("Sub-breeds:");

                foreach (dynamic m in myObject.message)
                {
                    Console.WriteLine("   " + m);
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Request failed!  Check spelling.");
            }

            Console.WriteLine();
            Console.Write("Press any key to return to option selection ");
            Console.ReadKey();
        }

        public void DownloadImageBreed(bool view)
        {
            Console.Clear();

            string dogInput;
            
            Console.Write("Enter name of dog breed: ");
            dogInput = Console.ReadLine();

            var responseStr = "https://dog.ceo/api/breed/" + dogInput + "/images/random";

            try
            {
                string DS = client.DownloadString(responseStr);
                dynamic myObject = JValue.Parse(DS);

                foreach (dynamic m in myObject)
                {
                    string trim = m.ToString().Remove(0, 12);
                    trim = trim.Remove(trim.Length - 1, 1);
                    picLink.Add(trim);
                }

                byte[] dataArr = client.DownloadData(picLink[0]);
                string path;

                try
                {
                    path = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
                }
                catch
                {
                    path = Directory.GetCurrentDirectory();
                }

                path += "\\dogPic.jpg";

                File.WriteAllBytes(@path, dataArr);

                Console.WriteLine();
                Console.WriteLine("File Downloaded");
                Console.WriteLine();
                Console.WriteLine("Location: {0}", path);

                if (view)
                {
                    Process.Start(@"D:\Downloads\dogPic.jpg");
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Request failed!  Check spelling.");
            }

            Console.WriteLine();
            Console.Write("Press any key to return to option selection ");
            Console.ReadKey();
            picLink.Clear();
        }
    }
}
