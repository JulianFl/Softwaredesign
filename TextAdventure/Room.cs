using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure
{
    public class Room
    {
        public List<Item> RoomItems = new List<Item>();
        public List<Characters> RoomPlayers = new List<Characters>();    
        public string name;
        public Room north ; 
        public  Room south; 
        public  Room west; 
        public  Room east;
        public void Exit (Characters player)
        {
            RoomPlayers.Remove(player);
        }
        public void Entry (Characters player)
        {
            RoomPlayers.Add(player);
        }

        public Enemy GetEnemy()
        {
            for (int i = 0; i < RoomPlayers.Count; i++)
            {   
                
                if( RoomPlayers[i].GetType() == typeof(Enemy))
                {
                        return (Enemy)RoomPlayers[i];
                }
            }
            return null;
        }

        public Item Take (string item)
        {
            Item take = null;
            for(int i=0; i < RoomItems.Count ;i++)
            {
                if(RoomItems[i].name == item)
                {
                    take = RoomItems[i];
                    RoomItems.Remove(RoomItems[i]);
                    Console.WriteLine("Sie haben " +item +" erfolgreich hinzugefügt.");
                }
            }
            return take;
        }
        
        public void Drop (Item item)
        {
            RoomItems.Add(item);
            Console.WriteLine("Sie haben " +item +" erfolgreich abgelegt.");
        }

        public void Look()
        {
            Console.WriteLine("Hier liegen " +RoomItems.Count +" Items. Geben Sie take(t) ein und anschließend den Namen des Items, um eins in Ihr Inventar einzufügen.");
            Console.WriteLine("Hier liegen folgende Items: ");

            for(int i=0; i<RoomItems.Count; i++)
            {
                Console.WriteLine(RoomItems[i].name );
            }            
        }
    }
} 
