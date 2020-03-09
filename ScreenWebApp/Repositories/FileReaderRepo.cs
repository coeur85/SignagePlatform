using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ScreenWebApp.Interfaces;
using ScreenWebApp.Models;

namespace ScreenWebApp.Repositories
{
    public class FileReaderRepo : iFileReader
    {



        private readonly iHelper _helper;
       
        public FileReaderRepo(iHelper helper){
            _helper = helper;
        }
        


        private List<FileInfo> FilesInRoot(string root, string ext){
            if (string.IsNullOrEmpty(root)){ return new List<FileInfo>(); }

                DirectoryInfo d = new DirectoryInfo(root);
                if(!d.Exists) return new List<FileInfo>();
                FileInfo[] files = d.GetFiles("*." + ext);

            return files.ToList();
        }
        public List<PictureModel> GetMyPictures(int setNumber)
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
            string localRoot = $"img/set0{setNumber}/";

            foreach (var ext in extAry)
            {
                var picFiles = FilesInRoot( _helper.AllBranchesRoot,ext);
                picFiles.AddRange(
                    FilesInRoot( 
                        setNumber == 1 ? 
                        _helper.MyBranchSetOneRoot :
                        _helper.MyBranchSetTwoRoot,
                    ext));
             
             
                foreach (var pic in picFiles)
                {

                  

                    CopyNewFile(localRoot, pic);

                    picList.Add(new PictureModel
                    {
                        PictureName = pic.Name,
                        Base64 = localRoot + pic.Name, 
                        LastWriteTime = pic.LastWriteTime
                    });
                  
                }
                Task.Run(() => DeleteUnsedFiles(FilesInRoot(localRoot, ext), picFiles) );
               
            }

            picList = picList.OrderBy(x=> x.PictureName).ToList();
            return  picList;
        }

        public List<VideoModel> GetMyVideos(int setNumber)
        {
            string mp4Ext = "mp4";
            var videoFiles = FilesInRoot(_helper.AllBranchesRoot, mp4Ext);
            videoFiles.AddRange(FilesInRoot(
                    setNumber == 1 ? 
                    _helper.MyBranchSetOneRoot :
                    _helper.MyBranchSetTwoRoot ,
                mp4Ext));
            

            string mp4Root ="mp4/";
            int i =0;

            List<VideoModel> output= new List<VideoModel>();
            foreach (var v in videoFiles)
            {
                    i+=1;

                CopyNewFile(mp4Root, v);

                output.Add(new VideoModel{ 
                    VideoFilePath = mp4Root.Replace("wwwroot/","") + Path.GetFileName(v.Name),
                    CreationTime =v.CreationTime,
                    VideoID = i, Lenth = v.Length
                });
                
            } 

            //delete files from local root that is not on the shared loacation

            var existingFiles = FilesInRoot(mp4Root, "mp4");

            Task.Run(() =>  DeleteUnsedFiles(existingFiles, videoFiles));  
            return  output;

        }



        private void CopyNewFile(string root, FileInfo file){

            root = "wwwroot/" + root ;
            if (File.Exists(root + file.Name))
            {
                FileInfo oldV = new FileInfo(root + file.Name);
                if (oldV.Length != file.Length)
                {
                    file.CopyTo( root + file.Name, true);
                }
            }
            else
            {
                file.CopyTo(root + file.Name);
            }
        }
        private void DeleteUnsedFiles(List<FileInfo> oldFiles, List<FileInfo> newFiles)
        {
            foreach (var vFile in oldFiles)
            {
                if (!(newFiles.Any(x => x.Name == vFile.Name &&
                       x.Length == vFile.Length)))
                {
                    vFile.Delete();
                }
            }
        }
    }
}
