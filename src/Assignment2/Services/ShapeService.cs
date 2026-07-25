using Assignment2.Repository;
using Assignment2.Validations;
using Assignment2.Views;

namespace Assignment2.Services
{
    /// <summary>
    /// Handles Pre-Check (Validation) Before Input Value enters the Repository
    /// </summary>
    public class ShapeService
    {
        private ShapeRepository _repo = new ShapeRepository();
        private ValidateInput _validate = new ValidateInput();
        public ShapeService(ShapeRepository _repo, ValidateInput _validate)
        {
            this._repo = _repo;
            this._validate = _validate;
        }

        /// <summary>
        /// Checks and passes the color, salary to the Shape Repository
        /// </summary>
        /// <param name="color"> color of the Rectangle entered by the user </param>
        /// <param name="length"> length of the Rectangle entered by the user </param>
        /// <param name="breadth"> breadth of the Rectangle entered by the user </param
        /// <returns> Details of the Shape If True, else Invalid Error Message </returns>
        public string AddRectangle(string color, string lengthStr, string breadthStr)
        {
            if (!_validate.IsString(color))
            {
                return "Invalid Input! No numbers or special characters allowed";
            }

            double length, bredth;
            if ( (!double.TryParse(lengthStr, out length) || (!double.TryParse(breadthStr,out bredth)) ) )
            {
                return "Invalid Input! Length and breadth must be valid numbers!";
            }

            if ((_validate.IsZero(length) || (_validate.IsZero(bredth)))) 
            {
                return "Invalid Input! Length and breadth must be Non Zero";
            }

            if ((_validate.IsNegative(length) || (_validate.IsNegative(bredth))))
            {
                return "Invalid Input! Length and breadth must be Non Negative";
            }

            return _repo.AddRectangle(color, length, bredth);
        }

        /// <summary>
        /// Checks and passes the color, salary to the Shape Repository
        /// </summary>
        /// <param name="color"> color of the Circle entered by the user </param>
        /// <param name="radius"> radius of the Circle entered by the user </param>
        /// <returns> Details of the Shape If True, else Invalid Error Message </returns>
        public string AddCircle(string color, string radiusStr)
        {
            if (!_validate.IsString(color))
            {
                return "Invalid Input! No numbers or special characters allowed";
            }

            double radius;
            if (!double.TryParse(radiusStr, out radius) )
            {
                return "Invalid Input! Radius must be valid number!";
            }

            if ((_validate.IsZero(radius) ))
            {
                return "Invalid Input! Radius must be a Non Zero value";
            }

            if ((_validate.IsNegative(radius)) )
            {
                return "Invalid Input! Radius must be Non Negative";
            }

            return _repo.AddCircle(color, radius);
        }
    }
}