using System;
using Microsoft.Extensions.Configuration;
using ScreenWebApp.Interfaces;


namespace ScreenWebApp.Helpers
{
    public class HelperRepo : iHelper
    {
        private readonly IConfiguration _congig;
        public HelperRepo(IConfiguration congig)
        {
            _congig = congig;
        }
        public string PicturesFileExtiontion => ConfigVlaue("PicturesFileExtiontion") ;

        public string MyBranchPictureRoot => ConfigVlaue("MyBranchPictureRoot") ;

        public decimal SlideintervalInSeconds => Convert.ToDecimal(ConfigVlaue("SlideintervalInSeconds")) * 1000 ;
        private string ConfigVlaue (string key) =>  
                _congig.GetSection(key).Value ;

            
    }
}