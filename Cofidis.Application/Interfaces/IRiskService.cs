using Cofidis.Domain.Entities;

namespace Cofidis.Application.Interfaces;

public interface IRiskService
{
    DataByNIF GetDataByNIF(string nif);
}