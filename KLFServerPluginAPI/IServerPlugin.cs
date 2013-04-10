using System;
using System.Collections.Generic;

namespace KLFServerPluginAPI
{
	/// <summary>
	/// The main interface all plugins should use
	/// </summary>
	public interface IServerPlugin
	{
		void OnEnable();
		void OnDisable();
		IServerAPI Server { get; }
		void Associate(IServerAPI Server);
	}
}