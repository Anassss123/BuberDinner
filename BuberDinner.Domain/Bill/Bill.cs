using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Bill
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public float Price { get; }    
        private Bill(BillId billId, DinnerId dinnerID , GuestId guestId, HostId hostId , float price ) : base(billId)
        {
            
        }

    }
}