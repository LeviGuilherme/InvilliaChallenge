using Invillia.Challenge.Domain.RepositoryContracts;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Invillia.Challenge.CrossCutting.IoC.Filters
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (_unitOfWork)
            {
                var result = await next();

                if (result.Exception == null)
                {
                    _unitOfWork.Commit();
                }
            }
        }
    }
}
