using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Controls Menu service and communicates with Console and Service
    /// </summary>
    public class ShapeController
    {
        private ShapeView _console = new ShapeView();
        private ShapeService _service = new ShapeService();

        /// <summary>
        /// Execution of Shape starts here
        /// </summary>
        public void Initialize()
        {
            _console.DisplayShapesMenu();
            char choice = _console.GetShapeMenuInput();
            decimal salary;
            string color;
            string message;
            switch (choice)
            {
                case 'R':
                case 'r':
                    color = _console.GetShapeColor();
                    int length = _console.GetLength();
                    int breadth = _console.GetBreadth();
                    message = _service.AddRectangle(color, length, breadth);
                    _console.DisplayMessage(message);
                    break;

                case 'C':
                case 'c':
                    color = _console.GetShapeColor();
                    int radius = _console.GetRadius();
                    message = _service.AddCircle(color, radius);
                    _console.DisplayMessage(message);
                    break;

                default:
                    _console.DisplayDefault();
                    break;
            }
        }
    }
}