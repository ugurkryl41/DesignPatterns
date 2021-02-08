using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 3, 30)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 0)));
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);

            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }

    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
}
