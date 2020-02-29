using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;

namespace ScreenWebApp.Interfaces
{
    public interface iVideo
    {
          public  Task<VideoModel> FirstVideo();
          public Task<VideoPageModel> NextVideo(VideoModel model);
    }
}