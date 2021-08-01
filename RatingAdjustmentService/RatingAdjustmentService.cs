using System;

namespace RatingAdjustment.Services
{
    /** Service calculating a star rating accounting for the number of reviews
     * 
     */
    public class RatingAdjustmentService
    {
        const double MAX_STARS = 5.0;  // Likert scale
        const double Z = 1.96; // 95% confidence interval

        double _q;
        double _percent_positive;

        /** Percentage of positive reviews
         * 
         * In this case, that means X of 5 ==> percent positive
         * 
         * Returns: [0, 1]
         */
        void SetPercentPositive(double stars)
        {
            // TODO: Implement this!
            _percent_positive = (stars / MAX_STARS);
        }

        /**
         * Calculate "Q" given the formula in the problem statement
         */
        void SetQ(double number_of_ratings)
        {
            // TODO: Implement this!

<<<<<<< HEAD
            double t = Z * (Math.Sqrt(_percent_positive * (1 - _percent_positive) + Math.Sqrt(Z) / 4 * number_of_ratings) / number_of_ratings);
=======
            void setQ(double number_of_ratings);
>>>>>>> 0591a18771e00eb49f7a8f8d43ce779ba47dc622
        }

        /** Adjusted lower bound
         * 
         * Lower bound of the confidence interval around the star rating.
         * 
         * Returns: a double, up to 5
         */
          double t = Z * (Math.Sqrt((_percent_positive * (1 - _percent_positive) + (Z * Z) / 4 * number_of_ratings)) / number_of_ratings);
       
        public double Adjust(double stars, double number_of_ratings) {
<<<<<<< HEAD
            // TODO: Implement this!
=======
>>>>>>> 0591a18771e00eb49f7a8f8d43ce779ba47dc622
            double lowerbound = (_percent_positive + ((Z * Z )/ (2 * number_of_ratings)) - stars) / (1 + ((Z * Z) / number_of_ratings));
            return lowerbound;

        }
    }
}
