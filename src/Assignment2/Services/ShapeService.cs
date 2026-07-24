using Assignment2.Repository;
using Assignment2.Validations;

namespace Assignment2.Services
{
    /// <summary>
    /// Handles Pre-Check (Validation) Before Input Value enters the Repository
    /// </summary>
    public class ShapeService
    {
        private ShapeRepository _repo = new ShapeRepository();
        private ValidateInput _validate = new ValidateInput();
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

            double length = int.Parse(lengthStr);
            double bredth = int.Parse(breadthStr);
            if (_validate.IsZero(length) && _validate.IsZero(bredth))
            {
                return "Invalid Input! Enter Non-zero numbers only!";
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

            double radius = int.Parse(radiusStr);
            if (_validate.IsZero(radius) && _validate.IsZero(radius))
            {
                return "Invalid Input! Enter Non-zero numbers only!";
            }
            return _repo.AddCircle(color, radius);

            return "Invalid Input! No numbers or special characters allowed";
        }
    }
}