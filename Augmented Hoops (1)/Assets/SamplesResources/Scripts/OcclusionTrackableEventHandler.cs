/*===============================================================================
Copyright (c) 2017-2018 PTC Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/

using UnityEngine;

public class OcclusionTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PROTECTED_METHODS

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        // Hide the sides of the MultiTarget

        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();

        foreach (Renderer component in rendererComponents)
        {
            if (component.name.Contains("Box."))
            {
                component.enabled = false;
            }
        }
    }

    #endregion // PROTECTED_METHODS
}
