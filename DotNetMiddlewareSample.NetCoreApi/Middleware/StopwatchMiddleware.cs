using System.Diagnostics;

namespace DotNetMiddlewareSample.NetCoreApi.Middleware
{
    /// <summary>
    /// 実行時間を記録するミドルウェアです。
    /// </summary>
    public class StopwatchMiddleware
    {
        private readonly RequestDelegate next;

        public StopwatchMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            // リクエスト実行時間をレスポンスヘッダーに記載します。
            context.Response.OnStarting(x =>
            {
                context.Response.Headers.Add("X-Execution-Time", new[] { sw.ElapsedMilliseconds.ToString() });
                return Task.CompletedTask;
            }, context);

            await next(context);
            sw.Stop();
        }
    }

    /// <summary>
    /// <see cref="StopwatchMiddleware"/> 用の拡張メソッドです。
    /// </summary>
    public static class StopwatchMiddlewareExtensions
    {
        /// <summary>
        /// <see cref="StopwatchMiddleware"/> をパイプラインに登録します。
        /// </summary>
        /// <param name="builder"><see cref="IApplicationBuilder"/></param>
        /// <returns><see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StopwatchMiddleware>();
        }
    }
}
