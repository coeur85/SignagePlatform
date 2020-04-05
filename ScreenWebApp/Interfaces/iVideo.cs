using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;

namespace ScreenWebApp.Interfaces
{
    public interface iVideo
    {
          public  Task<VideoModel> FirstVideo(int setNumber);
          public Task<VideoPageModel> NextVideo(int setNumber, VideoModel model);
    }
}