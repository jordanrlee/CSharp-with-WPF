using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign4_JRL_WPF
{
    interface InterfaceTTTWindow
    {
        #region Methods (Abstract)

        /// <summary>
        /// update game status in textBlock1 using the status array of type String
        /// </summary>
        /// <param name="status">The status to be set</param>
        void UpdateGameStatus(String status);

        /// <summary>
        /// Reset the game for rematch
        /// </summary>
        void Reset();

        /// <summary>
        /// update statistics inside groupbox1
        /// </summary>
        void UpdateStatistics();

        /// <summary>
        /// highlight the squares that were used to win
        /// </summary>
        /// <param name="squares">The tiles to higlight</param>
        void WinningSquares(int[] squares);
        #endregion
    }
}
//}
