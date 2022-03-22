using Microsoft.Extensions.Logging;

namespace SharedLibrary.Features.Scopes.Services;

public class ScopedService : ScopeServiceBase
{
	public ScopedService(ILogger<ScopedService> logger, NumberProducer producer) : base(logger, producer)
	{
	}
}
