using Assignment2.Repository;

namespace Assignment2.Services
{
    /// <summary>
    /// Handles Pre-Check (Validation) Before Input Value enters the Repository
    /// </summary>
    public class ShapeService
    {
        private ShapeRepository _repo = new ShapeRepository();

        /// <summary>
        /// Checks and passes the color, salary to the Shape Repository
        /// </summary>
        /// <param name="color"> color of the Rectangle entered by the user </param>
        /// <param name="length"> length of the Rectangle entered by the user </param>
        /// <param name="breadth"> breadth of the Rectangle entered by the user </param
        /// <returns> Details of the Shape If True, else Invalid Error Message </returns>
        public string AddRectangle(string color, int length, int breadth)
        {
            //if(_repo.ValidateColor(color))
            {
                return _repo.AddRectangle(color, length, breadth);
            }
            return "Invalid Input";
        }

        /// <summary>
        /// Checks and passes the color, salary to the Shape Repository
        /// </summary>
        /// <param name="color"> color of the Circle entered by the user </param>
        /// <param name="radius"> radius of the Circle entered by the user </param>
        /// <returns> Details of the Shape If True, else Invalid Error Message </returns>
        public string AddCircle(string color, int radius)
        {
            //if(_repo.ValidateColor(color))
            {
                return _repo.AddCircle(color, radius);
            }
            return "Invalid Input";
        }
    }
}