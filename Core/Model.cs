using System;
using sc.contracts;

namespace Core
{
	public class Model : IModel
	{
		public void Calculate(string text, CalculationModes mode)
		{
			if (On_result != null)
				On_result(99);
		}

		public event Action<int> On_result;
	}
}
