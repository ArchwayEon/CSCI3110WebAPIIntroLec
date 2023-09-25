using CSCI3110WebAPIIntroLec.Models.Entities;

namespace CSCI3110WebAPIIntroLec.Services;

public class DbPetRepository : IPetRepository
{
    private readonly ApplicationDbContext _db;

    public DbPetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Pet Create(Pet pet)
    {
        _db.Pets.Add(pet);
        _db.SaveChanges();
        return pet;
    }

    public ICollection<Pet> ReadAll()
    {
        return _db.Pets.ToList();
    }
}

