using System;

namespace RecommendationSystem.Data
{
    public class Game : IComparable<Game>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Universe Universe { get; set; }
        public Character Character { get; set; }
        public int MaxNumberGamers { get; set; }
        public int MinNumberGamers { get; set; }
        public int AvgGameTimeInMinutes { get; set; }
        public int AgeCategory { get; set; }
        public int Difficulty { get; set; }
        public int Rating { get; set; }

        public double CoefSimilarity { get; set; }

        public Game() { }

        public Game(int id, string name, int maxNumberGamers, int minNumberGamers, int avgGameTimeInMinutes, int ageCategory, int difficulty, Universe universe, Character character, int rating)
        {
            Id = id;
            Name = name;
            MaxNumberGamers = maxNumberGamers;
            MinNumberGamers = minNumberGamers;
            AvgGameTimeInMinutes = avgGameTimeInMinutes;
            AgeCategory = ageCategory;
            Difficulty = difficulty;
            Universe = universe;
            Character = character;
            Rating = rating;
        }

        public void IncreaseRating(int value)
        {
            Rating += value;
        }

        public int CompareTo(Game other)
        {
            return other.CoefSimilarity.CompareTo(CoefSimilarity);
        }
    }
}
