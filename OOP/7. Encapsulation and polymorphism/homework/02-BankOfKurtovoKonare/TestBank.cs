using System;

class TestBank
{
    static void Main()
    {
        Account Ivan = new DepositAccount("Ivan", 975.34, 5.3, AccountType.Individual);
        Console.WriteLine(Ivan.CalculateInterest(12).ToString("f2"));
        Console.WriteLine();

        Account Peter = new DepositAccount("Peter", 1637.94, 1.3, AccountType.Individual);
        Console.WriteLine(Peter.CalculateInterest(12).ToString("f2"));
        Console.WriteLine();

        Account Misho = new MortgageAccount("Misho", 4457.23, 7.3, AccountType.Individual);
        Console.WriteLine(Misho.CalculateInterest(12).ToString("f2"));
        Console.WriteLine();
    }
}