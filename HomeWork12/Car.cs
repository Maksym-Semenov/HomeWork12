using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace HomeWork12
{
    [Serializable]
    [DataContract]
    public class Car
    {
        private string name;
        private string description;
        private int price;
        [XmlAttribute]
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [XmlAttribute]
        [DataMember]

        public string Description { get { return description; } set { description = value; } }
        [XmlAttribute]
        [DataMember]

        public int Price { get { return price; } set { price = value; } }
        public Car()
        {

        }
        public Car(string name, string description, int price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

    }
}
