using AutoMapper;

namespace Zapas.Data.Automapper.Mappings
{
    public class DirectMapping<Result,Source>
    {
        public static Result CreateMapping(IMapper mapper, Source source)
        {
            return mapper
                .Map<Source,Result>(source);
        }
    }
}
