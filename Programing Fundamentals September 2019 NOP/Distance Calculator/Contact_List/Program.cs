using System;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] contacts = Console.ReadLine().Split();

            bool isItTimeToTakeABreak = false;

            while (true)
            {
                if (isItTimeToTakeABreak == true) break;
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                string contact = string.Empty;
                int index = 0;

                int startIndex = 0;
                int count = 0;

                string[] temp;
                int rightIndex = 0;

                switch (command)
                {
                    case "Add":
                        contact = input[1];
                        index = int.Parse(input[2]);
                        if(contacts.Contains(contact))
                        {
                            if (index < contacts.Length && index >= 0)
                            {
                                temp = new string[contacts.Length + 1];
                                for (int i = 0; i < temp.Length; i++)
                                {
                                    if (i == index)
                                        continue;
                                    else
                                    {
                                        temp[i] = contacts[rightIndex];
                                        rightIndex++;
                                    }
                                }
                                temp[index] = contact;
                                contacts = new string[temp.Length];
                                for (int i = 0; i < temp.Length; i++)
                                    contacts[i] = temp[i];
                            }
                        }
                        else
                        {
                            if (index < contacts.Length && index >= 0)
                            {
                                temp = new string[contacts.Length + 1];
                                for (int i = 0; i < contacts.Length; i++)
                                    temp[i] = contacts[i];

                                temp[contacts.Length] = contact;
                                contacts = new string[temp.Length];

                                for (int i = 0; i < temp.Length; i++)
                                    contacts[i] = temp[i];
                            }
                        }
                        break;
                    case "Remove":
                        index = int.Parse(input[1]);
                        if (index < contacts.Length && index >= 0)
                        {
                            contacts[index] = string.Empty;
                            temp = new string[contacts.Length - 1];

                            for (int i = 0; i < contacts.Length; i++)
                            {
                                if (contacts[i] != "")
                                {
                                    temp[rightIndex] = contacts[i];
                                    rightIndex++;
                                }
                            }

                            contacts = new string[temp.Length];
                            for (int i = 0; i < temp.Length; i++)
                                contacts[i] = temp[i];
                        }
                        break;
                    case "Export":
                        startIndex = int.Parse(input[1]);
                        count = int.Parse(input[2]);

                        int comValue = startIndex + count;
                        if (comValue >= contacts.Length - 1)
                        {
                            count = contacts.Length - startIndex;
                            for (int i = 0; i < count; i++)
                            {
                                Console.Write(contacts[startIndex + i] + " ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            for (int i = startIndex; i < count; i++)
                            {
                                Console.Write(contacts[i] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "Print":
                        string type = input[1];
                        switch (type)
                        {
                            case "Normal":
                                Console.Write("Contacts: ");
                                foreach (string item in contacts)
                                {
                                    Console.Write(item + " ");
                                }
                                Console.WriteLine();
                                break;
                            case "Reversed":
                                Console.Write("Contacts: ");
                                foreach (string item in contacts.Reverse())
                                {
                                    Console.Write(item + " ");
                                }
                                Console.WriteLine();
                                break;
                            default: break;
                        }
                        isItTimeToTakeABreak = true;
                        break;
                }
            }
        }
    }
}
