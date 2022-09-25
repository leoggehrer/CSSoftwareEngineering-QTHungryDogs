//@CodeCopy
//MdStart
#if ACCOUNT_ON && LOGGING_ON
using QTHungryDogs.Logic.Entities.Logging;

namespace QTHungryDogs.Logic.Controllers.Logging
{
    internal sealed partial class ActionLogsController : GenericController<ActionLog>
    {
        public ActionLogsController()
        {
        }

        public ActionLogsController(ControllerObject other) : base(other)
        {
        }
    }
}
#endif
//MdEnd
