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
        public void Initialize()
        {
        ConsoleView console = new ConsoleView();
        ContactService handler = new ContactService();
        string? ch;
        do
        {
            Thread.Sleep(1000);
            console.ClearConsole();
            console.DisplayMenu();
            ch = console.GetChoice();

            switch (ch)
            {
                case "0": // VIEW
                    List<Contact> contact = handler.GetAllContactInfo();
                    if (contact.Count() != 0)
                    {
                        console.DisplayContactList(contact);
                    }
                    else
                    {
                        console.DisplayEmptyListMessage();
                    }

                    break;

                case "1": // ADD
                    string name = console.GetName();
                    string phone = console.GetPhone();
                    string? email = console.GetEmail();
                    string? notes = console.GetNotes();
                    Contact newContact = new Contact(name, phone, email, notes);
                    int addStatus = handler.AddContact(newContact);
                    if (addStatus == -1)
                    {
                        console.DisplayDuplicateMessage();
                    }
                    else if (addStatus == -2)
                    {
                            console.DisplayInvalidInput();
                    }
                    else if (addStatus == -3)
                    {
                        console.DisplayInvalidPhoneMessage();
                    }
                    else if (addStatus == -4)
                    {
                        console.DisplayInvalidEmailMessage();
                    }
                    else
                    {
                        console.DisplaySuccess("Contact added successfully");
                    }

                    break;

                case "2": // EDIT
                    name = console.GetName();
                    string editChoice = console.DisplayEditMenu();
                    string newValue = string.Empty;
                    switch (editChoice)
                    {
                        case "1":
                            newValue = console.GetName();
                            break;
                        case "2":
                            newValue = console.GetPhone();
                            break;
                        case "3":
                            newValue = console.GetEmail();
                            break;
                        case "4":
                            newValue = console.GetNotes();
                            break;
                        default:
                            console.DisplayDefaultMessage();
                            break;
                    }

                    int editStatus = handler.EditContact(name, editChoice, newValue);
                    if (editStatus == -1)
                    {
                        console.DisplayNotFoundMessage();
                    }
                    else if (editStatus == -2)
                    {
                        console.DisplayInvalidInputMessage();
                    }
                    else
                    {
                        console.DisplaySuccess("Contact edited sucessfully");
                    }

                    break;

                case "3": // DELETE
                    phone = console.GetPhone();
                    int deleteStatus = handler.DeleteContact(phone);
                    if (deleteStatus == -1)
                    {
                        console.DisplayNotFoundMessage();
                    }
                    else
                    {
                        console.DisplaySuccess("Contact deleted successfully");
                    }

                    break;

                case "4": // SEARCH
                    name = console.GetName();
                    List<Contact>? foundContact = handler.SearchContact(name);
                    if (foundContact != null)
                    {
                        console.DisplayContactList(foundContact);
                    }
                    else
                    {
                        console.DisplayNotFoundMessage();
                    }

                    break;

                case "5": // SORT
                    List<Contact>? contacts = handler.SortContact();

                    if (contacts == null)
                    {
                        console.DisplayEmptyListMessage();
                    }
                    else
                    {
                        console.DisplayContactList(contacts);
                    }

                    break;

                case "6": // EXIT
                    console.DisplayExitWarning();
                    string exitCh = console.ExitConfirmation();
                    if (exitCh == "Y" || exitCh == "y")
                    {
                        console.DisplayExitConfirmation();
                    }
                    else
                    {
                        ch = "7"; // To prevent while loop termination
                        console.DisplayDefaultMessage();
                    }

                    break;

                default:
                    console.DisplayDefaultMessage();
                    break;
            }
        }
        while (ch != "6");
        }
    }
}