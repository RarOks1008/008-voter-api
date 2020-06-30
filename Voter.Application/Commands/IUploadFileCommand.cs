using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Application.Commands
{
    public interface IUploadFileCommand : ICommand<ReportDto>
    {
    }
}
