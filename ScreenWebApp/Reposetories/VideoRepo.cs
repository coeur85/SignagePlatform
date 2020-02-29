using ScreenWebApp.Models;
using ScreenWebApp.Interfaces;
using System.Threading.Tasks;
using ScreenWebApp.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ScreenWebApp.Reposetories
{
    public class VideoRepo : iVideo
    {
        private readonly iFileReader _reader;
        public VideoRepo(iFileReader  reader)
        {
            _reader = reader;
        }

        public async Task<VideoPageModel> NextVideo(VideoModel model)
        {
             var vList = await _reader.GetMyVideos();
            if(vList.Count ==1){
                if(vList.FirstOrDefault().VideoFilePath == model.VideoFilePath &&
                 vList.FirstOrDefault().Lenth ==model.Lenth){
                     return new VideoPageModel{
                         ChangedState = false,
                         VideoModel = model
                     };
                 }
            }

            VideoPageModel output =new VideoPageModel{ 
                ChangedState = true,
                VideoModel = model}
             ;
            if(vList.Any(x=> x.VideoID == (model.VideoID+1))) {
                output.VideoModel = vList.FirstOrDefault(x=> x.VideoID == (model.VideoID +1));
            }
            else{
                output.VideoModel = vList.First();
            }
            return output;
        }

        public async Task<VideoModel> FirstVideo()
        {
            var output =await _reader.GetMyVideos();
            return output.FirstOrDefault();
        }
    }
}