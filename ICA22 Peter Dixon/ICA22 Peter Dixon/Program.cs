using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.IO;

namespace ICA21_Peter_Dixon
{

    class Program
    {
        enum sex { Male, Female };
        struct Patient
        {
            public string _name;
            public int _age;
            public sex _sex;

            public Patient(string n, int a, sex s)
            {
                _name = n.Trim();
                _age = a;
                _sex = s;
            }

            public void DisplayPatient()
            {

                Console.WriteLine("\nPatient name: {0}", _name);
                Console.WriteLine("Patient age: {0}", _age);
                Console.WriteLine("Patient sex: {0}", _sex);

            }



        }
        static void Main(string[] args)
        {
            string menu = "\na. Add\nd. Display\nq. Quit\n\nYour Selection: ";
            string input;

            string nameMessage = "\nPatient name: ";
            string ageMessage = "Patient age: ";
            string sexMessage = "Patient sex: ";

            string name;
            int age;
            sex sex;

            string filename;

            Patient person;
            List<Patient> PatientsList = new List<Patient>();
            Console.WriteLine("\t\tPatient Records");
            do
            {
                Console.Write(menu);
                input = Console.ReadLine();

                switch (input)
                {
                    case "a":                                         
                            Console.Write(nameMessage);
                            name = Console.ReadLine();

                            age = CUtilities.GetInt(ageMessage, 0, 150);
                            sex = GetSex(sexMessage);

                        PatientsList.Add(new Patient(name, age, sex));
                            Console.WriteLine("\nPatient added. You now have {0} patient(s).", PatientsList.Count);
                                               
                        break;
                    case "d":
                        try
                        {
                            
                            Console.WriteLine("\nList of patient records...");
                            for (int i = 0; i < PatientsList.Count; i++)
                            {
                                person = PatientsList[i];
                                person.DisplayPatient();
                            }

                            Console.Write("\nPress any key to continue:");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        catch
                        { Console.WriteLine("\nYou must have a patient before you can display this array."); }
                        break;
                    case "l":
                        try
                        {
                            Console.Write("\nEnter filename to load: ");
                            filename = Console.ReadLine();
                            Load(filename);
                        }
                        catch
                        {
                            Console.WriteLine("\nError Loading file.");
                        }
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid option.");
                        break;

                }

            } while (input != "q");

            /*
            List<Patient> patients = new List<Patient>();
            Patient myPatient;

            do
            {
                Console.Write(menu);
                input = Console.ReadLine();

                switch(input)
                {
                    case "a":
                        if (patients.Count < 10)
                        {
                            Console.Write(nameMessage);
                            myName = Console.ReadLine();

                            myAge = CUtilities.GetInt(ageMessage, 0, 150);
                            mySex = GetSex(sexMessage);


                            patients.Add(new Patient { _name = myName, _age = myAge, _sex = mySex });
                            
                           
                            Console.WriteLine("Patient added.");
                        }
                        else
                        {
                            Console.WriteLine("You have more than 10 patients. You cannot add any more patients.");
                        }
                        break;
                    case "d":
                        for (int i = 0; i<patients.Count; i++)
                        {
                            myPatient = patients[i];
                            myPatient.DisplayPatient();
                        }
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid option.");
                        break;

                }

            } while (input != "q");
            */

        }
        static sex GetSex(string message)
        {
            sex s = sex.Male;
            bool error;
            string input;

            do
            {
                error = false;
                Console.Write(message);
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "m":
                    case "male":
                        s = sex.Male;
                        break;
                    case "f":
                    case "female":
                        s = sex.Female;
                        break;
                    default:
                        Console.WriteLine("You must enter either a male or female sex.");
                        error = true;
                        break;
                }


            } while (error == true);

            return s;
        }

        static List<Patient> Load(string filename)
        {
            List<Patient> myList = new List<Patient>();
            string line;
            sex Sex;
            string name;
            int age;
            string[] splitLine;
            try
            {
                StreamReader myReader = new StreamReader(filename);
                line = myReader.ReadLine();
                splitLine = line.Split(new char[] { ' ' });
                if (splitLine.Length > 3)
                {
                    //This means that the line has more than 4 entries.
                    throw new Exception()
                }

            }
            catch
            {
                throw new Exception();
            }


            return myList;
        }
        
    }
}
