using System;

class Program
{
    static void Main()
    {
        for (int i = 2; i < 15; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                string card = i < 11 ? i.ToString() : (i == 11 ? "J" : (i == 12 ? "Q" : (i == 13 ? "K" : "A")));

                switch (j)
                {
                    case 0:
                        Console.Write("{0}♣ ", card);
                        break;
                    case 1:
                        Console.Write("{0}♦ ", card);
                        break;
                    case 2:
                        Console.Write("{0}♥ ", card);
                        break;
                    case 3:
                        Console.Write("{0}♠ \n", card);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}