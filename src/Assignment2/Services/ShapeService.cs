namespace Assignment2.Services
{
    using Assignment2.Repository;
    using Assignment2.Validations;

    /// <summary>
    /// Handles business logic validation and sends call to repository after validation.
    /// </summary>
    public class ShapeService
    {
        private ShapeRepository repo = new ShapeRepository();
        private ValidateInput validate = new ValidateInput();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeService"/> class.
        /// </summary>
        /// <param name="repo"> The object to handle repository operations. </param>
        /// <param name="validate"> The object to handle validation operations. </param>
        public ShapeService(ShapeRepository repo, ValidateInput validate)
        {
            this.repo = repo;
            this.validate = validate;
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="color"> The color of the rectangle from the user. </param>
        /// <param name="lengthStr"> The length of the rectangle from the user. </param>
        /// <param name="breadthStr"> The breadth of the rectangle from the user. </param
        /// <returns> The details of the shape If True, else invalid error Message. </returns>
        public string AddRectangle(string color, string lengthStr, string breadthStr)
        {
            if (!this.validate.IsString(color))
            {
                return "Invalid Input! No numbers or special characters allowed";
            }

            double length, breadth;
            if (!double.TryParse(lengthStr, out length) || !double.TryParse(breadthStr, out breadth))
            {
                return "Invalid Input! Length and breadth must be valid numbers!";
            }

            if (this.validate.IsZero(length) || this.validate.IsZero(breadth))
            {
                return "Invalid Input! Length and breadth must be Non Zero";
            }

            if (this.validate.IsNegative(length) || this.validate.IsNegative(breadth))
            {
                return "Invalid Input! Length and breadth must be Non Negative";
            }

            return this.repo.AddRectangle(color, length, breadth);
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="color"> The color of the circle from the user. </param>
        /// <param name="radiusStr"> The radius of the circle from the user. </param>
        /// <returns> The details of the shape if True, else invalid error message. </returns>
        public string AddCircle(string color, string radiusStr)
        {
            if (!this.validate.IsString(color))
            {
                return "Invalid Input! No numbers or special characters allowed";
            }

            double radius;
            if (!double.TryParse(radiusStr, out radius))
            {
                return "Invalid Input! Radius must be valid number!";
            }

            if (this.validate.IsZero(radius))
            {
                return "Invalid Input! Radius must be a Non Zero value";
            }

            if (this.validate.IsNegative(radius))
            {
                return "Invalid Input! Radius must be Non Negative";
            }

            return this.repo.AddCircle(color, radius);
        }
    }
}