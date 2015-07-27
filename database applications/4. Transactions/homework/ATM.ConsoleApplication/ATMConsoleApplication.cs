namespace ATM.ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Data;
    using System.Data.Entity.Validation;
    using System.Data;
    using System.Data.Entity.Infrastructure;

    public class ATMConsoleApplication
    {
        public static void Main()
        {
            var atmContext = new ATMContext();
            string card = "8949848946";
            string pin = "4892";
            decimal requestedSum = 60m;

            using (var dbContextTransaction = atmContext.Database.BeginTransaction())
            {
                try
                {
                    var cardAccount = atmContext.CardAccount
                        .Where(a => a.CardNumber == card && a.CardPin == pin)
                        .FirstOrDefault();

                    if (cardAccount == null)
                    {
                        throw new InvalidOperationException("Invalid card number or pin.");
                    }

                    cardAccount.Money -= requestedSum;
                    if (cardAccount.Money < 0)
                    {
                        throw new InvalidOperationException("There are not enough funds in your card.");
                    }

                    TransactionHistory currentTransaction = new TransactionHistory(
                        cardAccount.CardNumber,
                        DateTime.Now,
                        requestedSum);

                    atmContext.TransactionHistory.Add(currentTransaction);

                    atmContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (DbUpdateConcurrencyException exc)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine("Conflict! Try again.");
                }
                catch (DataException exc)
                {
                    Console.WriteLine("Invalid value!");
                }
                catch(InvalidOperationException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}