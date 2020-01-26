using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab8
{
    class Program
    {
        //Create collections so all methods can access them
        static List<string> students = new List<string>();
        static Hashtable town = new Hashtable();
        static Hashtable food = new Hashtable();
        
        static void Main()
        {
            string student;
            string input;
            bool loop = true;
            
            //Add data + key/value pairs into tables
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

            //Continuation loop which allows for lookup of multiple students
            while (loop == true)
            {
                student = SelectStudent();

                //Prompts user to select student again if the first attempt failed. Will continue to do so until a valid input is recieved
                while (student == "error")
                {
                    student = SelectStudent();
                }

                Console.WriteLine("You have selected " + student + ". What would you like to know about " + student + "? (Enter: Hometown or Favorite Food).");
                input = UserInput();

                //Data validation for selection of member fact
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

                    //Nested if allows for program to determine the opposite table to look up after the first without asking
                    //table should be selected
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
                
                //calls method to ask if the user would like to search for another class member
                loop = TryAgain();
                
                //calls exit method to successfully exit the program
                if (loop == false)
                {
                    Exit();
                }
            }
        }
        
        //Returns class member name as a string.
        public static string SelectStudent()
        {
            int number;
            string response;
            string output = "error";

            //String concatenation shows max number of strings in students[] so it can scale
            Console.WriteLine("Which class member would you like to know about? (Enter: 1-" + students.Count + ").");
            //displays all members within students[]
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + students[i]);
            }

            response = UserInput();
            //uses exceptions to validate user response without crashing the program due to int.parse()
            try
            {
                number = int.Parse(response);
                number--;
                output = students[number];
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input. Please only enter an integer between 1 and " + students.Count);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Incorrect Integer. Please only enter an integer between 1 and " + students.Count);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please only enter an integer between 1 and " + students.Count);
            }
            //if exception is caught, returns "error" and prompts again due to while loop above
            return output;
        }

        //method to check hashtables for factoids about member selected
        public static string LookupTable(Hashtable table, string key)
        {
            string answer;
            answer = table[key].ToString();
            return answer;
        }

        //method to ask user if they would like to continue
        public static bool TryAgain()
        {
            string input;
            Console.WriteLine("Would you like to look up another class member? (Enter: Yes or No).");
            input = UserInput();

            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Invalid Input, please choose Yes or No.");
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

        //Takes user input and automatically trims whitespace and converts to lowercase
        public static string UserInput()
        {
            string userInput;
            userInput = Console.ReadLine();
            userInput = userInput.Trim().ToLower();
            return userInput;
        }
        
        //Successfully exits the program upon user not wishing to continue
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the Grand Circus Database System. Goodbye");
            Environment.Exit(1);
        }
    }
}
