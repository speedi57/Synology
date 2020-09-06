using Synology.Classes;
using Synology.DownloadStation.Task.Parameters;
using Synology.DownloadStation.Task.Results;
using Synology.Utilities;
using System.Collections.Generic;
using Synology.Attributes;
using Synology.Parameters;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Synology.DownloadStation.Statistic
{
    [Request("Statistic")]
    internal class StatisicRequest : DownloadStationRequest, IStatisicRequest
    {
        public StatisicRequest(IDownloadStationApi api) : base(api)
        {
        }

        [RequestMethod("getinfo")]
        public async Task<ResultData<IEnumerable<ITaskResult>>> InfoAsync(TaskInfoParameters parameters)
        {
            var res = await this.GetDataAsync<IEnumerable<TaskResult>>(new SynologyRequestParameters(this)
            {
                Additional = parameters
            });

            return new ResultData<IEnumerable<ITaskResult>>
            {
                Data = res.Data.Cast<ITaskResult>(),
                Error = res.Error,
                Success = res.Success
            };
        }
    }
}

