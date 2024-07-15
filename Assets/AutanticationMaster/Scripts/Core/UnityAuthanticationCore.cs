using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutanticationMaster.Core
{
	public class UnityAuthanticationCore : MonoBehaviour
	{
		[SerializeField] GameObject LoadingIcon;
		UnityAuthanticationEvents authanticationEvents;
		AnonymousSignIn anonymousSignIn;
		public bool IsInitialized { get; private set; } = false;
		private void Awake()
		{
			authanticationEvents =GetComponent<UnityAuthanticationEvents>();
			Initialize();
		}
		public void Initialize()
		{
			UnityServicesInitlizer unityServicesInitlizer = new UnityServicesInitlizer();
			unityServicesInitlizer.Initialize(OnUnityServicesInitlized);
		}
		void OnUnityServicesInitlized()
		{
			IsInitialized = true;
			authanticationEvents.SetupEvents();
		}
		public void AnonymousSingIn()
		{
			if(TryGetComponent<AnonymousSignIn>(out anonymousSignIn)){
				ShowLoadingIcon();
				anonymousSignIn.SignIn(OnSignedIn);
			}
		}

		private void OnSignedIn()
		{
			HideLoadingIcon();
		}

		void ShowLoadingIcon()
		{
			LoadingIcon.SetActive(true);
		}
		void HideLoadingIcon()
		{
			LoadingIcon.SetActive(false);
		}
	}
}