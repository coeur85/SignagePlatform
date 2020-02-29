using ScreenWebApp.Models;
using ScreenWebApp.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ScreenWebApp.Reposetories
{
    public class PictureRepo : iPicture
    {
        private readonly iFileReader _reader;
        public PictureRepo(iFileReader reader)
        {
            
            _reader = reader;
        }


        public async Task<List<PictureModel>> PictureArray()
        {
           
            var output = await _reader.GetMyPictures();
            return output;
        }


        public async Task<PicturePgaeModel> CheckForUpdate(List<PictureModel> model){
            var newArray = await _reader.GetMyPictures();
            PicturePgaeModel output = new PicturePgaeModel();
            output.ChangedState = false;
            
            foreach (var pic in newArray) // check if new pictures has been added
            {
                if(model.Any(x=> x.PictureName == pic.PictureName &&
                    x.LastWriteTime == pic.LastWriteTime )){          // an old file
                        output.Pictures.Add(pic);
                    }
                    else{
                        output.Pictures.Add(pic);
                        output.ChangedState = true;
                    }
            }

            foreach (var pic in model) // check if any old picure has been remove
            {
                if(!output.Pictures.Any(x=> x.PictureName == pic.PictureName &&
                    x.LastWriteTime == pic.LastWriteTime )){
                        output.ChangedState = true;
                        break;
                    }
            }


            return output;

        }

       
    }
}