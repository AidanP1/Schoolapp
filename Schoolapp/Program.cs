using System;
using System.IO;


namespace Schoolapp
{
    class Program
    {

        int id;
        string name;
        int clas;
        char section;
        string splitter = "|";
        string myPath = @"C:\Users\aidan\Desktop\file.txt";
        string temp = @"C:\Users\aidan\Desktop\temp.txt";


        class implementation
        {
            //Selects options to add data to the file or update it
            static void Main(string[] args)
            {
                Console.WriteLine("Enter '1' to Add data or '2' to Update data:");
                int read = int.Parse(Console.ReadLine());
                Program program = new Program();
                if (read == 1)
                    program.adddata();
                else if (read == 2)
                    program.updatedata();
                else
                    Console.WriteLine("Invalid value was entered, '1' or '2' only can be entered");

            }
        }

        public void adddata()
        //Add teacher's data entered by the user to the file, it will loop (to add more records) depending on the int 
        {
            Console.WriteLine("How many records you want to insert");
            int numberofrecords = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberofrecords; i++)
            {
                Console.Write("Enter the teacher id:");
                id = int.Parse(Console.ReadLine());
                Console.Write("Enter name:");
                name = Console.ReadLine();
                Console.Write("Enter class:");
                clas = int.Parse(Console.ReadLine());
                Console.Write("Enter section:");
                section = char.Parse(Console.ReadLine());
                using (StreamWriter streamwriter = new StreamWriter(myPath, true))
                {
                    streamwriter.Write(id);
                    streamwriter.Write(splitter);
                    streamwriter.Write(name);
                    streamwriter.Write(splitter);
                    streamwriter.Write(clas);
                    streamwriter.Write(splitter);
                    streamwriter.Write(section);
                    streamwriter.Write(splitter);
                    streamwriter.WriteLine();

                }
                Console.WriteLine("Record inserted sucessfully");

            }

        }


        public void updatedata()
        //Update records by reading all file lines to an array of strings and using the ID selected by the user
        {
            Console.WriteLine("Enter the ID to be updated:");
            int idtoupd = int.Parse(Console.ReadLine());
            string[] filelines = File.ReadAllLines(myPath);

            for (int i = 0; i < filelines.Length; i++)
            {
                string[] data = filelines[i].Split(splitter);
                if (Convert.ToInt32(data[0]) == idtoupd)

                {
                    Console.Write("Enter update name:");
                    string newname = Console.ReadLine();
                    Console.Write("Enter update class:");
                    string newclass = Console.ReadLine();
                    Console.Write("Enter update section:");
                    string newsection = Console.ReadLine();
                    data[0] = data[0];
                    data[1] = newname;
                    data[2] = newclass;
                    data[3] = newsection;
                    using (StreamWriter streamwriter = new StreamWriter(temp, true))
                    {
                        streamwriter.Write(data[0]);
                        streamwriter.Write(splitter);
                        streamwriter.Write(data[1]);
                        streamwriter.Write(splitter);
                        streamwriter.Write(data[2]);
                        streamwriter.Write(splitter);
                        streamwriter.Write(data[3]);
                        streamwriter.Write(splitter);
                        streamwriter.WriteLine();
                    }
                    Console.WriteLine("Record updated sucessfully!");
                }
                else
                {

                    using (StreamWriter streamwriter = new StreamWriter(temp, true))
                    {
                        streamwriter.Write(data[0]);
                        streamwriter.Write(splitter);
                        streamwriter.Write(data[1]);
                        streamwriter.Write(splitter);
                        streamwriter.Write(data[2]);
                        streamwriter.Write(splitter);
                        streamwriter.Write(data[3]);
                        streamwriter.Write(splitter);
                        streamwriter.WriteLine();
                    }

                }

            }
            //Deletes original file and updates changes from temp to File
            File.Delete(myPath);
            System.IO.File.Move(temp, myPath);

        }

    }
}
