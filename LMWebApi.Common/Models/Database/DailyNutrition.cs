using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMWebApi.Common.Models.Database
{
    public class DailyNutrition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Weight { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}