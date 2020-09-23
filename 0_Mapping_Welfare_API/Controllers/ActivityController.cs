using _02_Mapping_Welfare_Domain.DomainModels;
using _02_Mapping_Welfare_Domain.Interfaces;
using _03_Mapping_Welfare_Infrastructure.Data.Dtos.Comments;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0_Mapping_Welfare_API.Controllers
{
    /// <summary>
    /// 活动控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        private IMapper _mapper { get; set; }

        private readonly ILogger<ActivityController> _logger;

        public ActivityController(IActivityRepository activityRepository, IMapper mapper, ILogger<ActivityController> logger)
        {
            _activityRepository = activityRepository;

            _mapper = mapper;
            _logger = logger;

        }


    }
}
