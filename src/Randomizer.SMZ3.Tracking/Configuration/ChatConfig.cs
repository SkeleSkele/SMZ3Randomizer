﻿using System;
using System.Collections.Generic;

namespace Randomizer.SMZ3.Tracking.Configuration
{
    /// <summary>
    /// Provides the phrases for chat integration.
    /// </summary>
    public class ChatConfig
    {
        /// <summary>
        /// Gets a collection of greetings that tracker recognizes and responds
        /// to.
        /// </summary>
        public IReadOnlyCollection<string> RecognizedGreetings { get; init; }
            = new List<string>();

        /// <summary>
        /// Gets the phrases to respond with when connected to chat.
        /// </summary>
        public SchrodingersString WhenConnected { get; init; }
            = new("Hello chat.");

        /// <summary>
        /// Gets the phrases to respond with when disconnected to chat.
        /// </summary>
        public SchrodingersString WhenDisconnected { get; init; }
            = new("Error with Twitch chat connection. Please save and restart tracker.");

        /// <summary>
        /// Gets the phrases to respond with when disconnected to chat.
        /// </summary>
        public SchrodingersString NoConnection { get; init; }
            = new("I'm not currently connected to Twitch chat.");

        /// <summary>
        /// Gets the phrases to respond with when greeted by someone in chat.
        /// </summary>
        /// <remarks>
        /// <c>{0}</c> is a placeholder for the display name of the person in
        /// chat to respond to.
        /// </remarks>
        public SchrodingersString GreetingResponses { get; init; }
            = new("Hey {0}");

        /// <summary>
        /// Gets the phrases to respond with when greeting someone for the
        /// second time in chat.
        /// </summary>
        /// <remarks>
        /// <c>{0}</c> is a placeholder for the display name of the person in
        /// chat to respond to.
        /// </remarks>
        public SchrodingersString? GreetedTwice { get; init; }

        /// <summary>
        /// Gets the phrases to respond with when greeted by the broadcaster.
        /// </summary>
        /// <remarks>
        /// <c>{0}</c> is a placeholder for the display name of the person in
        /// chat to respond to.
        /// </remarks>
        public SchrodingersString? GreetedChannel { get; init; }

        /// <summary>
        /// Gets the phrases to respond with when starting the GT big key
        /// guessing game.
        /// </summary>
        public SchrodingersString StartedGuessingGame { get; init; }
            = new("The floor is now open for guesses.");

        /// <summary>
        /// Gets the phrases to respond with when closing guesses for the GT big
        /// key guessing game.
        /// </summary>
        public SchrodingersString ClosedGuessingGame { get; init; }
            = new("The floor is now closed for guesses.");

        /// <summary>
        /// Gets the phrases to respond with when a moderator closed guesses for
        /// the GT big key guessing game.
        /// </summary>
        /// <remarks>
        /// <c>{0}</c> is a placeholder for the name of the moderator that
        /// triggered the close.
        /// </remarks>
        public SchrodingersString ModeratorClosedGuessingGame { get; init; }
            = new("{0} closed the floor for guesses.");

        /// <summary>
        /// Gets the phrases to respond with when the guessing game has
        /// concluded.
        /// </summary>
        /// <remarks>
        /// <c>{0}</c> is a placeholder for the correct number.
        /// <c>{1}</c> is a placeholder for the names of the winners.
        /// </remarks>
        public SchrodingersString DeclareGuessingGameWinners { get; init; }
            = new("The winners who guessed number {0} are {1}.");

        /// <summary>
        /// Gets the phrases to respond with when the guessing game has
        /// concluded and nobody won.
        /// </summary>
        /// <remarks>
        /// <c>{0}</c> is a placeholder for the correct number.
        /// </remarks>
        public SchrodingersString NobodyWonGuessingGame { get; init; }
            = new("Nobody guessed {0}.");

        /// <summary>
        /// Gets a dictionary that contains usernames and their replacement for
        /// text-to-speech pronunciation purposes.
        /// </summary>
        public IReadOnlyDictionary<string, string> UserNamePronunciation { get; init; }
            = new Dictionary<string, string>();

        /// <summary>
        /// Gets the phrases for when asking the chat if content should be
        /// increased or not
        /// </summary>
        public SchrodingersString AskChatAboutContent { get; init; }
            = new("Hmm. I'm not so sure about that. Let's ask the professionals in chat if that was some hashtag content.");

        /// <summary>
        /// Gets the phrases for when chat decided to increase content
        /// </summary>
        public SchrodingersString AskChatAboutContentYes { get; init; }
            = new("It's your lucky day. Chat has confirmed that was some hashtag content.");

        /// <summary>
        /// Gets the phrases for when chat decided not to increase content
        /// </summary>
        public SchrodingersString AskChatAboutContentNo { get; init; }
            = new("I'm glad I asked. The chat has denied your request to increase your content levels.");

        /// <summary>
        /// Gets the phrases for when the poll is complete
        /// </summary>
        public SchrodingersString PollComplete { get; init; }
            = new("And the results are now in.");

        /// <summary>
        /// Gets the phrases for when the poll is opened
        /// </summary>
        public SchrodingersString PollOpened { get; init; }
            = new("I have opened a poll for {0} seconds.");

        /// <summary>
        /// Gets the phrases for when the poll outcome could not be determined
        /// </summary>
        public SchrodingersString PollError { get; init; }
            = new("Sorry, I was unable to get the poll results.");
    }
}
