using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airline_res_sys
{
    internal class Program
    { 
        static void Main()
        {
            int seatsFirst, seatsEconomy, reserve, i = 0, j = 6;
            bool[] seats = { false, false, false, false, false,
                         false, false, false, false, false }; // seating chart 
            Console.WriteLine("Welcome to Airline Reservation System."); // greet the user 

            while (true)
            {
                Console.WriteLine("There are " + checkFirstClass(out seatsFirst, seats) + " first class seats and " + checkEconomy(out seatsEconomy, seats) + " economy seats."); // check available seats
                Console.WriteLine("Please enter 1 to reserve a first class seat or enter 2 to reserve an economy class seat or 0 to exit"); // promt user for input 
                reserve = Convert.ToInt32(Console.ReadLine()); // input from user
                if (reserve == 1)
                {
                    if (i > 5 || i == 5)
                    {
                        Console.WriteLine("There are no first class seats available. Would you like an economy class seat? Type 2 for yes and 0 to exit.");
                        reserve = Convert.ToInt32(Console.ReadLine()); // RIGHT HERE I WOULD LIKE THE PROGRAM TO GO BACK TO THE INITIAL IF STATEMENT AND CHECK THE CONDITIONS. ANY ADVICE? 
                    }
                    else reserveFirstSeat(ref seats, ref i); // reserve first class seat
                }
                else if (reserve == 2)
                {
                    if (j < 5 || j > 10)
                    {
                        Console.WriteLine("There are no economy seats available. Would you like a first class seat? Type 1 for yes and 0 to exit.");
                        reserve = Convert.ToInt32(Console.ReadLine()); // RIGHT HERE I WOULD LIKE THE PROGRAM TO GO BACK TO THE INITIAL IF STATEMENT AND CHECK THE CONDITIONS. ANY ADVICE? 
                    }
                    else reserveEconomySeat(ref seats, ref j); // reserve economy class seat
                }
                else if (reserve == 0)
                {
                    Console.WriteLine("Next flight leaves in three hours."); // ALSO, I WANT TO ADD HOW MANY FIRST CLASS TICKETS WERE RESERVED IF ANY AND SAME THING FOR ECONO CLASS BUT I'M NOT SURE HOW TO KEEP TRACK OF IT. ANY ADVICE?
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }


            }
        }



        public static int checkFirstClass(out int seatsFirst, bool[] seats) // method to check available First Class seats
        {
            seatsFirst = 0;
            for (int i = 0; i < 5; i++)
            {
                if (seats[i] == false)
                    seatsFirst++;
            }

            return seatsFirst;
        }

        public static int checkEconomy(out int seatsEconomy, bool[] seats) // method to check available Economy seats
        {
            seatsEconomy = 0;
            for (int i = 5; i < 10; i++)
            {
                if (seats[i] == false)
                    seatsEconomy++;
            }

            return seatsEconomy;
        }

        public static void reserveFirstSeat(ref bool[] seats, ref int i) // reserve selected first class seat 
        {


            if (i < 5)
            {
                if (seats[i] == false)
                {
                    seats[i] = true;
                    Console.WriteLine("You have successfully reserved a first class seat");
                }
            }
            ++i;

        }

        public static void reserveEconomySeat(ref bool[] seats, ref int j) // reserve selected economy class seat
        {
            if (j > 5 || j == 5 || j < 10)
            {
                if (seats[j] == false)
                {
                    seats[j] = true;
                    Console.WriteLine("You have successfully reserved an economy class seat");

                }
            }
            ++j;

        }
    }

}
