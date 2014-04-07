using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gaia.Network.Core.Network.Core;

namespace Gaia.Network.Core
{
	/// <summary>
	/// Handles Http interaction
	/// </summary>
	public class HttpLoader
	{
		private readonly string username;
		private readonly string password;

		private HttpClientHandler handler;

		private HttpClient postClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpLoader" /> class.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		public HttpLoader(string username, string password)
		{
			this.username = username;
			this.password = password;
			if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
			{
				this.handler = new HttpClientHandler { Credentials = new NetworkCredential(username, password) };
			}
			else
			{
				this.handler = new HttpClientHandler();
			}

			this.Timeout = TimeSpan.FromSeconds(10);
		}

		/// <summary>
		/// Gets or sets the request timeout.
		/// </summary>
		/// <value>
		/// The timeout.
		/// </value>
		public TimeSpan Timeout { get; set; }

		/// <summary>
		/// Begins a server session.
		/// </summary>
		public void BeginSession()
		{
			this.handler = new HttpClientHandler { Credentials = new NetworkCredential(this.username, this.password), CookieContainer = new CookieContainer() };
		}

		/// <summary>
		/// Ends the previously created session.
		/// </summary>
		public void EndSession()
		{
			this.handler = new HttpClientHandler { Credentials = new NetworkCredential(this.username, this.password) };
		}

		/// <summary>
		/// Gets the async.
		/// </summary>
		/// <param name="uri">The URI.</param>
		/// <returns>Downloaded data or null in case of error</returns>
		public async Task<string> GetAsync(string uri)
		{
			HttpClient httpClient = this.GetClient();

			var response = await httpClient.GetByteArrayAsync(uri);
			var responseString = Encoding.GetEncoding("iso-8859-1").GetString(response, 0, response.Length);
			return responseString;

		}

		/// <summary>
		/// Posts to uri asyncronously.
		/// </summary>
		/// <param name="uri">The uri to invoke</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>
		/// True when operation succeedes
		/// </returns>
		public async Task<PostOperationResult> PostAsync(string uri, IEnumerable<KeyValuePair<string, string>> parameters = null)
		{
			try
			{
				this.postClient = this.GetClient();
				HttpResponseMessage response = await this.postClient.PostAsync(uri, new FormUrlEncodedContent(parameters));
				if (response.IsSuccessStatusCode)
				{
					string responseContent = await response.Content.ReadAsStringAsync();
					return new PostOperationResult() { ResponseContent = responseContent, Success = true };
				}

				return new PostOperationResult();
			}
			catch (Exception ex)
			{
				return new PostOperationResult();
			}
			finally
			{
				this.postClient = null;
			}
		}

		/// <summary>
		/// Gets the bytes at specified uri
		/// </summary>
		/// <param name="uri">The URI.</param>
		/// <returns></returns>
		public async Task<byte[]> GetBytes(string uri)
		{
			HttpClient httpClient = this.GetClient();
			var response = await httpClient.GetByteArrayAsync(uri);
			return response;
		}

		/// <summary>
		/// Aborts this instance.
		/// </summary>
		public void AbortCurrentOperation()
		{
			if (this.postClient != null)
			{
				try
				{
					this.postClient.CancelPendingRequests();
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Gets Http client.
		/// </summary>
		/// <returns>A brand new http client instance</returns>
		private HttpClient GetClient()
		{
			return new HttpClient(this.handler) { Timeout = this.Timeout };
		}
	}
}
