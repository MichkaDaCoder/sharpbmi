using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBMI.model
{
    class BodyMassIndex
    {
        #region Class Attributes
        private DateTime DateBmi;
        private double Weight;
        private double Height;
        private double Result;
        private string Evaluation;
        #endregion

        public BodyMassIndex()
        {

        }

        #region Getters
        public DateTime getDateBmi()
        {
            return this.DateBmi;
        }

        public double getWeight()
        {
            return this.Weight;
        }

        public double getHeight()
        {
            return this.Height;
        }

        public double getResult()
        {
            return this.Result;
        }

        public string getEvaluation()
        {
            return this.Evaluation;
        }



        public double getBMI(double HEIGHT, double WEIGHT)
        {
            return WEIGHT / Math.Pow(HEIGHT, 2);
        }

        #endregion

        #region Setters

        public void setDateBmi(DateTime DateBmi)
        {
            this.DateBmi = DateBmi;
        }

        public void setWeight(double Weight)
        {
            this.Weight = Weight;
        }

        public void setHeight(double Height)
        {
            this.Height = Height;
        }

        public void setResult(double Result)
        {
            this.Result = Result;
        }

        public void setEvaluation(string Evaluation)
        {
            this.Evaluation = Evaluation;
        }

        #endregion

        /// <summary>
        /// Evaluate the result according to the bmi calculation.
        /// </summary>
        /// <returns></returns>
        public string evaluate()
        {
            double bmi = getBMI(this.Height, this.Weight);
            string s = "";

            if (bmi <= 16.5)
            {
                s = "Underweight";
            }

            else if (bmi >= 18.5 && bmi <= 25.9)
            {
                s = "Normal";
            }

            else if (bmi >= 25 && bmi <= 29.9)
            {
                s = "Overweight";
            }

            else if (bmi >= 30 && bmi <= 34.9)
            {
                s = "Obese";
            }

            else if (bmi >= 35 && bmi <= 39.9)
            {
                s = "Severly Obese.";
            }

            else if(bmi>=40)
            {
                s = "Morbidly Obese";
            }

            return s;
        }
    }
}
