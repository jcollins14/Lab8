using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab8
{
    class Program
    {
        static List<string> students = new List<string>();
        static Hashtable town = new Hashtable();
        static Hashtable food = new Hashtable();
        static void Main()
        {
            string student;
            string input;
            bool loop = true;

            students.Add("Tommy Waalkes");
            students.Add("Albert Ngoudjou");
            students.Add("Jake Collins");
            students.Add("Austin Powel");
            students.Add("Dylan Rule");
            students.Add("Andrew Waltman");

            town.Add("Jake Collins", "Corona, CA");
            town.Add("Andrew Waltman", "Grand Rapids, MI");
            town.Add("Dylan Rule", "Newport, NH");
            town.Add("Austin Powel", "Blissfield, MI");
            town.Add("Tommy Waalkes", "Raleigh, NC");
            town.Add("Albert Ngoudjou", "Bafoussam, Camaroon");

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

                if (student == "error")
                {
                    student = SelectStudent();
                }

                Console.WriteLine("You have selected " + student + ". What would you like to know about " + student + "? (Enter: Hometown or Favorite Food).");
                input = UserInput();

                while (input != "favorite food" && input != "hometown")
                {
                    Console.WriteLine("I'm sorry, that data is not on file. Please try again. (Enter: Hometown or Favorite Food).");
                    input = UserInput();
                }

                if (input == "hometown")
                {
                    string home = LookupTable(town, student);
                    Console.WriteLine(student + " is from " + home + ".");
                    Console.WriteLine("Would you like to know more about " + student + "? (Enter: Yes or No).");
                    input = UserInput();

                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Invalid Input, please try again. (Enter: Yes or No).");
                        input = UserInput();
                    }

                    if (input == "yes")
                    {
                        string meal = LookupTable(food, student);
                        Console.WriteLine(student + "'s favorite food is " + meal + ".");
                    }
                }

                else if (input == "favorite food")
                {
                    string meal = LookupTable(food, student);
                    Console.WriteLine(student + "'s favorite food is " + meal + ".");
                    Console.WriteLine("Would you like to know more about " + student + "? (Enter: Yes or No).");
                    input = UserInput();

                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Invalid Input, please try again. (Enter: Yes or No).");
                        input = UserInput();
                    }

                    if (input == "yes")
                    {
                        string home = LookupTable(town, student);
                        Console.WriteLine(student + " is from " + home + ".");
                    }
                }
                loop = TryAgain();
                
                if (loop == false)
                {
                    Exit();
                }
            }

        }
        public static string SelectStudent()
        {
            int number;
            string response;
            string output = "error";

            Console.WriteLine("Which class member would you like to know about? (Enter: 1-6).");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + students[i]);
            }

            response = UserInput();
            try
            {
                number = int.Parse(response);
                number--;
                output = students[number];
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a valid number between 1-6");
                SelectStudent();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Selection. Please select a student again.");
                SelectStudent();
            }
            //catch (IndexOutOfRangeException)
            //{
            //    Console.WriteLine("Invalid Selection. Please select a student again.");
            //    SelectStudent();
            //}
            return output;
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
            input = UserInput();

            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Invalid Input, please try again.");
                input = UserInput();
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

        public static string UserInput()
        {
            string userInput = "";
            try
            {
                userInput = Console.ReadLine();
                userInput = userInput.Trim().ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                UserInput();
            }
            return userInput;
        }
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the Grand Circus Database System. Goodbye");
            Environment.Exit(1);
        }
    }
}
