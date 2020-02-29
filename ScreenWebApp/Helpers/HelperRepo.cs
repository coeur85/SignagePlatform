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
        public string PicturesFileExtiontion => PCV("PicturesFileExtiontion") ;

        public string MyBranchPictureRoot => PCV("MyBranchPictureRoot") ;

        public decimal SlideintervalInSeconds => Convert.ToDecimal(PCV("SlideintervalInSeconds")) * 1000 ;
        
        public int CycleTimesBeforeVideo => Convert.ToInt32(PCV("CycleTimesBeforeVideo")) >0 ?
                    Convert.ToInt32(PCV("CycleTimesBeforeVideo")) : 1;
        private string ConfigVlaue (string key) =>  
                _congig.GetSection(key).Value ;

        private string PCV(string key)=> 
                    _congig.GetSection("PicturesSettings").GetSection(key).Value;
        private string VCV(string key) => 
                _congig.GetSection("VideoSettings").GetSection(key).Value;
   
        public string MyBranchVideoRoot => VCV("MyBranchVideoRoot");
   
    }
}