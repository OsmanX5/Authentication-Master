using System;
using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
namespace AutanticationMaster.Core
{
	internal class UnityServicesInitlizer
	{
		public async Task Initialize(Action OnInitlized)
		{
			try
			{
				Debug.Log("Unity Services initialization started");
				if(UnityServices.State != ServicesInitializationState.Initialized)
				{
					await UnityServices.InitializeAsync();
				}
				Debug.Log("Unity Services initializated !");

				OnInitlized?.Invoke();
			}
			catch (ServicesInitializationException e)
			{
				Debug.LogError($"Unity Services initialization failed: {e.Message}");
			}
		}
	}
}
