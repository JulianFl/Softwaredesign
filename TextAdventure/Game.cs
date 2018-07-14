using System;
using System.Data;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Game
    {
        Player player;
        List<Room> Rooms = new List<Room>();
        Enemy e1;
        Enemy e2;
            
        public void BuildGame ()
        {
            DataTable data = GetTable();

            //Create rooms
            foreach (DataRow row in data.Rows) 
            {
                string _name = row["Name"].ToString();
                Rooms.Add( new Room() {name=_name});
            }

            //Create doors
            int ir = 0;
            foreach (DataRow row in data.Rows)
            {    
                // all rows
                string direction = "";
                string nextroom = "";
                Room neighbour;

                // all directions
                for (int i = 0; i < 4; i++)     
                {
                    //get next room
                    switch(i) 
                    {
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
                        for (int r = 0; r < Rooms.Count; r++)
                        {
                            if (Rooms[r].name == nextroom)
                            {
                                neighbour = Rooms[r];
                            }
                        }

                        //set neighbours
                        switch(direction)
                        {
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


            player = new Player("Ju",Rooms[RandomRoom()]);

            e1 = new Enemy("Monster",Rooms[RandomRoom()]);

            e2 = new Enemy("Monster 2",Rooms[RandomRoom()]);
        }
        
        int RandomRoom()
        {
            Random randomNumber = new Random();   
            int random = randomNumber.Next(0,Rooms.Count);
            return random;
        }
        int RandomMove()
        {
            Random randomNumber = new Random();   
            int random = randomNumber.Next(0,4);
            return random;
        }

        static DataTable GetTable()
        {
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
        public void Play()
        {
            string input = ""; 
            while (input != "q")
            { 
                if(input == "n" || input == "s" || input == "e" || input == "w")
                {
                    int x = RandomRoom();
                    switch(x)
                    {
                    case 0:
                        e1.Move("n");
                        break;
                    case 1:
                        e1.Move("s");
                        break;
                    case 2:
                        e1.Move("w");
                        break;
                    case 3:
                        e1.Move("e");
                        break;
                    }
                }
                Show(player);
                input = Console.ReadLine(); 
                
                try
                {
                    if (input != "q") 
                    {
                        switch(input) 
                        {
                            case "q":
                                break;
                            case "l":
                                Show(player);
                                break;
                            case "i":
                                player.Inventory();
                                break;
                            case "c":
                                Commands();
                                break;    
                            case "d":
                                Drop(player);
                                break;    
                            case "t":
                                Take(player);
                                break;    
                            case "n":
                                player.Move(input);
                                break;
                            case "e":
                                player.Move(input);
                                break;
                            case "s":
                                player.Move(input);
                                break;
                            case "w":
                                player.Move(input);
                                break;
                            case "a":
                                player.Attack();
                                break;    
                            default:
                                Console.WriteLine("Falsche Eingabe");
                                break;
                        }
                    }

                } catch(Exception)
                {
                     Console.WriteLine("Falsche Eingabe");
                }    
            }
        }
        void Show(Player p)
        {
            Enemy _enemy = p.position.GetEnemy();
            Console.WriteLine("");
            Console.WriteLine("Sie befinden sich in " +p.position.name +" und Ihr Gesundheitszustand beträgt "+p.health+". Geben Sie north(n), east(e), west(w) oder south(s) ein um sich zu bewegen.");
            p.position.Look();
            if( _enemy!= null)
            {
                Console.WriteLine("In " +p.position.name +" befindet sich ein " +_enemy.name +" mit dem Gesundheitszustand "+_enemy.health +". Wollen Sie es mit <a> angreifen?");
            }
        }
        void Take(Player p)
        {
            Console.WriteLine("Welches Item wollen Sie?");
            string item = Console.ReadLine();
            Item takeItem = p.position.Take(item);
            p.Insert(takeItem);
        }
        void Drop(Player p)
        {
            Console.WriteLine("Welches Item wollen Sie ablegen?");
            string item = Console.ReadLine();
            Item dropItem = p.Delete(item);
            p.position.Drop(dropItem);
        }
        void Commands()
        {
            Console.WriteLine("commands(c), look(l), inventory(i), take(t) item, drop(d) item, quit(q)");
        }
    }
}
