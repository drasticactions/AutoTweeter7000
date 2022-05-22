// <copyright file="CoreTweetClient.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using CoreTweet;
using Microsoft.Extensions.Logging;

namespace AutoTweeter7000
{
    /// <summary>
    /// Core Tweet Client.
    /// </summary>
    public class CoreTweetClient : ITwitterClient
    {
        private ILogger? logger;
        private bool authenticated;
        private ConnectionOptions? connectionOptions;

        private OAuth.OAuthSession session;
        private Tokens? tokens;

        public CoreTweetClient(string consumerKey, string consumerSecret, string oauthCallback = "autotweeter://", ConnectionOptions? options = default, ILogger? logger = default)
        {
            ArgumentNullException.ThrowIfNull(consumerKey);
            ArgumentNullException.ThrowIfNull(consumerSecret);

            this.logger = logger;
            this.connectionOptions = options;
            this.session = OAuth.Authorize(consumerKey, consumerSecret, oauthCallback, this.connectionOptions);
        }

        public CoreTweetClient(OAuth.OAuthSession session, ILogger? logger = default)
        {
            ArgumentNullException.ThrowIfNull(session);
            this.session = session;
            this.logger = logger;
        }

        public CoreTweetClient(OAuth.OAuthSession session, Tokens tokens, ILogger? logger = default)
        {
            ArgumentNullException.ThrowIfNull(session);
            ArgumentNullException.ThrowIfNull(tokens);

            this.session = session;
            this.tokens = tokens;
            this.logger = logger;
            this.authenticated = true;
        }

        /// <inheritdoc/>
        public string ConsumerKey => this.session.ConsumerKey;

        /// <inheritdoc/>
        public string ConsumerSecret => this.session.ConsumerSecret;

        /// <inheritdoc/>
        public bool Authenticated => this.authenticated;

        /// <inheritdoc/>
        public Uri AuthorizeUri => this.session.AuthorizeUri;

        /// <inheritdoc/>
        public async Task<bool> Login(string oauthVerifier)
        {
            try
            {
                this.tokens = await this.session.GetTokensAsync(oauthVerifier);
                return this.authenticated = true;
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, "Failed to Authenticate");
                return false;
            }
        }
    }
}
