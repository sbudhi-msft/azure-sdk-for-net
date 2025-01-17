﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// The subscription state. Possible values are Enabled, Warned, PastDue, Disabled, and Deleted.
    /// </summary>
    public enum SubscriptionState
    {
        /// <summary> Enabled. </summary>
        Enabled,
        /// <summary> Warned. </summary>
        Warned,
        /// <summary> PastDue. </summary>
        PastDue,
        /// <summary> Disabled. </summary>
        Disabled,
        /// <summary> Deleted. </summary>
        Deleted
    }
}
