using System;
using MongoDB.Driver;


namespace QuizSite.Controllers
{
	public static class OidExtensions
	{
		public static string ToStringWithoutQuotesIn( this Oid oid )
		{
			return BitConverter.ToString( oid.ToByteArray() ).Replace( "-", "" ).ToLower();
		}
	}
}