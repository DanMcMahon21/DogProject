using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog
{
    class KeyUtil
    {
        public static char GetKey()
        /************************************************************************/
        /*** Function to return a Control Key Code                            ***/
        /***                                                                  ***/
        /*** Input:                                                           ***/
        /***    Parameters:                                                   ***/
        /***       Nothing                                                    ***/
        /***    Global:                                                       ***/
        /***       Nothing                                                    ***/
        /***                                                                  ***/
        /*** Output:                                                          ***/
        /***    Returns:                                                      ***/
        /***       Up Arrow    -> 'U'    Up                                   ***/
        /***       Down Arrow  -> 'D'    Down                                 ***/
        /***       Left Arrow  -> 'L'    Left                                 ***/
        /***       Right Arrow -> 'R'    Right                                ***/
        /***       Page Up     -> 'P'    Previous                             ***/
        /***       Page Down   -> 'N'    Next                                 ***/
        /***       Escape      -> 'Q'    Quit                                 ***/
        /***       Enter       -> 'E'    Enter                                ***/
        /***       All Others  -> character pressed                           ***/
        /***    Parameters:                                                   ***/
        /***       Nothing                                                    ***/
        /***    Global:                                                       ***/
        /***       Nothing                                                    ***/
        /************************************************************************/
        {
            ConsoleKeyInfo k;

            k = Console.ReadKey(true); // true -> no echo
            if (k.Key == ConsoleKey.UpArrow)
                return 'U';
            else if (k.Key == ConsoleKey.DownArrow)
                return 'D';
            else if (k.Key == ConsoleKey.LeftArrow)
                return 'L';
            else if (k.Key == ConsoleKey.RightArrow)
                return 'R';
            else if (k.Key == ConsoleKey.PageUp)
                return 'P';
            else if (k.Key == ConsoleKey.PageDown)
                return 'N';
            else if (k.Key == ConsoleKey.Escape)
                return 'Q';
            else if (k.Key == ConsoleKey.Enter)
                return 'E';
            else
                return k.KeyChar;
        }
    }
}
