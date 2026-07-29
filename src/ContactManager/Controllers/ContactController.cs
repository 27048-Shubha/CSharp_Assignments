namespace ContactManager.Controllers
{
    using ContactManager.Models;
    using ContactManager.Services;

    /// <summary>
    /// Controlls actions between Views and Services.
    /// </summary>
    public class ContactController
    {
        /// <summary>
        /// Marks Starting Point of Contact Manager.
        /// </summary>
        /// 
        private readonly ConsoleView _console;
        private readonly ContactService _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="console">Handles console operations</param>
        /// <param name="handler">Handles service layer operations</param>
        internal ContactController(ConsoleView console, ContactService handler)
        {
            _console = console;
            _handler = handler;
        }
        public void Initialize()
        {
        

        string? ch;
        do
        {
            Thread.Sleep(1000);
            _console.ClearConsole();
            _console.DisplayMenu();
            ch = _console.GetChoice();

            switch (ch)
            {
                case "0": // VIEW
                    List<Contact> contact = _handler.GetAllContactInfo();
                    if (contact.Count() != 0)
                    {
                        _console.DisplayContactList(contact);
                    }
                    else
                    {
                        _console.DisplayEmptyListMessage();
                    }

                    break;

                case "1": // ADD
                    string name = _console.GetName();
                    string phone = _console.GetPhoneNumber();
                    string? email = _console.GetEmail();
                    string? notes = _console.GetNotes();
                    Contact newContact = new Contact(name, phone, email, notes);
                    int addStatus = _handler.AddContact(newContact);
                    if (addStatus == -1)
                    {
                        _console.DisplayDuplicateMessage();
                    }
                    else if (addStatus == -2)
                    {
                            _console.DisplayInvalidInput();
                    }
                    else if (addStatus == -3)
                    {
                        _console.DisplayInvalidPhoneMessage();
                    }
                    else if (addStatus == -4)
                    {
                        _console.DisplayInvalidEmailMessage();
                    }
                    else
                    {
                        _console.DisplaySuccess("Contact added successfully");
                    }

                    break;

                case "2": // EDIT
                    name = _console.GetName();
                    string editChoice = _console.DisplayEditMenu();
                    string newValue = string.Empty;
                    switch (editChoice)
                    {
                        case "1":
                            newValue = _console.GetName();
                            break;
                        case "2":
                            newValue = _console.GetPhoneNumber();
                            break;
                        case "3":
                            newValue = _console.GetEmail();
                            break;
                        case "4":
                            newValue = _console.GetNotes();
                            break;
                        default:
                            _console.DisplayDefaultMessage();
                            break;
                    }

                    int editStatus = _handler.EditContact(name, editChoice, newValue);
                    if (editStatus == -1)
                    {
                        _console.DisplayNotFoundMessage();
                    }
                    else if (editStatus == -2)
                    {
                        _console.DisplayInvalidInputMessage();
                    }
                    else
                    {
                        _console.DisplaySuccess("Contact edited sucessfully");
                    }

                    break;

                case "3": // DELETE
                    phone = _console.GetPhoneNumber();
                    int deleteStatus = _handler.DeleteContact(phone);
                    if (deleteStatus == -1)
                    {
                        _console.DisplayNotFoundMessage();
                    }
                    else
                    {
                        _console.DisplaySuccess("Contact deleted successfully");
                    }

                    break;

                case "4": // SEARCH
                    name = _console.GetName();
                    List<Contact>? foundContact = _handler.SearchContact(name);
                    if (foundContact != null)
                    {
                        _console.DisplayContactList(foundContact);
                    }
                    else
                    {
                        _console.DisplayNotFoundMessage();
                    }

                    break;

                case "5": // SORT
                    List<Contact>? contacts = _handler.SortContact();

                    if (contacts == null)
                    {
                        _console.DisplayEmptyListMessage();
                    }
                    else
                    {
                        _console.DisplayContactList(contacts);
                    }

                    break;

                case "6": // EXIT
                    _console.DisplayExitWarning();
                    string exitCh = _console.ExitConfirmation();
                    if (exitCh == "Y" || exitCh == "y")
                    {
                        _console.DisplayExitConfirmation();
                    }
                    else
                    {
                        ch = "7"; // To prevent while loop termination
                        _console.DisplayDefaultMessage();
                    }

                    break;

                default:
                    _console.DisplayDefaultMessage();
                    break;
            }
        }
        while (ch != "6");
        }
    }
}