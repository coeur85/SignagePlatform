using System;
using System.Collections.Generic;

namespace ScreenWebApp.Models
{
    public class PictureModel
    {
        public int PictureID { get; set; }
        public string PictureName { get; set; }
        public string Base64 { get; set; }
        public DateTimeOffset LastWriteTime { get; set; }
    }


    public class PicturePgaeModel {
        public List<PictureModel> Pictures { get; set; } = new List<PictureModel>();
        public bool ChangedState { get; set; }
    }
}
