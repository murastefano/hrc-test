using HRC.Service.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRC.Desktop
{
    public class BidimensionalMatrix
    {
        public int[,] CurrentMatrix { get; set; }

        public string Name { get; }

        public ArrayDataView CurrentMatrixView { get; set; }

        public BidimensionalMatrix(int width, int height) 
        {
            CurrentMatrix = new int[width, height]; 
            Name = $"{width}X{height}";
            colnames = new string[width];
            for (int c = 0; c < width; c++)
            {
                colnames[c] = string.Format("-{0}-", c);
            }
        }

        private string[] colnames;

        public void SetValue(int width, int height, int value)
        {
            CurrentMatrix[width, height] = value;
            CurrentMatrixView = new ArrayDataView(CurrentMatrix, colnames);
        }
    }
}
