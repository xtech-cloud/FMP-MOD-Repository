
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.28.2.  DO NOT EDIT!
//*************************************************************************************

using System;
using System.Threading;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Bridge;

namespace XTC.FMP.MOD.Repository.LIB.Unity
{

    public class ModuleUiBridgeBase : IModuleUiBridge
    {
        public LibMVCS.Logger logger { get; set; }

        public virtual void Alert(string _code, string _message, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }


        public virtual void RefreshCreate(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshUpdate(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshRetrieve(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshDelete(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshList(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshSearch(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshPrepareUpload(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshFlushUpload(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshAddFlag(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshRemoveFlag(IDTO _dto, SynchronizationContext _context)
        {
            throw new NotImplementedException();
        }

    }
}
