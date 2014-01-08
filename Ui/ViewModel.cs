using System;
using System.ComponentModel;
using System.Windows.Input;
using sc.contracts;
	//using UiStringCalculatorWithContract.Annotations;

namespace Ui
{
	public class ViewModel : IUI, INotifyPropertyChanged
	{
		private int _result;
		private ICommand _calcCommand;

		public event Action<string, CalculationModes> On_calc_cmd;

		public ViewModel()
		{
			CalcCommand = new RelayCommand(param => RaiseOnCalcEvent());
		}

		public void Show_result(int value)
		{
			Result = value;
		}

		public int Result
		{
			get { return _result; }
			set
			{
				if (value == _result)
					return;
				_result = value;
				OnPropertyChanged("Result");
			}
		}

		public ICommand CalcCommand
		{
			get { return _calcCommand; }
			set
			{
				if (Equals(value, _calcCommand))
					return;
				_calcCommand = value;
				OnPropertyChanged("CalcCommand");
			}
		}

		public void RaiseOnCalcEvent()
		{
			if (On_calc_cmd != null)
				On_calc_cmd("10,1,2,3", CalculationModes.Sum);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		//[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
