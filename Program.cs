/**************************************************************************/
/* Program Name:     Dog                                                  */
/* Date:             11/14/2021                                           */
/* Programmer:       Dan McMahon                                          */
/**************************************************************************/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dog
{
    class Program
    {
        static void Main(string[] args)
        {

            char c;
            int pos = 0;
            Display screen = new Display();

            do
            {
                screen.PrintSelectionScreen(pos);
                c = KeyUtil.GetKey();

                if (c == 'U')
                {
                    if (pos > 0)
                        pos--;
                }
                if (c == 'D')
                {
                    if (pos < 4)
                        pos++;
                }
                if (c == 'E')
                {
                    if (pos == 0)
                    {
                        screen.PrintDogList();
                        pos = 0;
                    }
                    if (pos == 1)
                    {
                        screen.DownloadImage();
                        pos = 0;
                    }
                    if (pos == 2)
                    {
                        screen.PrintSubList();
                        pos = 0;
                    }
                    if (pos == 3)
                    {
                        screen.DownloadImageBreed(false);
                        pos = 0;
                    }
                    if(pos == 4)
                    {
                        screen.DownloadImageBreed(true);
                        pos = 0;
                    }
                }

            } while (c != 'Q');

            Console.WriteLine();
        }
    }
}
