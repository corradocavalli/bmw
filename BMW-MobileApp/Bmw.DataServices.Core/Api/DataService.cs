using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bmw.DataServices.Core.Api.Responses;
using Bmw.DataServices.Core.Configuration;
using Gaia.Network.Core;

namespace Bmw.DataServices.Core.Api
{
	public class DataService
	{
		private readonly ConfigurationInfo configuration;

		public DataService(ConfigurationInfo configuration)
		{
			this.configuration = configuration;
		}

		/// <summary>
		/// Logins the specified user.
		/// </summary>
		/// <param name="username">The user name</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public async Task<LoginResponse> Login(string username, string password)
		{
			try
			{
				string url = this.GetTargetUri("/api/mobile/login");
				string json = await this.GetLoader().GetAsync(url);
				return null;
			}
			catch (Exception ex)
			{
				return new LoginResponse() { ErrorMessage = ex.Message, Status = ResponseStatus.Failed };
			}
		}

		/// <summary>
		/// Gets the target URI.
		/// </summary>
		/// <param name="path">The uri path.</param>
		/// <returns>Full api uri</returns>
		private string GetTargetUri(string path)
		{
			return string.Format("{0}{1}", this.configuration.Domain, path);
		}

		/// <summary>
		/// Gets a new instance of the http loader.
		/// </summary>
		/// <returns>HttpLoader instance</returns>
		private HttpLoader GetLoader()
		{
			return new HttpLoader(null, null) { Timeout = TimeSpan.FromSeconds(this.configuration.Timeout) };
		}

	}
}
