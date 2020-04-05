using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;

namespace ScreenWebApp.Interfaces
{
    public interface iFileReader
    {
         public List<PictureModel> GetMyPictures(int setNumber);
         public List<VideoModel> GetMyVideos(int setNumber);
         
    }
}
