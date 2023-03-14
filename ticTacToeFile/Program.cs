public class Solution
{
    static char[,] ticTacToeBoard = new char[3, 3]; 
    static char numberOfPlayers;




    public static void Main(string[] args)
    {


        bool gameEnded = false;



        while (!gameEnded)
        {
            Dictionary<char, (int, int)> myDict = new Dictionary<char, (int, int)>();
            myDict['1'] = (0, 0);
            myDict['2'] = (0, 1);
            myDict['3'] = (0, 2);
            myDict['4'] = (1, 0);
            myDict['5'] = (1, 1);
            myDict['6'] = (1, 2);
            myDict['7'] = (2, 0);
            myDict['8'] = (2, 1);
            myDict['9'] = (2, 2);
            int gameCounter = 0;

            System.Console.WriteLine("How many players are there?(1 or 2)");
            while (true)
            {
                ConsoleKeyInfo pickANum = Console.ReadKey();
                Console.Clear();
                numberOfPlayers = pickANum.KeyChar;
                if (numberOfPlayers != '1' && numberOfPlayers != '2')
                {
                    System.Console.WriteLine("Please select a valid option.");

                }
                else
                {
                    break;
                }

            }

            switch (numberOfPlayers)
            {
                case '1':
                    // scope couldn't access gameCounter
                    System.Console.WriteLine("Please enter your name.");
                    string name = Console.ReadLine();
                    initializeBoard(ticTacToeBoard);
                    while (true)
                    {




                        displayHelperMatrix();
                        drawBoard(ticTacToeBoard);
                        Console.WriteLine($"{name}: X, choose your position.");

                        while (true)
                        {
                            ConsoleKeyInfo pickAChar = Console.ReadKey();
                            Console.Clear();
                            if (pickAChar.KeyChar.GetType() != typeof(char))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name}: X, Please select a valid character");
                                continue;
                            }
                            char playerXInput = pickAChar.KeyChar;
                            if (!myDict.ContainsKey(playerXInput))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name}: X, Please select a existing character");
                                continue;
                            }
                            if (alreadyContains(myDict, ticTacToeBoard, playerXInput))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name}: X, Please select an empty spot");
                                continue;
                            }
                            else
                            {
                                (int, int) pairOfNumbers = myDict[playerXInput];
                                ticTacToeBoard[pairOfNumbers.Item1, pairOfNumbers.Item2] = 'x';
                                gameCounter++;
                                break;
                            }
                        }
                        if (gameCounter == 9)
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine("It is a tie.");
                            break;
                        }
                        if (checkBoard(ticTacToeBoard))
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine($"{name} won!");
                            break;
                        }
                        displayHelperMatrix();
                        drawBoard(ticTacToeBoard);
                        System.Console.WriteLine("It is the computer\'s turn");
                        computerPlayer(myDict, ticTacToeBoard);
                        if (gameCounter == 9)
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine("It is a tie.");
                            break;
                        }
                        if (checkBoard(ticTacToeBoard))
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine($"The computer won!");
                            break;
                        }


                    }
                    break;

                case '2':
                    System.Console.WriteLine("Player 1, please enter your name.");
                    string name1 = Console.ReadLine();
                    System.Console.WriteLine("Player 2, please enter your name.");
                    string name2 = Console.ReadLine();

                    initializeBoard(ticTacToeBoard);
                    while (true)
                    {




                        displayHelperMatrix();
                        drawBoard(ticTacToeBoard);
                        Console.WriteLine($"{name1}: X, choose your position.");

                        while (true)
                        {
                            ConsoleKeyInfo pickAChar = Console.ReadKey();
                            Console.Clear();
                            if (pickAChar.KeyChar.GetType() != typeof(char))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name1}: X, Please select a valid character");
                                continue;
                            }
                            char playerXInput = pickAChar.KeyChar;
                            if (!myDict.ContainsKey(playerXInput))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name1}: X, Please select a existing character");
                                continue;
                            }
                            if (alreadyContains(myDict, ticTacToeBoard, playerXInput))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name1}: X, Please select an empty spot");
                                continue;
                            }
                            else
                            {
                                (int, int) pairOfNumbers = myDict[playerXInput];
                                ticTacToeBoard[pairOfNumbers.Item1, pairOfNumbers.Item2] = 'x';
                                gameCounter++;
                                break;
                            }
                        }
                        if (gameCounter == 9)
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine("It is a tie.");
                            break;
                        }
                        if (checkBoard(ticTacToeBoard))
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine($"{name1} won!");
                            break;
                        }
                        displayHelperMatrix();
                        drawBoard(ticTacToeBoard);
                        Console.WriteLine($"{name2}: O, choose your position.");
                        while (true)
                        {
                            ConsoleKeyInfo pickAChar = Console.ReadKey();
                            Console.Clear();
                            if (pickAChar.KeyChar.GetType() != typeof(char))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name2}: O, Please select a valid character");
                                continue;
                            }
                            char playerXInput = pickAChar.KeyChar;
                            if (!myDict.ContainsKey(playerXInput))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name2}: O, Please select a existing character");
                                continue;
                            }
                            if (alreadyContains(myDict, ticTacToeBoard, playerXInput))
                            {
                                displayHelperMatrix();
                                drawBoard(ticTacToeBoard);
                                Console.WriteLine($"{name2}: O, Please select an empty spot");
                                continue;
                            }
                            else
                            {
                                (int, int) pairOfNumbers = myDict[playerXInput];
                                ticTacToeBoard[pairOfNumbers.Item1, pairOfNumbers.Item2] = 'o';
                                gameCounter++;
                                break;
                            }
                        }
                        if (gameCounter == 9)
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine("It is a tie.");
                            break;
                        }
                        if (checkBoard(ticTacToeBoard))
                        {
                            drawBoard(ticTacToeBoard);

                            System.Console.WriteLine($"{name2} won!");
                            break;
                        }


                    }
                    break;
                default:
                    break;
            }
            while (true)
            {
                System.Console.WriteLine("Would you like to continue or exit?\n" +
                "1. Continue\n" +
                "2. Exit");
                char gameContinuation = Console.ReadKey().KeyChar;
                Console.Clear();
                if (gameContinuation == '1')
                {
                    gameEnded = false;
                    break;
                }
                else if (gameContinuation == '2')
                {
                    gameEnded = true;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Please choose a valid option");
                }
            }
            // initializeBoard(ticTacToeBoard);

            // while (true)
            // {

            //     displayHelperMatrix();
            //     drawBoard(ticTacToeBoard);
            //     Console.WriteLine("Player X, choose your position.");

            //     while (true)
            //     {
            //         ConsoleKeyInfo pickAChar = Console.ReadKey();
            //         Console.Clear();
            //         if (pickAChar.KeyChar.GetType() != typeof(char))
            //         {
            //             displayHelperMatrix();
            //             drawBoard(ticTacToeBoard);
            //             Console.WriteLine("X, Please select a valid character");
            //             continue;
            //         }
            //         char playerXInput = pickAChar.KeyChar;
            //         if (!myDict.ContainsKey(playerXInput))
            //         {
            //             displayHelperMatrix();
            //             drawBoard(ticTacToeBoard);
            //             Console.WriteLine("X, Please select a existing character");
            //             continue;
            //         }
            //         if (alreadyContains(myDict, ticTacToeBoard, playerXInput))
            //         {
            //             displayHelperMatrix();
            //             drawBoard(ticTacToeBoard);
            //             Console.WriteLine("X, Please select an empty spot");
            //             continue;
            //         }
            //         else
            //         {
            //             (int, int) pairOfNumbers = myDict[playerXInput];
            //             ticTacToeBoard[pairOfNumbers.Item1, pairOfNumbers.Item2] = 'x';
            //             gameCounter++;
            //             break;
            //         }
            //     }
            //     if (gameCounter == 9)
            //     {
            //         drawBoard(ticTacToeBoard);
            //         System.Console.WriteLine("It is a tie.");
            //         break;
            //     }
            //     if (checkBoard(ticTacToeBoard))
            //     {
            //         drawBoard(ticTacToeBoard);
            //         System.Console.WriteLine("X won!");
            //         break;
            //     }
            //     displayHelperMatrix();
            //     drawBoard(ticTacToeBoard);

            //     Console.WriteLine("Player O, choose your position.");

            //     while (true)
            //     {
            //         ConsoleKeyInfo pickAChar = Console.ReadKey();
            //         Console.Clear();
            //         if (pickAChar.KeyChar.GetType() != typeof(char))
            //         {
            //             displayHelperMatrix();
            //             drawBoard(ticTacToeBoard);
            //             Console.WriteLine("O, Please select a valid character");
            //             continue;
            //         }
            //         char playerOInput = pickAChar.KeyChar;
            //         if (!myDict.ContainsKey(playerOInput))
            //         {
            //             displayHelperMatrix();
            //             drawBoard(ticTacToeBoard);
            //             Console.WriteLine("O, Please select a existing character");
            //             continue;
            //         }
            //         if (alreadyContains(myDict, ticTacToeBoard, playerOInput))
            //         {
            //             displayHelperMatrix();
            //             drawBoard(ticTacToeBoard);
            //             Console.WriteLine("O, Please select an empty spot");
            //             continue;
            //         }
            //         else
            //         {
            //             (int, int) pairOfNumbers = myDict[playerOInput];
            //             ticTacToeBoard[pairOfNumbers.Item1, pairOfNumbers.Item2] = 'o';
            //             gameCounter++;
            //             break;
            //         }
            //     }
            //     if (gameCounter == 9)
            //     {
            //         drawBoard(ticTacToeBoard);
            //         System.Console.WriteLine("It is a tie.");
            //         break;
            //     }
            //     if (checkBoard(ticTacToeBoard))
            //     {
            //         drawBoard(ticTacToeBoard);
            //         System.Console.WriteLine("O won!");
            //         break;
            //     }
            // }

            // System.Console.WriteLine("Would you like to continue or exit?");
            // string gameContinuation = Console.ReadLine();
            // Console.Clear();
            // if (gameContinuation == "continue")
            // {
            //     gameEnded = false;
            // }
            // else
            // {
            //     gameEnded = true;
            // }

            // while (true)
            // {
            //     System.Console.WriteLine("Would you like to continue or exit?");
            //     string gameContinuation = Console.ReadLine();
            //     Console.Clear();
            //     if (gameContinuation == "continue")
            //     {
            //         gameEnded = false;
            //         break;
            //     }
            //     else
            //     {
            //         gameEnded = true;
            //     }
            // }

        }

    }

    public static bool alreadyContains(Dictionary<char, (int, int)> myList, char[,] myArray, char myChar)
    {

        (int, int) placeHolder = myList[myChar];
        if (myArray[placeHolder.Item1, placeHolder.Item2] != ' ')
        {
            return true;
        }
        return false;
    }

    public static void initializeBoard(char[,] myArray)
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                myArray[r, c] = ' ';
            }
        }
    }
    public static void displayHelperMatrix()
    {
        System.Console.WriteLine("Helper Board\n" +
        "1 | 2 | 3\n" +
        "----------\n" +
        "4 | 5 | 6\n" +
        "----------\n" +
        "7 | 8 | 9\n");
    }
    public static void drawBoard(char[,] myArray)
    {
        System.Console.WriteLine
           ($"{myArray[0, 0]} | {myArray[0, 1]} | {myArray[0, 2]}\n" +
            $"---------\n" +
            $"{myArray[1, 0]} | {myArray[1, 1]} | {myArray[1, 2]}\n" +
            $"---------\n" +
            $"{myArray[2, 0]} | {myArray[2, 1]} | {myArray[2, 2]}\n"
            );
    }
    public static void computerPlayer(Dictionary<char, (int, int)> myList, char[,] myArray)
    {
        while (true)
        {
            Random random = new Random();
            int rng = random.Next(1, 10);

            char Num = (char)('0' + rng);

            if (alreadyContains(myList, myArray, Num))
            {
                continue;
            }

            else
            {
                (int, int) placeHolder = myList[Num];
                myArray[placeHolder.Item1, placeHolder.Item2] = 'o';
                System.Console.WriteLine("The computers turn is over.");
                break;
            }
        }
    }
    public static bool checkBoard(char[,] myArray)
    {
        if ((myArray[0, 0] == 'x' && myArray[0, 1] == 'x' && myArray[0, 2] == 'x') || (myArray[0, 0] == 'o' && myArray[0, 1] == 'o' && myArray[0, 2] == 'o'))
        {
            return true;
        }
        else if ((myArray[1, 0] == 'x' && myArray[1, 1] == 'x' && myArray[1, 2] == 'x') || (myArray[1, 0] == 'o' && myArray[1, 1] == 'o' && myArray[1, 2] == 'o'))
        {
            return true;
        }
        else if ((myArray[2, 0] == 'x' && myArray[2, 1] == 'x' && myArray[2, 2] == 'x') || (myArray[2, 0] == 'o' && myArray[2, 1] == 'o' && myArray[2, 2] == 'o'))
        {
            return true;
        }
        else if ((myArray[0, 0] == 'x' && myArray[1, 1] == 'x' && myArray[2, 2] == 'x') || (myArray[0, 0] == 'o' && myArray[1, 1] == 'o' && myArray[2, 2] == 'o'))
        {
            return true;
        }
        else if ((myArray[0, 0] == 'x' && myArray[1, 0] == 'x' && myArray[2, 0] == 'x') || (myArray[0, 0] == 'o' && myArray[1, 0] == 'o' && myArray[2, 0] == 'o'))
        {
            return true;
        }
        else if ((myArray[0, 1] == 'x' && myArray[1, 1] == 'x' && myArray[2, 1] == 'x') || (myArray[0, 1] == 'o' && myArray[1, 1] == 'o' && myArray[2, 1] == 'o'))
        {
            return true;
        }
        else if ((myArray[0, 2] == 'x' && myArray[1, 2] == 'x' && myArray[2, 2] == 'x') || (myArray[0, 2] == 'o' && myArray[1, 2] == 'o' && myArray[2, 2] == 'o'))
        {
            return true;
        }
        else if ((myArray[0, 2] == 'x' && myArray[1, 1] == 'x' && myArray[2, 0] == 'x') || (myArray[0, 2] == 'o' && myArray[1, 1] == 'o' && myArray[2, 0] == 'o'))
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}
