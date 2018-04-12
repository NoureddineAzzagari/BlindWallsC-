using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindWalls.BusinessLogic.AOP
{
    [Serializable]
    public class TraceAttribute : OnMethodBoundaryAspect
    {
        public TraceAttribute()
        {
        }

        public override void OnEntry(MethodExecutionArgs eventArgs)
        { Trace.TraceInformation("Entering {0}.", eventArgs.Method); }

        public override void OnExit(MethodExecutionArgs eventArgs)
        { Trace.TraceInformation("Leaving {0}.", eventArgs.Method); }
    }
}
