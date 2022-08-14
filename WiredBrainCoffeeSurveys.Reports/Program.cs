using System;
using System.Collections.Generic;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateTasksReport();
        }

        private static void GenerateTasksReport()
        {
            var tasks = new List<string>();
            // Calulate Values
            double responseRate = Q1Results.NumberResponded / Q1Results.NumberSurveyed;
            //double unansweredCount = Q1Results.NumberSurveyed - Q1Results.NumberResponded;
            double overallScore = (Q1Results.ServiceScore + Q1Results.CoffeeScore + Q1Results.FoodScore + Q1Results.PriceScore) / 4;

            /*Console.WriteLine($"Overall Score: {overallScore}");
            Console.WriteLine($"Response Percentage: {responseRate}");
            Console.WriteLine($"Umaswered Surveys: {unansweredCount}");*/

            //Logical comparison
            /*bool higherCoffeeScore = Q1Results.CoffeeScore > Q1Results.FoodScore;
            bool customersRecommend = Q1Results.WouldRecommend >= 7;
            bool noGranolaYesCappucino = Q1Results.LeastFavoriteProduct == "Granola" && Q1Results.FavoriteProduct == "Cappucino";

            Console.WriteLine($"Coffee Score Higher Than Food: {higherCoffeeScore}");
            Console.WriteLine($"Customers Would Recommend Us: {customersRecommend}");
            Console.WriteLine($"Hate Granola, Love Cappucino: {noGranolaYesCappucino}");*/

            bool isCoffeeScoreLower = Q1Results.CoffeeScore < Q1Results.FoodScore;

            if (isCoffeeScoreLower)
            {
                tasks.Add("Investigate coffee recipes and ingredents.");
            }

            if (overallScore > 8.0)
            {
                tasks.Add("Work with leadership to reward staff");
            }
            else
            {
                tasks.Add("Work with employee for new ideas");
            }

            if (responseRate < .33)
            {
                tasks.Add("Research options to improve response rate.");
            }
            else if (responseRate > .33 && responseRate < .66)
            {
                tasks.Add("Reward participants with free coffee coupon.");
            }
            else
            {
                tasks.Add("Rewards participants with discount coffee coupon");
            }

            switch (Q1Results.AreaToImprove)
            {
                case "RewardsProgram":
                    tasks.Add("revisit the rewards deals");
                    break;

                case "Cleanliness":
                    tasks.Add("Contact the cleaning service");
                    break;

                case "MobileApp":
                    tasks.Add("Contact consulting firm about app.");
                    break;

                default:
                    tasks.Add("Investigate individual comments for ideas.");
                    break;
            }
        }
    }
}
