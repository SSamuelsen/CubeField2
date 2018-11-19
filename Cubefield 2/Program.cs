using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Cubefield
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

                    


        static void Main()
        {

            //if (File.Exists("scores.txt"))      //checks to see if the high score file exists on computer 
            //{

            //}
            //else
            //{
            //    File.Create("scores.txt");  //if file does not exist, create one
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new menuScreen());
        }



    }
}
