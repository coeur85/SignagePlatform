using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;

namespace ScreenWebApp.Interfaces
{
    public interface iFileReader 
    {
         public Task<List<PictureModel>> GetMyPictures();
          public Task<List<VideoModel>> GetMyVideos();
         
    }
}