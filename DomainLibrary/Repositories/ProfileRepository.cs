using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Repositories
{
    public class ProfileRepository
    {
        public string GetImageSrc(Profile profile)
        {
            var pic = profile.Content;
            var base64 = Convert.ToBase64String(pic);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            return imgSrc;
        }
    }
}
