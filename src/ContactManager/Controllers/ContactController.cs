namespace ContactManager.Controllers
{
    using ContactManager.Models;
    using ContactManager.Services;

    /// <summary>
    /// Controlls actions between Views and Services.
    /// </summary>
    internal class ContactController
    {
        private readonly ConsoleView _console;
        private readonly ContactService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="console">Handles console operations.</param>
        /// <param name="handler">Handles service layer operations.</param>
        internal ContactController(ConsoleView console, ContactService handler)
        {
            this._console = console;
            this._service = handler;
        }

        /// <summary>
        /// Contact Manager Application entry point.
        /// </summary>
        public void Initialize()
        {
            bool isRunning = true;
            string? choice;
            while (isRunning)
            {
                Thread.Sleep(1000); // Delay of 1 second to allow users to read messages before the console is refreshed.
                this._console.ClearConsole();
                this._console.DisplayMenu();
                choice = this._console.GetInput("your choice");

                switch (choice)
                {
                    case "0":
                        this.View();

                        break;

                    case "1":
                        this.Add();
                        break;

                    case "2":
                        this.Edit();
                        break;

                    case "3":
                        this.Delete();
                        break;

                    case "4":
                        this.Search();
                        break;

                    case "5":
                        this.Sort();
                        break;

                    case "6":
                        isRunning = !this.CanExit();
                        break;

                    default:
                        this._console.DisplayErrorMessage("Enter valid inputs only!");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays contacts from the contact list.
        /// </summary>
        public void View()
        {
            IReadOnlyList<Contact> contacts = this._service.GetAll();
            this._console.DisplayContact(contacts);
        }

        /// <summary>
        /// Adds contact to the contact list.
        /// </summary>
        public void Add()
        {
            string name = this._console.GetName();
            string phone = this._console.GetPhoneNumber();
            string email = this._console.GetInput("email");
            string notes = this._console.GetInput("notes");
            var newContact = new Contact(name, phone, email, notes);
            int status = this._service.Add(newContact);

            switch ((Enums.Status)status)
            {
                case Enums.Status.DuplicateExists:
                    this._console.DisplayErrorMessage("Contact already exists!");
                    break;

                case Enums.Status.NullInput:
                    this._console.DisplayErrorMessage("Blank spaces aren't allowed for name! Please enter a valid input!");
                    break;

                case Enums.Status.InvalidPhoneNumber:
                    this._console.DisplayErrorMessage("Invalid phone number!\nPlease enter a valid 10-digit phone number containing only 0-9 digits\n(Format:9876543210)");
                    break;

                case Enums.Status.InvalidEmailId:
                    this._console.DisplayErrorMessage("Invalid email id! Please enter a valid email id  (Format:yourname@example.com)");
                    break;

                default:
                    this._console.DisplaySuccess("Contact added successfully");
                    break;
            }
        }

        /// <summary>
        /// Edits existing contact from the contactl list.
        /// </summary>
        public void Edit()
        {
            if (!this._service.HasContacts())
            {
                this._console.DisplayWarning("The contact list is currently empty!");
                return;
            }

            string name = this._console.GetName();
            string editChoice = this._console.DisplayEditMenu();
            string newValue = string.Empty;
            switch (editChoice)
            {
                case "1":
                    newValue = this._console.GetInput("name");
                    break;
                case "2":
                    newValue = this._console.GetInput("phone number");
                    break;
                case "3":
                    newValue = this._console.GetInput("email");
                    break;
                case "4":
                    newValue = this._console.GetInput("notes");
                    break;
                default:
                    this._console.DisplayErrorMessage("Enter valid inputs only!");
                    return;
            }

            Enums.Status status = this._service.Edit(name, editChoice, newValue);
            if (status == Enums.Status.NotFound)
            {
                this._console.DisplayErrorMessage("Contact not found!");
            }
            else if (status == Enums.Status.InvalidInput)
            {
                this._console.DisplayErrorMessage("Invalid Input! Please enter a valid input");
            }
            else
            {
                this._console.DisplaySuccess("Contact edited sucessfully");
            }
        }

        /// <summary>
        /// Deletes contact from the existing contact list.
        /// </summary>
        public void Delete()
        {
            if (!this._service.HasContacts())
            {
                this._console.DisplayWarning("The contact list is currently empty!");
                return;
            }

            string phone = this._console.GetInput("phone number");
            Enums.Status status = this._service.Delete(phone);
            if (status == Enums.Status.NotFound)
            {
                this._console.DisplayErrorMessage("Contact not found!");
            }
            else
            {
                this._console.DisplaySuccess("Contact deleted successfully");
            }
        }

        /// <summary>
        /// Searches for a contact from the contact list.
        /// </summary>
        public void Search()
        {
            if (!this._service.HasContacts())
            {
                this._console.DisplayWarning("The contact list is currently empty!");
                return;
            }

            string name = this._console.GetName();
            List<Contact>? foundContact = this._service.Search(name);
            if (foundContact != null)
            {
                this._console.DisplayContact(foundContact);
            }
            else
            {
                this._console.DisplayErrorMessage("Contact not found!");
            }
        }

        /// <summary>
        /// Sorts contact list.
        /// </summary>
        public void Sort()
        {
            List<Contact>? contacts = this._service.Sort();

            if (contacts == null)
            {
                this._console.DisplayWarning("No Contacts to display\n");
            }
            else
            {
                this._console.DisplayContact(contacts);
            }
        }

        /// <summary>
        /// Checks whether to exit contact manager application.
        /// </summary>
        /// <returns>True if user confirms exit, else False.</returns>
        public bool CanExit()
        {
            this._console.DisplayExitWarning();
            string exitCh = this._console.ExitConfirmation();
            if (exitCh.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                this._console.DisplayExitConfirmation();
                return true;
            }
            else
            {
                this._console.DisplayErrorMessage("Enter valid inputs only!");
                return false;
            }
        }
    }
}