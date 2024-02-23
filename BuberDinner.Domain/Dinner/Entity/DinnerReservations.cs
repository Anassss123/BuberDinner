using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entity
{
    public class DinnerReservations : Entity<DinnerReservationsId>
    {
        public string Name { get; } = null!;
        public string Description { get; } = null!;
        private DinnerReservations(DinnerReservationsId dinnerReservationsId, int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime)
            : base(dinnerReservationsId)
        {
            
        }
        public static DinnerReservations Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime )
        {
            return new(DinnerReservationsId.CreateUnique() ,guestCount, reservationStatus,guestId, billId, createdDateTime, updatedDateTime);
        }
    }
}