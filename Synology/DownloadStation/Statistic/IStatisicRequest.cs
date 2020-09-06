using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Synology.Classes;
using Synology.DownloadStation.Task.Parameters;
using Synology.DownloadStation.Task.Results;
using Synology.Interfaces;

namespace Synology.DownloadStation.Statistic
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public interface IStatisicRequest : ISynologyRequest
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<ResultData<IEnumerable<ITaskResult>>> InfoAsync(TaskInfoParameters parameters);
    }
}
