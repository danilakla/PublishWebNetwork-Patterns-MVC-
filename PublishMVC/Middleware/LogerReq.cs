
using Pattern.Singleton;

namespace PublishMVC.Middleware
{
	public class RequestLogerMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestLogerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var logerService = FileWorkerSingleton.Instance;
			logerService.WriteText(DateTime.Now.ToString());
			logerService.WriteText(" IP: ");

			logerService.WriteText(context.Request.HttpContext.Connection.RemoteIpAddress.ToString());

			var saveData = new Task(() => logerService.Save());
			 saveData.Start();
			Console.WriteLine("1");

			
			// Call the next delegate/middleware in the pipeline.
			await _next(context);
		}
	}

	public static class RequestCultureMiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestLoger(
			this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestLogerMiddleware>();
		}
	}
}
