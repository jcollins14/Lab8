using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab8
{
    class Program
    {
        static void Main()
        {
            int student;
            string input;
            bool loop = true;

            List<string> students = new List<string>();
            students.Add("Tommy Waalkes");
            students.Add("Albert Ngoudjou");
            students.Add("Jake Collins");
            students.Add("Austin Powel");
            students.Add("Dylan Rule");
            students.Add("Andrew Waltman");

            Hashtable town = new Hashtable();
            town.Add("Jake Collins", "Corona, CA");
            town.Add("Andrew Waltman", "Grand Rapids, MI");
            town.Add("Dylan Rule", "Newport, NH");
            town.Add("Austin Powel", "Blissfield, MI");
            town.Add("Tommy Waalkes", "Raleigh, NC");
            town.Add("Albert Ngoudjou", "Bafoussam, Camaroon");

            Hashtable food = new Hashtable();
            food.Add("Jake Collins", "Sushi");
            food.Add("Andrew Waltman", "Burgers");
            food.Add("Dylan Rule", "Poutine");
            food.Add("Austin Powel", "Spaghetti");
            food.Add("Tommy Waalkes", "Indian Chicken Curry");
            food.Add("Albert Ngoudjou", "Lasagna");

            Console.WriteLine("Welcome to the Grand Circus After Hours C# Database.");

            while (loop == true)
            {
                student = SelectStudent();
                Console.WriteLine("You have selected " + students[student] + ". What would you like to know about " + students[student] + "?. (Enter: Hometown or Favorite Food).");

                input = Console.ReadLine();
                input = input.Trim().ToLower();

                while (input != "favorite food" && input != "hometown")
                {
                    Console.WriteLine("I'm sorry, that data is not on file. Please try again. (Enter: Hometown or Favorite Food).");
                    input = Console.ReadLine();
                    input = input.Trim().ToLower();
                }

                if (input == "hometown")
                {
                    string home = LookupTable(town, students[student]);
                    Console.WriteLine(students[student] + " is from " + home + ".");
                    Console.WriteLine("Would you like to know more about " + students[student] + "? (Enter: Yes or No).");
                    input = Console.ReadLine();
                    input = input.Trim().ToLower();

                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Invalid Input, please try again.");
                        input = Console.ReadLine();
                        input = input.Trim().ToLower();
                    }

                    if (input == "yes")
                    {
                        string meal = LookupTable(food, students[student]);
                        Console.WriteLine(students[student] + "'s favorite food is " + meal + ".");
                    }
                }

                else if (input == "favorite food")
                {
                    string meal = LookupTable(food, students[student]);
                    Console.WriteLine(students[student] + "'s favorite food is " + meal + ".");
                    Console.WriteLine("Would you like to know more about " + students[student] + "? (Enter: Yes or No).");
                    input = Console.ReadLine();
                    input = input.Trim().ToLower();

                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Invalid Input, please try again.");
                        input = Console.ReadLine();
                        input = input.Trim().ToLower();
                    }

                    if (input == "yes")
                    {
                        string home = LookupTable(town, students[student]);
                        Console.WriteLine(students[student] + " is from " + home + ".");
                    }
                }
                loop = TryAgain();
                if (loop == false)
                {
                    Exit();
                }
            }

        }
        public static int SelectStudent()
        {
            int number = 0;

            while (number < 1 || number > 6)
            {
                Console.WriteLine("Which class member would you like to know about? (Enter: 1-6).");
                Console.WriteLine("1: Tommy Waalkes");
                Console.WriteLine("2: Albert Ngoudjou");
                Console.WriteLine("3: Jake Collins");
                Console.WriteLine("4: Austin Powel");
                Console.WriteLine("5: Dylan Rule");
                Console.WriteLine("6: Andrew Waltman");
                string response = Console.ReadLine();
                number = int.Parse(response);
            }
            number--;
            return number;
        }

        public static string LookupTable(Hashtable table, string key)
        {
            string answer;
            answer = table[key].ToString();
            return answer;
        }

        public static bool TryAgain()
        {
            string input;
            Console.WriteLine("Would you like to look up another class member? (Enter: Yes or No).");
            input = Console.ReadLine();
            input = input.Trim().ToLower();

            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Invalid Input, please try again.");
                input = Console.ReadLine();
                input = input.Trim().ToLower();
            }

            if (input == "yes" )
                {
                return true;
                }
            else
            {
                return false;
            }
        }
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the Grand Circus Database System. Goodbye");
            Environment.Exit(1);
        }
    }
}
