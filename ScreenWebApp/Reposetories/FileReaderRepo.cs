using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using ScreenWebApp.Interfaces;
using ScreenWebApp.Models;

namespace ScreenWebApp.Reposetories
{
    public class FileReaderRepo : iFileReader
    {



        private readonly iHelper _helper;

        public FileReaderRepo(iHelper helper)
        {
            _helper = helper;
        }

        private FileInfo[] FilesInRoot(string root, string ext){
                DirectoryInfo d = new DirectoryInfo(root);
                FileInfo[] files = d.GetFiles("*." + ext);
            return files;
        }
        public Task<List<PictureModel>> GetMyPictures()
        {
            string extCongigValue = _helper.PicturesFileExtiontion;
            string[] extAry;
            if (extCongigValue.Contains(";"))
            {
                extAry = extCongigValue.Split(";");
            }
            else
            {
                extAry = extCongigValue.Split("");
            }

            List<PictureModel> picList = new List<PictureModel>();
            foreach (var ext in extAry)
            {
                var picFiles = FilesInRoot(_helper.MyBranchPictureRoot,ext);
                foreach (var pic in picFiles)
                {
                    var byteArray = File.ReadAllBytes(pic.FullName);
                    var base64 = Convert.ToBase64String(byteArray);
                    picList.Add(new PictureModel
                    {
                        PictureName = pic.FullName,
                        Base64 = String.Format("data:image/" + ext + ";base64,{0}", base64),
                        LastWriteTime = pic.LastWriteTime
                    });
                    byteArray = null; base64 = null; 
                }
                picList = picList.OrderBy(x=> x.PictureName).ToList();


            }
            return Task.Run(() => picList);

        }

        public Task<List<VideoModel>> GetMyVideos()
        {
            var videoFiles = FilesInRoot(_helper.MyBranchVideoRoot, "mp4");
            string mp4Root ="wwwroot/mp4/";
            int i =0;

            List<VideoModel> output= new List<VideoModel>();
            foreach (var v in videoFiles)
            {
                    i+=1;
                
                if(File.Exists(mp4Root + v.Name)){
                    FileInfo oldV = new FileInfo(mp4Root + v.Name);
                    if(oldV.Length != v.Length){
                        v.CopyTo(mp4Root+ v.Name ,true);
                    }
                }
                else{
                     v.CopyTo(Path.Combine(mp4Root,v.Name));
                }

                output.Add(new VideoModel{ 
                    VideoFilePath = mp4Root.Replace("wwwroot/","") + Path.GetFileName(v.Name),
                    CreationTime =v.CreationTime,
                    VideoID = i, Lenth = v.Length
                });
                
            } 

            //delete files from local root that is not on the shared loacation

            var existingFiles = FilesInRoot(mp4Root, "mp4");

            foreach (var vFile in existingFiles)
            {
                if(!(output.Any(x=> Path.GetFileName(x.VideoFilePath) == vFile.Name && 
                      x.Lenth == vFile.Length  ))){
                    vFile.Delete();
                }
            }
            return Task.Run(() => output);

        }
    }
}