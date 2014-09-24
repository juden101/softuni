using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] board = new int[8, 4];
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            string[] directions = Console.ReadLine().Split(',');
            int position =  Convert.ToInt32(directions[0]);

            if(board[0, position] == 0)
            {
                board[0, position] = 1;
            }
            else
            {
                board[0, position] = 0;
            }

            for (int j = 1; j < 8; j++)
            {
                if (directions[j].Trim() == "-1")
                {
                    position--;

                    if(board[j, position] == 0)
                    {
                        board[j, position] = 1;
                    }
                    else if (board[j, position] == 1)
                    {
                        board[j, position] = 0;
                    }
                }
                else if (directions[j].Trim() == "0")
                {
                    if (board[j, position] == 0)
                    {
                        board[j, position] = 1;
                    }
                    else if (board[j, position] == 1)
                    {
                        board[j, position] = 0;
                    }
                }
                else if (directions[j].Trim() == "+1")
                {
                    position++;

                    if (board[j, position] == 0)
                    {
                        board[j, position] = 1;
                    }
                    else if (board[j, position] == 1)
                    {
                        board[j, position] = 0;
                    }
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            string rowBinary = "";

            for (int j = 0; j < 4; j++)
            {
                rowBinary += board[i, j].ToString();
            }

            sum += Convert.ToInt32(rowBinary, 2);
        }

        Console.WriteLine(Convert.ToString(sum, 2));
        Console.WriteLine(Convert.ToString(sum, 16).ToUpper());
    }
}