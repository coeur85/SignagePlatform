using System;

namespace ScreenWebApp.Models
{
    public class VideoModel
    {
        public int VideoID { get; set; }
        public string  VideoFilePath { get; set; }
        public DateTime CreationTime{get;set;}

        public long Lenth {get;set;}
    }


    public class VideoPageModel{
        public bool ChangedState { get; set; }
        public VideoModel VideoModel { get; set; }
    }
}