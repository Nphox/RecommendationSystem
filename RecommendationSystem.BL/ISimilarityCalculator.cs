using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public interface ISimilarityCalculator
    {
        double CalculateSimilarity(Game checkGame, Game templateGame);
        double Percentage(double a, double b);
    }
}
