using FileUpload.Objects.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Objects.Views
{
    public class FileUploadModelView: AView<FileUploadModel>
    {
        public IFormFile File { get; set; }  
        public string Description { get; set; }  
        public List<FileUploadModel> UploadedFiles { get; set; } 
    }

}
