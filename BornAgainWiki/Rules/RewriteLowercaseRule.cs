using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace BornAgainWiki.Rules
{
	public sealed class RewriteLowercaseRule : IRule
	{
		public int StatusCode { get; } = (int)HttpStatusCode.MovedPermanently;

		public void ApplyRule(RewriteContext context)
		{
			HttpRequest request = context.HttpContext.Request;
			PathString path = context.HttpContext.Request.Path;
			HostString host = context.HttpContext.Request.Host;

			if (path.HasValue && path.Value.Any(char.IsUpper) || host.HasValue && host.Value.Any(char.IsUpper))
			{
				HttpResponse response = context.HttpContext.Response;
				response.StatusCode = StatusCode;
				response.Headers[HeaderNames.Location] = (request.Scheme + "://" + host.Value + request.PathBase.Value + request.Path.Value).ToLower() + request.QueryString;
				context.Result = RuleResult.EndResponse;
			}
			else
			{
				context.Result = RuleResult.ContinueRules;
			}
		}
	}
}
