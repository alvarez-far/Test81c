using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test81b.DAL;
using Test81b.Models;

namespace Test81b.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private DefaultContext db;

        public DepartmentsController(DefaultContext context)
        {
            db = context;
        }

        //READ
        [HttpGet]
        public IEnumerable<Departamento> getUsers()
        {
            return db.Departamentos.ToArray();
        }

    }
}
