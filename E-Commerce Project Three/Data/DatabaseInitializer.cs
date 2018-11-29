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
                    Name = "夜景桌布",
                    Description = "從西邊俯瞰維多利亞港",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "白晝桌布",
                    Description = "從太平山俯瞰維多利亞港",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "白晝桌布",
                    Description = "沐浴在朝霞中的維多利亞港",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "夜景桌布",
                    Description = "日落時分的維多利亞港",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "白晝桌布",
                    Description = "沐浴在晚霞中的維多利亞港",
                    Price = 0.01m
                });
            context.DesktopWallpapers.Add(
                new DesktopWallpaper
                {
                    Name = "夜景桌布",
                    Description = "散發着朦朧紫色光芒的維多利亞港",
                    Price = 0.01m
                });
            context.SaveChanges();
        }
    }
}