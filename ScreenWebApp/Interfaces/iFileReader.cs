using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;

namespace ScreenWebApp.Interfaces
{
    public interface iFileReader 
    {
         public Task<List<PictureModel>> GetMyPictures(int setNumber);
          public Task<List<VideoModel>> GetMyVideos(int setNumber);
         
    }
}