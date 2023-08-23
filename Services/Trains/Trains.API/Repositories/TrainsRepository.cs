using Microsoft.EntityFrameworkCore;
using Trains.API.Context;
using Trains.API.Entities;


namespace Trains.API.Repositories
{
    public class TrainsRepository : ITrainsRepository
    {       
        private readonly TrainsDbContext _context;

        public TrainsRepository(TrainsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Attachment>> GetAttachmentsAsync()
        {
            return await _context.attachments.ToListAsync();
        }

        public async Task<Attachment> GetResultsByFileNameAsync(string documentName)
        {
            return await _context.attachments.Where(x => x.FileName == documentName).FirstOrDefaultAsync();
        }

        public async Task CreateAttachmentAsync(Attachment attachmentPayload)
        {
            _context.attachments.Add(attachmentPayload);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttachment(string documentName)
        { 
            if (string.IsNullOrEmpty(documentName)) throw new ArgumentNullException(nameof(documentName));
            var documentToDelete = await _context.attachments.Where(x => x.FileName == documentName).FirstOrDefaultAsync();
            _context.attachments.Remove(documentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
