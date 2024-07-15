using UnityEngine;


using Unity.Services.Authentication;
using System;
using Unity.Services.Core;
using UnityEngine.Events;

namespace AutanticationMaster.Core
{
	internal class UnityAuthanticationEvents : MonoBehaviour
	{
		public UnityEvent OnSignIn;
		public UnityEvent OnSignOut;
		public UnityEvent OnSignInFailed;
		public void SetupEvents()
		{
			if (AuthenticationService.Instance == null)
			{
				Debug.LogError("AuthenticationService is not initialized");
				return;
			}
			AuthenticationService.Instance.SignedIn += AuthenticationService_OnSignIn;
			AuthenticationService.Instance.SignedOut += AuthenticationService_OnSignOut;
			AuthenticationService.Instance.SignInFailed += AuthenticationService_OnSignInFailed;

		}
		private void AuthenticationService_OnSignIn()
		{
			Debug.Log("Signed In");
			OnSignIn?.Invoke();
		}
		private void AuthenticationService_OnSignInFailed(RequestFailedException exception)
		{
			Debug.LogError("Sign In Failed: " + exception.Message);
			OnSignInFailed?.Invoke();
		}

		private void AuthenticationService_OnSignOut()
		{
			Debug.Log("Signed Out");
			OnSignOut?.Invoke();
		}


	}
}
