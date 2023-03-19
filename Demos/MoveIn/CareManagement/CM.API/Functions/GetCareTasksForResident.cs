using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SLS.CM.Services.Responses;
using TaleLearnCode;

namespace SLS.CM.Functions.Functions;

public class GetCareTasksForResident
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly ICareServices _careServices;

	public GetCareTasksForResident(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		ICareServices careServices)
	{
		_logger = loggerFactory.CreateLogger<GetCommunityResident>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_careServices = careServices;
	}

	[Function("GetCareTasksForResident")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "get", Route = "communities/{communityId}/residents/{residentId}/tasks")] HttpRequestData request,
		int communityId,
		int residentId)
	{
		try
		{
			ArgumentNullException.ThrowIfNull(communityId);
			ArgumentNullException.ThrowIfNull(residentId);
			ResidentCareTasks? response = await _careServices.GetCareTasksForResident(
				communityId,
				residentId);
			return await request.CreateResponseAsync(response, _jsonSerializerOptions);
		}
		catch (Exception ex) when (ex is ArgumentNullException)
		{
			return request.CreateBadRequestResponse(ex);
		}
		catch (Exception ex)
		{
			_logger.LogError("Unexpected exception: {ExceptionMessage}", ex.Message);
			return request.CreateErrorResponse(ex);
		}
	}


}