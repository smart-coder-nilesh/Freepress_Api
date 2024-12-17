using Freepress_Api.DbContextFiles;
using Freepress_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freepress_Api.Controllers
{
    [ApiController]
    public class Freepress_Api : ControllerBase
    {
        private readonly ILogger<Freepress_Api> _logger;
        public FreepressDbContext _freepressDbContext;
        public Freepress_Api(ILogger<Freepress_Api> logger ,FreepressDbContext freepressDbContext)
        {
            _logger = logger;
            _freepressDbContext = freepressDbContext;
        }
        [Route("Api/getnews")]
        [HttpGet]
        public async Task<IEnumerable<newsmodel>> Get()
        {
            var news = await  _freepressDbContext.news.Take(10).ToListAsync();
            return news!=null ? news : new List<newsmodel>();
        }
        [Route("Api/Subscribe")]
        [HttpPost]
        public async Task<JsonResult> AddEmail([FromBody]Emailobject email)
        {
            var subcriber_model = new Subscribe
            {
                Email = email.Email,
                dateTime = DateTime.Now,
            };

            if ( await _freepressDbContext.subscribe.AnyAsync(x => x.Email.ToLower() == email.Email.ToLower()))
            {

                return new JsonResult(new { Message = "Thanks you are alreay register", Email = email });
            }
            else
            {
                var res = await _freepressDbContext.subscribe.AddAsync(subcriber_model);
                await _freepressDbContext.SaveChangesAsync();

                return new JsonResult(new { Message = "successfully Subscribed to Newsleter", Email = email });
            }

        }

        
    }
}
