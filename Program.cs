using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tic_Tac_Toe_Game
{

    //Connor Sidwell
    class Program
    {

        static char[,] pSpace = new char[3, 3];
        static int x;
        static int y;
        static int t;
        static int c;
        static int d;
        static string myvalue;
        static char done;
        


        static void Main(string[] args)
        {// ---------Main Start---------

            string name;
            //Start of the program where the program moves into different functions and collects the instructions.
            Console.Clear();
            first_screen();

            Console.Clear();
            name = welcome();

            Initialize_Array();
            
            //does a loop constantly to keep the game running without the loop it would only do the game moves once because it follows an order. 
            do
            {// ---------DO WHILE Begin---------

                Display_Array();

                get_player_move();

                done = check_emptycell();

                //Checks the function check_emptycell to see what the value of done is and depending on the outcome does a certain instruction based on what it is.
                if (done == 'd')
                {// ---------IF ELSE Begin---------
                    Display_Array();
                    break;
                }
                else
                {
                    done = check_down();
                }// ---------IF ELSE End---------

                if (done != ' ')
                {// ---------IF ELSE Begin---------
                    break;
                }      
                else
                {
                    Display_Array();
                    get_computers_move();
                    done = check_down();
                    Console.Clear();
                }// ---------IF ELSE End---------

                if (done != ' ')
                {// ---------IF Begin---------
                    Display_Array();
                    break;

                }// ---------IF End---------

               

            } while (done == ' ');// ---------DO WHILE End---------

            //Checks to see what the outcome of done is if it is not equal to ' ' by the end of the loop.
            // If it is equal to o it will display the array
            if (done == 'o')
            {// ---------IF Begin---------
                Display_Array();
            }// ---------IF End---------
            // If done is equal to d then it counts as a draw
            if (done == 'd')
            {// ---------IF ELSE Begin---------
                Console.WriteLine("No Winner, Its a draw!");
                Console.WriteLine("Would you like to play again?");
            }
            //If done is not equal to d then the winner is whatever value is inside done
            else
            {
                Console.WriteLine("The Winner is {0}", done);
                Console.Read();
                Console.Clear();
                if (done == 'X')//---------Nested IF, if the player wins it will show the players name instead of just X---------
                {
                    Console.WriteLine("Congratulations {0}, You are the winner your name will be put into the Scores list thank you for playing", name);
                    ScoreBoard(name);
                    Console.ReadKey();
                }
                //Console.ReadLine();
            }// ---------IF ELSE End---------
                Console.ReadLine();
        

        }// ---------Main End---------

        //Initializing the array this has a for loop that creates a 3 x 3 grid by adding to the values until they are both equal to 3
        static void Initialize_Array()
        {// ---------Initialize Start---------

            for (c = 0; c < 3; c++)
            {// ---------FOR Begin---------
                for (d = 0; d < 3; d++)
                {
                    pSpace[c, d] = (' ');
                }
            }// ---------FOR End---------
        }// ---------Initialize End---------


        /*This function displays the array its the same princable as the initialize it just loops until it has a 3 x 3 grid but instead it uses the array to
        print out a 3 x 3 grid*/
        static void Display_Array()
        {// ---------Display Start---------

            for (t = 0; t < 3; t++)
            {// ---------FOR Begin---------
                Console.WriteLine(" {0} | {1} | {2} ", pSpace[t, 0], pSpace[t, 1], pSpace[t, 2]);

                if (t != 2)
                {
                    Console.WriteLine("\n---+---+---\n");

                }
            }// ---------FOR End---------

            Console.WriteLine("\n");

        }// ---------Display End---------


        //This function asks the user to enter a row and column and then converts them into int's so that they can be used in the global array.
        static void get_player_move()
        {// ---------Player Move Start---------

            Console.Write("Please enter row for X:");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("please enter a column for X:");
            y = Convert.ToInt32(Console.ReadLine());


            pSpace[x, y] = ('X');
        }// ---------Player Move End---------


        /*Same as player move but it checks for a space if the player has already put something in the space the computer chooses it will find another space
         It does this by checking if the space is equal to ' '*/
        static void get_computers_move()
        {// ---------Computer Move Start---------
            for (x = 0; x < 2; x++)
            {// ---------FOR Begin---------
                for (y = 0; y < 2; y++)
                {
                    if (pSpace[x, y] == (' '))
                    {
                        break;
                    }
                }

                if (pSpace[x, y] == (' '))
                {
                    break;
                }
            }// ---------FOR End---------

            if ((x * y) > 4)
            {// ---------IF ELSE Begin---------
                done = ('d');
            }
            else
            {
                pSpace[x, y] = ('O');
            }// ---------IF ELSE End---------



        }// ---------Computer Move End---------

        /* The check down is the win check condition it checks every space on the array for something if all 3 are taken up by either X or 0 it sends it back
         to the main and gives the win condition*/
        static char check_down()
        {// ---------Check Down Start---------

            for (c = 0; c < 3; c++)
            {// ---------FOR Begin---------
                if (pSpace[0, c] == pSpace[1, c] && pSpace[0, c] == pSpace[2, c])//---------Verticle Win Condition---------
                {
                    return pSpace[0, c];
                }
                else if (pSpace[c, 0] == pSpace[c, 1] && pSpace[c, 0] == pSpace[c, 2])//---------Horizontal Win Condition---------
                {
                    return pSpace[c, 0];
                }

                else if (pSpace[c, 0] == pSpace[1, 1] && pSpace[c, 0] == pSpace[2, 2])//---------Diagonal Win Condition---------
                {
                    return pSpace[c, 0];
                }
                else if (pSpace[0, c] == pSpace[1, 1] && pSpace[0, c] == pSpace[2, 2])//---------Diagonal Win Condition---------
                {
                    return pSpace[c, 0];
                }

            }// ---------FOR End---------

            return ' ';

        }// ---------Check Down End---------

        /*This function checks the array for empty cells if the spaces in the array are empty it returns the value as ' ' if they all have something in them
         then it will return d*/
        static char check_emptycell()
        {// ---------Check Emptycell Start---------

            for (c = 0; c < 3; c++)
            {// ---------FOR Begin---------
                if (pSpace[c, 0] == ' ')
                {
                    return ' ';
                }
                else if (pSpace[c, 1] == (' '))
                {
                    return ' ';
                }
                else if (pSpace[c, 1] == (' '))
                {
                    return ' ';
                }
            }// ---------FOR End---------



            return 'd';
        }// ---------Check Emptycell End---------

        //This is just the start scren it tells the player what the game is and asks them to press enter.
        static void first_screen()
        {// ---------Check First Screen Start---------

            do
            {
                Console.Clear();
                Console.SetCursorPosition(4, 8);
                Console.WriteLine("This is a Noughts and Crosses game you can play against the computer");
                Console.SetCursorPosition(16, 9);
                Console.WriteLine("Please press enter to continue");
                myvalue = Console.ReadLine();

            } while (myvalue != (""));

        }// ---------Check First Screen End---------

        // This is the welcome screen where the player enters a name and is asked if they want to see instructions.
        static string welcome()
        {
            string Pname;
            string instructions;

            do
            {
                Console.SetCursorPosition(16, 9);
                Console.Write("Please enter a name:");
                Console.SetCursorPosition(37, 9);
                Pname = Console.ReadLine();
            } while (Pname == (""));

            Console.Clear();
            Console.SetCursorPosition(12, 0);

            Console.WriteLine("Hello {0}, Welcome to Noughts and Crosses.\n               If you would like to view instructions please press y", Pname);
            Console.WriteLine("Otherwise just press enter");
            instructions = Console.ReadLine();

            if (instructions == "y" || instructions == "Y")
            {
                Instructions();
            }
           

           

            return Pname;

        }

        // This is the scores Function where the file writer writes the final score into a seperate text document.
        static void ScoreBoard(string winner)
        {

            

                FileInfo fleScores = new FileInfo("Scores.txt");

                StreamWriter swScores = null;

                string score;
                score = winner;


                if (fleScores.Exists == true)
                {
                    swScores = fleScores.AppendText();
                }
                else
                {
                    swScores = fleScores.CreateText();
                }


               

                swScores.WriteLine(winner);
                swScores.Flush();
                swScores.Close();

                Console.Clear();

                StreamReader swrScores = File.OpenText("Scores.txt");

                Console.WriteLine("The total scores including yours are");

                while ((score = swrScores.ReadLine()) != null)
                {

                    Console.WriteLine(winner);
                }

                swrScores.Close();

                Console.ReadLine();
            

        }
        // This is the instructions page that displays all of the instructions
        static void Instructions()
        {
            Console.Clear();
            Console.WriteLine("This is a Tic-Tac Toe Game");
            Console.WriteLine("The game starts with an empty 3 x 3 grid");
            Console.WriteLine("To enter a move you must first type the Row cooridinates an example would be 0 /n This would enter a move on the first row");
            Console.WriteLine("Then do the same for the column so 0 for example would enter the player move on the first row in the first column");
            Console.WriteLine("Once you have done this the computer will make a move and you will be re-prompted if the game has not already been won");
            Console.WriteLine("The win condition for the game is to get three in a row so as a player you are X so getting 3 in a row or column or diagonaly /n will win you the game.");
            Console.WriteLine("Press any Key to continue to the game");
            Console.ReadLine();
            Console.Clear();

        }




    }
}
