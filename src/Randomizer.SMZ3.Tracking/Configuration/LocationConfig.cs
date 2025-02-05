﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizer.SMZ3.Tracking.Configuration
{
    /// <summary>
    /// Provides configurable information about locations in SMZ3.
    /// </summary>
    public class LocationConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationConfig"/>
        /// class.
        /// </summary>
        /// <param name="regions">The region information.</param>
        /// <param name="dungeons">The dungeon information.</param>
        /// <param name="bosses">The boss information.</param>
        /// <param name="rooms">The room information.</param>
        /// <param name="locations">The location information.</param>
        public LocationConfig(IReadOnlyCollection<RegionInfo> regions,
            IReadOnlyCollection<DungeonInfo> dungeons,
            IReadOnlyCollection<BossInfo> bosses,
            IReadOnlyCollection<RoomInfo> rooms,
            IReadOnlyCollection<LocationInfo> locations)
        {
            Regions = regions;
            Dungeons = dungeons;
            Bosses = bosses;
            Rooms = rooms;
            Locations = locations;
        }

        /// <summary>
        /// Gets a collection of extra information about regions.
        /// </summary>
        public IReadOnlyCollection<RegionInfo> Regions { get; }

        /// <summary>
        /// Gets a collection of extra information about dungeons.
        /// </summary>
        public IReadOnlyCollection<DungeonInfo> Dungeons { get; }

        /// <summary>
        /// Gets a collection of bosses.
        /// </summary>
        public IReadOnlyCollection<BossInfo> Bosses { get; init; }

        /// <summary>
        /// Gets a collection of extra information about rooms.
        /// </summary>
        public IReadOnlyCollection<RoomInfo> Rooms { get; }

        /// <summary>
        /// Gets a collection of extra information about locations.
        /// </summary>
        public IReadOnlyCollection<LocationInfo> Locations { get; }

        /// <summary>
        /// Returns extra information for the specified region.
        /// </summary>
        /// <param name="typeName">
        /// The fully qualified type name of the region.
        /// </param>
        /// <returns>
        /// A new <see cref="RegionInfo"/> for the specified region.
        /// </returns>
        public RegionInfo Region(string typeName)
            => Regions.Single(x => x.TypeName == typeName);

        /// <summary>
        /// Returns extra information for the specified region.
        /// </summary>
        /// <param name="region">The region to get extra information for.</param>
        /// <returns>
        /// A new <see cref="RegionInfo"/> for the specified region.
        /// </returns>
        public RegionInfo Region(Region region)
            => Regions.Single(x => x.TypeName == region.GetType().FullName);

        /// <summary>
        /// Returns extra information for the specified region.
        /// </summary>
        /// <typeparam name="TRegion">
        /// The type of region to get extra information for.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="RegionInfo"/> for the specified region.
        /// </returns>
        public RegionInfo Region<TRegion>() where TRegion : Region
            => Regions.Single(x => x.TypeName == typeof(TRegion).FullName);

        /// <summary>
        /// Returns extra information for the specified dungeon.
        /// </summary>
        /// <param name="typeName">
        /// The fully qualified type name of the dungeon region.
        /// </param>
        /// <returns>
        /// A new <see cref="DungeonInfo"/> for the specified dungeon region, or
        /// <c>null</c> if <paramref name="typeName"/> is not a valid dungeon.
        /// </returns>
        public DungeonInfo? Dungeon(string typeName)
            => Dungeons.SingleOrDefault(x => x.TypeName == typeName);

        /// <summary>
        /// Returns extra information for the specified dungeon.
        /// </summary>
        /// <param name="region">
        /// The dungeon region to get extra information for.
        /// </param>
        /// <returns>
        /// A new <see cref="DungeonInfo"/> for the specified dungeon region.
        /// </returns>
        public DungeonInfo Dungeon(Region region)
            => Dungeons.Single(x => x.TypeName == region.GetType().FullName);

        /// <summary>
        /// Returns extra information for the specified dungeon.
        /// </summary>
        /// <typeparam name="TRegion">
        /// The type of region that represents the dungeon to get extra
        /// information for.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="DungeonInfo"/> for the specified dungeon region.
        /// </returns>
        public DungeonInfo Dungeon<TRegion>() where TRegion : Region
            => Dungeons.Single(x => x.TypeName == typeof(TRegion).FullName);

        /// <summary>
        /// Returns extra information for the specified room.
        /// </summary>
        /// <param name="typeName">
        /// The fully qualified type name of the room.
        /// </param>
        /// <returns>
        /// A new <see cref="RoomInfo"/> for the specified room.
        /// </returns>
        public RoomInfo Room(string typeName)
            => Rooms.Single(x => x.TypeName == typeName);

        /// <summary>
        /// Returns extra information for the specified room.
        /// </summary>
        /// <param name="room">The room to get extra information for.</param>
        /// <returns>
        /// A new <see cref="RoomInfo"/> for the specified room.
        /// </returns>
        public RoomInfo Room(Room room)
            => Rooms.Single(x => x.TypeName == room.GetType().FullName);

        /// <summary>
        /// Returns extra information for the specified room.
        /// </summary>
        /// <typeparam name="TRoom">
        /// The type of room to get extra information for.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="RoomInfo"/> for the specified room.
        /// </returns>
        public RoomInfo Room<TRoom>() where TRoom : Room
            => Rooms.Single(x => x.TypeName == typeof(TRoom).FullName);

        /// <summary>
        /// Returns extra information for the specified location.
        /// </summary>
        /// <param name="id">The numeric ID of the location.</param>
        /// <returns>
        /// A new <see cref="LocationInfo"/> for the specified room.
        /// </returns>
        public LocationInfo Location(int id)
            => Locations.Single(x => x.Id == id);

        /// <summary>
        /// Returns extra information for the specified location.
        /// </summary>
        /// <param name="location">
        /// The location to get extra information for.
        /// </param>
        /// <returns>
        /// A new <see cref="LocationInfo"/> for the specified room.
        /// </returns>
        public LocationInfo Location(Location location)
            => Locations.Single(x => x.Id == location.Id);
    }
}
