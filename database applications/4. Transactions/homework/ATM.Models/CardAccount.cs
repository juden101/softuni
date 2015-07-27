namespace ATM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CardAccount
    {
        public CardAccount()
        {
        }

        public CardAccount(string cardNumber, string cardPin, decimal money)
        {
            this.CardNumber = cardNumber;
            this.CardPin = cardPin;
            this.Money = money;
        }

        [Key]
        public int Id { get; private set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; private set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string CardPin { get; private set; }

        [Required]
        [ConcurrencyCheck]
        public decimal Money { get; set; }
    }
}