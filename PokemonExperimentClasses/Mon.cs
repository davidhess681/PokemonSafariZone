using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonExperimentClasses
{
    class Mon
    {

        // constructor method
        public Mon(Random r)
        {
            // there's probably an easier way to do this with subclasses

            // roll between 1 and 100 and set it to an int
            int rarity = r.Next(1, 100); 

            // set properties of the pokemon based on "rarity"

            // 60% chance of common
            if (rarity <=60)
            {
                // roll again to pick an index number to pull from
                Name = Common()[r.Next(0, 48)];

                // catch rate is constant between rarities
                CatchRate = 80;
            }
            // 25% chance of uncommon
            if (rarity >60 && rarity <= 85)
            {
                Name = Uncommon()[r.Next(0, 53)];
                CatchRate = 40;
            }
            // 13% chance of rare
            if (rarity >85 && rarity <= 98)
            {
                Name = Rare()[r.Next(0, 38)];
                CatchRate = 15;
            }
            // 2% chance of very rare
            if (rarity > 98)
            {
                Name = VRare()[r.Next(0, 8)];
                CatchRate = 5;
            }

            // flee rate is always 15
            FleeRate = 15;
        }

        public void GenerateEncounter()
        {
            // Inform user which pokemon was chosen
            Console.WriteLine("\nA wild {0} appeared!", Name);
            Console.WriteLine("");
            
        }

        public bool ThrowBall()
        {
            // I probably don't need to be creating so many Randoms but I'm paranoid >:[
            Random ball = new Random();

            // if random number is less than catch rate, return true (pokemon is caught)
            if (ball.Next(1,100) <= CatchRate)
            {
                return true;
            }
            else
            {
                // else return false (pokemon is not caught)
                Console.WriteLine("\n{0} broke free!", Name);
                return false;
            }
        }
        public void FeedBerry()
        {
            // increase current pokemon's catch rate by 20
            CatchRate = CatchRate + 20;
            Console.WriteLine("\n{0} is eating the berry!", Name);
        }
        public void Run()
        {
            Console.WriteLine("\nGot away safely!");
        }
        
        // properties we set in the constructor method
        public string Name { get; set; }
        public int CatchRate { get; set; }
        public int FleeRate { get; set; }
        

        // arrays storing the pokemon's names
        private string[] Common()
        {
            string[] list = new string[49];
            list[0] = "Caterpie";
            list[1] = "Metapod";
            list[2] = "Weedle";
            list[3] = "Kakuna";
            list[4] = "Pidgey";
            list[5] = "Pidgeotto";
            list[6] = "Rattata";
            list[7] = "Raticate";
            list[8] = "Spearow";
            list[9] = "Ekans";
            list[10] = "Sandshrew";
            list[11] = "Nidoran F";
            list[12] = "Nidoran M";
            list[13] = "Vulpix";
            list[14] = "Jigglypuff";
            list[15] = "Zubat";
            list[16] = "Oddish";
            list[17] = "Paras";
            list[18] = "Venonat";
            list[19] = "Diglett";
            list[20] = "Meowth";
            list[21] = "Psyduck";
            list[22] = "Mankey";
            list[23] = "Growlithe";
            list[24] = "Poliwag";
            list[25] = "Abra";
            list[26] = "Machop";
            list[27] = "Bellsprout";
            list[28] = "Tentacool";
            list[29] = "Geodude";
            list[30] = "Ponyta";
            list[31] = "Slowpoke";
            list[32] = "Magnemite";
            list[33] = "Doduo";
            list[34] = "Seel";
            list[35] = "Grimer";
            list[36] = "Shellder";
            list[37] = "Gastly";
            list[38] = "Drowzee";
            list[39] = "Krabby";
            list[40] = "Voltorb";
            list[41] = "Exeggcute";
            list[42] = "Cubone";
            list[43] = "Koffing";
            list[44] = "Rhyhorn";
            list[45] = "Horsea";
            list[46] = "Goldeen";
            list[47] = "Staryu";
            list[48] = "Magikarp";
            return list;

        }

        private string[] Uncommon()
        {
            string[] list = new string[54];
            list[0] = "Bulbasaur";
            list[1] = "Charmander";
            list[2] = "Squirtle";
            list[3] = "Butterfree";
            list[4] = "Beedrill";
            list[5] = "Pidgeot";
            list[6] = "Fearow";
            list[7] = "Arbok";
            list[8] = "Pikachu";
            list[9] = "Sandslash";
            list[10] = "Nidorina";
            list[11] = "Nidorino";
            list[12] = "Clefairy";
            list[13] = "Ninetales";
            list[14] = "Wigglytuff";
            list[15] = "Golbat";
            list[16] = "Gloom";
            list[17] = "Parasect";
            list[18] = "Venomoth";
            list[19] = "Dugtrio";
            list[20] = "Persian";
            list[21] = "Golduck";
            list[22] = "Primeape";
            list[23] = "Arcanine";
            list[24] = "Poliwhirl";
            list[25] = "Kadabra";
            list[26] = "Machoke";
            list[27] = "Weepinbell";
            list[28] = "Tentacruel";
            list[29] = "Graveler";
            list[30] = "Rapidash";
            list[31] = "Slowbro";
            list[32] = "Magneton";
            list[33] = "Farfetch'd";
            list[34] = "Dodrio";
            list[35] = "Dewgong";
            list[36] = "Muk";
            list[37] = "Cloyster";
            list[38] = "Haunter";
            list[39] = "Onix";
            list[40] = "Hypno";
            list[41] = "Kingler";
            list[42] = "Electrode";
            list[43] = "Exeggutor";
            list[44] = "Marowak";
            list[45] = "Weezing";
            list[46] = "Seadra";
            list[47] = "Seaking";
            list[48] = "Starmie";
            list[49] = "Eevee";
            list[50] = "Ditto";
            list[51] = "Omanyte";
            list[52] = "Kabuto";
            list[53] = "Dratini";

            return list;
        }

        private string[] Rare()
        {
            string[] list = new string[39];
            list[0] = "Ivysaur";
            list[1] = "Charmeleon";
            list[2] = "Wartortle";
            list[3] = "Raichu";
            list[4] = "Nidoqueen";
            list[5] = "Nidoking";
            list[6] = "Clefable";
            list[7] = "Vileplume";
            list[8] = "Poliwrath";
            list[9] = "Alakazam";
            list[10] = "Machamp";
            list[11] = "Victreebel";
            list[12] = "Golem";
            list[13] = "Gengar";
            list[14] = "Hitmonlee";
            list[15] = "Hitmonchan";
            list[16] = "Lickitung";
            list[17] = "Rhydon";
            list[18] = "Chansey";
            list[19] = "Tangela";
            list[20] = "Kangaskhan";
            list[21] = "Mr. Mime";
            list[22] = "Scyther";
            list[23] = "Jynx";
            list[24] = "Electabuzz";
            list[25] = "Magmar";
            list[26] = "Pinsir";
            list[27] = "Tauros";
            list[28] = "Gyarados";
            list[29] = "Lapras";
            list[30] = "Vaporeon";
            list[31] = "Jolteon";
            list[32] = "Flareon";
            list[33] = "Porygon";
            list[34] = "Omastar";
            list[35] = "Kabutops";
            list[36] = "Aerodactyl";
            list[37] = "Snorlax";
            list[38] = "Dragonair";
            return list;
        }

        private string[] VRare()
        {
            string[] list = new string[9];
            list[0] = "Venusaur";
            list[1] = "Charizard";
            list[2] = "Blastoise";
            list[3] = "Articuno";
            list[4] = "Zapdos";
            list[5] = "Moltres";
            list[6] = "Dragonite";
            list[7] = "Mewtwo";
            list[8] = "Mew";
            return list;
        }

        
    }





    
}
