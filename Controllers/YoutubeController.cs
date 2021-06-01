using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : ControllerBase
    {          
        [HttpGet("First_5")]
        public async Task<List<Showcase>> Search_5(string SearchQuery)
        {
           YouTubeClient Current_client = new YouTubeClient();
            return Current_client.Output(await Current_client.Search(SearchQuery));
        }

        [HttpGet("First_5_By_Time")]
        public async Task<List<Showcase_det>> SearchById(string search, int time)
        {
            YouTubeClient Current_client = new YouTubeClient();
            return Current_client.Output(await Current_client.SearchByTime(search,time));
        }

        [HttpGet("SearchByArragment")]
        public async Task<List<Showcase>> SearchByArrg(string Search, string arragment, int MAXRESULT)
        {
            YouTubeClient Current_client = new YouTubeClient();
            return Current_client.Output(await Current_client.SearchByArragment(Search, arragment, MAXRESULT));
        }
    }
}
