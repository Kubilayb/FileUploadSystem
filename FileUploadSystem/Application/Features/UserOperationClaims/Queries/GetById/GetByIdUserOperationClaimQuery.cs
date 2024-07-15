using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetById
{
    public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimResponse>
    {
        public int Id { get; set; }
    }
}
