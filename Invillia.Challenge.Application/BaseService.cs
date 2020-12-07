using AutoMapper;
using Volo.Abp.Guids;

namespace Invillia.Challenge.Application
{
    public abstract class BaseService
    {
        public IGuidGenerator GuidGenerator { get; private set; }

        public IMapper Mapper { get; private set; }


        public BaseService(IGuidGenerator guidGenerator, IMapper mapper)
        {
            GuidGenerator = guidGenerator;
            Mapper = mapper;
        }
    }
}
