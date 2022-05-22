// <copyright file="IErrorHandlerService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace AutoTweeter7000
{
    /// <summary>
    /// Error Handler Service.
    /// </summary>
    public interface IErrorHandlerService
    {
        /// <summary>
        /// Called when an error is hit through the service.
        /// </summary>
        event EventHandler<ErrorHandlerEventArgs> OnError;

        /// <summary>
        /// Handle error in UI.
        /// </summary>
        /// <param name="ex">Exception being thrown.</param>
        void HandleError(Exception ex);
    }
}
