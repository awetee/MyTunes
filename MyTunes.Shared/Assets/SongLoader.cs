﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyTunes
{
    public static class SongLoader
    {
        private const string Filename = "songs.json";

        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(OpenData()))
            {
                return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
            }
        }

        private static Stream OpenData()
        {
#if __ANDROID__
            return Android.App.Application.Context.Assets.Open(Filename);

#else
               // TODO: add code to open file here.
               return null;
#endif
        }
    }
}