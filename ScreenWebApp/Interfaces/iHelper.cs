namespace ScreenWebApp.Interfaces
{
    public interface iHelper
    {
         public string PicturesFileExtiontion { get; }
         public string AllBranchesRoot {get ;}
         public decimal SlideintervalInSeconds { get; }

         public int CycleTimesBeforeVideo{get;}

         public string MyBranchSetOneRoot{get;}
         public string MyBranchSetTwoRoot{get;}

    }
}