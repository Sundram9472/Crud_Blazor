using BlazorInputFile;
using Crud_Blazor.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Blazor.Data
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        public FileUpload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task Upload(IFileListEntry file)
        {
            var path = Path.Combine(_environment.ContentRootPath, "UploadedFiles", file.Name);
            var memoryStream = new MemoryStream();
            await file.Data.CopyToAsync(memoryStream);

            using(FileStream fileStream = new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}
