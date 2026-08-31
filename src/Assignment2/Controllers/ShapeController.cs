namespace Assignment2.Controllers
{
    using Assignment2.Services;
    using Assignment2.Views;

    /// <summary>
    /// Controls Shape system's menu service and communicates with console and service.
    /// </summary>
    public class ShapeController
    {
        private ShapeView _console;
        private ShapeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle console operations. </param>
        /// <param name="service"> The object to handle services. </param>
        public ShapeController(ShapeView console, ShapeService service)
        {
            this._console = console;
            this._service = service;
        }

        /// <summary>
        /// Start point of execution of Shape Hierarchy system.
        /// </summary>
        public void Initialize()
        {
            char choice;
            while (true)
            {
                this._console.DisplayShapesMenu();
                choice = this._console.GetUserChoice();
                string color;
                string message;
                switch (choice)
                {
                    case 'R':
                    case 'r':
                        color = this._console.GetShapeColor();
                        double length = this._console.GetLength();
                        double breadth = this._console.GetBreadth();
                        message = this._service.AddRectangle(color, length, breadth);
                        this._console.DisplayMessage(message);
                        break;

                    case 'C':
                    case 'c':
                        color = this._console.GetShapeColor();
                        double radius = this._console.GetRadius();
                        message = this._service.AddCircle(color, radius);
                        this._console.DisplayMessage(message);
                        break;

                    case 'B':
                    case 'b':
                        this._console.DisplayExitMessage();
                        return;

                    default:
                        this._console.DisplayDefault();
                        break;
                }
            }
        }
    }
}