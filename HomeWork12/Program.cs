using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace HomeWork12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] car = new Car[3];
            car[0] = new Car("Model X","white",50000);
            car[1] = new Car("Model L", "grey", 60000);
            car[2] = new Car("Model L", "red", 70000);
            //BIN
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Car.bin",FileMode.Create,FileAccess.Write);

            formatter.Serialize(stream,car);
            stream.Close();

            stream = new FileStream("Car.bin", FileMode.Open, FileAccess.Read);
            Car[] carbin = (Car[])formatter.Deserialize(stream);
            stream.Close();

            foreach (var item in carbin)
            {
                Console.WriteLine($"Bi {item.Name}, {item.Description}, {item.Price} ");
            }
            //XML
            XmlSerializer serializer = new XmlSerializer(typeof(Car[]));
            FileStream fs = new FileStream("car.xml", FileMode.Create);
            
                serializer.Serialize(fs, car);
            fs.Close();
            fs = new FileStream("car.xml", FileMode.Open);
            
            Car[] carxml = serializer.Deserialize(fs) as Car[];
            fs.Close();

            foreach (var item in carxml)
            {
                Console.WriteLine($"XML {item.Name}, {item.Description}, {item.Price} ");
            }
            //JSON
            Stream file = new FileStream("car.json", FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Car[]));

            ser.WriteObject(file, car);

            file.Position = 0;

            Car[] carjson = (Car[])ser.ReadObject(file);


            foreach (var item in carjson)
            {
                Console.WriteLine($"JSON {item.Name}, {item.Description}, {item.Price} ");
            }
        }
    }
}
