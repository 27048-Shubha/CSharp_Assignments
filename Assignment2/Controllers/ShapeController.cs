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
            string name;
            decimal salary;
            string message;

            switch(choice)
            {
                case 'R':
                case 'r':
                    name = _console.GetShapeColor();
                    message = _service.AddRectangle(name);
                    _console.DisplayMessage(message);

                    break;

                case 'C':
                case 'c':
                    name = _console.GetShapeColor();
                    message = _service.AddCircle(name);
                    _console.DisplayMessage(message);
                    break;

                default:
                    _console.DisplayDefault();
                    break;
            }
        } 
    }
}
