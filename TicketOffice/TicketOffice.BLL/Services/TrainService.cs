using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.BLL.Interfaces;
using TicketOffice.BLL.VMs.Train;
using TicketOffice.DAL.Patterns;
using TicketOffice.Models;

namespace TicketOffice.BLL.Services
{
    public class TrainService : ITrainService
    {
        public TrainService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;

        public async Task<Guid> CreateTrainAsync(CreateTrain train)
        {
            try
            {
                var dbTrain = new Train()
                {
                    TrainNumber = train.TrainNumber,
                    Destination = train.Destination,
                    Departs = train.Departs,
                    Track = train.Track
                };
                dbTrain = await db.Trains.CreateAsync(dbTrain);

                return dbTrain.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoTrain> FindTrain(TrainSearch train)
        {
            try
            {
                var findTrain = db.Trains.GetAll();

                if (train.Track != null)
                {
                    findTrain = findTrain.Where(t => t.Track == train.Track);
                }
                if (train.Departs != null)
                {
                    findTrain = findTrain.Where(t => t.Departs == train.Departs);
                }
                if (train.Destination != null)
                {
                    findTrain = findTrain.Where(t => t.Destination == train.Destination);
                }
                if (train.TrainNumber != null)
                {
                    findTrain = findTrain.Where(t => t.TrainNumber == train.TrainNumber);
                }
                if (train.Id != null)
                {
                    findTrain = findTrain.Where(t => t.Id == train.Id);
                }

                return findTrain.Select(t => new InfoTrain(t)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(InfoTrain t)
        {
            try
            {
                var train = db.Trains.GetByIdAsync(t.Id).Result;
                train.TrainNumber = t.TrainNumber;
                train.Destination = t.Destination;
                train.Departs = t.Departs;
                train.Track = t.Track;
                db.Trains.UpdateAsync(train);
                db.SaveAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(InfoTrain train)
        {
            try
            {
                db.Trains.DeleteAsync(train.Id);
                db.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
