using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class UserInterface
    {
        private GameManager gm;

        private Player p1;
        private Player p2;

        public void Show()
        {
            gm = new GameManager();

            p1 = gm.Player1;
            p2 = gm.Player2;

            int key = 0;
            
            do
            {
                Console.Clear();
                Console.WriteLine("------(PROJECT PP)------");
                Console.WriteLine("1 - START");
                Console.WriteLine("2 - Set Players usernames");
                Console.WriteLine("0 - EXIT");
                Console.WriteLine("--------------------------");

                if(gm.GameFinished)
                    ShowWinnerUI();

                key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        UIField();
                        break;
                    case 2:
                        UIUsername();
                        break;
                }
                
            } while (key != 0);
            
            
        }

        public void UIUsername()
        {
            Console.Write("Write Player's 1 username: ");
            p1.Username = Console.ReadLine();
            Console.Write("\nWrite Player's 2 username: ");
            p2.Username = Console.ReadLine();
            
        }

        public void UIField()
        {
            Coordinate? addCoordinate = null;

            bool isToTrain = false;

            int numberOfUnitsToProduce = 0;

            string errorMessage = null;
            string option,coordinate = null;
            string strBuilding = null;
            string unit = null;
            string unitToTrain = null;
            string optionalCoordinate = null;
            string isNewTurn = null;

            Field field = new Field(gm);
            field.Show();
            int n_moves = 0;

            if (gm.PlayerTurn == null)
            {
                gm.PlayerTurn = p1;
            }

            
            do
            {
                if(isNewTurn == null)
                    n_moves = gm.PlayerTurn.Resources.N_Moves;
                else if(isNewTurn == "YES")
                    n_moves = gm.PlayerTurn.Resources.N_Moves;

                int nBarracks = gm.PlayerTurn.Resources.CountBarracks();
                int nStables = gm.PlayerTurn.Resources.CountStables();
                int nArtilleryFactories = gm.PlayerTurn.Resources.CountArtilleryFactories();
                
                Console.WriteLine("────────────────────────────────────────────");
                Console.ForegroundColor = gm.PlayerTurn.Color;
                Console.WriteLine("{0} its your turn", gm.PlayerTurn.Username);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have {0} points to move",n_moves);
                Console.WriteLine("You have {0} coins",gm.PlayerTurn.Resources.Coins);
                Console.ResetColor();
                Console.WriteLine("────────────────────────────────────────────");
                Console.WriteLine("What is your next move?");
                Console.WriteLine("────────────────────────────────────────────");
                Console.WriteLine("ADD");
                if(nBarracks > 0 || nStables > 0 || nArtilleryFactories > 0)
                    Console.WriteLine("TRAIN UNITS");
                Console.WriteLine("MOVE");
                Console.WriteLine("ATTACK");
                Console.WriteLine("────────────────────────────────────────────");
                option = Console.ReadLine().ToUpper();



                if (option == "ADD")
                {
                    Console.WriteLine("Which coordinate do you want to add?");
                    coordinate = Console.ReadLine().ToUpper();

                    string[] coordinateSplit = coordinate.Split(',');

                    char letter = Convert.ToChar(coordinateSplit[0]);
                    int number = Int32.Parse(coordinateSplit[1]);

                    addCoordinate = new Coordinate(letter, number);
                }
                else if (option == "TRAIN UNITS")
                {
                    isToTrain = true;
                }
                else
                {
                    string firstTextMoveOrAttack = option == "MOVE"
                        ? "Which coordinate do you want to move?"
                        : "Select the unit that you want to attack with!";
                    string secondTextMoveOrAttack = option == "MOVE"
                        ? "Where do you want to replace it?"
                        : "Select the unit that you want to attack!";

                    Console.WriteLine(firstTextMoveOrAttack);
                    coordinate = Console.ReadLine().ToUpper();

                    string[] coordinateSplit = coordinate.Split(',');

                    char letter = Convert.ToChar(coordinateSplit[0]);
                    int number = Int32.Parse(coordinateSplit[1]);

                    addCoordinate = new Coordinate(letter, number);
                    
                    Console.WriteLine(secondTextMoveOrAttack);

                    optionalCoordinate = Console.ReadLine().ToUpper();
                }

                if (isToTrain)
                {
                    Console.WriteLine("SELECT ONE OF THIS UNITS TO TRAIN");
                    Console.WriteLine("────────────────────────────────────────────");
                    if(nBarracks > 0)
                        Console.WriteLine("INFANTRY | You got {0}", gm.PlayerTurn.Resources.N_Infantry);
                    if(nStables > 0)
                        Console.WriteLine("CAVALRY  | You got {0}", gm.PlayerTurn.Resources.N_Cavalry);
                    if(nArtilleryFactories > 0)
                        Console.WriteLine("ARTILLERY| You got {0}", gm.PlayerTurn.Resources.N_Artillery);
                    Console.WriteLine("────────────────────────────────────────────");
                    unitToTrain = Console.ReadLine().ToUpper();

                    Console.WriteLine("How many units you want?");
                    numberOfUnitsToProduce = int.Parse(Console.ReadLine());


                }
                else if (optionalCoordinate == null)
                {
                    
                    Console.WriteLine("Which type of unit you want to add?");
                    Console.WriteLine("────────────────────────────────────────────");
                    Console.WriteLine("BUILDING");
                    if (gm.PlayerTurn.Resources.HasAnyKindOfUnit())
                        Console.WriteLine("UNIT");
                    Console.WriteLine("────────────────────────────────────────────");

                    string isBuildingString = Console.ReadLine().ToUpper();
                    bool isBuilding = isBuildingString == "BUILDING" ? true : false;

                    if (isBuilding)
                    {
                        Console.WriteLine("SELECT ONE OF THIS BUILDINGS TO BUILD!");
                        Console.WriteLine("────────────────────────────────────────────");
                        Console.WriteLine("FARM");
                        Console.WriteLine("BARRACK");
                        Console.WriteLine("STABLE");
                        Console.WriteLine("ARTILLERY FACTORY");
                        Console.WriteLine("────────────────────────────────────────────");
                        strBuilding = Console.ReadLine().ToUpper();
                    }
                    else if(gm.PlayerTurn.Resources.HasAnyKindOfUnit())
                    {
                        Console.WriteLine("SELECT ONE OF THIS UNITS TO SPAWN");
                        Console.WriteLine("────────────────────────────────────────────");
                        Console.WriteLine("INFANTRY | You got {0}", gm.PlayerTurn.Resources.N_Infantry);
                        Console.WriteLine("CAVALRY  | You got {0}", gm.PlayerTurn.Resources.N_Cavalry);
                        Console.WriteLine("ARTILLERY| You got {0}", gm.PlayerTurn.Resources.N_Artillery);
                        Console.WriteLine("────────────────────────────────────────────");
                        unit = Console.ReadLine().ToUpper();
                    }
                }
                
                if (option == "MOVE" && optionalCoordinate != null && addCoordinate.HasValue && (!field.IsOutOfBorders(addCoordinate.Value)))
                {
                    string[] optionalCoordinateSplit = optionalCoordinate.Split(',');

                    char newLetter = Convert.ToChar(optionalCoordinateSplit[0]);
                    int newNumber = Int32.Parse(optionalCoordinateSplit[1]);
                    Coordinate moveCoordinate = new Coordinate(newLetter, newNumber);
                    if (field.IsOutOfBorders(moveCoordinate))
                    {
                        Console.WriteLine("You can't move a unit to out of the field!");
                    }

                    //TODO : Remove this from where when the update doesn't needs the GameEntity
                    GameEntity ge = null;
                    if (gm.PlayerTurn == p1)
                    {
                        if (gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value) != null)
                        {
                            if (gm.PlayerTurn.Resources.IsCoordinateAvailable(moveCoordinate) == null && p2.Resources.IsCoordinateAvailable(moveCoordinate) == null)
                            {
                                ge = gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value);
                                if (ge is Building)
                                {
                                    errorMessage = "You cannot move buildings!";
                                }
                                else if (ge != null)
                                {
                                    Unit u = ge as Unit;

                                    int distance = ge.Distance(moveCoordinate);
                                    int moveDistance = u.CanMove(distance, n_moves);
                                    if (moveDistance > 0)
                                    {
                                        n_moves -= moveDistance;
                                        gm.PlayerTurn.Resources.MoveEntity(ge, moveCoordinate);
                                        //field.Update();
                                    }
                                    else
                                    {
                                        errorMessage = "You don't have enough move points to do that!";
                                    }
                                }
                            }
                            else
                            {
                                errorMessage = "You can't do that!";
                            }
                        }
                        else
                        {
                            errorMessage = "You cannot move the unknown!";
                        }
                    }
                    else if (gm.PlayerTurn == p2)
                    {
                        if (gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value) != null)
                        {
                            if (gm.PlayerTurn.Resources.IsCoordinateAvailable(moveCoordinate) == null && p1.Resources.IsCoordinateAvailable(moveCoordinate) == null)
                            {
                                ge = gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value);
                                if (ge is Building)
                                {
                                    errorMessage = "You cannot move buildings!";
                                }
                                else if (ge != null)
                                {
                                    Unit u = ge as Unit;

                                    int distance = ge.Distance(moveCoordinate);
                                    int moveDistance = u.CanMove(distance, n_moves);
                                    if (moveDistance > 0)
                                    {
                                        n_moves -= moveDistance;
                                        gm.PlayerTurn.Resources.MoveEntity(ge, moveCoordinate);
                                        //field.Update();
                                    }
                                    else
                                    {
                                        errorMessage = "You don't have enough move points to do that!";
                                    }
                                }
                            }
                            else
                            {
                                errorMessage = "You can't do that!";
                            }
                        }
                        
                        else
                        {
                            errorMessage = "You cannot move the unknown!";
                        }
                    }

                    addCoordinate = null;

                    optionalCoordinate = null;

                    field.Update();

                    if (errorMessage != null)
                    {
                        Console.WriteLine(errorMessage);
                        errorMessage = null;
                    }

                    Console.WriteLine("Are you done? Do you want to finish the turn? (Yes or No)");
                    isNewTurn = Console.ReadLine().ToUpper();

                    if (isNewTurn == "YES")
                    {
                        isNewTurn = null;
                        gm.NewTurn();
                    }
                }
                else if (option == "ATTACK" && optionalCoordinate != null && addCoordinate.HasValue)
                {
                    string[] optionalCoordinateSplit = optionalCoordinate.Split(',');

                    char newLetter = Convert.ToChar(optionalCoordinateSplit[0]);
                    int newNumber = Int32.Parse(optionalCoordinateSplit[1]);
                    Coordinate moveCoordinate = new Coordinate(newLetter, newNumber);

                    if (gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value) != null)
                    {
                        GameEntity playerEntity = gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value);
                        if (playerEntity is Unit)
                        {
                            Unit playerUnit = playerEntity as Unit;

                            Player enemy = gm.PlayerTurn == p1 ? p2 : p1;

                            if (enemy.Resources.IsCoordinateAvailable(moveCoordinate) != null)
                            {
                                GameEntity enemyEntity = enemy.Resources.IsCoordinateAvailable(moveCoordinate);
                                
                                int distanceToEnemy = playerEntity.Distance(moveCoordinate);
                                if (distanceToEnemy <= playerUnit.AttackRange)
                                {
                                    if (enemyEntity.TakeDamage(playerUnit.AttackValue))
                                    {
                                        gm.PlayerTurn.Resources.Score += enemyEntity.Score;
                                        enemy.Resources.RemoveEntity(enemyEntity);
                                        if (enemyEntity is PlayerBase)
                                        {
                                            gm.SetGameOver();
                                            return;
                                        }
                                        
                                        //gm.PlayerTurn.Resources.MoveEntity(playerEntity, moveCoordinate);
                                    }
                                    
                                }
                                else
                                {
                                    errorMessage = "That's to far for my range!";
                                }

                            }
                            else if (gm.PlayerTurn.Resources.IsCoordinateAvailable(moveCoordinate) != null)
                            {
                                errorMessage = "You can't attack your self!";
                            }
                        }
                        else
                        {
                            errorMessage = "You can't attack other unit with a building selected!";
                        }
                    }
                    else
                    {
                        errorMessage = "You need to select a unit!";
                    }

                    optionalCoordinate = null;

                    field.Update();

                    if (errorMessage != null)
                    {
                        Console.WriteLine(errorMessage);
                        errorMessage = null;
                    }

                    Console.WriteLine("Are you done? Do you want to finish the turn? (Yes or No)");
                    isNewTurn = Console.ReadLine().ToUpper();

                    if (isNewTurn == "YES")
                    {
                        isNewTurn = null;
                        gm.NewTurn();
                    }
                }
                else if (option == "TRAIN UNITS" && (nArtilleryFactories > 0 || nBarracks > 0 || nStables > 0) && unitToTrain != null)
                {
                    string buildingToWork = null;
                    switch (unitToTrain)
                    {
                        case "INFANTRY":
                            buildingToWork = "barrack";
                            break;
                        case "CAVALRY":
                            buildingToWork = "stable";
                            break;
                        case "ARTILLERY":
                            buildingToWork = "artillery_factory";
                            break;
                        default:
                            errorMessage = "You need to specify the unity!";
                            break;
                    }
                    
                    if (gm.PlayerTurn.Resources.Coins <= 0)
                    {
                        errorMessage = "You don't have enough coins to train any kind of units";
                    }
                    else if(!gm.PlayerTurn.Resources.GetToWork(numberOfUnitsToProduce, buildingToWork))
                    {
                        errorMessage = "You don't have enough coins to train that unit";
                    }

                    isToTrain = false;

                    if (errorMessage != null)
                    {
                        Console.WriteLine(errorMessage);
                        errorMessage = null;
                    }

                    Console.WriteLine("Are you done? Do you want to finish the turn? (Yes or No)");
                    isNewTurn = Console.ReadLine().ToUpper();

                    if (isNewTurn == "YES")
                    {
                        isNewTurn = null;
                        gm.NewTurn();
                    }
                    
                }
                else if (option == "ADD" && optionalCoordinate == null && addCoordinate.HasValue &&(!field.IsOutOfBorders(addCoordinate.Value)))
                {
                    GameEntity ge = null;

                    if (unit != null)
                    {
                        switch (unit)
                        {
                            case "INFANTRY":
                                if(gm.PlayerTurn.Resources.N_Infantry > 0)
                                    ge = new Infantry(addCoordinate.Value, gm.PlayerTurn.Color);
                                break;
                            case "CAVALRY":
                                if (gm.PlayerTurn.Resources.N_Cavalry> 0)
                                    ge = new Cavalry(addCoordinate.Value, gm.PlayerTurn.Color);
                                break;
                            case "ARTILLERY":
                                if (gm.PlayerTurn.Resources.N_Artillery> 0)
                                    ge = new Artillery(addCoordinate.Value, gm.PlayerTurn.Color);
                                break;
                            default:
                                errorMessage = "You need to specify the unit!";
                                continue;
                        }

                        if (ge != null)
                        {
                            Building building = null;
                            if (ge is Cavalry)
                            {
                                building = gm.PlayerTurn.Resources.GetRandomBuilding<Stable>();
                            }
                            else if (ge is Artillery)
                            {
                                building = gm.PlayerTurn.Resources.GetRandomBuilding<ArtilleryFactory>();
                            }
                            else if (ge is Infantry)
                            {
                                building = gm.PlayerTurn.Resources.GetRandomBuilding<Barrack>();
                            }
                            if (gm.PlayerTurn.Resources.CanPlaceAroundBuilding(building,gm.GetEnemyPlayer()) != null)
                            {
                                //CanPlaceAroundBuilding needs the enemyPlayer to check if the enemy player has the coordinate free!
                                Coordinate? coordinateFree = gm.PlayerTurn.Resources.CanPlaceAroundBuilding(building, gm.GetEnemyPlayer());
                                if (coordinateFree.HasValue)
                                {
                                    ge.Position = coordinateFree.Value;
                                    gm.PlayerTurn.Resources.AddEntity(ge);
                                }
                                else
                                {
                                    errorMessage = "I can't place the unit around the building!";
                                }

                            }
                        }

                        unit = null;

                    }
                    else if (strBuilding != null)
                    {
                        char firstLetter = addCoordinate.Value.Letter;
                        int firstNumber = addCoordinate.Value.Number;
                        List<Coordinate> listCoordinates = new List<Coordinate>();

                        Coordinate secondCoordinate = new Coordinate(++firstLetter, firstNumber);
                        Coordinate thirdCoordinate = new Coordinate(firstLetter, ++firstNumber);
                        Coordinate fourthCoordinate = new Coordinate(--firstLetter, firstNumber);

                        listCoordinates.Add(secondCoordinate);
                        //listCoordinates.Add(thirdCoordinate);
                        //listCoordinates.Add(fourthCoordinate);
                        switch (strBuilding)
                        {
                            case "FARM":
                                ge = new Farm(addCoordinate.Value, listCoordinates, gm.PlayerTurn.Color); 
                                break;
                            case "BARRACK":
                                ge = new Barrack(addCoordinate.Value, listCoordinates, gm.PlayerTurn.Color);
                                break;
                            case "STABLE":
                                ge = new Stable(addCoordinate.Value, listCoordinates, gm.PlayerTurn.Color);
                                break;
                            case "ARTILLERY FACTORY":
                                ge = new ArtilleryFactory(addCoordinate.Value, listCoordinates, gm.PlayerTurn.Color);
                                break;
                            default:
                                errorMessage = "You need to specify the building!";
                                continue;
                        }
                        if (gm.PlayerTurn.Resources.IsCoordinateAvailable(addCoordinate.Value) != null
                            || gm.PlayerTurn.Resources.IsCoordinateAvailable(secondCoordinate) != null)
                        {
                            errorMessage = "There's a unit on that coordinate!";
                        }
                        else if (gm.PlayerTurn == p1 && p2.Resources.IsCoordinateAvailable(addCoordinate.Value) != null
                                                     || p2.Resources.IsCoordinateAvailable(secondCoordinate) != null)
                        {
                            errorMessage = "Enemy collision!";
                        }
                        else if (gm.PlayerTurn == p2 && p1.Resources.IsCoordinateAvailable(addCoordinate.Value) != null
                                                     || p1.Resources.IsCoordinateAvailable(secondCoordinate) != null)
                        {
                            errorMessage = "Enemy collision!";
                        }
                        else
                        {
                            Building b = ge as Building;
                            if (gm.PlayerTurn.Resources.Coins >= b.CostToBuild)
                            {
                                bool hasBuildingClose = gm.PlayerTurn.Resources.HasBuildingClose(b);
                                if (hasBuildingClose)
                                    gm.PlayerTurn.Resources.AddEntity(ge);
                                else
                                    errorMessage = "There's no building around that coordinate!";
                            }
                            else
                            {
                                errorMessage = "You don't have enough coins to build that building!";
                            }
                            
                        }
                        strBuilding = null;
                        
                    }
                    

                    field.Update();

                    if (errorMessage != null)
                    {
                        Console.WriteLine(errorMessage);
                        errorMessage = null;
                    }

                    Console.WriteLine("Are you done? Do you want to finish the turn? (Yes or No)");
                    isNewTurn = Console.ReadLine().ToUpper();

                    if (isNewTurn == "YES")
                    {
                        isNewTurn = null;
                        gm.NewTurn();
                    }
                    
                }

                
                
            } while (option != "EXIT" || !gm.GameFinished);
        }

        public void ShowWinnerUI()
        {
            string exit = "";
            do
            {
                Console.Clear();
                Console.WriteLine("───────────────────────────────");
                Console.WriteLine("The winner is {0}", gm.PlayerTurn.Username);
                Console.WriteLine("Score : {0}", gm.PlayerTurn.Resources.Score);
                Console.WriteLine("───────────────────────────────");
                exit = Console.ReadLine().ToUpper();

            } while (exit != "EXIT");
            
        }

        
    }
}
