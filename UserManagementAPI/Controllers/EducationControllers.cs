using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagementAPI.DTO;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            this.educationRepository = educationRepository;
        }

        // POST api/education/add
        [HttpPost("add")]
        public async Task<IActionResult> AddEducation([FromBody] EducationDTO educationDto)
        {
            if (educationDto == null)
            {
                return BadRequest("Education data is null.");
            }

            try
            {
                var education = new Education
                {
                    EducationId = educationDto.EducationId,
                    Institution = educationDto.Institution,
                    Degree = educationDto.Degree
                };

                await educationRepository.AddEducationAsync(education);
                return Ok("Education record added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding education: {ex.Message}");
            }
        }

        // DELETE api/education/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            try
            {
                await educationRepository.DeleteEducationAsync(id);
                return Ok("Education record deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting record: {ex.Message}");
            }
        }

        // PUT api/education/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateEducation([FromBody] EducationDTO educationDto, int userId)
        {
            if (educationDto == null)
            {
                return BadRequest("Education data is null.");
            }

            try
            {
                var education = new Education
                {
                    EducationId = educationDto.EducationId,
                    Institution = educationDto.Institution,
                    Degree = educationDto.Degree
                };

                await educationRepository.UpdateEducationAsync(education, userId);
                return Ok("Education record updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating record: {ex.Message}");
            }
        }
    }
}
