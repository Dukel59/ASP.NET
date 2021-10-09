using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.BLL.VMs.Train
{
    public class InfoTrain
    {
        public Guid Id { get; set; }
        public string TrainNumber { get; set; }
        public string Destination { get; set; }
        public DateTime Departs { get; set; }
        public int Track { get; set; }

        public InfoTrain() { }

        public InfoTrain(TicketOffice.Models.Train train)
        {
            Id = train.Id;
            TrainNumber = train.TrainNumber;
            Destination = train.Destination;
            Departs = train.Departs;
            Track = train.Track;
        }
    }
}
