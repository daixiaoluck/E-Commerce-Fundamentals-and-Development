using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using E_Commerce_Project_Three.Models;

namespace E_Commerce_Project_Three.Data
{
    public class DatabaseInitializer:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "First",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas quod sit sequi debitis, accusamus corporis, vero eligendi ducimus molestiae! Vel nam laborum, rem aperiam? Vitae labore provident reprehenderit tempora quod.",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "Second",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas quod sit sequi debitis, accusamus corporis, vero eligendi ducimus molestiae! Vel nam laborum, rem aperiam? Vitae labore provident reprehenderit tempora quod.",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "Third",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas quod sit sequi debitis, accusamus corporis, vero eligendi ducimus molestiae! Vel nam laborum, rem aperiam? Vitae labore provident reprehenderit tempora quod.",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "Fourth",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas quod sit sequi debitis, accusamus corporis, vero eligendi ducimus molestiae! Vel nam laborum, rem aperiam? Vitae labore provident reprehenderit tempora quod.",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "Fifth",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas quod sit sequi debitis, accusamus corporis, vero eligendi ducimus molestiae! Vel nam laborum, rem aperiam? Vitae labore provident reprehenderit tempora quod.",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "Sixth",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas quod sit sequi debitis, accusamus corporis, vero eligendi ducimus molestiae! Vel nam laborum, rem aperiam? Vitae labore provident reprehenderit tempora quod.",
                    Price = 0.01m
                });
            context.SaveChanges();
        }
    }
}