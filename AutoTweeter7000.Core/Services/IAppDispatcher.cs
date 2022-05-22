// <copyright file="IAppDispatcher.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace AutoTweeter7000
{
    public interface IAppDispatcher
    {
        bool Dispatch(Action action);
    }
}
