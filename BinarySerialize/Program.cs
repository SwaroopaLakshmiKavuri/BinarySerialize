using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BinarySerialize
{
    [Serializable]
    class Binary : IDeserializationCallback
    {
        public int Year { get; set; }
        [NonSerialized]
        public int Age;

        public Binary(int year)
        {
            this.Year = year;

        }


        public void OnDeserialization(object sender)
        {
            DateTime d = DateTime.Now;
            Age = DateTime.Now.Year - Year;


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Year :");
            int Year = int.Parse(Console.ReadLine());
            Binary b = new Binary(Year);
            FileStream fs = new FileStream(@"binary.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter br = new BinaryFormatter();
            br.Serialize(fs, b);
            fs.Seek(0, SeekOrigin.Begin);
            Binary b1 = (Binary)br.Deserialize(fs);
            Console.WriteLine("Age : " + b1.Age);

        }
    }
}

