using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Objects.Models
{
    public class FileUploadModel : AModel
    {
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}
