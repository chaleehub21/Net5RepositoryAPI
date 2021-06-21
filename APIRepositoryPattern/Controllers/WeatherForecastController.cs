using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRepositoryPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private RepositoryWrapper _repoWrapper;

        public WeatherForecastController(RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [HttpGet]
        [Route("/Studen")]
        public string GetStuden()
        {
            var studen = _repoWrapper.Studen.GetOnce();
            return studen;
        }

        [HttpGet]
        [Route("/Studen/{id}")]
        public Studen GetStuden(string id)
        {
            var studen = _repoWrapper.Studen.FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();
            return studen;
        }

        [HttpGet]
        [Route("/School")]
        public List<School> GetSchool()
        {
            var studen = _repoWrapper.School.FindAll().ToList();
            return studen;
        }

        [HttpGet]
        [Route("/School/{id}")]
        public School GetSchool(string id)
        {
            var studen = _repoWrapper.School.FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();
            return studen;
        }
    }
}
