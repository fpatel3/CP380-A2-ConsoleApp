using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using RatingAdjustment.Services;
using BreadmakerReport.Models;

namespace BreadmakerReport
{
    class Program
    {
        static string dbfile = @".\data\breadmakers.db";
        static RatingAdjustmentService ratingAdjustmentService = new RatingAdjustmentService();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bread World");
            var BreadmakerDb = new BreadMakerSqliteContext(dbfile);
            var BMList = BreadmakerDb.Breadmakers.Include(ri=> ri.Reviews).AsEnumerable().Select(rj => new
                // TODO: add LINQ logic ...
                 {
                TotalReviews = rj.Reviews.Count,
                AverageReviews = Math.Round(rj.Reviews.Average(riObject => riObject.stars),2),
                AdjustReview = Math.Round(ratingAdjustmentService.Adjust(rj.Reviews.Average(riObject => riObject.stars), rj.Reviews.Count()),2),
                rj.title
            })
                .OrderByDescending(rj => rj.AdjustReview)
                //       ...
                .ToList();

            Console.WriteLine("[#]  Reviews Average  Adjust    Description");
            for (var j = 0; j < 3; j++)
            {
                var i = BMList[j];
                // TODO: add output
                // Console.WriteLine( ... );
                 Console.WriteLine( "[{0}] {1} {2} {3} {4}", i+1, j.TotalReviews, j.AverageReviews, j.AdjustReview, j.title);
            }
        }
    }
}
