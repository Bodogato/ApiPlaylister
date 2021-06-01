using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Playster
{
    public class YouTubeClient
    {
        private HttpClient client;
        private static string addres;
        private static string key;
        

        public YouTubeClient()
        {
            addres = Constants._addres;
            key = Constants.key;
      
            client = new HttpClient();
            client.BaseAddress = new Uri(addres);
        }

        public async Task<Showcase_List> Search(string search)
        {
            var response = await client.GetAsync($"v3/search?part=snippet&q={search}&maxResults=50&key={key}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            var current_list = JsonConvert.DeserializeObject<Showcase_List>(content);   
            return current_list;
        }

        public async Task<Showcase_List> SearchByArragment(string search, string arragment, int MAXRESULT)
        {
            var response = await client.GetAsync($"v3/search?part=snippet&maxResults={MAXRESULT}&q={search}&key={key}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            var current_list = JsonConvert.DeserializeObject<Showcase_List>(content);

         
            for (int i = 0; i < current_list.items.Count; i++)
            {
                var k = current_list.items[i];
                if (!k.snippet.Title.ToLower().Contains(arragment.ToLower()) && !k.snippet.Descripption.ToLower().Contains(arragment.ToLower()))
                {
                    current_list.items.RemoveAt(i);
                    i--;
                }
            }

            return current_list;
        }


        public async Task<Showcase_List_det> SearchByTime(string search, int time)
        {
            var result_list = new Showcase_List_det();
            var current_list = Search(search);
            for(int i = 0; i < current_list.Result.items.Count; i++)
            { 
                var k = current_list.Result.items[i];
                if (k.id.videoId == null)
                    continue;
                    var response = await client.GetAsync($"v3/videos?id={k.id.videoId}&part=contentDetails&key={key}");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                var detail = JsonConvert.DeserializeObject<Showcase_List_det>(content);
                string[] l = detail.items[0].contentDetails.duration.Split(new char[] { 'M', 'S', 'P', 'T', 'H'}, StringSplitOptions.RemoveEmptyEntries);
                int t;
                if (l.Length == 3)
                    t = int.Parse(l[0]) * 3600 + int.Parse(l[1]) * 60 + int.Parse(l[2]);
                else if (l.Length == 2)
                    t = int.Parse(l[0]) * 60 + int.Parse(l[1]);
                else
                    t = int.Parse(l[0]);
                if (t <= time)
                {
                    result_list.items.Add(detail.items[0]);
                }  
            }
            return result_list;
        }
        public List<Showcase> Output(Showcase_List current_list)
        {

            List<Showcase> str = new List<Showcase>();
            for (int i = 0; i < current_list.items.Count; i++)
            {
                str.Add(current_list.items[i]);
            }
            return str;
        }
        public List<Showcase_det> Output(Showcase_List_det current_list)
        {

            List<Showcase_det> str = new List<Showcase_det>();
            for (int i = 0; i < current_list.items.Count; i++)
            {
                str.Add(current_list.items[i]);
            }
            return str;
        }
    }
}
