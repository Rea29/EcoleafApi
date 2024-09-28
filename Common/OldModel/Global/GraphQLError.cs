using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate;

namespace Common.Model.Global
{
	public class GraphQLError
	{
		public string message { get; set; }
		public ErrorExtensions extensions { get; set; }
	}
	public class ErrorExtensions
	{
		public string code { get; set; }
		public string fieldName { get; set; }
	}
}
