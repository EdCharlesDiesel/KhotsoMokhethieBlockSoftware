
using Trains.API.Entities;

namespace Trains.API.Repositories
{
    public interface ITrainsRepository
    {
        public Task PostFileAsync(IFormFile fileData);

        public Task PostMultiFileAsync(List<IFormFile> fileData);

        public Task DownloadFileById(Guid fileName);
    }
}
