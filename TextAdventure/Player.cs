using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure
{
    public class Player : Characters
    {    
        public Player(string _name,Room _position) : base(_name,_position)
        {       
        }
        public void Attack()
        {
            if(position.GetEnemy().health > 0)
            {
                health = health - 5;
                position.GetEnemy().health -= 10;
            }else
            {
                Console.WriteLine(position.GetEnemy().name +" hat kein Leben mehr.");
                Console.WriteLine("Herzlichen Glückwunsch. Sie haben gewonnen!");
            }   
        }
    }
}

   
