using System.Windows;
using Core;
using Ui;
using sc.contracts;

namespace UiStringCalculatorWithContract
{
	public partial class App : Application
	{
		public new void Run()
		{
			IUI vm = new ViewModel();
			IModel model = new Model();

			vm.On_calc_cmd += model.Calculate;
			model.On_result += vm.Show_result;

			View view = new View();
			view.DataContext = vm;

			base.Run(view);
		}
	}
}
