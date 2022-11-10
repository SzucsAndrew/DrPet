using DrPet.Bll.Models;
using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DrPet.Bll.Services
{
    public sealed class OrderingHourService
    {
        private readonly DrPetDbContext _drPetDbContext;
        private const double PAGE_SIZE = 2;
        private const int SHOW_DAYS = 7;

        public OrderingHourService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IEnumerable<OrderingHour>> GetOrderingHoursAsync(int year, int month)
        {
            return await _drPetDbContext.OrderingHours
                .Include(o => o.Doctor)
                .Where(o => o.Date.Year == year
                         && o.Date.Month == month)
                .OrderBy(o => o.Date)
                .ThenBy(o => o.Start)
                .ToListAsync();
        }

        private async Task<int> GetOrderingHoursCountAsync(int year, int month)
        {
            return await _drPetDbContext.OrderingHours
                .Where(o => o.Date.Year == year
                         && o.Date.Month == month)
                .CountAsync();
        }

        private async Task<IEnumerable<OrderingHour>> GetOrderingHoursAsync(int year, int month, int currentPage)
        {
            return await _drPetDbContext.OrderingHours
                .Include(o => o.Doctor)
                .Where(o => o.Date.Year == year
                         && o.Date.Month == month)
                .OrderBy(o => o.Date)
                .ThenBy(o => o.Start)
                .Skip(currentPage * (int)PAGE_SIZE)
                .Take((int)PAGE_SIZE)
                .ToListAsync();
        }

        public async Task<PaginationModel<OrderingHour>> GetOrderingHoursPaginationAsync(DateOnly dateOnly, int currentPage)
        {
            var count = await GetOrderingHoursCountAsync(dateOnly.Year, dateOnly.Month);
            var orderingHours = await GetOrderingHoursAsync(dateOnly.Year, dateOnly.Month, currentPage);

            var result = new PaginationModel<OrderingHour>
            {
                CurrentPage = currentPage,
                Results = orderingHours,
                TotalOfPage = (int)Math.Ceiling(count / PAGE_SIZE)
            };
            return result;
        }

        public async Task<IEnumerable<OrderingHour>> GetOrderingHoursAsync(int year, string monthName)
        {
            var month = DateTime.ParseExact(monthName, "MMM", CultureInfo.InvariantCulture).Month;
            return await GetOrderingHoursAsync(year, month);
        }

        public async Task<IEnumerable<OrderingHour>> GetOrderingOursAsync(DateTime dateTime)
        {
            var startDate = dateTime.Date;
            var endDate = startDate.AddDays(SHOW_DAYS);

            return await _drPetDbContext.OrderingHours
                .Include(o => o.Doctor)
                .Where(o => o.Date >= startDate && o.Date <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderingHour>> GetFuturingOrderingOursByDoctorAsync(int doctorId, DateTime startDate)
        {
            return await _drPetDbContext.OrderingHours
               .Where(o =>o.DoctorId == doctorId
                          && o.Date >= startDate.Date)
               .ToListAsync();
        }
    }
}
