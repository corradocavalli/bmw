//-----------------------------------------------------------------------
// <copyright file="ConfigurationInfo.cs" company="Gaia srl">
//     Copyright (c) Gaia srl. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bmw.DataServices.Core.Configuration
{
	public class ConfigurationInfo
	{
		/// <summary>
		/// Gets or sets the API domain sources.
		/// </summary>
		/// <value>
		/// The data sources.
		/// </value>
		public string Domain { get; set; }

		/// <summary>
		/// Gets or sets the channel timeout.
		/// </summary>
		/// <value>
		/// The timeout.
		/// </value>
		public int Timeout { get; set; }

		/// <summary>
		/// Gets configuration from provided json text
		/// </summary>
		/// <param name="json">The json.</param>
		/// <returns>Configuration info</returns>
		internal static ConfigurationInfo FromJson(string json)
		{
			ConfigurationInfo configurationInfo = JsonConvert.DeserializeObject<ConfigurationInfo>(json);
			return configurationInfo;
		}
	}
}

