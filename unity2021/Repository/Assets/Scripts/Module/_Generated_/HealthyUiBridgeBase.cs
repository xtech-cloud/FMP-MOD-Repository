
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.26.0.  DO NOT EDIT!
//*************************************************************************************

using System;
using System.Threading;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Bridge;

namespace XTC.FMP.MOD.Repository.LIB.Unity
{

    public class HealthyUiBridgeBase : IHealthyUiBridge
    {
        public LibMVCS.Logger logger { get; set; }

        public virtual void Alert(string _code, string _message, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }


        public virtual void RefreshEcho(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

    }
}
