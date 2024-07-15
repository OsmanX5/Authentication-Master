using UnityEditor;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
namespace AutanticationMaster.Core
{
	[CustomEditor(typeof(UnityAuthanticationCore))]
	internal class UnityAuthanticationCoreEditor : Editor
	{
		string AccessToken = "Not Set Yet";
		public override void OnInspectorGUI()
		{
			UnityAuthanticationCore unityAuthanticationCore = (UnityAuthanticationCore)target;
			base.OnInspectorGUI();
			GUILayout.Space(30);
			GUILayout.Label("#For Debug");
			if (EditorApplication.isPlaying)
			{
				if (GUILayout.Button("Initialize"))
				{
					unityAuthanticationCore.Initialize();
				}
				
				if (unityAuthanticationCore.IsInitialized)
				{
					AccessToken = AuthenticationService.Instance.AccessToken;
					EditorGUILayout.LabelField("IsInitialized", UnityServices.State.ToString());
					if (GUILayout.Button("Anonymous Sign in"))
					{
						unityAuthanticationCore.AnonymousSingIn();
					}
				}
				EditorGUILayout.LabelField("AccessToken", AccessToken);
			}
		}
	}
}
