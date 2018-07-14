using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure
{
    public class Characters
    {
        
        public int health = 100;
        public string name;
        public List<Item> PlayerItems = new List<Item>();
        public Room position;
        public Characters(string _name,Room _position)
        {
            position = _position;
            name = _name;
            position.Entry(this);
        }
        public void Look()
        {            
        }
        public void Inventory()
        {
            for(int i=0; i<PlayerItems.Count; i++)
            {
                Console.WriteLine("Ihre Items sind: " +PlayerItems[i].name);
            }
        }
        public void Insert(Item item)
        {
            PlayerItems.Add(item);
        }
        public Item Delete(string item)
        {
            Item drop = null;
            for(int i=0; i < PlayerItems.Count ;i++)
            {
                if(PlayerItems[i].name == item)
                {
                        drop = PlayerItems[i]; 
                        PlayerItems.Remove(PlayerItems[i]);
                }
            }
            return drop;
        }
        public void Move(string input)
        {
            Room newRoom;
            Room oldRoom=position;
            switch(input)
            {
            case "n":
                newRoom = position.north; 
                break;
            case "s":
                newRoom = position.south;
                break;
            case "w":
                newRoom = position.west;
                break;
            case "e": 
                newRoom = position.east;
                break;
            default:
                Console.WriteLine("Falsche Eingabe"); 
                newRoom = position;
                break;
            }    
            if (newRoom==null)
            {
                Console.WriteLine(this.name+": Diesen Weg gibt es nicht. Ihr Gesundheitszustand hat sich reduziert"); 
                this.health -= 5;

            }else
            {
                if (newRoom != position)
                {
                    position = newRoom;
                    oldRoom.Exit(this);
                    Console.WriteLine(this.name +": ging von "+oldRoom.name +" nach " +newRoom.name);
                    newRoom.Entry(this);
                }
            }
        }
    }
}