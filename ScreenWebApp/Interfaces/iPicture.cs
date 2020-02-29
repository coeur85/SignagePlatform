using System.Collections.Generic;
using System.Threading.Tasks;
using ScreenWebApp.Models;
namespace ScreenWebApp.Interfaces
{
    public interface iPicture
    {
        public Task<List<PictureModel>> PictureArray();
        public Task<PicturePgaeModel> CheckForUpdate(List<PictureModel> model);
    }
}