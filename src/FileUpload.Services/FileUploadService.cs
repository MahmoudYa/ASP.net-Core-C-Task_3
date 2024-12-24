using FileUpload.Data;
using FileUpload.Objects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public class FileUploadService : AService
    {
        public FileUploadService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string SaveFile(IFormFile file)
        {
            String[] allowedExtensions = new[] { ".pdf", ".png", ".jpg", ".docx" };
            String fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
                throw new ArgumentException("Invalid file type.");

            if (file.Length > 5 * 1024 * 1024)  
                throw new ArgumentException("File size exceeds 5MB.");

            String uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            String uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            String filePath = Path.Combine(uploadPath, uniqueFileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        public FileUploadModel CreateFileUploadRecord(string fileName, string description)
        {
            FileUploadModel fileRecord = new FileUploadModel
            {
                FileName = fileName,
                Description = description
            };

            UnitOfWork.Insert(fileRecord);
            UnitOfWork.Commit();

            return fileRecord;
        }

        public List<FileUploadModel> GetUploadedFiles()
        {
            return UnitOfWork.Select<FileUploadModel>()
                .ToList(); 
        }

    }
}
