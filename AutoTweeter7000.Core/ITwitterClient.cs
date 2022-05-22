// <copyright file="ITwitterClient.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace AutoTweeter7000
{
    public interface ITwitterClient
    {
        string ConsumerKey { get; }

        string ConsumerSecret { get; }

        bool Authenticated { get; }

        Uri AuthorizeUri { get; }

        Task<bool> Login(string oauthVerifier);
    }
}
