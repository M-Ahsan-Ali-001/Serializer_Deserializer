using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization_pratice
{

    [Serializable]
    class Custoomers
    {
        public string user_name;
        public string password;
        public Custoomers(string name, string password)
        {
            this.user_name = name;
            this.password = password;


        }
    };
    class Program
    {
        

        public static void Obj_maker(string name , string pass)
        {
            string path = "dang.txt";
            Custoomers obj = new Custoomers(name ,pass);
            FileStream openFile = new FileStream(path, FileMode.Append);
            BinaryFormatter format = new BinaryFormatter();

            format.Serialize(openFile, obj);
            openFile.Close();
            Console.WriteLine("DataSaved!");


        }
        public static void Deserializer(string path)
        {
            Stream openFileRead = new FileStream(path,FileMode.Open ,FileAccess.Read);
            BinaryFormatter Deformat = new BinaryFormatter();
            try
            {
                while (openFileRead.Position < openFileRead.Length)
                {
                    Custoomers obj = (Custoomers)Deformat.Deserialize(openFileRead);
                    Console.WriteLine(obj.user_name);
                    Console.WriteLine(obj.password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                openFileRead.Close();
            }


        }

        static void Main(string[] args)
        {
             //Obj_maker("ahsan101","1222234a ");
            Deserializer("dang.txt");
           // Obj_maker("player122", "1234a ");


         
        }
    } 
}
