﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace LINQExcelOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\Sobala\source\repos\LINQExcelOperations\googleplaystore1.csv";
            var googleApps = LoadGoogleApps(csvPath);

            // Display(googleApps);
            // ProjectData(googleApps);
            // DivideData(googleApps);
            // OrderData(googleApps);
            // DataSetOperation(googleApps);
            DataVerification(googleApps);
        }

        static void DataVerification(IEnumerable<GoogleApp> googleApps)
        {
            var allOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER)
                .All(a => a.Reviews > 20);

            Console.WriteLine($"allOperatorResult {allOperatorResult}");

            var anyOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER)
                .Any(a => a.Reviews > 2_000_000);

            Console.WriteLine($"anyOperatorResult {anyOperatorResult}");
        }

        static void DataSetOperation(IEnumerable<GoogleApp> googleApps)
        {
            var paidAppsCategories = googleApps.Where(a => a.Type == Type.Paid)
                .Select(a => a.Category).Distinct();

            // Console.WriteLine($"Paid apps categories: {string.Join(", ", paidAppsCategories)}");

            var setA = googleApps.Where(a => a.Rating > 4.7 && a.Type == Type.Paid && a.Reviews > 1000);

            var setB = googleApps.Where(a => a.Name.Contains("Pro") && a.Rating > 4.6 && a.Reviews > 10000);

            Display(setA);

            Console.WriteLine("\n***********************");

            Display(setB);

            var appsUnion = setA.Union(setB);
            Console.WriteLine("Apps union");
            Display(appsUnion);

            var appsIntersect = setA.Intersect(setB);
            Console.WriteLine("Apps intersect");
            Display(appsIntersect);

            var appsExcept = setA.Except(setB);
            Console.WriteLine("App except");
            Display(appsExcept);
        }

        static void OrderData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.4 && app.Category == Category.BEAUTY);

            var sortedResults = highRatedBeautyApps
                .OrderByDescending(app => app.Rating)
                .ThenByDescending(app => app.Name)
                .Take(5);

            Display(sortedResults);
        }

        static void DivideData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.4 && app.Category == Category.BEAUTY);
            Display(highRatedBeautyApps);

            //var first5HighRatedBeautyApps = highRatedBeautyApps.TakeWhile(app => app.Reviews > 1000);

            //Display(first5HighRatedBeautyApps);

            var skippedResults = highRatedBeautyApps.SkipWhile(app => app.Reviews > 1000);
            Console.WriteLine("Skipped result:");
            Display(skippedResults);
        }

        static void ProjectData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.6 && app.Category == Category.BEAUTY);
            var highRatedBeautyAppsNames = highRatedBeautyApps.Select(app => app.Name);

            var dtos = highRatedBeautyApps.Select(app => new GoogleAppDto()
            {
                Reviews = app.Reviews,
                Name = app.Name
            });

            var anonymousDtos = highRatedBeautyApps.Select(app => new
            {
                Reviews = app.Reviews,
                Name = app.Name,
                Category = app.Category
            });

            foreach (var dto in anonymousDtos)
            {
                Console.WriteLine($"{dto.Name}: {dto.Reviews}");
            }

            var genres = highRatedBeautyApps.SelectMany(app => app.Genres);
            Console.WriteLine(string.Join(":", genres));
        }

        static void GetData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedApps = googleApps.Where(app => app.Rating > 4.6);
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.6 && app.Category == Category.BEAUTY);
            Display(highRatedBeautyApps);

            var firstHighRatedBeautyApp = highRatedBeautyApps.FirstOrDefault(app => app.Reviews < 300);
            Console.WriteLine("firstHighRatedBeautyApp ");
            Console.WriteLine(firstHighRatedBeautyApp);
        }

        static void Display(IEnumerable<GoogleApp> googleApps)
        {
            foreach (var googleApp in googleApps)
            {
                Console.WriteLine(googleApp);
            }
        }
        static void Display(GoogleApp googleApp)
        {
            Console.WriteLine(googleApp);
        }

        static List<GoogleApp> LoadGoogleApps(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<GoogleAppMap>();
                var records = csv.GetRecords<GoogleApp>().ToList();
                return records;
            }
        }
    }
}
