using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPhoto : BaseEntity
    {
        public UserPhoto()
        {
        }

        public UserPhoto(int userId, string defaultUrl, string smallUrl, string defaultPath, string smallPath)
        {
            UserId = userId;
            DefaultUrl = defaultUrl;
            SmallUrl = smallUrl;
            DefaultPath = defaultPath;
            SmallPath = smallPath;
        }

        public User User { get; set; }
        public int UserId { get; set; }
        public string DefaultUrl { get; set; }
        public string SmallUrl { get; set; }
        public string DefaultPath { get; set; }
        public string SmallPath { get; set; }

        public void ChangeUrls(string defaultUrl, string small, string defaultPath, string smallPath)
        {
            DefaultUrl = defaultUrl;
            SmallUrl = small;
            DefaultPath = defaultPath;
            SmallPath = smallPath;
        }
    }
}
