namespace DotNetDev.Web.Extensions
{
	/// <summary>A simple set of string extensions for use with the IHttpModules used by the demo code</summary>
	public static class StringExtensions
	{
		/// <param name="text">By prefixing the parameter with 'this' and being a static method this becomes an 'extension method'.
		/// For all intents and purposes it then looks like an instance method on the 'this' parameter type.  In this case string.
		/// In reality at compile time it becomes a simple call to StringExtensions.ReplaceFirst(string,string,string).  'Syntactic Sugar'
		/// if you like.</param>
		public static string ReplaceFirst(this string text, string search, string replace)
		{
			int pos = text.IndexOf(search, System.StringComparison.InvariantCultureIgnoreCase);
			if (pos < 0)
				return text;

			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}
	}
}
