using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace DotNetMiddlewareSample.WebApi.Middleware
{
    /// <summary>
    /// 実行時間を記録するミドルウェアです。
    /// </summary>
    public class StopwatchMiddleware : OwinMiddleware
    {
        public StopwatchMiddleware(OwinMiddleware next) : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            context.Response.OnSendingHeaders(x =>
            {
                // リクエスト実行時間をレスポンスヘッダーに記載します。
                context.Response.Headers.Add("X-Execution-Time", new[] { sw.ElapsedMilliseconds.ToString() });
            }, context);

            await Next.Invoke(context);
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
        /// <param name="app"><see cref="IAppBuilder"/>></param>
        /// <returns><see cref="IAppBuilder"/></returns>
        public static IAppBuilder UseStopwatch(this IAppBuilder app)
        {
            return app.Use<StopwatchMiddleware>();
        }
    }
}
