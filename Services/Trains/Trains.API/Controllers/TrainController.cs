using Microsoft.AspNetCore.Mvc;
using System.Net;
using Trains.API.Entities;
using Trains.API.Helper;
using Trains.API.Repositories;

namespace Trains.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly ITrainsRepository _repository;
        public const string folderName = "UploadedFiles";
        public readonly string folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        public TrainController(ITrainsRepository repository)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Single File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] IFormFile  fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
               await _repository.PostFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Multiple File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<IFormFile> fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _repository.PostMultiFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                await _repository.DownloadFileById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

