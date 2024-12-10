using Freepress_Api.DbContextFiles;
using Freepress_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freepress_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Freepress_Api : ControllerBase
    {
        private readonly ILogger<Freepress_Api> _logger;
        public FreepressDbContext _freepressDbContext;
        public Freepress_Api(ILogger<Freepress_Api> logger , FreepressDbContext freepressDbContext)
        {
            _logger = logger;
            _freepressDbContext = freepressDbContext;
        }

        [HttpGet(Name = "Quick-filter")]
        public async Task<IEnumerable<newsmodel>> Get()
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
            var news = await  _freepressDbContext.newsDbContext.ToListAsync();


            return news!=null ? news : new List<newsmodel>();
        }
    }
}
