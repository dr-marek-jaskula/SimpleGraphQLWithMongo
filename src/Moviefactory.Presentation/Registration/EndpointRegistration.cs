using Microsoft.AspNetCore.Builder;
using Moviefactory.Presentation.Endpoints;
using System.Reflection;

namespace Moviefactory.Presentation.Registration;

public static class EndpointRegistration
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        var endpointTypes = GetEndpointTypes();

        foreach (var endpointType in endpointTypes)
        {
            var endpointGroup = GetEndpointGroupType(endpointType);
            var endpointRegisterMethod = endpointType.GetStaticMethod(nameof(IEndpoint.RegisterEndpoint));

            if (endpointGroup is null)
            {
                endpointRegisterMethod.Invoke(null, [app]);
                continue;
            }

            var endpointGroupRegisterMethod = endpointGroup.GetStaticMethod(nameof(IEndpointGroup.RegisterEndpointGroup));
            var routeGroupBuilder = endpointGroupRegisterMethod.Invoke(null, [app]);
            endpointRegisterMethod.Invoke(null, [routeGroupBuilder]);
        }

        return app;
    }

    private static Type? GetEndpointGroupType(TypeInfo endpoint)
    {
        return endpoint
            .GetInterfaces()
            .First(x => x.IsGenericType && x.Name.Contains(nameof(IEndpoint)))
            .GetGenericArguments()
            .FirstOrDefault(x => x.IsAssignableTo(typeof(IEndpointGroup)));
    }

    private static TypeInfo[] GetEndpointTypes()
    {
        return typeof(EndpointRegistration)
            .Assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
            .ToArray();
    }

    private static MethodInfo GetStaticMethod(this Type type, string name)
    {
        return type.GetMethod(name, BindingFlags.Static | BindingFlags.Public)!;
    }
}