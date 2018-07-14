using System;
using System.Data;
using System.Collections.Generic;

namespace TextAdventure{
    public class Game{
            Player player;
         public void BuildGame () {
            DataTable data = GetTable();

            //Create rooms
            List<Room> Rooms = new List<Room>();
            foreach (DataRow row in data.Rows) {
                string _name = row["Name"].ToString();
                Rooms.Add( new Room() {name=_name});
            }

            //Create doors
            int ir = 0;
            foreach (DataRow row in data.Rows) {    // all rows
                String direction = "";
                String nextroom = "";
                Room neighbour;

                for (int i = 0; i < 4; i++)     // all directions
                {
                    //get next room
                    switch(i) {
                    case 0:
                        direction = "North";
                        break;
                    case 1:
                        direction = "South";
                        break;
                    case 2:
                        direction = "East";
                        break;
                    case 3:
                        direction = "West";
                        break;
                    }
                    nextroom = row[direction].ToString();

                    if (nextroom != "")
                    {
                        //search room in list
                        neighbour = null;
                        for (int r = 0; r < Rooms.Count; r++) {
                            if (Rooms[r].name == nextroom) {
                                neighbour = Rooms[r];
                            }
                        }

                        //set neighbours
                        switch(direction) {
                        case "North":
                            Rooms[ir].north = neighbour;
                            break;
                        case "South":
                            Rooms[ir].south = neighbour;
                            break;
                        case "East":
                            Rooms[ir].east = neighbour;
                            break;
                        case "West":
                            Rooms[ir].west = neighbour;
                            break;
                        }
                    }

                }

                ir++;
            }

            //Set room items
            Rooms[0].RoomItems.Add(new Item{name="Bier"});
            Rooms[0].RoomItems.Add(new Item{name="Brezel"});
            
            Rooms[1].RoomItems.Add(new Item{name="Baguette"});
            Rooms[1].RoomItems.Add(new Item{name="Wine"});

            Rooms[2].RoomItems.Add(new Item{name="Wodka"});
            Rooms[2].RoomItems.Add(new Item{name="Matruschka"});
            
            Rooms[3].RoomItems.Add(new Item{name="Pizza"});
            Rooms[3].RoomItems.Add(new Item{name="Espresso"});
            
            Rooms[4].RoomItems.Add(new Item{name="Tapas"});
            Rooms[4].RoomItems.Add(new Item{name="Cerveza"});


            player = new Player("Ju",Rooms[0]);
            //p1.position = Rooms[(int)enumRooms.Germany];

            Enemy e1 = new Enemy("Monster",Rooms[1]);
            e1.position = Rooms[1];

            Enemy e2 = new Enemy("Monster 2",Rooms[4]);
            e1.position = Rooms[4];


        }

       static DataTable GetTable() {
            DataTable table = new DataTable();

            //Define columns
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("North", typeof(string));
            table.Columns.Add("South", typeof(string));
            table.Columns.Add("East", typeof(string));
            table.Columns.Add("West", typeof(string));

            //Define rows
            table.Rows.Add("Germany", "","Italy","Russia","France");
            table.Rows.Add("France", "","Spain","Germany","");
            table.Rows.Add("Russia", "","","","Germany");
            table.Rows.Add("Italy", "Germany","","","Spain");
            table.Rows.Add("Spain", "France","","Italy","");
            return table;
        }
        void show(Player p)
        {
            Enemy _enemy = p.position.getEnemy();
            if( _enemy!= null){
                Console.WriteLine("In " +p.position.name +" befindet sich ein " +_enemy.name +" mit dem Gesundheitszustand "+_enemy.health +". Wollen Sie es mit <a> angreifen?");
            }
            Console.WriteLine("Sie befinden sich in " +p.position.name +" Geben Sie north(n), east(e), west(w) oder south(s) ein um sich zu bewegen.");
            p.position.look();
            Console.WriteLine("Ihr Gesundheitszustand beträgt " +p.health);
            
        }
        void take(Player p)
        {
            Console.WriteLine("Welches Item wollen Sie?");
            string item = Console.ReadLine();
            Item takeItem = p.position.take(item);
            p.insert(takeItem);
            //p.inventory();
        }
        void drop(Player p)
        {
            Console.WriteLine("Welches Item wollen Sie ablegen?");
            string item = Console.ReadLine();
           
            Item dropItem = p.delete(item);
            p.position.drop(dropItem);
            //p.inventory();
        }
        void commands(){
            Console.WriteLine("commands(c), look(l), inventory(i), take(t) item, drop(d) item, quit(q)");
        }
        public void play(){
             string input = ""; 
            while (input != "q"){ 
                show(player);
                input = Console.ReadLine(); 
                
                try{
                    if (input != "q") {
                        switch(input) {
                            case "q":
                                break;
                            case "l":
                                show(player);
                                break;
                            case "i":
                                player.inventory();
                                break;
                            case "c":
                                commands();
                                break;    
                            case "d":
                                drop(player);
                                break;    
                            case "t":
                                take(player);
                                break;    
                            case "n":
                                player.move(input);
                                break;
                            case "e":
                                player.move(input);
                                break;
                            case "s":
                                player.move(input);
                                break;
                            case "w":
                                player.move(input);
                                break;
                            case "a":
                                player.attack();
                                break;    
                            default:
                                Console.WriteLine("Go to an other direction.");
                                break;
                        }
                    }

                } catch(Exception){
                     Console.WriteLine("Please enter n, s, w or e ");
                    }    
            }
        }
    }
}
