//@CodeCopy
//MdStart
#if ACCOUNT_ON
using QTHungryDogs.Logic.Entities.Logging;

namespace QTHungryDogs.Logic.Controllers.Account
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
