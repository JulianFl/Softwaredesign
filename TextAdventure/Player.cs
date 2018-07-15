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
        int MyRandomTotal()
        {
            Random _randomNumber = new Random();   
            int _random = _randomNumber.Next(0,10);
            return _random;
        }

        int EnemyRandomTotal()
        {
            Random _randomNumber = new Random();   
            int _random = _randomNumber.Next(0,30);
            return _random;
        }
        public void Attack()
        {         
            Game game= new Game();
            int _reduce = MyRandomTotal();
            Total = Total - _reduce;
            int _myreduce = _reduce;
            Console.WriteLine("Ihr Kontostand hat sich um " +_reduce +" Euro verringert.");

            Enemy enemy = Position.GetEnemy();  
            _reduce = EnemyRandomTotal();
            int _enemyReduce = _reduce;
            enemy.Total -= _reduce;  
            
            Console.WriteLine( "Der Kontostand von "+enemy.Name +" hat sich um " +_reduce +" Euro verringert.");
            if(_myreduce < _enemyReduce){
                Console.WriteLine("Sie haben das Duell gegen "+enemy.Name +" gewonnen. Sie können nun ein Item von " +enemy.Name +" haben.");
                TakeEnemyItems();
            }
            if (enemy.Total <= 0){
                Console.WriteLine("Sie haben gegen " +enemy.Name +" gewonnen." );     
            }
        }
        public Item TakeEnemyItems()
        {
            string _item = Console.ReadLine();
            Item _take = null;
            for(int i=0; i < Position.GetEnemy().PlayerItems.Count ;i++)
            {
                if(Position.GetEnemy().PlayerItems[i].Name == _item)
                {
                    _take = Position.GetEnemy().PlayerItems[i];
                    PlayerItems.Remove(Position.GetEnemy().PlayerItems[i]);
                    Insert(_take);
                    Position.GetEnemy().PlayerItems.Remove(PlayerItems[i]);

                    Console.WriteLine("Sie haben " +_item +" erfolgreich hinzugefügt.");
                }
            }
            return _take;
        }
    }
}

   
