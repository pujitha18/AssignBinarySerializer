using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace AssignBinarySerializer
{
    [Serializable]
    class BinarySerialize: IDeserializationCallback
    {
        public int Year;
        [NonSerialized]
        public int Age;

        public BinarySerialize(int bYear)
        {
            Year = bYear;

        }
        public void OnDeserialization(object sender)
        {
            DateTime dt = DateTime.Now;
            Age = DateTime.Now.Year-Year;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Year:");
            int Y =Convert.ToInt32(Console.ReadLine());
            BinarySerialize bs = new BinarySerialize(Y);
            FileStream fs = new FileStream(@"Assign.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, bs);
            fs.Seek(0, SeekOrigin.Begin);
            BinarySerialize bs1 = (BinarySerialize)bf.Deserialize(fs);
            Console.WriteLine("Age:"+bs1.Age);
        }
    }
}
