﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.SMZ3.Tracking.Configuration
{
    /// <summary>
    /// Representation of a location to be displayed on the map at a certain position
    /// </summary>
    public class TrackerMapLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="TrackerMapLocation"/> class using the specified JSON file
        /// name.
        /// </summary>
        /// <param name="region">The region that this location belongs to</param>
        /// <param name="name">The name of this location</param>
        /// <param name="x">The x location to place this location on the map</param>
        /// <param name="y">The y location to place this location on the map</param>
        /// <param name="scale">The ratio at which this location has been scaled down (for combined maps)</param>
        public TrackerMapLocation(string region, string name, int x, int y, double scale = 1)
        {
            Region = region;
            Name = name;
            X = x;
            Y = y;
            Scale = scale;
        }

        /// <summary>
        /// The region that this location belongs to
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The name of this location
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The x location to place this location on the map
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y location to place this location on the map
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The ratio at which this location has been scaled down (for combined maps)
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// Given a randomizer <see cref="Location"/>, see if this location matches it by name
        /// </summary>
        /// <param name="loc">The randomizer location to compare to</param>
        /// <returns>True if the location matches the randomizer location, false otherwise</returns>
        public bool MatchesSMZ3Location(Location loc)
        {
            return (Region == loc.Region.Name && Name == loc.Name)
                || (Region == loc.Region.Name && Name == loc.Room?.Name)
                || (Region == Name && Name == loc.Region.Name);
        }
    }
}
