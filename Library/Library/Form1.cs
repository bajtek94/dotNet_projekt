using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        List<Book> bookDatabase = new List<Book>();
        List<User> userDatabase = new List<User>();

        public Form1()
        {
            InitializeComponent();
            listBox_books.DisplayMember = "title";
            text_hire_bookid.DisplayMember = "titleAndId";
            text_hire_userid.DisplayMember = "fullNameWithId";
            text_return_bookid.DisplayMember = "titleAndId";
            label_info_book.Text = "";
            label_info_found.Text = "";
            updateAll();
            addBookToDatabase(new Book("Pan Tadeusz", "Adam Mickiewicz"));
            addBookToDatabase(new Book("Boska Komedia", "Dante Alighieri"));
            addBookToDatabase(new Book("Chłopi", "Stanisław Reymont"));
            addBookToDatabase(new Book("Dziady", "Adam Mickiewicz"));
            addBookToDatabase(new Book("Ferdydurke", "Witold Gombrowicz"));
            userDatabase.Add(new User("Jan", "Nowak"));
            addUserToDatabase(new User("Paweł", "Kowalski"));
            addUserToDatabase(new User("Alicja", "Brzoza"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_book_Click(object sender, EventArgs e)
        {
            String title = text_add_book_title.Text;
            String author = text_add_book_author.Text;
            if (title != "" && author != "")
            {
                Book book = new Book(title, author);
                addBookToDatabase(book);
            }
            else
            {
                Console.WriteLine("[WARNING] No data to add.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBookInfo();
        }
        private void updateBookInfo()
        {
            if (listBox_books.SelectedItem != null)
            {
                setLabelForBook(label_info_book, listBox_books);
            }
        }
        private void updateFoundsInfo()
        {
            if (listBox_founds.SelectedItem != null)
            {
                if(listBox_founds.SelectedItem is Book)
                {
                    setLabelForBook(label_info_found, listBox_founds);
                }
                else if (listBox_founds.SelectedItem is User)
                {
                    setLabelForUser(label_info_found, listBox_founds);
                }
            }
        }

        private void setLabelForBook(Label label, ListBox listBox)
        {
            Book selectedBook = (Book)listBox.SelectedItem;
            String status;
            if (selectedBook.isHired)
            {
                status = "Hired";
            }
            else
            {
                status = "To hire";
            }
            label.Text = "Info about selected book: \n" +
                "Id: " + selectedBook.Id.ToString() + "\n" +
                "Title: " + selectedBook.Title + "\n" +
                "Author: " + selectedBook.Author + "\n" +
                "Status: " + status + "\n";
            if (selectedBook.isHired)
            {
                label.Text += "User: " + selectedBook.ActualUser.Name + " " + selectedBook.ActualUser.LastName;
            }
        }
        private void setLabelForUser(Label label, ListBox listBox)
        {
            User selectedUser = (User)listBox.SelectedItem;
            String books = "";
            bool hasHires = false;
            foreach (Book book in bookDatabase)
            {
                if(book.ActualUser == selectedUser)
                {
                    books += book.Title + "(" + book.Id +")" + "\n";
                    hasHires = true;
                }
            }
            if(hasHires == false)
            {
                books = "No hired books.";
            }

            label.Text = "Info about selected user: \n" +
                "Id: " + selectedUser.Id.ToString() + "\n" +
                "Name: " + selectedUser.Name + "\n" +
                "Last name: " + selectedUser.LastName + "\n\n" +
                "Hired books: " + "\n" + books;
        }

        private void updateBooksToHire()
        {
            text_hire_bookid.Items.Clear();
            text_hire_userid.Items.Clear();
            foreach(Book book in bookDatabase)
            {
                if(book.isHired == false)
                {
                    text_hire_bookid.Items.Add(book);
                }
            }
            foreach (User user in userDatabase)
            {
                text_hire_userid.Items.Add(user);
            }
        }
        private void updateBooksToReturn()
        {
            text_return_bookid.Items.Clear();
            foreach (Book book in bookDatabase)
            {
                if (book.isHired == true)
                {
                    text_return_bookid.Items.Add(book);
                }
            }
        }

        private void addBookToDatabase(Book book)
        {
            bookDatabase.Add(book);
            listBox_books.Items.Add(book);
            Console.WriteLine("[INFO] Book has added.");
            updateAll();
        }
        private void addUserToDatabase(User user)
        {
            userDatabase.Add(user);
            Console.WriteLine("[INFO] User has added.");
            updateAll();
        }

        private void btn_hire_Click(object sender, EventArgs e)
        {
            if (text_hire_bookid.Text != "" && text_hire_userid.Text != "")
            {
                Book book = (Book)text_hire_bookid.SelectedItem;
                book.isHired = true;
                book.ActualUser = (User)text_hire_userid.SelectedItem;
                updateAll();
            }
        }


        private void updateAll()
        {
            updateBooksToHire();
            updateBooksToReturn();
            updateBookInfo();
            updateFoundsInfo();
            clearFields();
        }

        private void clearFields()
        {
            text_add_book_title.Text = "";
            text_add_book_author.Text = "";
            text_add_user_name.Text = "";
            text_add_user_lastName.Text = "";
            text_find_book_title.Text = "";
            text_find_book_author.Text = "";
            text_find_user_name.Text = "";
            text_find_user_lastName.Text = "";
            text_hire_bookid.SelectionLength = 0;
            text_hire_bookid.Text = "";
            text_hire_userid.SelectionLength = 0;
            text_hire_userid.Text = "";
            text_return_bookid.SelectionLength = 0;
            text_return_bookid.Text = "";
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            if(text_return_bookid.Text != "")
            {
                Book book = (Book)text_return_bookid.SelectedItem;
                book.isHired = false;
                book.ActualUser = null;
                updateAll();
            }
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            String name = text_add_user_name.Text;
            String lastName = text_add_user_lastName.Text;
            if (name != "" && lastName != "")
            {
                User user = new User(name, lastName);
                addUserToDatabase(user);
            }
            else
            {
                Console.WriteLine("[WARNING] No data to add.");
            }
        }

        private void btn_find_book_Click(object sender, EventArgs e)
        {
            listBox_founds.Items.Clear();
            label_info_found.Text = "";
            listBox_founds.DisplayMember = "title";
            String title = text_find_book_title.Text;
            String author = text_find_book_author.Text;
            if (title != "" || author != "")
            {
                if (author == "")
                {
                    foreach (Book book in bookDatabase)
                    {
                        if(book.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listBox_founds.Items.Add(book);
                        }
                    }
                }
                else if (title == "")
                {
                    foreach (Book book in bookDatabase)
                    {
                        if (book.Author.Equals(author, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listBox_founds.Items.Add(book);
                        }
                    }
                }
                else
                {
                    foreach (Book book in bookDatabase)
                    {
                        if (book.Author.Equals(author, StringComparison.InvariantCultureIgnoreCase) && book.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listBox_founds.Items.Add(book);
                        }
                    }
                }
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void listBox_founds_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFoundsInfo();
        }

        private void btn_find_user_Click(object sender, EventArgs e)
        {
            listBox_founds.Items.Clear();
            label_info_found.Text = "";
            listBox_founds.DisplayMember = "fullNameWithId";
            String name = text_find_user_name.Text;
            String lastName = text_find_user_lastName.Text;
            if (name != "" || lastName != "")
            {
                if (lastName == "")
                {
                    foreach (User user in userDatabase)
                    {
                        if (user.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listBox_founds.Items.Add(user);
                        }
                    }
                }
                else if (name == "")
                {
                    foreach (User user in userDatabase)
                    {
                        if (user.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listBox_founds.Items.Add(user);
                        }
                    }
                }
                else
                {
                    foreach (User user in userDatabase)
                    {
                        if (user.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && user.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listBox_founds.Items.Add(user);
                        }
                    }
                }
            }
        }
    }
}
