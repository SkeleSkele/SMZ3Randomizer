﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using Randomizer.Shared;

using Xunit;

namespace Randomizer.SMZ3.Tests.LogicTests
{
    public class LocationLogicTests
    {
        public LocationLogicTests()
        {
            Config = new Config();
            World = new World(Config, "", 0, "");
        }

        protected Config Config { get; }

        protected World World { get; }

        [Fact]
        public void LocationWithoutLogicNeverHasMissingItems()
        {
            var emptyProgression = new Progression();
            var missingItems = Logic.GetMissingRequiredItems(World.HyruleCastle.LinksUncle, emptyProgression);
            missingItems.Should().BeEmpty();
        }

        [Fact]
        public void LocationWithSatisfiedLogicHasNoMissingItems()
        {
            var progression = new Progression(new[] { new Item(ItemType.Boots) });
            var missingItems = Logic.GetMissingRequiredItems(World.LightWorldSouth.Library, progression);
            missingItems.Should().BeEmpty();
        }

        [Fact]
        public void LocationWithSimpleLogicOnlyHasOneSetOfItems()
        {
            var emptyProgression = new Progression();
            var missingItems = Logic.GetMissingRequiredItems(World.LightWorldSouth.Library, emptyProgression);
            missingItems.Should().HaveCount(1);
        }

        [Fact]
        public void LocationWithSimpleLogicReturnsSingleMissingItem()
        {
            var emptyProgression = new Progression();
            var missingItems = Logic.GetMissingRequiredItems(World.LightWorldSouth.Library, emptyProgression);
            missingItems.Should().ContainEquivalentOf(new[] { ItemType.Boots });
        }

        [Fact]
        public void LocationWithTwoMissingItemsReturnsTwoMissingItems()
        {
            var emptyProgression = new Progression(Item.CreateKeycards(null));
            var missingItems = Logic.GetMissingRequiredItems(World.GreenBrinstar.PowerBomb, emptyProgression);
            missingItems.Should().ContainEquivalentOf(new[] { ItemType.Morph, ItemType.PowerBomb });
        }

        [Fact]
        public void LocationWithMultipleOptionsReturnsAllOptions()
        {
            var emptyProgression = new Progression(Item.CreateKeycards(null));
            var missingItems = Logic.GetMissingRequiredItems(World.BlueBrinstar.Ceiling, emptyProgression);
            missingItems.Should().ContainEquivalentOf(new[] { ItemType.SpaceJump })
                .And.ContainEquivalentOf(new[] { ItemType.HiJump })
                .And.ContainEquivalentOf(new[] { ItemType.SpeedBooster })
                .And.ContainEquivalentOf(new[] { ItemType.Ice });
        }

        [Fact]
        public void LocationWithThreeMissingItemsReturnsThreeMissingItems()
        {
            var emptyProgression = new Progression(Item.CreateKeycards(null));
            var missingItems = Logic.GetMissingRequiredItems(World.CentralCrateria.BombTorizo, emptyProgression);
            missingItems.Should().ContainEquivalentOf(new[] { ItemType.Morph, ItemType.Super, ItemType.PowerBomb });
        }
    }
}
