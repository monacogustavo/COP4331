/*==============================================================================
Copyright (c) 2016-2018 PTC Inc. All Rights Reserved.

Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
/// This script sets up shader variables for the occlusion shaders.
/// Different parameters are used for each device orientation.
/// </summary>
public class BoxSetUpShader : MonoBehaviour, IVideoBackgroundEventHandler
{
    #region PRIVATE_MEMBERS
    VuforiaRenderer.VideoBGCfgData m_VideoBGCfgData;
    VuforiaRenderer.VideoTextureInfo m_VideoTextureInfo;
    bool m_VideoBackgroundReady;
    bool m_ShaderHasBeenSetup;
    bool m_EnableLogging = false;
    Vector2 m_TexureRatio;
    Vector2 m_ViewportSize;
    Vector2 m_ViewportOrig;
    Vector2 m_Prefix;
    Vector2 m_InversionMultiplier;
    Material m_OcclusionMaterial;
    #endregion //PRIVATE_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        m_OcclusionMaterial = GetComponent<Renderer>().material;

        VuforiaARController.Instance.RegisterVideoBgEventHandler(this);
        VuforiaARController.Instance.RegisterBackgroundTextureChangedCallback(OnBackgroundTextureChanged);
    }

    void Update()
    {
        if (!m_VideoBackgroundReady)
        {
            m_VideoBGCfgData = VuforiaRenderer.Instance.GetVideoBackgroundConfig();
            m_VideoTextureInfo = VuforiaRenderer.Instance.GetVideoTextureInfo();

            if (m_EnableLogging)
            {
                Debug.Log(
                    "\nBkgdInfoAvail: " + VuforiaRenderer.Instance.IsVideoBackgroundInfoAvailable() +
                    "\nBkgdInfoSize: " + m_VideoBGCfgData.size.x + "x" + m_VideoBGCfgData.size.y +
                    "\nImageSize: " + m_VideoTextureInfo.imageSize.x + "x" + m_VideoTextureInfo.imageSize.y +
                    "\nTextureSize: " + m_VideoTextureInfo.textureSize.x + "x" + m_VideoTextureInfo.textureSize.y);
            }
        }

        if (!m_ShaderHasBeenSetup)
        {
            // Before setting up the shader, code will verify that background info is available
            // and that sizes in VideoBGCfgData and VideoTextureInfo are not zero.
            // The asynchonous init order may differ between PlayMode and Device.
            if (VuforiaRenderer.Instance.IsVideoBackgroundInfoAvailable() &&
                m_VideoBGCfgData.size.x > 0 &&
                m_VideoTextureInfo.imageSize.x > 0 &&
                m_VideoTextureInfo.textureSize.x > 0)
            {
                m_VideoBackgroundReady = true;

                m_OcclusionMaterial.mainTexture = VuforiaRenderer.Instance.VideoBackgroundTexture;

                SetViewportParameters();

                m_ShaderHasBeenSetup = true;
            }
        }
    }

    void OnDestroy()
    {
        VuforiaARController.Instance.UnregisterVideoBgEventHandler(this);
        VuforiaARController.Instance.UnregisterBackgroundTextureChangedCallback(OnBackgroundTextureChanged);
    }

    #endregion //MONOBEHAVIOUR_METHODS

    #region VUFORIA_CALLBACK_METHODS

    public void OnVideoBackgroundConfigChanged()
    {
        VuforiaRenderer.VideoBGCfgData videoBGCfgData = VuforiaRenderer.Instance.GetVideoBackgroundConfig();

        Debug.Log("OnVideoBackgroundConfigChanged() called with:" +
                  "\nBackground Size: " + videoBGCfgData.size.x + "x" + videoBGCfgData.size.y);

        // If the video background config is changed, recalculate and pass new values to shader
        SetViewportParameters();
    }

    void OnBackgroundTextureChanged()
    {
        VuforiaRenderer.VideoTextureInfo videoTextureInfo = VuforiaRenderer.Instance.GetVideoTextureInfo();

        Debug.Log("OnBackgroundTextureChanged() called with:" +
                  "\nImage Size: " + videoTextureInfo.imageSize.x + "x" + videoTextureInfo.imageSize.y +
                  "\nTexture Size: " + videoTextureInfo.textureSize.x + "x" + videoTextureInfo.textureSize.y);

        // If the video background texture is changed, reassign to the occlusion material texture
        m_OcclusionMaterial.mainTexture = VuforiaRenderer.Instance.VideoBackgroundTexture;
    }

    #endregion // VUFORIA_CALLBACK_METHODS


    #region PRIVATE_METHODS

    void SetViewportParameters()
    {
        VuforiaRenderer.VideoTextureInfo textureInfo = VuforiaRenderer.Instance.GetVideoTextureInfo();
        m_TexureRatio.x = (float)textureInfo.imageSize.x / (float)textureInfo.textureSize.x;
        m_TexureRatio.y = (float)textureInfo.imageSize.y / (float)textureInfo.textureSize.y;

        // update viewport size
        Rect viewport = VuforiaARController.Instance.GetVideoBackgroundRectInViewPort();

        m_ViewportOrig.x = viewport.xMin;
        m_ViewportOrig.y = viewport.yMin;
        m_ViewportSize.x = viewport.xMax - viewport.xMin;
        m_ViewportSize.y = viewport.yMax - viewport.yMin;

        bool isMirrored = VuforiaARController.Instance.VideoBackGroundMirrored == VuforiaRenderer.VideoBackgroundReflection.ON;

        bool isPortrait = (VuforiaRuntimeUtilities.ScreenOrientation == ScreenOrientation.Portrait ||
                         VuforiaRuntimeUtilities.ScreenOrientation == ScreenOrientation.PortraitUpsideDown);

        Shader.DisableKeyword(isPortrait ? "PORTRAIT_OFF" : "PORTRAIT_ON");
        Shader.EnableKeyword(isPortrait ? "PORTRAIT_ON" : "PORTRAIT_OFF");

        // determine for which orientation the shaders should be set up:
        switch (VuforiaRuntimeUtilities.ScreenOrientation)
        {
            case ScreenOrientation.Portrait:
                m_Prefix.x = isMirrored ? 0.0f : 1.0f;
                m_Prefix.y = 1.0f;
                m_InversionMultiplier.x = isMirrored ? 1.0f : -1.0f;
                m_InversionMultiplier.y = -1.0f;
                break;
            case ScreenOrientation.PortraitUpsideDown:
                m_Prefix.x = isMirrored ? 1.0f : 0.0f;
                m_Prefix.y = 0.0f;
                m_InversionMultiplier.x = isMirrored ? -1.0f : 1.0f;
                m_InversionMultiplier.y = 1.0f;
                break;
            case ScreenOrientation.LandscapeLeft:
                m_Prefix.x = isMirrored ? 1.0f : 0.0f;
                m_Prefix.y = 1.0f;
                m_InversionMultiplier.x = isMirrored ? -1.0f : 1.0f;
                m_InversionMultiplier.y = -1.0f;
                break;
            case ScreenOrientation.LandscapeRight:
                m_Prefix.x = isMirrored ? 0.0f : 1.0f;
                m_Prefix.y = 0.0f;
                m_InversionMultiplier.x = isMirrored ? 1.0f : -1.0f;
                m_InversionMultiplier.y = 1.0f;
                break;
        }

        // Pass the updated values to the shader
        m_OcclusionMaterial.SetFloat("_TextureRatioX", m_TexureRatio.x);
        m_OcclusionMaterial.SetFloat("_TextureRatioY", m_TexureRatio.y);
        m_OcclusionMaterial.SetFloat("_ViewportSizeX", m_ViewportSize.x);
        m_OcclusionMaterial.SetFloat("_ViewportSizeY", m_ViewportSize.y);
        m_OcclusionMaterial.SetFloat("_ViewportOrigX", m_ViewportOrig.x);
        m_OcclusionMaterial.SetFloat("_ViewportOrigY", m_ViewportOrig.y);
        m_OcclusionMaterial.SetFloat("_ScreenWidth", Screen.width);
        m_OcclusionMaterial.SetFloat("_ScreenHeight", Screen.height);
        m_OcclusionMaterial.SetFloat("_PrefixX", m_Prefix.x);
        m_OcclusionMaterial.SetFloat("_PrefixY", m_Prefix.y);
        m_OcclusionMaterial.SetFloat("_InversionMultiplierX", m_InversionMultiplier.x);
        m_OcclusionMaterial.SetFloat("_InversionMultiplierY", m_InversionMultiplier.y);
    }

    #endregion //PRIVATE_METHODS

}
