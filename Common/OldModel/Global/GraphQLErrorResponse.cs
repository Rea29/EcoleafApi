using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global
{
	public class GraphQLErrorResponse
	{
		public List<GraphQLError> errors { get; set; }
	}
}
