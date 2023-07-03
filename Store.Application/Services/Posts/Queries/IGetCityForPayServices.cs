using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Posts.Queries
{
    public interface IGetCityForPayServices
    {
        Task<ResultDto<List<GetCityForPayDto>>> Execute(string CityId);
    }
    public class GetCityForPayServices : IGetCityForPayServices
    {
        private readonly IDatabaseContext _context;
        public GetCityForPayServices(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<GetCityForPayDto>>> Execute(string CityId)
        {

            var cities = _context.Provinces
                .Where(p => p.Id == CityId)
                .OrderBy(p => p.Id)
                .ToList()
                .Select(p => new GetCityForPayDto
                {
                    Id = p.Id,
                    Cost = p.Cost,
                    Day = p.DeliverDay,
                }).ToList();
            return new ResultDto<List<GetCityForPayDto>>()
            {
                Data = cities,
                IsSuccess = true,
            };
        }
    }
    public class GetCityForPayDto
    {
        public string Id { get; set; }
        public double Cost { get; set; }
        public int Day { get; set; }
    }
}
