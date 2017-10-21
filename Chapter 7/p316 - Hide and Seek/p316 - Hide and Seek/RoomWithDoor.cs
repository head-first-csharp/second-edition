using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hide_and_Seek
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration,
                            string hidingPlaceName, string doorDescription)
            : base(name, decoration, hidingPlaceName)
        {
            this.doorDescription = doorDescription;
        }

        private string doorDescription;
        public string DoorDescription
        {
            get { return doorDescription; }
        }

        private Location doorLocation;
        public Location DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }
    }
}
