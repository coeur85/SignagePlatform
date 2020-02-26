using System;
using System.Collections.Generic;
using System.IO;
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
                DirectoryInfo d = new DirectoryInfo(_helper.MyBranchPictureRoot);
                FileInfo[] picFiles = d.GetFiles("*." + ext);
                foreach (var pic in picFiles)
                {
                    var byteArray = File.ReadAllBytes(pic.FullName);
                    var base64 = Convert.ToBase64String(byteArray);
                    picList.Add(new PictureModel
                    {
                        PictureName = pic.FullName,
                        Base64 = String.Format("data:image/" + ext + ";base64,{0}", base64)
                    });
                    byteArray = null; base64 = null; 
                }



            }
            return Task.Run(() => picList);

        }
    }
}