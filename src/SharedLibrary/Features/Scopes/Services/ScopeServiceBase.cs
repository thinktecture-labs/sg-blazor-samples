using Microsoft.Extensions.Logging;

namespace SharedLibrary.Features.Scopes.Services;

public class ScopeServiceBase
{
	private readonly ILogger<ScopeServiceBase> _logger;
	private readonly int _count;

	public int Number => _count;

	public ScopeServiceBase(ILogger<ScopeServiceBase> logger, NumberProducer producer)
	{
		_logger = logger;
		_count = producer.GetNumber();
		_logger.LogInformation("{Typename} created as instance #{Count}", GetType().Name, _count);
	}

	public void Call()
	{
		_logger.LogInformation("{Typename} instance #{Count} called", GetType().Name, _count);
	}
}
