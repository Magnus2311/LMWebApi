using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMWebApi.Common.Models.Database
{
    public class ShopItemFeedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Rating { get; set; }

        public string Feedback { get; set; }

        public DateTime Date { get; set; }

        public int ShopItemId { get; set; }
        public ShopItem ShopItem { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
