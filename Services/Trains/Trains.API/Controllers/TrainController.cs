using Microsoft.AspNetCore.Mvc;
using System.Net;
using Trains.API.Entities;
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
        /// Upload document
        /// </summary>
        /// <param name="myFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromForm(Name = "myFile")] IFormFile myFile)
        {
            using (var fileContentStream = new MemoryStream())
            {
                await myFile.CopyToAsync(fileContentStream);
                await System.IO.File.WriteAllBytesAsync(Path.Combine(folderPath, myFile.FileName), fileContentStream.ToArray());
            }

            ReadFile(folderName);

            return CreatedAtRoute(routeName: "myFile", routeValues: new { filename = myFile.FileName }, value: null); ;
        }

        private void ReadFile(string folderName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the uploaded Document 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpGet("{filename}", Name = "myFile")]
        public async Task<IActionResult> GetUploadedDocument([FromRoute] String filename)
        {
            var filePath = Path.Combine(folderPath, filename);
            if (System.IO.File.Exists(filePath))
            {
                return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", filename);
            }
            return NotFound();
        }

        /// <summary>
        /// Get the uploaded Document 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpGet(Name ="Get Results")]
        public async Task<IActionResult> GetResults([FromRoute] String filename)
        {
            var filePath = Path.Combine(folderPath, filename);
            if (System.IO.File.Exists(filePath))
            {
                return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", filename);
            }
            return NotFound();
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(Attachment), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<Attachment>> UploadFile([FromBody] Attachment attachment)
        //{
        //    await _repository.CreateAttachment(attachment);
            
        //    return CreatedAtRoute("GetAttachment", 
        //        new  { 
                    
        //        }, attachment);
        //}

        //[HttpPut]
        //[ProducesResponseType(typeof(Attachment), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<Attachment>> UpdateAttachment([FromBody] Attachment attachment)
        //{
        //    return Ok(await _repository.UpdateAttachment(attachment));
        //}

        [HttpDelete("{documentName}", Name = "DeleteAttachment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteAttachment(string attachment)
        {
            return Ok();
            //return Ok(await _repository.DeleteAttachment(attachment));
        }

    }
}

