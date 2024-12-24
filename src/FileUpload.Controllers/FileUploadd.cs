using FileUpload.Components.Security;
using FileUpload.Objects.Models;
using FileUpload.Objects.Views;
using FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Controllers
{
    [AllowUnauthorized]
    [Route("fileupload")]
    public class FileUploadd : ServicedController<FileUploadService>
    {
        public FileUploadd(FileUploadService fileUploadService) : base(fileUploadService)
        { }

        [HttpGet("index")]
        public IActionResult Index()
        {
            FileUploadModelView model = new FileUploadModelView
            {
                UploadedFiles = Service.GetUploadedFiles()
            };
            return View(model);
        }

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file, string description)
        {
            if (file == null || file.Length == 0)
            {
                TempData["ErrorMessage"] = "No file uploaded.";
                return RedirectToAction("Index");
            }

            try
            {
                string fileName = Service.SaveFile(file);
                FileUploadModel fileRecord = Service.CreateFileUploadRecord(fileName, description);

                TempData["SuccessMessage"] = "File uploaded successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpGet("download/{id}")]
        public IActionResult DownloadFile(int id)
        {
            try
            {
                FileUploadModel? fileRecord = Service.GetUploadedFiles().FirstOrDefault(f => f.Id == id);

                if (fileRecord == null)
                {
                    return NotFound("File not found.");
                }

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileRecord.FileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found on the server.");
                }

                string fileExtension = Path.GetExtension(fileRecord.FileName).ToLower();
                string mimeType = "application/octet-stream";

                if (fileExtension == ".pdf")
                    mimeType = "application/pdf";
                else if (fileExtension == ".jpg")
                    mimeType = "image/jpeg";
                else if (fileExtension == ".png")
                    mimeType = "image/png";
                else if (fileExtension == ".docx")
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, mimeType, fileRecord.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
