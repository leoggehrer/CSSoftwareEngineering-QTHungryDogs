//@CodeCopy
//MdStart

using QTHungryDogs.Logic.Controllers;

namespace QTHungryDogs.Logic.Facades
{
    public abstract partial class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
