using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure
{
   
       
    public class Player : Characters{
        
        //string characterType = "Player";

        public Player(string _name,Room _position) : base(_name,_position)
        {
            
        }

        public void attack(){
            health= health - 5;
            position.getEnemy().health -= 10;
        }
    }
    
}

   
