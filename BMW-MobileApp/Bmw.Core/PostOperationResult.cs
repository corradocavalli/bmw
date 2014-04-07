//-----------------------------------------------------------------------
// <copyright file="PostOperationResult.cs" company="Gaia srl">
//     Copyright (c) Gaia srl. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gaia.Network.Core.Network.Core
{
	/// <summary>
	/// Response to a post operation
	/// </summary>
	public class PostOperationResult
	{
		/// <summary>
		/// Gets or sets a value indication whether operation is successful.
		/// </summary>
		/// <value>
		/// <c>true</c> if success; otherwise, <c>false</c>.
		/// </value>
		public bool Success { get; set; }

		/// <summary>
		/// Gets or sets the content of the response.
		/// </summary>
		/// <value>
		/// The content of the response.
		/// </value>
		public string ResponseContent { get; set; }
	}
}
