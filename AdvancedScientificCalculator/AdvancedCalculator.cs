using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScientificCalculator
{
    internal class AdvancedCalculator
    {
        public double Sin(double x) => Math.Sin(x);
        public double Cos(double x) => Math.Cos(x);
        public double Tan(double x) => Math.Tan(x);
        public double Log(double x) => Math.Log10(x);
        public double Ln(double x) => Math.Log(x);
        public double Exp(double x) => Math.Exp(x);
        public double Power(double x, double y) => Math.Pow(x, y);
        public Complex AddComplex(Complex a, Complex b) => a + b;
        public Complex SubtractComplex(Complex a, Complex b) => a - b;
        public Complex MultiplyComplex(Complex a, Complex b) => a * b;
        public Complex DivideComplex(Complex a, Complex b) => a / b;
        public double Mean(double[] values) => values.Length == 0 ? 0 : values.Average();
        public double Median(double[] values)
        {
            if (values.Length == 0) return 0;
            Array.Sort(values);
            int middleIndex = values.Length / 2;
            return (values.Length % 2 == 0) ? (values[middleIndex - 1] + values[middleIndex]) / 2.0 : values[middleIndex];
        }
        public double StandardDeviation(double[] values)
        {
            if (values.Length == 0) return 0;
            double mean = Mean(values);
            double sumOfSquares = values.Select(val => (val - mean) * (val - mean)).Sum();
            return Math.Sqrt(sumOfSquares / values.Length);
        }
    }
}
