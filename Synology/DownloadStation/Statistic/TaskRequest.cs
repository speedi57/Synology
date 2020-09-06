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
    internal class TaskRequest : DownloadStationRequest, ITaskRequest
    {
        public TaskRequest(IDownloadStationApi api) : base(api)
        {
        }

        public Task<ResultData> CreateAsync(TaskCreateParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ResultData<IEnumerable<ITaskMinimalResult>>> DeleteAsync(TaskDeleteParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ResultData<IEnumerable<ITaskMinimalResult>>> EditAsync(TaskEditParameters parameters)
        {
            throw new NotImplementedException();
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

        public Task<ResultData<ITaskListResult>> ListAsync(TaskListParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ResultData<IEnumerable<ITaskMinimalResult>>> PauseAsync(params string[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<ResultData<IEnumerable<ITaskMinimalResult>>> ResumeAsync(params string[] ids)
        {
            throw new NotImplementedException();
        }
    }
}

