using HRC.Service.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRC.Desktop
{
    public class CalculatorViewModel : BaseViewModel
    {
        private int _determinant;
        public int MatrixDeterminant
        {
            get { return _determinant; }
            set
            {
                if (_determinant != value)
                {
                    _determinant = value;
                    OnPropertyChanged("MatrixDeterminant");
                }
            }
        }

        private string _sortedValues;
        public string MatrixFilteredSorted
        {
            get { return _sortedValues; }
            set
            {
                if (_sortedValues != value)
                {
                    _sortedValues = value;
                    OnPropertyChanged("MatrixFilteredSorted");
                }
            }
        }

        private BidimensionalMatrix _matix;
        public BidimensionalMatrix SelectedMatrix
        {
            get { return _matix; }
            set
            {
                if (_matix != value)
                {
                    MatrixFilteredSorted = string.Empty;
                    MatrixDeterminant = 0;
                    _matix = value;
                    OnPropertyChanged("SelectedMatrix");
                }
            }
        }

        public ObservableCollection<BidimensionalMatrix> MatrixList { get; }

        private DelegateCommand _calculateDeterminant;
        private delegate void calculateDeterminantAsync();
        public DelegateCommand CalculateDeterminantCommand
        {
            get
            {
                if (_calculateDeterminant == null)
                {
                    _calculateDeterminant = new DelegateCommand(() =>
                    {
                        MatrixDeterminant = 0;
                        IsWorking = true;
                        var _load = new calculateDeterminantAsync(DoCalculateDeterminant);
                        _load.BeginInvoke(null, null);
                    });
                }
                return _calculateDeterminant;
            }
        }

        private DelegateCommand _filterAndSort;
        private delegate void filterAndSortAsync();
        public DelegateCommand FilterAndSortCommand
        {
            get
            {
                if (_filterAndSort == null)
                {
                    _filterAndSort = new DelegateCommand(() =>
                    {
                        MatrixFilteredSorted = string.Empty;
                        IsWorking = true;
                        var _load = new filterAndSortAsync(DoFilterAndSort);
                        _load.BeginInvoke(null, null);
                    });
                }
                return _filterAndSort;
            }
        }

        private void DoCalculateDeterminant()
        {
            MatrixDeterminant = calculatorServiceClient.CalcDeterminant(SelectedMatrix.CurrentMatrix);
            IsWorking = false;
        }

        private void DoFilterAndSort()
        {
            MatrixFilteredSorted = calculatorServiceClient.FilterAndOrderValues(SelectedMatrix.CurrentMatrix);
            IsWorking = false;
        }

        private CalculatorServiceClient calculatorServiceClient;

        public CalculatorViewModel()
        {
            calculatorServiceClient = new CalculatorServiceClient();
            MatrixList = new ObservableCollection<BidimensionalMatrix>();
            BidimensionalMatrix _4x4 = FillMatrix(4, 4); 
            MatrixList.Add(_4x4);
            BidimensionalMatrix _5x5 = FillMatrix(5, 5);
            MatrixList.Add(_5x5);
            BidimensionalMatrix _36x36 = FillMatrix(36, 36);
            MatrixList.Add(_36x36);
            SelectedMatrix = _5x5;
        }

        private BidimensionalMatrix FillMatrix(int width, int height)
        {
            var _matrix = new BidimensionalMatrix(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int y = 0; y < height; y++)
                {
                    _matrix.SetValue(i, y, RandomValue());
                }
            }

            return _matrix;
                 
        }

        Random rnd = new Random();
        private int RandomValue()
        {
            return rnd.Next(1, 9);
        }
    }
}
