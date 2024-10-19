using AlternativeEngineerBlogServer.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEngineerBlogServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class SizesController(DatabaseInfoService databaseInfoService, FileSizeService fileSizeService) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetDatabaseInfo()
    {
        var response = await databaseInfoService.GetDatabaseInfo();
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetTotalFileSize()
    {
        var response = await fileSizeService.GetTotalSizeAsync();
        return StatusCode(response.StatusCode, response);
    }
}
