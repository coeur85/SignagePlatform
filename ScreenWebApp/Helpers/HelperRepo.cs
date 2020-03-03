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
        public string PicturesFileExtiontion => PicConfigValue("PicturesFileExtiontion") ;

      //  public string MyBranchPictureRoot => PCV("MyBranchPictureRoot") ;

        public decimal SlideintervalInSeconds => Convert.ToDecimal(PicConfigValue("SlideintervalInSeconds")) * 1000 ;
        
        public int CycleTimesBeforeVideo => Convert.ToInt32(PicConfigValue("CycleTimesBeforeVideo")) >0 ?
                    Convert.ToInt32(PicConfigValue("CycleTimesBeforeVideo")) : 1;

        public string AllBranchesRoot => RootConfigValue("AllBranchesRoot");

        public string MyBranchSetOneRoot => RootConfigValue("MyBranchSetOneRoot") ;

        public string MyBranchSetTwoRoot => RootConfigValue("MyBranchSetTwoRoot");

        private string ConfigVlaue (string key) =>  
                _congig.GetSection(key).Value ;

        private string PicConfigValue(string key)=> 
                    _congig.GetSection("PicturesSettings").GetSection(key).Value;
         private string RootConfigValue(string key) => 
                 _congig.GetSection("RootSettings").GetSection(key).Value;
   
        // public string MyBranchVideoRoot => VCV("MyBranchVideoRoot");


   
    }
}