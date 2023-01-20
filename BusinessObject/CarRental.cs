using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessObject
{
    public partial class CarRental
    {
        public string CustomerId { get; set; }
        public string CarId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal? RentPrice { get; set; }
        [NotMapped]
        public decimal? TotalPrice {
            get
            {
                return RentPrice * (ReturnDate - PickupDate).Days;
            }
         }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
