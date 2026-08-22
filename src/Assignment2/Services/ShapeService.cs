namespace Assignment2.Services
{
    using Assignment2.Repository;
    using Assignment2.Validators;

    /// <summary>
    /// Handles business logic validation and sends call to repository after validation.
    /// </summary>
    public class ShapeService
    {
        private readonly ShapeRepository _repo = new ShapeRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeService"/> class.
        /// </summary>
        /// <param name="repo"> The object to handle repository operations. </param>
        public ShapeService(ShapeRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="color"> The color of the rectangle from the user. </param>
        /// <param name="length"> The length of the rectangle from the user. </param>
        /// <param name="breadth"> The breadth of the rectangle from the user. </param
        /// <returns> The details of the shape If True, else invalid error Message. </returns>
        public string AddRectangle(string color, double length, double breadth)
        {
            if (InputValidator.IsZero(length) || InputValidator.IsZero(breadth))
            {
                return "Invalid input! Length and breadth must be Non Zero";
            }

            if (InputValidator.IsNegative(length) || InputValidator.IsNegative(breadth))
            {
                return "Invalid input! Length and breadth must be Non Negative";
            }

            return this._repo.AddRectangle(color, length, breadth);
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="color"> The color of the circle from the user. </param>
        /// <param name="radius"> The radius of the circle from the user. </param>
        /// <returns> The details of the shape if True, else invalid error message. </returns>
        public string AddCircle(string color, double radius)
        {
            if (!InputValidator.IsString(color))
            {
                return "Invalid input for color! No numbers or special characters allowed";
            }

            if (InputValidator.IsZero(radius))
            {
                return "Invalid input! Radius must be a non zero value";
            }

            if (InputValidator.IsNegative(radius))
            {
                return "Invalid input! Radius must be non negative";
            }

            return this._repo.AddCircle(color, radius);
        }
    }
}