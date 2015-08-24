using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex03
{
    public class Vector
    {
        public double? R = null;
        public double? Theta = null;
        public double? ThetaRadiance
        {
            get { return (Theta * Math.PI / 180.0); }
        }

        public Vector(double? r, double? theta)
        {
            // Нормализация. 
            if (r < 0) 
            { 
                r = -r; 
                theta += 180; 
            } 
            theta = theta % 360; 
            // Установка полей. 
            R = r; 
            Theta = theta; 
        }

        public static Vector operator +(Vector op1, Vector op2)
        {
            try
            {
                // Получение координат (х, у) для нового вектора. 
                double newX = op1.R.Value * Math.Sin(op1.ThetaRadiance.Value)
                + op2.R.Value * Math.Sin(op2.ThetaRadiance.Value);
                double newY = op1.R.Value * Math.Cos(op1.ThetaRadiance.Value)
                + op2.R.Value * Math.Cos(op2.ThetaRadiance.Value);
                // Выполнение преобразования в (г, theta). 
                double newR = Math.Sqrt(newX * newX + newY * newY);
                double newTheta = Math.Atan2(newX, newY) * 180.0 / Math.PI;
                // Возврат результата. 
                return new Vector(newR, newTheta);
            }
            catch
            {
                // Возврат "нулевого" вектора. 
                return new Vector(null, null);
            }
        }

        public static Vector operator -(Vector opl)
        {
            return new Vector(-opl.R, opl.Theta);
        }

        public static Vector operator -(Vector opl, Vector op2)
        {
            return opl + (-op2);
        }

        public override string ToString()
        {
            string rString = R.HasValue ? R.ToString() : "null";
            string thetaString = Theta.HasValue ? Theta.ToString() : "null";
            return string.Format("({0}, {1})", rString, thetaString);
        }
    }
}
