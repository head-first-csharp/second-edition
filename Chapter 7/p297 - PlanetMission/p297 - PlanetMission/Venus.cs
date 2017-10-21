using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p297___PlanetMission
{
    class Venus : PlanetMission
    {
        public Venus()
        {
            MilesToPlanet = 40000000;
            RocketFuelPerMile = 100000;
            RocketSpeedMPH = 25000;
        }
    }

}
