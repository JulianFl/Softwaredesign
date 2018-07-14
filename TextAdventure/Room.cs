using System;
using System.Collections.Generic;
using System.Data;


namespace TextAdventure
{
   public class Room{
        public List<Item> RoomItems = new List<Item>();
        public List<Characters> RoomPlayers = new List<Characters>();
        
        public string name;
        public Room north ; 
        public  Room south; 
        public  Room west; 
        public  Room east;
        public Room move(string input){
            Room temp;
            switch(input){
            case "n":
                temp = north; 
                break;
            case "s":
                temp = south;
                break;
            case "w":
                temp = west;
                break;
            case "e": 
                temp = east;
                break;
            default:
                Console.WriteLine("Falsche Eingabe"); 
                temp = this;
                break;
            }    
            if (temp==null){
                Console.WriteLine("Diesen Weg gibt es nicht"); 
                return this;
            }else{
                return temp;
            }
        }
            
        
            /*
        public Room gonorth(){
            if(north == null){
                Console.WriteLine("Diesen Weg gibt es nicht"); 
                return this;
            }
            return north;
        }
        public Room goeast(){
            if(east == null){
                Console.WriteLine("Diesen Weg gibt es nicht"); 
                return this;
            }
            return east;
        }
        public Room gowest(){
            if(west == null){
                Console.WriteLine("Diesen Weg gibt es nicht"); 
                return this;
            }
            return west;
        }
        public Room gosouth(){
            if(south == null){
                Console.WriteLine("Diesen Weg gibt es nicht"); 
                return this;
            }
            return south;
        } */
        public void exit (Characters player){
            RoomPlayers.Remove(player);
        }
        public void entry (Characters player){
            RoomPlayers.Add(player);
        }

        public Enemy getEnemy(){
            for (int i = 0; i < RoomPlayers.Count; i++)
            {   
                
                if( RoomPlayers[i].GetType() == typeof(Enemy)){
                        return (Enemy)RoomPlayers[i];
                }
            }
            return null;
        }

        public Item take (string item){
            Item take = null;
            for(int i=0; i < RoomItems.Count ;i++){
                if(RoomItems[i].name == item){
                    take = RoomItems[i];
                    RoomItems.Remove(RoomItems[i]);
                        Console.WriteLine("Sie haben " +item +" erfolgreich hinzugefügt.");
                }
            }
            return take;
        }
        
        public void drop (Item item){
            RoomItems.Add(item);
            Console.WriteLine("Sie haben " +item +" erfolgreich abgelegt.");
        }

        public void look(){
            for(int i=0; i<RoomItems.Count; i++){
                Console.WriteLine(RoomItems[i].name);
            }
        }
    }
} 
