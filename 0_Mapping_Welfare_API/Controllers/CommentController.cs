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
    [ApiController]
    [Route("api/{activityId}/comments")]
    public class CommentController:ControllerBase
    {

        private readonly IActivityRepository _activityRepository;

        private readonly IUnitwork _unitwork;

        private IMapper _mapper { get; set; }

        private readonly ILogger<ActivityController> _logger;

        public CommentController(IActivityRepository activityRepository, IMapper mapper, ILogger<ActivityController> logger, IUnitwork unitwork)
        {
            _activityRepository = activityRepository;

            _mapper = mapper;
            _logger = logger;
            _unitwork = unitwork;
        }



        /// <summary>
        /// 获取所有的评论
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CommentDto>> GetComments(Guid activityId)
        {
            if (!await _activityRepository.ActivityExits(activityId))
            {
                //记录日志
                return NotFound();
            }

            var query = await _activityRepository.GetComments(activityId);

            var commentsList = _mapper.Map<CommentDto>(query);

            return Ok(commentsList);
        }


        /// <summary>
        /// 添加一条评论
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddComment(Guid activityId,CommentDto comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            var commentEntity = _mapper.Map<Comments>(comment);

            _activityRepository.AddComment(commentEntity,activityId);

            await _unitwork.SaveAsync();

            return Ok();

        }
    }
}
