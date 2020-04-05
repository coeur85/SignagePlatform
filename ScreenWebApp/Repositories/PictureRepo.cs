using ScreenWebApp.Models;
using ScreenWebApp.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ScreenWebApp.Repositories
{
    public class PictureRepo : iPicture
    {
        private readonly iFileReader _reader;
        public PictureRepo(iFileReader reader)
        {
            
            _reader = reader;
        }


        public async Task<List<PictureModel>> PictureArray(int setNumber)
        {
           
            var output = await Task.Run(()=> _reader.GetMyPictures(setNumber))  ;
            return output;
        }


        public async Task<PicturePgaeModel> CheckForUpdate(int setNumber,List<PictureModel> model){
            var newArray = await Task.Run(() =>  _reader.GetMyPictures(setNumber)  );
            PicturePgaeModel output = new PicturePgaeModel
            {
                ChangedState = false
            };

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
