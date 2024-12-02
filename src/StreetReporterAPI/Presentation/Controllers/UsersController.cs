using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Application.Interfaces;

namespace StreetReporterAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service; 
        public UsersController(IUserService userService) 
        {
            _service = userService;
        }

        /// <summary>
        /// Get a user from its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<IncidentResponse>>> GetById(uint id)
        {
            var response = await _service.GetById(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Get a user from its unique email address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/by-email/{email}")]
        public async Task<ActionResult<ApiResponse<IncidentResponse>>> GetByEmail(string email)
        {
            var response = await _service.GetByEmail(email);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="userToAdd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddUser(UserRequest userToAdd)
        {
            var response = await _service.AddUser(userToAdd);

            if (!response)
                return BadRequest();

            return Ok();
        }
    }
}
