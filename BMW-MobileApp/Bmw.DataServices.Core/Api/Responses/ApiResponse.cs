
namespace Bmw.DataServices.Core.Api.Responses
{
	public abstract class ApiResponse
	{
		/// <summary>
		/// Gets the response status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public ResponseStatus Status { get; internal set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>
		/// The error message.
		/// </value>
		public string ErrorMessage { get; internal set; }
	}
}
