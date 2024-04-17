using Microsoft.AspNetCore.Routing;

namespace Moviefactory.Presentation.Endpoints;

public interface IEndpointGroup
{
    IEndpointRouteBuilder RegisterEndpointGroup(IEndpointRouteBuilder app);
}