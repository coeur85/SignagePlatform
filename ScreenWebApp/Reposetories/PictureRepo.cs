using ScreenWebApp.Models;
using ScreenWebApp.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.JSInterop;

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

       
    }
}