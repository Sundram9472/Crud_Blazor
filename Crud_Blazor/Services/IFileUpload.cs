using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Blazor.Services
{
    interface IFileUpload
    {
        Task Upload(IFileListEntry file);
    }
}
