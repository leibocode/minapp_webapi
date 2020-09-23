using _02_Mapping_Welfare_Domain.DomainModels;
using _02_Mapping_Welfare_Domain.Interfaces;
using _03_Mapping_Welfare_Infrastructure.Data.Dtos.BannerDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0_Mapping_Welfare_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController:ControllerBase
    {

        private readonly IBannerRepository _bannerRepository;

        private  IMapper _mapper { get; set; }

        private readonly ILogger<BannerController> _logger;

        public BannerController(IBannerRepository bannerRepository,IMapper mapper, ILogger<BannerController>  logger)
        {
            _bannerRepository = bannerRepository;

            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BannerDto>>> GetBanners()
        {
            var banners = await _bannerRepository.GetBanners();
            var bannerDtos = _mapper.Map<IEnumerable<BannerDto>>(banners);

            return Ok(bannerDtos);
        }
    }
}
