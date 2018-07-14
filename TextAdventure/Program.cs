using System;
using System.Data;
using System.Collections.Generic;

namespace TextAdventure
{
    //public enum enumRooms { Germany, France, Russia, Italy , Spain };

   public class Program
    {
        static void Main(string[] args){

            //Create game
            Game game = new Game();
            game.BuildGame();
            game.play();
        }

      
    }
}

    
