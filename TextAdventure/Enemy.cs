using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure
{
 public class Enemy : Characters{
      
        public Enemy(string _name,Room _position) : base(_name,_position)
        {
        }

        public int navigateEnemy(){
            Random randomNumber = new Random();   
            int random = randomNumber.Next(0,5);
            return random;
        }
 }
}