using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using XamarinWeb.Api.Models;
using XamarinWeb.Api.Models.Requests;

namespace XamarinWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentsController(StudentDbContext context)
        {
            this.context = context;
        }

        
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [HttpPost("Create")]
        public async Task<IActionResult> PostCreate([FromBody] StudentRequestModel request)
        {
            if(request != null)
            {
                var student = new Student
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    ContactNo = request.ContactNo
                };

                context.Add(student);
                await context.SaveChangesAsync();

                var response = new Response
                {
                    Status = true,
                    Message = "Student record created successfully",
                    Data = new List<StudentRequestModel>
                    {
                        new StudentRequestModel{ UserName = request.UserName, Password = request.Password, ContactNo = request.ContactNo }
                    }
                };

                return Ok(response);
            }

            return BadRequest();
        }

        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [HttpGet("AllStudents")]
        public async Task<IActionResult> GetStudentRecords()
        {
            var students = await context.Students.ToListAsync();
            if(students != null)
            {
                return Ok(students);
            }
            return BadRequest();
        }
    }
}
