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

        ///// <summary>
        ///// Upload a text document with the coordinations
        ///// </summary>
        ///// <param name="myFile"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> UploadDocument([FromForm(Name = "myFile")] IFormFile myFile)
        //{
        //    using (var fileContentStream = new MemoryStream())
        //    {
        //        await myFile.CopyToAsync(fileContentStream);
        //        await System.IO.File.WriteAllBytesAsync(Path.Combine(folderPath, myFile.FileName), fileContentStream.ToArray());
        //    }           

        //    return CreatedAtRoute(routeName: "myFile", routeValues: new { filename = myFile.FileName }, value: null); ;
        //}  

        ///// <summary>
        ///// Get the uploaded Document 
        ///// </summary>
        ///// <param name="filename"></param>
        ///// <returns></returns>
        //[HttpGet("{fileName}", Name = "myFile")]
        //public async Task<IActionResult> GetResultFromUploadDocument([FromRoute] String filename)
        //{
        //    var filePath = Path.Combine(folderPath, filename);
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", filename);
        //    }

        //    Fileupload.ReadFile(folderName);
        //    return NotFound();
        //}

        ///// <summary>
        ///// Delete an upload document.
        ///// </summary>
        ///// <param name="attachment"></param>
        ///// <returns>No Content</returns>      
        //[HttpDelete("{documentName}", Name = "DeleteAttachment")]
        //[ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<bool>> DeleteAttachment(string attachment)
        //{
        //    return Ok();
        //    //return Ok(await _repository.DeleteAttachment(attachment));
        //}
    }
}

