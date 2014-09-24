using System;

class Program
{
    static void Main()
    {
        string secretNumber = Console.ReadLine();
        int targetBulls = int.Parse(Console.ReadLine());
        int targetCows = int.Parse(Console.ReadLine());
        bool solutionFound = false;

        for (int i1 = 1; i1 <= 9; i1++)
        {
            for (int i2 = 1; i2 <= 9; i2++)
            {
                for (int i3 = 1; i3 <= 9; i3++)
                {
                    for (int i4 = 1; i4 <= 9; i4++)
                    {
                        string currentNumber = "" + i1 + i2 + i3 + i4;
                        char[] digits = currentNumber.ToCharArray();
                        char[] guess = secretNumber.ToCharArray();
                        int bulls = 0;
                        int cows = 0;

                        for (int i = 0; i < guess.Length; i++)
                        {
                            if (guess[i] == digits[i])
                            {
                                bulls++;
                                guess[i] = '*';
                                digits[i] = '@';
                            }
                        }

                        for (int guessIndex = 0; guessIndex < guess.Length; guessIndex++)
                        {
                            for (int digitsIndex = 0; digitsIndex < digits.Length; digitsIndex++)
                            {
                                if (guess[guessIndex] == digits[digitsIndex])
                                {
                                    cows++;
                                    guess[guessIndex] = '*';
                                    digits[digitsIndex] = '@';
                                }
                            }
                        }

                        if (bulls == targetBulls && cows == targetCows)
                        {
                            if (solutionFound)
                            {
                                Console.Write(" ");
                            }
                            Console.Write(currentNumber);
                            solutionFound = true;
                        }
                    }
                }
            }
        }

        if(!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}
