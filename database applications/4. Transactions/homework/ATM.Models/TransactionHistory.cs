namespace ATM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class TransactionHistory
    {
        public TransactionHistory()
        {
        }

        public TransactionHistory(string cardNumber, DateTime transactionDate, decimal amount)
        {
            this.CardNumber = cardNumber;
            this.TransactionDate = transactionDate;
            this.Amount = amount;
        }

        [Key]
        public int Id { get; private set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; private set; }

        [Required]
        public DateTime TransactionDate { get; private set; }

        [Required]
        public decimal Amount { get; private set; }
    }
}