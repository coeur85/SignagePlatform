using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;
namespace ScreenWebApp.Interfaces
{
    public interface iPicture
    {
        public Task<List<PictureModel>> PictureArray(int setNumber);
        public Task<PicturePgaeModel> CheckForUpdate(int setNumber, List<PictureModel> model);
    }
}