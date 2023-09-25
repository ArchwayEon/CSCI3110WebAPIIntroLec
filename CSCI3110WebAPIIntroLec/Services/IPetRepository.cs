using CSCI3110WebAPIIntroLec.Models.Entities;

namespace CSCI3110WebAPIIntroLec.Services;

public interface IPetRepository
{
    ICollection<Pet> ReadAll();
    Pet Create(Pet pet);
}

