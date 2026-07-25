using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Controls Menu service and communicates with Console and Service
    /// </summary>
    public class ShapeController
    {
        private ShapeView _console;
        private ShapeService _service;

        public ShapeController(ShapeView _console, ShapeService _service)
        {
            this._console = _console;
            this._service = _service;
        }


        /// <summary>
        /// Execution of Shape starts here
        /// </summary>
        public void Initialize()
        {
            char choice;
            do
            {
                _console.DisplayShapesMenu();
                choice = _console.GetShapeMenuInput();
                decimal salary;
                string color;
                string message;
                switch (choice)
                {
                    case 'R':
                    case 'r':
                        color = _console.GetShapeColor();
                        string length = _console.GetLength();
                        string breadth = _console.GetBreadth();
                        message = _service.AddRectangle(color, length, breadth);
                        _console.DisplayMessage(message);
                        break;

                    case 'C':
                    case 'c':
                        color = _console.GetShapeColor();
                        string radius = _console.GetRadius();
                        message = _service.AddCircle(color, radius);
                        _console.DisplayMessage(message);
                        break;


                    case 'Q':
                    case 'q':
                        _console.DisplayExitMessage();
                        break;

                    default:
                        _console.DisplayDefault();
                        break;
                }
            } while (choice != 'Q' && choice != 'q');
        }
    }
}