using System;
using UnityEngine;
using Unity.Services.Authentication;
using System.Threading.Tasks;

namespace AutanticationMaster.Core
{
	internal class AnonymousSignIn : MonoBehaviour
	{
		public async void  SignIn(Action OnSignIn =null)
		{
			try
			{
				Debug.Log("Anonymous Sign In started");
				await AuthenticationService.Instance.SignInAnonymouslyAsync();
				Debug.Log("Anonymous Sign In success !");
				if(OnSignIn!=null)
				OnSignIn?.Invoke();
			}
			catch (Exception e)
			{
				Debug.LogError($"Anonymous Sign In failed: {e.Message}");
			}
		}
	}
}
