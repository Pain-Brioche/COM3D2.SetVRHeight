using System;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace COM3D2.SetVRHeight.plugin
{
	[BepInPlugin("org.bepinex.plugins.SetVRHeight", "SetVRHeight", "1.0.0.0")]
	public class SetVRHeight : BaseUnityPlugin
	{
		private void Awake()
		{
			if (!GameMain.Instance.VRMode)
			{
				Logger.LogWarning("VR Mode Off: Shutting Set VR Height down.");
				Destroy(this);
				return;
			}

			VRHeight = base.Config.Bind<float>("Offsets", "VRHeight", 0.2f, "Global Vertical Offset");
			KaraokeVRHeight = base.Config.Bind<float>("Offsets", "KaraokeVRHeight", 0.1f, "Vertical Offset in Karaoke Mode");
		}

		private void OnLevelWasLoaded(int level)
		{
			if (level == 36)
            {
				yOffset = KaraokeVRHeight.Value;
			}
			else
            {
				yOffset = VRHeight.Value;
			}

			isDance = FindObjectOfType(typeof(DanceMain)) != null ? true : false;
		}


		void LateUpdate()
        {
			if (!isDance)
            {
				if (GameMain.Instance.MainCamera.IsFadeOut() && !hasFadeOut)
				{
					hasFadeOut = true;
					// Logger.LogInfo("hasFadeOut = true");
				}
				if (GameMain.Instance.MainCamera.IsFadeStateNon() && hasFadeOut)
				{
					updatedCameraPosition = GameMain.Instance.MainCamera.GetPos();
					Logger.LogInfo("Original Camera y offset: " + updatedCameraPosition.y.ToString());
					updatedCameraPosition.y += yOffset;				
					Logger.LogInfo("New Camera y offset: " + updatedCameraPosition.y.ToString());
					GameMain.Instance.MainCamera.SetRealHeadPos(updatedCameraPosition, false);
					hasFadeOut = false;
					// UpdateVRHeight();
				}
			}
		}

		private ConfigEntry<float> VRHeight;

		private ConfigEntry<float> KaraokeVRHeight;

		private Vector3 updatedCameraPosition;

		private float yOffset;

		private bool hasFadeOut = false;

		private bool isDance;

	}
}
