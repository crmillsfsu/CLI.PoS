using System;
using System.Collections.Generic;
using System.Text;

namespace Library.PoS.Model
{
    public class Table
    {
        /*
         Capacity of patrons
        Current patrons
        Location
        Identification of patrons
        Is the table dirty?
        Status
        Time stamps for changing status
        Reservations?
         */

        public int Capacity { get; set; }
        public int CurrentPartySize { get; set; }
        public string? Location { get; set; }
        List<string>? MemberIds { get; set; }
        public TableState Status { get; set;  }
        public List<DateTime> StatusChanges {  get; set; }
        public bool? IsReserved { get; set;  }
    }

    public enum TableState
    {
        Ready, Assigned, Dirty
    }
}
