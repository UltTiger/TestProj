﻿using MalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MalCL
{
    class Program
    {
        static void Main(string[] args)
        {
            MalAPI.MalAPI api = new MalAPI.MalAPI();
            Console.WriteLine(api.ToString());

            //Console.WriteLine(api.GetWebDataRaw("http://www.google.com/"));

            string[] creds = File.ReadAllLines("../../../debugCreds.txt");
            api.SetCredentials(creds[0], creds[1]);

            Console.WriteLine("user correct: " + api.ValidateUser() );

            List<MalAPI.Entry> data = api.SearchAnime("bleach");

            if (data.Count > 0)
                Console.WriteLine("first name: " + data[0].title);

            List<ProgressEntry> watchData = api.GetUserListAnime();
            if (watchData.Count > 0)
                Console.WriteLine("first anime: " + watchData[0].title + " status: " + watchData[0].status + " watched: " + watchData[0].my_watched_episodes + "/" + watchData[0].episodes);
            
            Console.WriteLine("Profile snap: ");

            UserInfo info = api.GetUserInfo();
            Console.WriteLine("user: " + info.username + " watching: " + info.user_watching_anime + " & reading: " + info.user_reading_manga);
            
            Console.WriteLine("Program finished!");
        }
    }
}
