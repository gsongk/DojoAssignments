using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist FromMtVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine($"The artist {FromMtVernon.ArtistName} from Mt Vernon is {FromMtVernon.Age} years old");

            //Who is the youngest artist in our collection of artists?
            Artist YoungestArtist = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"Youngest Artist: {YoungestArtist.ArtistName}");

            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach (var artist in Williams){
                Console.WriteLine($"Named William Artist: {artist.ArtistName}, {artist.RealName}");
            }
            //Display the names of all groups less than 8 characters in length
            List<Group> groupLength = Groups.Where(group => group.GroupName.Length < 8).ToList();
            foreach (var group in groupLength){
                Console.WriteLine($"Group with less than 8 character Length: {group.GroupName}");
            }

            //Display the 3 oldest artist from Atlanta
            List<Artist> Oldest = Artists.Where(artist => artist.Hometown =="Atlanta")
                    .OrderByDescending(artist => artist.Age)
                    .Take(3)
                    .ToList();
            foreach (var oldest in Oldest){
                Console.WriteLine($"Oldest 3 from Atlanta: {oldest.ArtistName}, Age: {oldest.Age}");
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> NonNY = Artists
                    .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist; })
                    .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                    .Select(artist => artist.Group.GroupName)
                    .Distinct()
                    .ToList();
            foreach (var NNY in NonNY){
                Console.WriteLine($"Group not from NY: {NNY}");
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<string> WTC = Artists
                   .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist; })
                   .Where(artist => artist.Group.GroupName == "Wu-Tang Clan")
                   .Select(artist => artist.ArtistName)
                   .ToList();
            foreach (var name in WTC){
                Console.WriteLine($"WTC members: {name}");
            }
        }
    }
}
