//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Gaia srl">
//     Copyright (c) Gaia srl. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Gaia.Network.Core;

namespace Bmw.DataServices.Core.Configuration
{
	public static class ConfigurationService
	{
		public static ConfigurationInfo Configuration { get; set; }

		/// <summary>
		/// Loads application configuration
		/// </summary>
		/// <returns>Configuration info or null in case of error</returns>
		public async static Task<ConfigurationInfo> Load(string uri)
		{
			try
			{
				HttpLoader loader = new HttpLoader(null, null);
				string configUri = string.Format("{0}?id={1}", uri, DateTime.Now.Ticks);
				string json = await loader.GetAsync(configUri);
				Configuration = string.IsNullOrEmpty(json) ? null : ConfigurationInfo.FromJson(json);
				return Configuration;
			}
			catch
			{
				Configuration = null;
				return null;
			}
		}
	}
}
