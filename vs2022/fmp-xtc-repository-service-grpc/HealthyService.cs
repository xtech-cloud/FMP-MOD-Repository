
using Grpc.Core;
using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class HealthyService : HealthyServiceBase
    {
        // 解开以下代码的注释，可支持数据库操作
        /*
        private readonly YourDAO yourDAO_;

         /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// 支持多个参数，均为自动注入，注入点位于MyProgram.PreBuild
        /// </remarks>
        /// <param name="_yourDAO">自动注入的数据操作对象</param>
        public HealthyService(YourDAO _yourDAO)
        {
            yourDAO_ = _yourDAO;
        }
        */

        protected override async Task<HealthyEchoResponse> safeEcho(HealthyEchoRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new HealthyEchoResponse
            {
                Status = new LIB.Proto.Status(),
                Msg = _request.Msg,
            });
        }
    }
}
