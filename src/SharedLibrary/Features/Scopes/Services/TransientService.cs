using Microsoft.Extensions.Logging;

namespace SharedLibrary.Features.Scopes.Services;

public class TransientService : ScopeServiceBase
{
	public TransientService(ILogger<TransientService> logger, NumberProducer producer) : base(logger, producer)
	{
	}
}
