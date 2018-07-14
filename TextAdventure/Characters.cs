using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure
{
 public class Characters{
        
        public int health = 100;
        public string name;
        public List<Item> PlayerItems = new List<Item>();
        public Room position;
        //public string characterType;
        public Characters(string _name,Room _position){
            position = _position;
            name = _name;
            position.entry(this);
        }
        public void look(){            
        }
        public void inventory(){
            for(int i=0; i<PlayerItems.Count; i++){
                Console.WriteLine(PlayerItems[i].name);
            }
        }
        public void insert(Item item){
            PlayerItems.Add(item);
        }
        public Item delete(string item){
            Item drop = null;
            for(int i=0; i < PlayerItems.Count ;i++){
                if(PlayerItems[i].name == item){
                        drop = PlayerItems[i]; 
                        PlayerItems.Remove(PlayerItems[i]);
                }
            }
            return drop;
        }
        public void move(string input){
            Room temp = position;
            position=position.move(input);
            if (temp != position) {
                temp.exit(this);
                position.entry(this);
            }
        }
    }
}