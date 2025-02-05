﻿using System;
using System.Collections.Generic;
using System.Linq;
using Randomizer.Shared;

namespace Randomizer.SMZ3.Tracking.Configuration
{
    /// <summary>
    /// Represents extra information about a region in SMZ3.
    /// </summary>
    public class RegionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionInfo"/> class
        /// with the specified info.
        /// </summary>
        /// <param name="typeName">
        /// The fully qualified name of the region type.
        /// </param>
        /// <param name="name">The possible names for the region.</param>
        /// <param name="mapName">The map name to display for the region.</param>
        public RegionInfo(string typeName, SchrodingersString name, string mapName)
        {
            TypeName = typeName;
            Name = name;
            MapName = mapName;
        }

        /// <summary>
        /// Gets the fully qualified name of the region, e.g.
        /// <c>Randomizer.SMZ3.Regions.SuperMetroid.Brinstar.BlueBrinstar</c>.
        /// </summary>
        public string TypeName { get; }

        /// <summary>
        /// Gets the possible names for the region.
        /// </summary>
        public SchrodingersString Name { get; }

        /// <summary>
        /// Gets the possible hints for the region, if any are defined.
        /// </summary>
        public SchrodingersString? Hints { get; init; }

        /// <summary>
        /// The name of the map to display for this region
        /// </summary>
        public string MapName { get; init; }

        /// <summary>
        /// Returns the <see cref="Region"/> that matches the region info in the
        /// specified world.
        /// </summary>
        /// <param name="world">The world to find the region in.</param>
        /// <returns>
        /// A matching <see cref="Region"/> for the current region info.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// There is no matching region in <paramref name="world"/>. -or- There
        /// is more than one matching region in <paramref name="world"/>.
        /// </exception>
        public Region GetRegion(World world)
            => world.Regions.Single(x => x.GetType().FullName == TypeName);

        /// <summary>
        /// Returns a string representation of the region.
        /// </summary>
        /// <returns>A string representation of this region.</returns>
        public override string? ToString() => Name[0];

        /// <summary>
        /// Text for Tracker to say when dying in a room or screen in the region
        /// </summary>
        public Dictionary<string, SchrodingersString>? WhenDiedInRoom { get; init; }
    }
}
