using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hide_and_Seek
{
    interface IHasExteriorDoor
    {
        string DoorDescription { get; }
        Location DoorLocation { get; set; }
    }
}
