using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace userClass;

class User {
    public string Username;
    public string Role;
    public string Password;


    public User(string username, string role,  string password) {
        Username = username;
        Role = "user";
        Password = password;
    }

    public static List<User> UserList = new List<User>
        {
            new User("KingArthur", "admin", "SwordOfLegend42"),
            new User("MerlinTheWise", "admin", "MysticW1zard!79"),
            new User("VIPStar", "vip", "ShinyGalaxy101"),
            new User("GoldenWolf", "vip", "LunarHowl2023"),
            new User("RoyalFalcon", "vip", "SkyKing07"),
            new User("CrystalQueen", "vip", "GemEmpress88"),
            new User("ThunderLord", "vip", "StormBreaker65"),
            new User("SilverArrow", "vip", "SharpShooter33"),
            new User("EmeraldKnight", "vip", "GreenGuardian52"),
            new User("PlatinumTiger", "vip", "RoaringPride99"),
            new User("RubyWarrior", "vip", "CrimsonBlade18"),
            new User("SapphireMage", "vip", "BlueSorcery45"),
            new User("JerrySumChot", "vip", "IL0veJerbaMate5"),
            new User("JohnDoe", "user", "HiddenTrail16"),
            new User("JaneSmith", "user", "SilentShadow88"),
            new User("HappyCamper", "user", "ForestSmile23"),
            new User("CoolDude", "user", "IceBreaker14"),
            new User("ChocoLover", "user", "SweetBite92"),
            new User("NateHiggers25", "admin", "lukaszek28"),
            new User("PixelArt", "user", "DigitalBrush03"),
            new User("CyberPunk", "user", "NeonDream67"),
            new User("GamerGirl", "user", "LevelUp!42"),
            new User("BookWorm", "user", "PageTurner07"),
            new User("TravelBug", "user", "GlobeTrotter56"),
            new User("SkyWatcher", "user", "StarGazer19"),
            new User("NatureLover", "user", "WildBloom31"),
            new User("CoffeeAddict", "user", "CaffeinatedMind84"),
            new User("MusicFan", "user", "MelodyLover65"),
            new User("MovieBuff", "user", "ReelFanatic02"),
            new User("Foodie", "user", "FlavorQuest74"),
            new User("PetLover", "user", "PawPrints21"),
            new User("FitnessGuru", "user", "IronMind99"),
            new User("TechGeek", "user", "BinaryCode81"),
            new User("CarEnthusiast", "user", "RoadsterFan12"),
            new User("SpaceFan", "user", "CosmicVoyager11"),
            new User("OceanExplorer", "user", "AquaDiver38"),
            new User("HistoryBuff", "user", "TimeTraveler54"),
            new User("ArtLover", "user", "CanvasDreamer87"),
            new User("ScienceNerd", "user", "AtomCrafter49"),
            new User("Fashionista", "user", "StyleIcon77"),
            new User("AdventureSeeker", "user", "ThrillHunter13"),
            new User("ChefMaster", "user", "SpiceArtisan72"),
            new User("DIYCrafter", "user", "CraftyHands95"),
            new User("GardenGuru", "user", "BloomingSoul26"),
            new User("BeachLover", "user", "SandyToes39"),
            new User("FitnessFan", "user", "PeakPusher44"),
            new User("RetroGamer", "user", "PixelKnight68"),
            new User("CryptoFan", "user", "ChainExplorer23"),
            new User("YogaLover", "user", "ZenSeeker15"),
            new User("CatLady", "user", "WhiskerDream94"),
            new User("DogGuy", "user", "PupPal47"),
            new User("WineConnoisseur", "user", "VineTaster82"),
            new User("ChessMaster", "user", "KingCapture17"),
            new User("Programmer", "user", "CodeWizard34"),
            new User("SpeedRunner", "user", "QuickDash58"),
            new User("BirdWatcher", "user", "FeatherGaze03"),
            new User("PlantParent", "user", "LeafTender29"),
            new User("MountainClimber", "user", "SummitDreamer61"),
            new User("SneakerHead", "user", "SoleCollector14"),
            new User("AnimeFan", "user", "OtakuVibes97"),
            new User("ComicBook", "user", "HeroFan84"),
            new User("MagicTrick", "user", "Illusionist42"),
            new User("Puzzler", "user", "MindTwister24"),
            new User("Hiker", "user", "TrailBlazer19"),
            new User("FoodCritic", "user", "GourmetStar63"),
            new User("AstronomyFan", "user", "CelestialMind88"),
            new User("PotterHead", "user", "MagicWand73"),
            new User("ClassicCar", "user", "RetroRide46"),
            new User("VinylFan", "user", "GrooveSpin31"),
            new User("NaturePhotog", "user", "WildFrame57"),
            new User("Marathoner", "user", "TrailRunner28"),
            new User("BoardGamer", "user", "DiceMaster79"),
            new User("LanguageLover", "user", "WordWeaver20"),
            new User("JigsawFan", "user", "PuzzleCrafter95"),
            new User("FossilHunter", "user", "BoneCollector53"),
            new User("AquariumFan", "user", "CoralReef06"),
            new User("LegoBuilder", "user", "BrickArchitect41"),
            new User("HaikuWriter", "user", "PoeticSoul11"),
            new User("WhiskeyFan", "user", "BarrelAged76"),
            new User("TeaLover", "user", "BrewMaster04"),
            new User("RetroCollector", "user", "MemoryVault98"),
            new User("PodcastFan", "user", "Earworm18"),
            new User("MindfulGuru", "user", "InnerPeace69"),
            new User("CodeWizard", "user", "DebugMaster83"),
            new User("HomeChef", "user", "KitchenWhiz59"),
            new User("KaraokeStar", "user", "VocalChamp12"),
            new User("Biker", "user", "WheelSpin71"),
            new User("GymRat", "user", "IronPusher38"),
            new User("FishingFan", "user", "ReelMaster64"),
            new User("Cinephile", "user", "SceneStealer85"),
            new User("ModelMaker", "user", "ScaleArtist16"),
            new User("BeachWalker", "user", "WaveCatcher47"),
            new User("Woodworker", "user", "CarveKing99"),
            new User("CraftBeerFan", "user", "Hopster75"),
            new User("HorrorFan", "user", "DarkChills14"),
            new User("Knitter", "user", "YarnSpinner50"),
            new User("PianoPlayer", "user", "KeyMaster09"),
            new User("SoccerFan", "user", "GoalieDream66"),
            new User("VolleyballFan", "user", "SpikeMaster22"),
            new User("SkiLover", "user", "SnowGlider30"),
            new User("Snowboarder", "user", "PowderRush80"),
            new User("ChefBaker", "user", "DoughCrafter43")
            };
    

    public static User SignIn() {
        
        User? realUser;
        do {
            Console.WriteLine("Enter Username:");
            string? userLogin = Console.ReadLine();
            realUser = UserList.Find(user => user.Username == userLogin);

            if(realUser == null) {
                Console.WriteLine("username does not exist");
            }
                
        } while(realUser == null);

        string? userPassword = "";
        do {
            Console.WriteLine("Enter Password:");
            userPassword = Console.ReadLine();
            if (userPassword != realUser.Password) {
                Console.WriteLine("Invalid password");
                userPassword = "";
            }
        } while(userPassword == null || userPassword == "");

        Console.WriteLine("Successfully logged in");
        return realUser;
    }


}