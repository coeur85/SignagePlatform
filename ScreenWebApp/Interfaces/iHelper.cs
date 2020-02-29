namespace ScreenWebApp.Interfaces
{
    public interface iHelper
    {
         public string PicturesFileExtiontion { get; }
         public string MyBranchPictureRoot {get ;}
         public decimal SlideintervalInSeconds { get; }

         public int CycleTimesBeforeVideo{get;}

         public string MyBranchVideoRoot{get;}

    }
}