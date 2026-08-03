namespace Assignment2.Controllers
{
    using Assignment2.Services;
    using Assignment2.Views;

    /// <summary>
    /// Controls Shape system's menu service and communicates with console and service.
    /// </summary>
    public class ShapeController
    {
        private ShapeView console;
        private ShapeService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle console operations. </param>
        /// <param name="service"> The object to handle services. </param>
        public ShapeController(ShapeView console, ShapeService service)
        {
            this.console = console;
            this.service = service;
        }

        /// <summary>
        /// Start point of execution of Shape Hierarchy system.
        /// </summary>
        public void Initialize()
        {
            char choice;
            do
            {
                this.console.DisplayShapesMenu();
                choice = this.console.GetUserChoice();
                string color;
                string message;
                switch (choice)
                {
                    case 'R':
                    case 'r':
                        color = this.console.GetShapeColor();
                        string length = this.console.GetLength();
                        string breadth = this.console.GetBreadth();
                        message = this.service.AddRectangle(color, length, breadth);
                        this.console.DisplayMessage(message);
                        break;

                    case 'C':
                    case 'c':
                        color = this.console.GetShapeColor();
                        string radius = this.console.GetRadius();
                        message = this.service.AddCircle(color, radius);
                        this.console.DisplayMessage(message);
                        break;

                    case 'Q':
                    case 'q':
                        this.console.DisplayExitMessage();
                        break;

                    default:
                        this.console.DisplayDefault();
                        break;
                }
            }
            while (choice != 'Q' && choice != 'q');
        }
    }
}