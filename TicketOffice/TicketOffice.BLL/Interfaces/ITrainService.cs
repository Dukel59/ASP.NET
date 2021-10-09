using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.BLL.VMs.Train;

namespace TicketOffice.BLL.Interfaces
{
    public interface ITrainService
    {
        Task<Guid> CreateTrainAsync(CreateTrain train);
        void Update(InfoTrain train);
        void Delete(InfoTrain train);
        List<InfoTrain> FindTrain(TrainSearch train);
    }
}
