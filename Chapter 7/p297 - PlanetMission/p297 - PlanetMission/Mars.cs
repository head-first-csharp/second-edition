using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p297___PlanetMission
{
    class Mars : PlanetMission
    {
        public Mars()
        {
            MilesToPlanet = 75000000;
            RocketFuelPerMile = 100000;
            RocketSpeedMPH = 25000;
        }
    }
}
