using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubefield
{
    class Levels
    {


        public int Level { get; set; }              //property that will adjust change the level

        public bool displayLevelTitle { get; set; }

        public string barrierColor { get; set; }        //sets the barrier color to a new color for each level



        public void displayLevelCount()                 //displays the text that shows next level
        {


            if (Level == 1)
            {

                displayLevelTitle = true;
                //barrierColor = "Green";

            }

            else if (Level == 2)
            {

                displayLevelTitle = true;

                barrierColor = "Blue";

            }

            else if (Level == 3)
            {
                
                displayLevelTitle = true;
                barrierColor = "Green";

            }
            else if (Level == 4)
            {

                displayLevelTitle = true;
                barrierColor = "Purple";

            }

            else if (Level == 5)
            {

                displayLevelTitle = true;
                barrierColor = "Orange";

            }

            else if (Level == 6)
            {

                displayLevelTitle = true;
                barrierColor = "Yellow";

            }
            else if (Level == 7)
            {

                displayLevelTitle = true;
                barrierColor = "Blue";

            }




        }


        public void hideLevelCount()            //function to hide the next level title
        {

            displayLevelTitle = false;

        }





        }
}
