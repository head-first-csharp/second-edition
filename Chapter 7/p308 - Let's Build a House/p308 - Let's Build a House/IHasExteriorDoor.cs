using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lets_Build_a_House
{
    interface IHasExteriorDoor
    {
        string DoorDescription { get; }
        Location DoorLocation { get; set; }
    }
}
