using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EndPointTrii.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EndPointTrii.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpisodeController : ControllerBase
    {
        
        private readonly ILogger<EpisodeController> _logger;
        string URL = "https://rickandmortyapi.com/api/episode";
        

        public EpisodeController(ILogger<EpisodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id, [FromQuery] string name, [FromQuery] string episode)
        {

            EpisodeResponse episodelist = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    episodelist = JsonConvert.DeserializeObject<EpisodeResponse>(apiResponse);
                }
            }
            var filterList = episodelist.results;
            if (id != null) filterList = filterList.Where(x => x.id == id).ToList();
            if (!string.IsNullOrEmpty(name)) filterList = filterList.Where(x => x.name.Contains(name)).ToList();
            if (!string.IsNullOrEmpty(episode)) filterList = filterList.Where(x => x.episode.Contains(episode)).ToList();
            episodelist.results = filterList;
            return Ok(episodelist);
           
        } 

    }
}
