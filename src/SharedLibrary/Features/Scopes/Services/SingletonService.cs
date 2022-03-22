using Microsoft.Extensions.Logging;

namespace SharedLibrary.Features.Scopes.Services;

public class SingletonService : ScopeServiceBase
{
	public SingletonService(ILogger<SingletonService> logger, NumberProducer producer) : base(logger, producer)
	{
	}
}
