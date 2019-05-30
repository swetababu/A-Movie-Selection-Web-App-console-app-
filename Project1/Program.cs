
// Project 1
// Purpose - Movie Selection App
// Created By - Sweta Saurabh Gupta (8252397)
// Date Created - 01 June 2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            // exception handling try-catch method begins
            try
            {

                // declaration of variables
                int age, film, no_of_films = 0;
                string again;
                bool isValid = true; // declare a boolean variable to check if the user enters correct film name or not

                // ask user how many films he wants to enter
                do
                {
                    try // try method to handle exception
                    {
                        Console.WriteLine("How many films you want to enter: ");
                        no_of_films = int.Parse(Console.ReadLine());
                        if (no_of_films == 0)
                        {
                            Console.WriteLine("You cannot enter 0 number of films. Please enter a valid number.");
                            Console.WriteLine("How many films you want to enter: ");
                            no_of_films = int.Parse(Console.ReadLine());
                        }
                    }
                   catch(Exception e) // catch block to handle if the user enter invalid input
                    {
                        Console.WriteLine("You can enter only number. Please enter a valid number.\n");
                        Console.WriteLine("How many films you want to enter: ");
                        no_of_films = int.Parse(Console.ReadLine());
                    }

                }
                while (no_of_films == 0); // loop will continue till user keep entering 0 number of films
                

                // declare an array for film names
                string[] film_names = new string[no_of_films];

                // read movie names from user
                
                    for (int i = 0; i < film_names.Length; i++)
                    {
                        int display_number = i + 1;
                        do
                        {
                            Console.WriteLine("Enter the name of the film number " + display_number + ": ");
                            film_names[i] = Console.ReadLine().Trim().ToUpper();

                            if (!(film_names[i].EndsWith("(U)") || film_names[i].EndsWith("(15)") || film_names[i].EndsWith("(12)") || film_names[i].EndsWith("(12A)") || film_names[i].EndsWith("(18)")))
                            {
                                Console.WriteLine("Film Name not valid. It should end with (U) / (15) / (12) / (12A) / (18) depending on the age criteria.. \n");
                                isValid = false;
                            }
                            else
                            {
                                isValid = true;
                            }
                        }
                        while (isValid == false);
                   
                    }

                // display movie names
                Console.WriteLine("\n\nWelcome to our Multiplex");
                Console.WriteLine("We are presently showing:");
                for (int i = 0; i < film_names.Length; i++)
                {
                    int display_number = i + 1;
                    Console.WriteLine(display_number + ". " + film_names[i]);
                }

                // get other values from user
                do
                {
                    do
                    {
                        Console.WriteLine("Enter the number of the film you want to see (between 1 to " + no_of_films + " ): "); // The film number entered must be between 1 to 5
                        film = int.Parse(Console.ReadLine());
                        if ((film < 1) || (film > no_of_films))
                        {
                            Console.WriteLine("This film number is invalid!\n"); // displays this message if the film number is invalid
                        }
                    }
                    while ((film < 1) || (film > no_of_films)); // loop to be executed if the user does not enter the correct film number

                    // get valid age from user
                    do
                    {
                        Console.WriteLine("Enter your age: "); // age must be in range from 5 to 120
                        age = int.Parse(Console.ReadLine());
                        if (age >= 120 || age <= 5)
                        {
                            Console.WriteLine("Please enter a valid age between 5 to 120.. ");
                            Console.WriteLine("Enter your age: "); // age must be in range from 5 to 120
                            age = int.Parse(Console.ReadLine());
                        }
                    }
                    while (age >= 120 || age <=5 ); // loop to be executed if the user does not enter the valid age

                    // check if the user age is valid or not to watch the film selected

                    if (age > 11 && (film_names[film - 1].EndsWith("(12)"))) // condition for (12) movies
                    {
                        
                        Console.WriteLine("Enjoy the film.");
                    }
                    else if (film_names[film - 1].EndsWith("(12A)") && age <= 11) // condition for (12A) movies
                    {
                        Console.WriteLine("Is the customer accompanied with some adult (Y/N)?");
                        string adult = Console.ReadLine().Trim().ToUpper();
                        if (adult == "Y")
                        {
                            Console.WriteLine("Enjoy the film.");
                        }
                        else
                        {
                            Console.WriteLine("Access Denied - You are too young.");
                        }
                    }
                    else if ((age > 4 && film_names[film - 1].EndsWith("(U)")) || (age > 14 && film_names[film - 1].EndsWith("(15)")) || (age > 17 && film_names[film - 1].EndsWith("(18)"))) // condition for (U) and (15) and (18) movies
                    {
                        Console.WriteLine("Enjoy the film.");
                    }
                    else
                    {
                        Console.WriteLine("Access Denied - You are too young.");
                    }

                    
                    Console.WriteLine("\n\nAnother Customer? (Press Y to continue and any other key to terminate.)"); // check if the user wants to continue for another customer
                    again = Console.ReadLine();
                    again = again.ToUpper(); // converts user entry to uppercase
                }
                while (again == "Y");
                Console.ReadKey();
            }
            // catch to handle the program if it terminates due to some error
            catch(Exception ex)
            {
                Console.WriteLine("The program got terminated due to an error! "); // displays this message when the program terminates
                Console.WriteLine(ex.Message); // error message
                Console.ReadKey();
            }
        }
    }
}




