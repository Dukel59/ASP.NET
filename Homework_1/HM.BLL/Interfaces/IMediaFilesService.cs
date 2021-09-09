using HM.BLL.ViewModels.MediaFiles;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Interfaces
{
    public interface IMediaFilesService
    {
        Task<Guid> CreateMediaFilesAsync(CreateMediaFiles mediaFiles);
        List<CreateMediaFiles> FindMediaFilesByFunc(Func<MediaFiles, bool> func);
    }
}
