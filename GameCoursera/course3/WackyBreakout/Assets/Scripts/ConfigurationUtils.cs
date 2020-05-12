using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    static ConfigurationData conData;

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return conData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return conData.BallImpulseForce; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        conData = new ConfigurationData();
    }
}
