using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Application.Interfaces;

namespace StreetincidenterAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _service;
        public IncidentsController(IIncidentService service)
        {
            _service = service;
        }


        /// <summary>
        /// Gets all incidents for a given organization id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/by-organization/{id}")]
        public async Task<ActionResult<ApiResponse<List<IncidentResponse>>>> GetAllByOrganization(uint id)
        {
            var response = await _service.GetAllByOrganization(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Gets all active incidents for a given organization id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/by-organization/{id}/active")]
        public async Task<ActionResult<ApiResponse<List<IncidentResponse>>>> GetAllActiveByOrganization(uint id)
        {
            var response = await _service.GetAllActiveByOrganization(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Get a incident from its unique id
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
        /// Add a incident
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(IncidentRequest incident)
        {
            var response = await _service.AddIncident(incident);

            if (response)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Delete a incident from its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(uint id)
        {
            var response = await _service.DeleteIncident(id);

            if (response)
                return Ok();

            return BadRequest();
        }
    }
}
