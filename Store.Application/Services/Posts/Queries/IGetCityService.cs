using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Posts.Queries
{
    public interface IGetCityService
    {
      Task<ResultDto<List<GetCityDto>>> Execute(string provinceId);
    }
    public class GetCityService : IGetCityService
    {
        private readonly IDatabaseContext _context;
        public GetCityService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<GetCityDto>>> Execute(string provinceId)
        {

            var cities = _context.Provinces
                .Where(p => p.ParrentId == provinceId)
                .OrderBy(p => p.Id)
                .ToList()
                .Select(p => new GetCityDto
                {
                    Id = p.Id,
                    CityName = p.CityName,
                    Cost = p.Cost,
                    Day = p.DeliverDay,
                    ProvinceId = p.ParrentId
                }).ToList();
            return new ResultDto<List<GetCityDto>>()
            {
                Data = cities,
                IsSuccess = true,
            };
        }
    }
    public class GetCityDto
    {
        public string Id { get; set; }
        public string CityName { get; set; }
        public double Cost { get; set; }
        public int Day { get; set; }
        public string ProvinceId { get; set; }
    }
}
