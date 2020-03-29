using System.Collections.Generic;

namespace Censo.Application.Mappers
{
    public interface IMapper<MapFrom, MapTo>
    {
        MapTo Map(MapFrom source);

        IEnumerable<MapTo> Map(IEnumerable<MapFrom> source);
    }
}
