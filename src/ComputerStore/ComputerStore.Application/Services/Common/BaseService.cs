using AutoMapper;
using ComputerStore.Application.Common.Interfaces.UOW;

namespace ComputerStore.Application.Services.Common
{
    public abstract class BaseService
    {
        protected IMapper mapper;
        protected IUnitOfWork unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            this.unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
        }

    }
}
