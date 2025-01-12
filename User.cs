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
            new User("JerrySumchot", "vip", "IL0veJerbaMate5"),
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
            new User("PetLover", "user", "PawPrints21")
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