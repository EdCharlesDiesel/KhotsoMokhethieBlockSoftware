using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Text;
using Trains.API.Context;
using Trains.API.Entities;
using Trains.API.Helper;

namespace Trains.API.Repositories
{
    public class TrainsRepository : ITrainsRepository
    {       
        private readonly TrainsDbContext _context;

        public TrainsRepository(TrainsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    //Id = new Guid(),
                    FileName = fileData.FileName,
                    FileType = null,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _context.FileDetails.Add(fileDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostMultiFileAsync(List<IFormFile> fileData)
        {
            try
            {
                foreach (FileUploadModel file in fileData)
                {
                    var fileDetails = new FileDetails()
                    {
                        Id = new Guid(),
                        FileName = file.FileDetails.FileName,
                        FileType = "",
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        fileDetails.FileData = stream.ToArray();
                    }

                    var result = _context.FileDetails.Add(fileDetails);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DownloadFileById(Guid Id)
        {
            try
            {
                var file = _context.FileDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);
                await CopyStream(content, path);

                //Read File and apply algorithmn.
                int start = 0;
                int[][][] roads = {
                    new int[][] { new int[] { 1, 7 } },
                    new int[][] { new int[] { 2, 6 }, new int[] { 3, 20 }, new int[] { 4, 3 } },
                    new int[][] { new int[] { 3, 14 } },
                    new int[][] { new int[] { 4, 2 } },
                    new int[][] {},
                    new int[][] {}
                    };

                var result = ShortestDistanceAlgorithmn.CalculateDistance(start, roads);
                var newString = new StringBuilder();
                foreach (var item in result)
                {
                    if (item == -1)
                        newString.Append("Output #:NO ROUTE");
                    newString.Append($"Output #:{item}");
                    newString.Append(Environment.NewLine);
                }
                    
               

                File.WriteAllText(path, $"Output #: {newString}");               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
