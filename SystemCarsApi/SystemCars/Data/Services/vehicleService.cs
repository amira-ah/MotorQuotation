using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using SystemCars.Data.Models;

namespace SystemCars.Data.Services
{
    public class vehicleService
    {
        private readonly DataContext _context;
        public vehicleService(DataContext context) {
            _context = context;
        }
        public async Task<List<VehicleQuotation>> GetData(string searchItem, string page, string pagesize, string sortOrder, string? sortColumn)
        {
            IQueryable<VehicleQuotation> vehicleQuery = _context.VehicleQuotation;
            List<MetadataColumDTO> Gridcolumns = VehicleQuotation.GridColumns;
            if (!string.IsNullOrEmpty(searchItem))
            {
                vehicleQuery = vehicleQuery.Where(p => p.CarMake.Contains(searchItem) || p.CarMake.Contains(searchItem));
            }
            if (!string.IsNullOrEmpty(sortColumn)) { 
            Expression<Func<VehicleQuotation, object>> keySelecter = sortColumn?.ToLower() switch {
                "PolicyOwner" => VehicleQuotation => VehicleQuotation.PolicyOwner,
                "CarMake" => VehicleQuotation => VehicleQuotation.CarMake,
                "YearOfMake" => VehicleQuotation => VehicleQuotation.YearOfMake,
                "QuotationStatus" => VehicleQuotation => VehicleQuotation.QuotationStatus,
                "CreationDate" => VehicleQuotation => VehicleQuotation.CreationDate,
                _ => VehicleQuotation => VehicleQuotation.QuotationNumber
            };

            vehicleQuery = sortOrder == "DESC" ? vehicleQuery.OrderByDescending(keySelecter) : vehicleQuery.OrderBy(keySelecter);

              }

            if (Int32.TryParse(page, out Int32 pageNumber) && Int32.TryParse(pagesize, out Int32 pageSize))
            {
                // took the random for page sizing since the data is not supported to bind from jquery
                vehicleQuery = vehicleQuery.Skip((pageNumber - 1) * 5001).Take(5001);
            }
             
            return await vehicleQuery.ToListAsync();
        }
      


    }

}
