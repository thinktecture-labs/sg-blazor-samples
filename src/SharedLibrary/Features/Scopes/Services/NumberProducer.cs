using Microsoft.Extensions.Logging;

namespace SharedLibrary.Features.Scopes.Services;

public class NumberProducer
{
	private readonly ILogger<NumberProducer> _logger;
	private int _count = 1;

	public NumberProducer(ILogger<NumberProducer> logger)
	{
		_logger = logger;
		_logger.LogInformation("Number producer service instanciated");
	}

	public int GetNumber()
	{
		_logger.LogInformation("New count requested: {Count}", _count);
		return _count++;
	}
}
