﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Application.Interfaces;
using StreetReporterAPI.Domain.Entities.Reports;

namespace StreetReporterAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;
        public ReportsController(IReportService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all reports for a given user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/by-user/{id}")]
        public async Task<ActionResult<ApiResponse<List<ReportResponse>>>> GetAllByUser(uint id)
        {
            var response = await _service.GetAllByUser(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Gets all reports for a given organization id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/by-organization/{id}")]
        public async Task<ActionResult<ApiResponse<List<ReportResponse>>>> GetAllByOrganization(uint id)
        {
            var response = await _service.GetAllByOrganization(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Gets all active reports for a given organization id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/by-organization/{id}/active")]
        public async Task<ActionResult<ApiResponse<List<ReportResponse>>>> GetAllActiveByOrganization(uint id)
        {
            var response = await _service.GetAllActiveByOrganization(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Get a report from its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ReportResponse>>> GetById(uint id)
        {
            var response = await _service.GetById(id);

            if (response?.ResponseObject == null)
                return NotFound(response?.ErrorMessage);

            return Ok(response.ResponseObject);
        }

        /// <summary>
        /// Add a report
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(ReportRequest report)
        {
            var response = await _service.AddReport(report);

            if (response)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Delete a report from its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(uint id)
        {
            var response = await _service.DeleteReport(id);

            if (response)
                return Ok();

            return BadRequest();
        }

    }
}
