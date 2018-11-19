using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cubefield
{
    class SaveScores
    {



        public void createSaveFile()             //method to create a save file if needed
        {

            if (File.Exists("scores.txt"))      //checks to see if the high score file exists on computer 
            {
                //do not do anything is there already exists a file
            }
            else
            {
                File.Create("scores.txt");  //if file does not exist, create one
            }

        }

        


}
}
