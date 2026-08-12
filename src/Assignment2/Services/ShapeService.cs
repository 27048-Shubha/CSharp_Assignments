namespace Assignment2.Services
{
    using Assignment2.Repository;
    using Assignment2.Validations;

    /// <summary>
    /// Handles business logic validation and sends call to repository after validation.
    /// </summary>
    public class ShapeService
    {
        private ShapeRepository _repo = new ShapeRepository();
        private InputValidation _validate = new InputValidation();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeService"/> class.
        /// </summary>
        /// <param name="repo"> The object to handle repository operations. </param>
        /// <param name="validate"> The object to handle validation operations. </param>
        public ShapeService(ShapeRepository repo, InputValidation validate)
        {
            this._repo = repo;
            this._validate = validate;
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
            if (!this._validate.IsString(color))
            {
                return "Invalid input for color! No numbers or special characters allowed";
            }

            double length, breadth;
            if (!double.TryParse(lengthStr, out length) || !double.TryParse(breadthStr, out breadth))
            {
                return "Invalid input! Length and breadth must be valid numbers!";
            }

            if (this._validate.IsZero(length) || this._validate.IsZero(breadth))
            {
                return "Invalid input! Length and breadth must be Non Zero";
            }

            if (this._validate.IsNegative(length) || this._validate.IsNegative(breadth))
            {
                return "Invalid input! Length and breadth must be Non Negative";
            }

            return this._repo.AddRectangle(color, length, breadth);
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="color"> The color of the circle from the user. </param>
        /// <param name="radiusStr"> The radius of the circle from the user. </param>
        /// <returns> The details of the shape if True, else invalid error message. </returns>
        public string AddCircle(string color, string radiusStr)
        {
            if (!this._validate.IsString(color))
            {
                return "Invalid input for color! No numbers or special characters allowed";
            }

            double radius;
            if (!double.TryParse(radiusStr, out radius))
            {
                return "Invalid input! Radius must be valid number!";
            }

            if (this._validate.IsZero(radius))
            {
                return "Invalid input! Radius must be a Non Zero value";
            }

            if (this._validate.IsNegative(radius))
            {
                return "Invalid input! Radius must be Non Negative";
            }

            return this._repo.AddCircle(color, radius);
        }
    }
}