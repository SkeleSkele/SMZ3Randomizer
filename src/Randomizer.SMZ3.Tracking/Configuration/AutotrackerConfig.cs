﻿using System;
using System.Collections.Generic;

namespace Randomizer.SMZ3.Tracking.Configuration
{
    /// <summary>
    /// Provides the phrases for chat integration.
    /// </summary>
    public class AutoTrackerConfig
    {
        /// <summary>
        /// Gets the phrases to respond with when connected to to emulator.
        /// </summary>
        public SchrodingersString WhenConnected { get; init; }
            = new("Auto tracker connected");

        /// <summary>
        /// Gets the phrases to respond with when the game is started.
        /// </summary>
        public SchrodingersString GameStarted { get; init; }
            = new("Incoming PB for seed {0}");

        /// <summary>
        /// Gets the phrases to respond with when nearing KAD
        /// </summary>
        public SchrodingersString NearKraidsAwfulSon { get; init; }
            = new("Oh no. Disaster imminent.");

        /// <summary>
        /// Gets the phrases to respond with when nearing shaktool
        /// </summary>
        public SchrodingersString NearShaktool { get; init; }
            = new("Finally, the moment we've all been waiting for since the start of this run. We get to see Shaktool.");

        /// <summary>
        /// Gets the phrases to respond with when nearing crocomire
        /// </summary>
        public SchrodingersString NearCrocomire { get; init; }
            = new("You currently have {0} out of {1} super missiles. Do you think you have enough?");

        /// <summary>
        /// Gets the phrases to respond with when falling down the pit from moldorm
        /// </summary>
        public SchrodingersString FallFromMoldorm { get; init; }
            = new("Ha ha. Moldorm strikes again. Content increased by one step.");

        /// <summary>
        /// Gets the phrases to respond with when falling down the pit from moldorm in GT
        /// </summary>
        public SchrodingersString FallFromGTMoldorm { get; init; }
            = new("Ha ha. Moldorm strikes again. Content increased by one step.");

        /// <summary>
        /// Gets the phrases to respond with when falling down the pit from moldorm
        /// </summary>
        public SchrodingersString FallFromGanon { get; init; }
            = new("Oops. Don't worry, I'm sure no one saw that.");

        /// <summary>
        /// Gets the phrases to respond with when performing Hera Pot tech
        /// </summary>
        public SchrodingersString HeraPot { get; init; }
            = new("Good job on the tech. Was it a first try?");

        /// <summary>
        /// Gets the phrases to respond with when performing Ice Breaker tech
        /// </summary>
        public SchrodingersString IceBreaker { get; init; }
            = new("Good job on the tech. Was it a first try?");

        /// <summary>
        /// Gets the phrases to respond with when performing Diver Down tech
        /// </summary>
        public SchrodingersString DiverDown { get; init; }
            = new("Good job on the tech. Was it a first try?");

        /// <summary>
        /// Gets the phrases to respond with when entering Hyrule Castle tower
        /// </summary>
        public SchrodingersString EnterHyruleCastleTower { get; init; }
            = new("Ouch. So it's come to this, then?");

        /// <summary>
        /// Gets the phrases to respond with when entering a pendant dungeon
        /// </summary>
        public SchrodingersString EnterPendantDungeon { get; init; }
            = new("Ouch. So it's come to this, then?");

        /// <summary>
        /// Entered GT without all crystals
        /// </summary>
        public SchrodingersString EnteredGTEarly { get; init; }
            = new("How did you get here without all seven crystals?");

        /// <summary>
        /// Gets the phrases to respond with when swimming without flippers
        /// </summary>
        public SchrodingersString FakeFlippers { get; init; }
            = new("How can you swim without the flippers?");

        /// <summary>
        /// Gets the phrases to respond with when performing mockball
        /// </summary>
        public SchrodingersString MockBall { get; init; }
            = new("You just had to get these items early?");

        /// <summary>
        /// Skipping spore spawn
        /// </summary>
        public SchrodingersString SkipSporeSpawn { get; init; }
            = new("Skipping spore spawn again?");

        /// <summary>
        /// Seeing Ridley's face entrance
        /// </summary>
        public SchrodingersString RidleyFace { get; init; }
            = new("Oh hi there");

        /// <summary>
        /// Player asked auto tracker to look at something, but there was nothing
        /// </summary>
        public SchrodingersString LookedAtNothing { get; init; }
            = new("What am I supposed to be looking at?");

        /// <summary>
        /// Light world only has pendants
        /// </summary>
        public SchrodingersString LightWorldAllCrystals { get; init; }
            = new("That's a relief, I'm sure.");

        /// <summary>
        /// Misery Mire and Turtle Rock have pendants
        /// </summary>
        public SchrodingersString DarkWorldNoMedallions { get; init; }
            = new("I hope you don't find any medallions soon.");

    }
}
