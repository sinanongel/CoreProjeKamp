using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPasword { get; set; }
        public bool WriterStatus { get; set; }

        public static string ImageAdd(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            return newImageName;
        }
    }
}
