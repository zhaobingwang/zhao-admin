using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zhao.Admin.ApplicationCore.Entities;
using Zhao.Admin.ApplicationCore.Interfaces;
using Zhao.Admin.WebApi.Dtos;

namespace Zhao.Admin.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;
        private readonly IMapper _mapper;
        private readonly ILogger<SampleController> _logger;

        public SampleController(ISampleService sampleService, IMapper mapper, ILogger<SampleController> logger)
        {
            _sampleService = sampleService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{sampleId}")]
        public async Task<ActionResult> GetAsync([FromRoute]Guid sampleId)
        {
            var entity = await _sampleService.GeyAsync(sampleId);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SampleDto sampleDto)
        {
            var sample = _mapper.Map<SampleDto, Sample>(sampleDto);
            var result = await _sampleService.CreateAsync(sample);
            return Ok(result);
        }

    }
}