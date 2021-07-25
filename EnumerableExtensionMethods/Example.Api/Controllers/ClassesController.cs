using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Extensions.Enumerable;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Example.Api.Controllers
{
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// RESTful API endpoint for a <see cref="Class"/>'s.
        /// </summary>
        private readonly DatabaseContext _databaseContext;
        
        public ClassesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        /// The GET: Method for a <see cref="Class"/>
        /// </summary>
        /// <param name="id">The identifier for the class</param>
        /// <returns>A <see cref="ClassModel"/> with a matching id.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ClassModel> Get(Guid id) =>
            await _databaseContext
                .Classes
                .Include(c => c.Members)
                .WithId(id)
                .Select(ClassModel.FromClass)
                .SingleOrDefaultAsync();

        /// <summary>
        /// The GET: Method for getting a class by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="ClassModel"/> with matching name.</returns>
        [HttpGet("/name/{name}")]
        public async Task<ClassModel> WithName(string name) =>
            await _databaseContext
                .Classes
                .WithName(name)
                .Select(ClassModel.FromClass)
                .SingleOrDefaultAsync();
        
    }
}