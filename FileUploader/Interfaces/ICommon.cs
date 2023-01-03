using FileUploader.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FileUploader.Interfaces
{
    public interface ICommon
    {
        string UploadedFile(IFormFile ProfilePicture);
        Tuple<byte[], string> GetDownloadDetails(long id);
        Task<AttachmentFile> AddAttachmentFile(IFormFile _IFormFile);
    }
}
