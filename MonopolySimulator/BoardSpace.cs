using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    public struct BoardSpace
    {
        public enum Location
        {
            GO = 0,
            Mediterranean_Ave,
            Chest1,
            Baltic_Ave,
            Income1,
            ReadingRR,
            Oriental_Ave,
            Chance1,
            Vermont_Ave,
            Connecticut_Ave,
            Jail,
            StCharles_Place,
            Electric_Company,
            States_Ave,
            Virginia_Ave,
            PennsylvaniaRR,
            StJames_Place,
            Chest2,
            Tennessee_Ave,
            NY_Ave,
            Free_Parking,
            Kentucky_Ave,
            Chance2,
            Indiana_Ave,
            Illinois_Ave,
            BnORR,
            Atlantic_Ave,
            Ventnor_Ave,
            WaterWorks,
            Marvin_Gardens,
            Police,
            Pacific_Ave,
            NC_Ave,
            Chest3,
            Pennsylvania_Ave,
            Short_LineRR,
            Chance3,
            Park_Place,
            Luxury_Tax,
            Boardwalk
        }

        public Location location;
        public int timesLanded;

        public BoardSpace(Location loc)
        {
            location = loc;
            timesLanded = 0;
        }

        public override string ToString()
        {
            switch(location)
            {
                case Location.GO:
                    return "GO";
                case Location.Mediterranean_Ave:
                    return "Mediterranean Avenue";
                case Location.Chest1:
                    return "Community Chest 1";
                case Location.Chest2:
                    return "Community Chest 2";
                case Location.Chest3:
                    return "Community Chest 3";
                case Location.Chance1:
                    return "Chance 1";
                case Location.Chance2:
                    return "Chance 2";
                case Location.Chance3:
                    return "Chance 3";
                case Location.Baltic_Ave:
                    return "Baltic Avenue";
                case Location.Income1:
                    return "Income Tax 1";
                case Location.ReadingRR:
                    return "Reading Railroad";
                case Location.Oriental_Ave:
                    return "Oriental Avenue";
                case Location.Vermont_Ave:
                    return "Vermont Avenue";
                case Location.Connecticut_Ave:
                    return "Connecticut Avenue";
                case Location.Jail:
                    return "Jail";
                case Location.StCharles_Place:
                    return "St. Charles Place";
                case Location.Electric_Company:
                    return "Electric Company";
                case Location.States_Ave:
                    return "States Avenue";
                case Location.Virginia_Ave:
                    return "Virginia Avenue";
                case Location.PennsylvaniaRR:
                    return "Pennsylvania Railroad";
                case Location.StJames_Place:
                    return "St. James Place";
                case Location.Tennessee_Ave:
                    return "Tennessee Avenue";
                case Location.NY_Ave:
                    return "New York Avenue";
                case Location.Free_Parking:
                    return "Free Parking";
                case Location.Kentucky_Ave:
                    return "Kentucky Avenue";
                case Location.Indiana_Ave:
                    return "Indiana Avenue";
                case Location.Illinois_Ave:
                    return "Illinois Avenue";
                case Location.BnORR:
                    return "B&O Railroad";
                case Location.Atlantic_Ave:
                    return "Atlantic Avenue";
                case Location.Ventnor_Ave:
                    return "Ventnor Avenue";
                case Location.WaterWorks:
                    return "Waterworks";
                case Location.Marvin_Gardens:
                    return "Marvin Gardens";
                case Location.Police:
                    return "Go to Jail";
                case Location.Pacific_Ave:
                    return "Pacific Avenue";
                case Location.NC_Ave:
                    return "North Carolina Avenue";
                case Location.Pennsylvania_Ave:
                    return "Pennsylvania Avenue";
                case Location.Short_LineRR:
                    return "Short Line Railroad";
                case Location.Park_Place:
                    return "Park Place";
                case Location.Luxury_Tax:
                    return "Luxury Tax";
                case Location.Boardwalk:
                    return "Boardwalk";
                default:
                    return "GO";
            }
        }
    }
}
