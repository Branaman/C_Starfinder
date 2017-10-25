using C_Starfinder.Models;
using System.Collections.Generic;
namespace C_Starfinder.Factories
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}