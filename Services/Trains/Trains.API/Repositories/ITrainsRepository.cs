
using Trains.API.Entities;

namespace Trains.API.Repositories
{
    public interface ITrainsRepository
    {
        Task<IEnumerable<Attachment>> GetAttachmentsAsync();
        Task<Attachment> GetAttachmentByNameAsync(string documentName);        
        Task CreateAttachmentAsync(Attachment attachment);
        Task UpdateAttachment(Attachment attachment);        
        Task DeleteAttachment(string documentName);
        Task SaveChangesAsync();
    }
}
