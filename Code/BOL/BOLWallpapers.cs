using HDWalls.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BOLWallpapers
{
    internal int GetCount(string Keyword, string CatName)
    {
        WallDataContext dc = new WallDataContext();
        IQueryable<Wallpaper> Result = dc.Wallpapers;
        if (!string.IsNullOrEmpty(CatName))
            Result = Result.Where(p => p.CatName.Equals(CatName));

        if (!string.IsNullOrEmpty(Keyword))
            Result = Result.Where(p => p.Title.Contains(Keyword));

        return Result.Count();
    }

    internal object GetAll(int StartIndex, int PageSize)
    {
        WallDataContext dc = new WallDataContext();
        return dc.Wallpapers.Skip(StartIndex).Take(PageSize);
    }

    internal Wallpaper GetDetailsByID(string iD)
    {
        try
        {
            WallDataContext dc = new WallDataContext();
            return dc.Wallpapers.SingleOrDefault(p => p.ID.Equals(iD));
        }
        catch
        {
            return null;
        }
    }

    internal IQueryable<Wallpaper> GetWallpapers(string Keyword, string CatName, int pageNo, int pageSize)
    {
        int SkipCount = (pageNo - 1) * pageSize;
        WallDataContext dc = new WallDataContext();
        IQueryable<Wallpaper> Result = dc.Wallpapers.OrderBy(p=> p.OrderNum);
        if (!string.IsNullOrEmpty(CatName))
            Result = Result.Where(p => p.CatName.Equals(CatName));
        if (!string.IsNullOrEmpty(Keyword))
            Result = Result.Where(p => p.Title.Contains(Keyword));


        Result = Result.Skip(SkipCount).Take(pageSize);

        return Result;
    }

    internal object GetOthers(string id, string catName, int TakeCount)
    {
        WallDataContext dc = new WallDataContext();
        //var r = new Random();
        //IQueryable<Wallpaper> Result = dc.Wallpapers;
        //return Result.Where(p => !p.ID.Equals(id) && p.CatName.Equals(catName)).OrderBy(qu => Guid.NewGuid()).Take(TakeCount);
        return dc.spGetRandomWalls(id, catName);



    }
}
