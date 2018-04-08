using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem.Data
{
    public class Game
    {
        private int ID;
        private String Name;
        private int MaxNumberGamers;
        private int MinNumberGamers;
        private int AvgGameTimeInMinutes;
        private int AgeCategory;
        private int Difficulty;

        public void SetID(int ID)
        {
            this.ID = ID;
        }

        public void SetName(String Name)
        {
            this.Name = Name;
        }

        public void SetMaxNumberGamers(int MaxNumberGamers)
        {
            this.MaxNumberGamers = MaxNumberGamers;
        }

        public void SetMinNumberGamers(int MinNumberGamers)
        {
            this.MinNumberGamers = MinNumberGamers;
        }

        public void SetAvgGameTimeInMinutes(int AvgGameTimeInMinutes)
        {
            this.AvgGameTimeInMinutes = AvgGameTimeInMinutes;
        }

        public void SetAgeCategory(int AgeCategory)
        {
            this.AgeCategory = AgeCategory;
        }

        public void SetDifficulty(int Difficulty)
        {
            this.Difficulty = Difficulty;
        }

        public int GetID()
        {
            return ID;
        }

        public String GetName()
        {
            return Name;
        }

        public int GetMaxNumberGamers()
        {
            return MaxNumberGamers;
        }

        public int GetMinNumberGamers()
        {
            return MinNumberGamers;
        }

        public int GetAvgGameTimeInMinutes()
        {
            return AvgGameTimeInMinutes;
        }

        public int GetAgeCategory()
        {
            return AgeCategory;
        }

        public int GetDifficulty()
        {
            return Difficulty;
        }
    }
}
