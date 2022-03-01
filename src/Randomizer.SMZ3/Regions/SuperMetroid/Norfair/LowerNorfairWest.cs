﻿using System.Collections.Generic;
using Randomizer.Shared;
using static Randomizer.SMZ3.SMLogic;

namespace Randomizer.SMZ3.Regions.SuperMetroid.Norfair
{
    public class LowerNorfairWest : SMRegion
    {
        public LowerNorfairWest(World world, Config config) : base(world, config)
        {
            BeforeGoldTorizo = new(this, 70, 0x8F8E6E, LocationType.Visible,
                name: "Missile (Gold Torizo)",
                alsoKnownAs: "Gold Torizo - Drop down",
                vanillaItem: ItemType.Missile,
                access: Logic switch
                {
                    Normal => items => World.AdvancedLogic.CanUsePowerBombs(items) && items.SpaceJump && items.Super,
                    _ => items => World.AdvancedLogic.CanUsePowerBombs(items) && items.SpaceJump && items.Varia && (
                        items.HiJump || items.Gravity ||
                        (World.AdvancedLogic.CanAccessNorfairLowerPortal(items) && (World.AdvancedLogic.CanFly(items) || World.AdvancedLogic.CanSpringBallJump(items) || items.SpeedBooster) && items.Super))
                });
            GoldTorizoCeiling = new(this, 71, 0x8F8E74, LocationType.Hidden,
                name: "Super Missile (Gold Torizo)",
                alsoKnownAs: "Golden Torizo - Ceiling",
                vanillaItem: ItemType.Super,
                access: Logic switch
                {
                    Normal => items => World.AdvancedLogic.CanDestroyBombWalls(items) && (items.Super || items.Charge) &&
                        (World.AdvancedLogic.CanAccessNorfairLowerPortal(items) || (items.SpaceJump && World.AdvancedLogic.CanUsePowerBombs(items))),
                    _ => items => World.AdvancedLogic.CanDestroyBombWalls(items) && items.Varia && (items.Super || items.Charge)
                });
            ScrewAttackRoom = new(this, 79, 0x8F9110, LocationType.Chozo,
                name: "Screw Attack",
                access: Logic switch
                {
                    Normal => items => World.AdvancedLogic.CanDestroyBombWalls(items) && (items.SpaceJump && World.AdvancedLogic.CanUsePowerBombs(items) || World.AdvancedLogic.CanAccessNorfairLowerPortal(items)),
                    _ => items => World.AdvancedLogic.CanDestroyBombWalls(items) && (items.Varia || World.AdvancedLogic.CanAccessNorfairLowerPortal(items))
                });
            MickeyMouseClubhouse = new(this, 73, 0x8F8F30, LocationType.Visible,
                name: "Missile (Mickey Mouse room)",
                alsoKnownAs: "Mickey Mouse Clubhouse",
                vanillaItem: ItemType.Missile,
                access: Logic switch
                {
                    Normal => items => World.AdvancedLogic.CanFly(items) && items.Morph && items.Super &&
                        /*Exit to Upper Norfair*/
                        (((items.CardLowerNorfairL1 || items.Gravity /*Vanilla or Reverse Lava Dive*/) && items.CardNorfairL2) /*Bubble Mountain*/ ||
                        (items.Gravity && items.Wave /* Volcano Room and Blue Gate */ && (items.Grapple || items.SpaceJump)) /*Spikey Acid Snakes and Croc Escape*/ ||
                        /*Exit via GT fight and Portal*/
                        (World.AdvancedLogic.CanUsePowerBombs(items) && items.SpaceJump && (items.Super || items.Charge))),
                    _ => items =>
                         items.Morph && items.Varia && items.Super && (((World.AdvancedLogic.CanFly(items) || (World.AdvancedLogic.CanSpringBallJump(items) && World.AdvancedLogic.CanPassBombPassages(items)) ||
                                         (((items.CardNorfairL2 && World.AdvancedLogic.CanUsePowerBombs(items) && (items.HiJump || items.Gravity)) || items.SpeedBooster)
                                           && ((items.HiJump && World.AdvancedLogic.CanUsePowerBombs(items)) || (items.Charge && items.Ice)))) &&
                         /*Exit to Upper Norfair*/
                         (items.CardNorfairL2 || items.SpeedBooster || World.AdvancedLogic.CanFly(items) || items.Grapple || (items.HiJump &&
                        (World.AdvancedLogic.CanSpringBallJump(items) || items.Ice)))) ||
                         /*Return to Portal*/
                         World.AdvancedLogic.CanUsePowerBombs(items))
                });
        }

        public override string Name => "Lower Norfair, West";

        public override string Area => "Lower Norfair";

        public Location BeforeGoldTorizo { get; }

        public Location GoldTorizoCeiling { get; }

        public Location ScrewAttackRoom { get; }

        public Location MickeyMouseClubhouse { get; }

        // Todo: account for Croc Speedway once Norfair Upper East also do so, otherwise it would be inconsistent to do so here
        public override bool CanEnter(Progression items)
        {
            return Logic switch
            {
                Normal =>
                    items.Varia && (
                        World.UpperNorfairEast.CanEnter(items) && World.AdvancedLogic.CanUsePowerBombs(items) && items.SpaceJump && items.Gravity && (
                            /* Trivial case, Bubble Mountain access */
                            items.CardNorfairL2 ||
                            /* Frog Speedway -> UN Farming Room gate */
                            items.SpeedBooster && items.Wave
                        ) ||
                        World.AdvancedLogic.CanAccessNorfairLowerPortal(items) && World.AdvancedLogic.CanDestroyBombWalls(items)
                    ),
                _ =>
                    World.UpperNorfairEast.CanEnter(items) && World.AdvancedLogic.CanUsePowerBombs(items) && items.Varia && (items.HiJump || items.Gravity) && (
                        /* Trivial case, Bubble Mountain access */
                        items.CardNorfairL2 ||
                        /* Frog Speedway -> UN Farming Room gate */
                        items.SpeedBooster && (items.Missile || items.Super || items.Wave) /* Blue Gate */
                    ) ||
                    World.AdvancedLogic.CanAccessNorfairLowerPortal(items) && World.AdvancedLogic.CanDestroyBombWalls(items)
            };
        }

    }

}
