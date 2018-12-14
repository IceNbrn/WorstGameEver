using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class ResourcesManager
    {
        //Each player starts with 40 coins to build their first farm
        private int coins = 40;
        private int n_Moves;
        private int n_Infantry;
        private int n_Cavalry;
        private int n_Artillery;

        private List<GameEntity> entities;

        public ResourcesManager()
        {
            entities = new List<GameEntity>();
        }

        public bool HasAnyKindOfUnit()
        {
            if (n_Cavalry > 0 || n_Artillery > 0 || n_Infantry > 0)
                return true;
            return false;
        }

        public bool GetToWork(int xUnits = 0,string type = "farm")
        {
            bool canWork = true;
            foreach (GameEntity entity in entities)
            {
                if (type == "farm" && entity is Farm)
                {
                    coins += (entity as Farm).Work();
                }
                else if (type == "barrack" && entity is Barrack)
                {
                    Barrack barrack = (entity as Barrack);
                    if (barrack.Work(xUnits) <= coins)
                    {
                        if (xUnits <= barrack.Capacity)
                        {
                            barrack.Capacity -= xUnits;
                            n_Infantry += xUnits;
                            coins -= barrack.Work(xUnits);
                            canWork = true;
                        }
                        else
                        {
                            canWork = false;
                        }
                    }
                    else
                    {
                        canWork = false;
                    }
                }
                else if (type == "stable" && entity is Stable)
                {
                    Stable stable = (entity as Stable);
                    if (stable.Work(xUnits) <= coins)
                    {
                        n_Cavalry += xUnits;
                        coins -= stable.Work(xUnits);
                        canWork = true;
                    }
                    else
                    {
                        canWork = false;
                    }
                }
                else if (type == "artillery_factory" && entity is ArtilleryFactory)
                {
                    ArtilleryFactory artilleryFactory = (entity as ArtilleryFactory);
                    if (artilleryFactory.Work(xUnits) <= coins)
                    {
                        n_Artillery += xUnits;
                        coins -= artilleryFactory.Work(xUnits);
                        canWork = true;
                    }
                    else
                    {
                        canWork = false;
                    }
                }
            }

            return canWork;
        }

        public bool AddEntity(GameEntity ge)
        {
            if (IsCoordinateAvailable(ge.Position) == null)
            {
                entities.Add(ge);
                n_Moves = entities.Count;
                if (ge is Building)
                {
                    coins -= (ge as Building).CostToBuild;
                }
                else if (ge is Cavalry)
                    n_Cavalry--;
                else if (ge is Artillery)
                    n_Artillery--;
                else if (ge is Infantry)
                    n_Infantry--;
                return true;
            }

            return false;

        }

        public bool RemoveEntity(GameEntity ge)
        {
            if (entities.Contains(ge))
            {
                entities.Remove(ge);
                n_Moves = entities.Count;
                if (ge is Cavalry)
                    n_Cavalry--;
                else if (ge is Artillery)
                    n_Artillery--;
                else if (ge is Infantry)
                    n_Infantry--;
                return true;
            }

            return false;
        }

        public bool MoveEntity(GameEntity ge, Coordinate moveCoordinate)
        {
            if (RemoveEntity(ge))
            {
                ge.Position = moveCoordinate;
                AddEntity(ge);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Coordinate? CanPlaceAroundBuilding(Building building, Player enemyPlayer)
        {

            int radius = 2;

            char firstLetter = building.Position.Letter;
            int firstNumber = building.Position.Number;

            char lastLetter = building.OptinalCoordinates.Last().Letter;
            int lastNumber = building.OptinalCoordinates.Last().Number;

            for (int i = firstLetter - radius; i < lastLetter + radius; i++)
            {
                for (int j = firstNumber - radius; j < lastNumber + radius; j++)
                {
                    Coordinate coordinate = new Coordinate((char)i,j);
                    if ((coordinate.Letter >= 'A' && coordinate.Letter <= 'Z') && (coordinate.Number >= 0 && coordinate.Number <= 16) && building.Distance(coordinate) <= radius)
                    {
                        //The coordinate is only free if the player has the coordinate free and if the enemy has it free too!
                        if(IsCoordinateAvailable(coordinate) == null && enemyPlayer.Resources.IsCoordinateAvailable(coordinate) == null)
                            return coordinate;
                    }
                }
            }
            
            return null;
        }
        //TODO: This should be removed!
        public GameEntity GetGameEntity(Coordinate coordinate)
        {
            foreach (GameEntity ge in entities)
            {
                if (ge.Position.GetLetter() == coordinate.GetLetter() && ge.Position.GetNumber() == coordinate.GetNumber())
                    return ge;
                    
            }
            return null;
        }

        public GameEntity IsCoordinateAvailable(Coordinate coordinate)
        {
            foreach (var entity in entities)
            {
                if (entity.Position.Equals(coordinate) || ((entity is Building) && ((entity as Building).HasCoordinate(coordinate) != null )))
                {
                    return entity;
                }
            }

            return null;
        }

        public Building GetRandomBuilding<Type>()
        {
            List<Type> list = entities.OfType<Type>().ToList();
            
            Random rnd = new Random();
            int rndNumber = rnd.Next(0, list.Count);
            
            return list[rndNumber] as Building;
        }

        public int CountStables()
        {
            int count = 0;
            foreach (var entity in entities)
            {
                if (entity is Stable)
                    count++;
            }

            return count;
        }

        public int CountArtilleryFactories()
        {
            int count = 0;
            foreach (var entity in entities)
            {
                if (entity is ArtilleryFactory)
                    count++;
            }

            return count;
        }

        public int CountBarracks()
        {
            int count = 0;
            foreach (var entity in entities)
            {
                if (entity is Barrack)
                    count++;
            }

            return count;
        }

        public int N_Moves
        {
            get { return n_Moves; }
            set { n_Moves = value; }
        }

        public int N_Cavalry
        {
            get { return n_Cavalry; }
            set { n_Cavalry = value; }
        }

        public int N_Infantry
        {
            get { return n_Infantry; }
            set { n_Infantry = value; }
        }

        public int N_Artillery
        {
            get { return n_Artillery; }
            set { n_Artillery = value; }
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }

        public bool HasBuildingClose(Building building)
        {
            int radius = 2;

            char firstLetter = building.Position.Letter;
            int firstNumber = building.Position.Number;

            char lastLetter = building.OptinalCoordinates.Last().Letter;
            int lastNumber = building.OptinalCoordinates.Last().Number;

            for (int i = firstLetter - radius; i < lastLetter + radius; i++)
            {
                for (int j = firstNumber - radius; j < lastNumber + radius; j++)
                {
                    Coordinate coordinate = new Coordinate((char)i, j);
                    if ((coordinate.Letter >= 'A' && coordinate.Letter <= 'Z') && (coordinate.Number >= 0 && coordinate.Number <= 16) && building.Distance(coordinate) <= radius)
                    {
                        //The coordinate is only free if the player has the coordinate free and if the enemy has it free too!
                        if (IsCoordinateAvailable(coordinate) != null && IsCoordinateAvailable(coordinate) is Building)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
