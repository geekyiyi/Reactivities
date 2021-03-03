using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        // Get Method
        [HttpGet]
        // Get a list of activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //_context is database(DbContext)
            // Activities is the DbSet in the database
            // ToListAsync() is a method which convert the result into a list
            return await _context.Activities.ToListAsync();
        }

        // Get Method with specified id
        [HttpGet("{id}")]

        // find one activity with given id(Guid is the id type)
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}