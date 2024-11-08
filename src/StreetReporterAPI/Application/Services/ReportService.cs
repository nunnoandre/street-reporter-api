using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Application.Constants;
using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Application.Helpers;
using StreetReporterAPI.Application.Interfaces;
using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Domain.Entities.Users;
using StreetReporterAPI.Infrastructure.Data;

namespace StreetReporterAPI.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly DataContext _context;
        public ReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReport(ReportRequest reportToAdd)
        {       
            var reportModel = reportToAdd.ToReportModel();

            await _context.Reports.AddAsync(reportModel);

            var rowsAdded = await _context.SaveChangesAsync();

            if(rowsAdded == 1 && reportModel.Id != 0)
                return true; 

            return false;

        }

        public async Task<bool> DeleteReport(uint idToDelete)
        {
            var reportToDelete = await _context.Reports.FindAsync(idToDelete);
            
            if(reportToDelete == null) return false;

            _context.Reports.Remove(reportToDelete);

            var rowsDeleted = await _context.SaveChangesAsync();

            if (rowsDeleted == 1)
                return true;

            return false;
        }

        public async Task<ApiResponse<List<ReportResponse>>> GetAllActiveByOrganization(uint idOrganization)
        {
            var response = new ApiResponse<List<ReportResponse>>();

            var reportsFound = await _context.Reports.Where(x => x.ResponsibleOrganizationId.Equals(idOrganization) && x.IsArchived == false).ToListAsync();

            if (reportsFound is null)
            {
                response.ErrorMessage = ErrorMessage.ActiveReportsNotFoundByOrganization;
                return response;
            }

            var reportsResponseList = new List<ReportResponse>();

            foreach (var report in reportsFound)
            {
                reportsResponseList.Add(report.ToReponseModel());
            }

            response.ResponseObject = reportsResponseList;
            return response;
        }

        public async Task<ApiResponse<List<ReportResponse>>> GetAllByOrganization(uint idOrganization)
        {
            var response = new ApiResponse<List<ReportResponse>>();

            var reportsFound = await _context.Reports.Where(x => x.ResponsibleOrganizationId.Equals(idOrganization)).ToListAsync();

            if (reportsFound is null)
            {
                response.ErrorMessage = ErrorMessage.ReportsNotFoundByOrganization;
                return response;
            }

            var reportsResponseList = new List<ReportResponse>();

            foreach (var report in reportsFound)
            {
                reportsResponseList.Add(report.ToReponseModel());
            }

            response.ResponseObject = reportsResponseList;
            return response;
        }

        public async Task<ApiResponse<List<ReportResponse>>> GetAllByUser(uint idUser)
        {
            var response = new ApiResponse<List<ReportResponse>>();
            
            var reportsFound =  await _context.Reports.Where(x => x.UserId.Equals(idUser)).ToListAsync();
            
            if(reportsFound is null)
            {
                response.ErrorMessage = ErrorMessage.ReportsNotFoundByUser;
                return response;
            } 

            var reportsResponseList = new List<ReportResponse>();

            foreach(var report in reportsFound)
            {
                reportsResponseList.Add(report.ToReponseModel());
            }
            
            response.ResponseObject = reportsResponseList;
            return response;
        }

        public async Task<ApiResponse<ReportResponse>> GetById(uint idReport)
        {
            var response = new ApiResponse<ReportResponse>();
            var reportFound = await _context.Reports.FindAsync(idReport);

            if(reportFound is null) 
            {
                response.ErrorMessage = ErrorMessage.ReportNotFoundById;
                return response;
            }

            response.ResponseObject = reportFound.ToReponseModel();
            return response;
        }
    }
}
