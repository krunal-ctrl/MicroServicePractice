using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController(IPlatformRepo platformRepo, IMapper mapper): ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var enumerable = platformRepo.GetAll();
        return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(enumerable));
    }

    [HttpGet("{id:int}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = platformRepo.Get(id);
        if (platform == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<PlatformReadDto>(platform)); 
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> Create(PlatformCreateDto platform)
    {
        var platformModel = mapper.Map<Platform>(platform);
        platformRepo.Create(platformModel);

        var platformReadDto = mapper.Map<PlatformReadDto>(platformModel);
        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
    }
}