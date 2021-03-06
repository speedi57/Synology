﻿using Synology.FileStation.Common.Results;

namespace Synology.FileStation.FileShare.Results
{
    /// <summary>
    /// Share perm result.
    /// </summary>
    public interface ISharePermResult : ITaskSharePermResult<ISharePermAclResult, ISharePermAdvRightResult>
    {
    }
}