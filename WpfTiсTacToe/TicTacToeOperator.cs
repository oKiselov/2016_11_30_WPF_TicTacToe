using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTiсTacToe
{
    class TicTacToeOperator
    {
        /// <summary>
        /// field for playing 
        /// </summary>
        private int[][] _iTable = new int[3][];

        /// <summary>
        /// Constructor initialize all cells in table 
        /// </summary>
        public TicTacToeOperator()
        {
            _iTable[0] = new int[3];
            _iTable[1] = new int[3];
            _iTable[2] = new int[3];
            for (int i = 0; i < _iTable.GetLength(0); i++)
            {
                for (int j = 0; j < _iTable.GetLength(0); j++)
                {
                    _iTable[i][j] = (int) CellStatus.Empty;
                }
            }
        }

        /// <summary>
        /// Method sets O to pushed position 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetO(int x, int y)
        {
            _iTable[x][y] = (int) CellStatus.O;
        }

        /// <summary>
        /// Method sets X to pushed position 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetX(int x, int y)
        {
            _iTable[x][y] = (int) CellStatus.X;
        }

        /// <summary>
        /// Method for advance
        /// </summary>
        /// <returns></returns>
        public bool IsAvailableField()
        {
            foreach (var dimension in _iTable)
            {
                foreach (var position in dimension)
                {
                    if (position == (int) CellStatus.Empty)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Inspection(int x, int y)
        {
            bool bRetVictory = false;
            // amount of mathes in one row 
            int iNumOfMathesHorizontal = 0, iNumOfMatchesVertical = 0;

            try
            {
                // horizontal neighbors
                for (int i = x - 2; i < x + 2; i++)
                {
                    // vertical neighbors 
                    for (int j = y - 2; j < y + 2; j++)
                    {
                        // inspection for out of range exception 
                        if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
                        {
                            if (j + 1 <= 2)
                            {
                                // horizontal neighbor's values are equal to each other and not equal to 0 
                                if (_iTable[i][j] == _iTable[i][j+1] && _iTable[i][j] != (int) CellStatus.Empty)
                                {
                                    // increase the counter of mathes 
                                    iNumOfMathesHorizontal++;
                                }

                                // vertical neighbor's values are equal to each other and not equal to 0 
                                if (_iTable[j][i] == _iTable[j+1][i] && _iTable[j][i] != (int) CellStatus.Empty)
                                {
                                    // increase the counter of mathes 
                                    iNumOfMatchesVertical++;
                                }
                            }
                        }
                    }
                    if (iNumOfMatchesVertical == 2 || iNumOfMathesHorizontal == 2)
                        {
                            return bRetVictory = true;
                        }
                        iNumOfMatchesVertical = 0;
                        iNumOfMathesHorizontal = 0;
                    
                }
                // diagonal neighbor's values are equal to each other and not equal to 0 
                if (_iTable[0][0] == _iTable[1][1] && _iTable[2][2] == _iTable[1][1] &&
                    _iTable[1][1] != (int) CellStatus.Empty)
                {
                    return bRetVictory = true;
                }
                if (_iTable[0][2] == _iTable[1][1] && _iTable[2][0] == _iTable[1][1] &&
                    _iTable[1][1] != (int) CellStatus.Empty)
                {
                    return bRetVictory = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bRetVictory;
        }
    }
}
