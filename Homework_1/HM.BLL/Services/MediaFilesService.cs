using HM.BLL.Interfaces;
using HM.BLL.ViewModels.MediaFiles;
using HM.DAL.Patterns;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Services
{
    public class MediaFilesService: IMediaFilesService
    {
        public MediaFilesService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;

        public async Task<Guid> CreateMediaFilesAsync(CreateMediaFiles mediaFiles)
        {
            try
            {
                var dbMediaFiles = new MediaFiles()
                {
                    FeedbackId = mediaFiles.FeedbackId.Value,
                    Name = mediaFiles.Name,
                    Path = mediaFiles.Path,
                    Type = mediaFiles.Type
                };
                dbMediaFiles = await db.MediaFiles.CreateAsync(dbMediaFiles);
                return dbMediaFiles.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateMediaFiles> FindMediaFilesByFunc(Func<MediaFiles, bool> func)
        {
            try
            {
                var dbMediaFiles = db.MediaFiles.GetAll().Where(func).Select(m =>
                {
                    return new CreateMediaFiles()
                    {
                        FeedbackId = m.FeedbackId,
                        Name = m.Name,
                        Path = m.Path,
                        Type = m.Type
                    };
                }).ToList();

                return dbMediaFiles;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
