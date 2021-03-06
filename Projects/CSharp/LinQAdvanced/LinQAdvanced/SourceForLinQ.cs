﻿using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinQAdvanced
{
    public class SourceForLinQ
    {
        public IEnumerable<string> GetSource()
        {
            string[] directories = Directory.GetDirectories("D:\\");
            var fileNames =DriveInfo.GetDrives().Select(driver=>driver.Name).Where(driver=>{try{Directory.GetDirectories(driver);return true;}catch{return false;}}).SelectMany(driver=> Directory.GetDirectories(driver)).Where(directory => { try { Directory.GetFiles(directory); return true; } catch { return false; } }).SelectMany(Directory.GetFiles);
            return fileNames;
           // new string[] { "first", "second", "third" };
        }

        public IEnumerable<string[]> GetSource1()
        {
            string[] directories = Directory.GetDirectories("D:\\");
            var groupsOfFileNames = Directory.GetDirectories(@"D:\localrepo").Select(Directory.GetFiles);
            return groupsOfFileNames;
            // new string[] { "first", "second", "third" };
        }
    }
}
