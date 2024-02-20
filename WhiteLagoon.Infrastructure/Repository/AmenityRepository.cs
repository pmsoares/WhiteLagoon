using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class AmenityRepository(ApplicationDbContext db) : Repository<Amenity>(db), IAmenityRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Amenity entity)
        {
            _db.Amenities.Update(entity);
        }
    }
}
