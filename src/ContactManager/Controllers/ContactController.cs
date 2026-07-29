namespace ContactManager.Controllers
{
    using System.Collections.Generic;
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
        private readonly ConsoleView console;
        private readonly ContactService handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="console">Handles console operations.</param>
        /// <param name="handler">Handles service layer operations.</param>
        internal ContactController(ConsoleView console, ContactService handler)
        {
            this.console = console;
            this.handler = handler;
        }

        /// <summary>
        /// Start of execution of Contact Manager Application.
        /// </summary>
        public void Initialize()
        {
        string? ch;
        do
        {
            Thread.Sleep(1000);
            this.console.ClearConsole();
            this.console.DisplayMenu();
            ch = this.console.GetChoice();

            switch (ch)
            {
                case "0": // VIEW
                    IReadOnlyList<Contact> contact = this.handler.GetAll();
                    if (contact.Count() != 0)
                    {
                        this.console.DisplayContact(contact);
                    }
                    else
                    {
                        this.console.DisplayEmptyListMessage();
                    }

                    break;

                case "1": // ADD
                    string name = this.console.GetName();
                    string phone = this.console.GetPhoneNumber();
                    string? email = this.console.GetEmail();
                    string? notes = this.console.GetNotes();
                    Contact newContact = new Contact(name, phone, email, notes);
                    int addStatus = this.handler.Add(newContact);
                    if (addStatus == -1)
                    {
                        this.console.DisplayDuplicateMessage();
                    }
                    else if (addStatus == -2)
                    {
                        this.console.DisplayInvalidInputMessage("Blank spaces aren't allowed for name! Please enter a valid input!");
                    }
                    else if (addStatus == -3)
                    {
                        this.console.DisplayInvalidInputMessage("Invalid phone number!\nPlease enter a valid 10-digit phone number containing only 0-9 digits\n(Format:9876543210)");
                    }
                    else if (addStatus == -4)
                    {
                        this.console.DisplayInvalidInputMessage("Invalid email id! Please enter a valid email id  (Format:yourname@example.com)");
                    }
                    else
                    {
                        this.console.DisplaySuccess("Contact added successfully");
                    }

                    break;

                case "2": // EDIT
                    name = this.console.GetName();
                    string editChoice = this.console.DisplayEditMenu();
                    string newValue = string.Empty;
                    switch (editChoice)
                    {
                        case "1":
                            newValue = this.console.GetName();
                            break;
                        case "2":
                            newValue = this.console.GetPhoneNumber();
                            break;
                        case "3":
                            newValue = this.console.GetEmail();
                            break;
                        case "4":
                            newValue = this.console.GetNotes();
                            break;
                        default:
                            this.console.DisplayDefaultMessage();
                            break;
                    }

                    int editStatus = this.handler.Edit(name, editChoice, newValue);
                    if (editStatus == -1)
                    {
                        this.console.DisplayNotFoundMessage();
                    }
                    else if (editStatus == -2)
                    {
                        this.console.DisplayInvalidInputMessage("Invalid Input! Please enter a valid input");
                    }
                    else
                    {
                        this.console.DisplaySuccess("Contact edited sucessfully");
                    }

                    break;

                case "3": // DELETE
                    phone = this.console.GetPhoneNumber();
                    int deleteStatus = this.handler.Delete(phone);
                    if (deleteStatus == -1)
                    {
                        this.console.DisplayNotFoundMessage();
                    }
                    else
                    {
                        this.console.DisplaySuccess("Contact deleted successfully");
                    }

                    break;

                case "4": // SEARCH
                    name = this.console.GetName();
                    List<Contact>? foundContact = this.handler.Search(name);
                    if (foundContact != null)
                    {
                        this.console.DisplayContact(foundContact);
                    }
                    else
                    {
                        this.console.DisplayNotFoundMessage();
                    }

                    break;

                case "5": // SORT
                    List<Contact>? contacts = this.handler.Sort();

                    if (contacts == null)
                    {
                        this.console.DisplayEmptyListMessage();
                    }
                    else
                    {
                        this.console.DisplayContact(contacts);
                    }

                    break;

                case "6": // EXIT
                    this.console.DisplayExitWarning();
                    string exitCh = this.console.ExitConfirmation();
                    if (exitCh == "Y" || exitCh == "y")
                    {
                        this.console.DisplayExitConfirmation();
                    }
                    else
                    {
                        ch = "7"; // To prevent while loop termination
                        this.console.DisplayDefaultMessage();
                    }

                    break;

                default:
                    this.console.DisplayDefaultMessage();
                    break;
            }
        }
        while (ch != "6");
        }
    }
}