using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301
{
    class Program
    {



        static void Main(string[] args)
        {

            MemberCollection membersCollection = new MemberCollection();

            MovieCollection movieCollection = new MovieCollection();

            movieCollection.Insert("Movie 6", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 7", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 2", "A", "D", "G", "A", "1", "2000", 5);
            movieCollection.Insert("Movie 9", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 4", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 5", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 1", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 3", "A", "D", "G", "A", "1", "2000", 1);
            movieCollection.Insert("Movie 8", "A", "D", "G", "A", "1", "2000", 1);

           

            MainMenu(membersCollection, movieCollection);


            Console.ReadLine();

        }

        public static void MainMenu(MemberCollection membersCollection, MovieCollection movieCollection)
        {

            string input;

            Console.WriteLine("Welcome to the Community Library"
            + "\n===========Main Menu==========="
            + "\n 1. Staff Login\n 2. Member Login"
            + "\n 0. Exit"
            + "\n===============================\n"
            + "\n Please make a selection(1-2, or 0 to exit):");



            input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    break;
                case "1":
                    StaffLogin(membersCollection, movieCollection);
                    break;
                case "2":
                    MemberLogin(membersCollection, movieCollection);
                    break;
                default:
                    Console.WriteLine($"An unexpected value ({input})\n");
                    MainMenu(membersCollection, movieCollection);
                    break;
            }
        }


        //
        public static void StaffLogin(MemberCollection membersCollection, MovieCollection movieCollection)
        {
            string inputName;
            string inputPassword;

            string correctUsername = "staff";
            string correctPassword = "today123";

            bool loggedIn = false;

            while (!loggedIn) {

                Console.WriteLine("\n==========Staff Login==========");
                Console.Write("Enter username: ");
                inputName = Console.ReadLine();
                Console.Write("Enter password: ");
                inputPassword = Console.ReadLine();

                if(inputName == correctUsername && inputPassword == correctPassword)
                {
                    Console.WriteLine("\nLogin Successful!");
                    loggedIn = true;
                    StaffMenu(membersCollection, movieCollection);
                    
                }

                else
                {
                    Console.WriteLine("Wrong username or password");
                }

                

            }
        }

        public static void StaffMenu(MemberCollection membersCollection, MovieCollection movieCollection)
        {
            string input;

            Console.WriteLine("\n==========Staff Menu==========="
                + "\n1. Add a new movie DVD"
                + "\n2. Remove a movie DVD"
                + "\n3. Register a new Member"
                + "\n4. Find a registered member's phone number"
                + "\n0. Return to main menu"
                + "\n==============================="
                + "\n Please make a selection (1-4 or 0 to return to main menu)");

            input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    MainMenu(membersCollection, movieCollection);
                    break;
                case "1":

                    string movieTitle;
                    string actorList;
                    string directorList;
                    String[] genreArray = { "Drama", "Adventure", "Family", "Action", "Sci-Fi", "Comedy", "Thriller", "Other" };
                    string genre;
                    String[] classificationArray = { "General (G)", "Parental Guidance (PG)", "Mature (M15+)", "Mature Accompanied (MA15+)" };
                    string classification;
                    string duration;
                    string releaseDate;
                    int numberCopies;

                    Console.Write("Enter the movie title: ");
                    movieTitle = Console.ReadLine();

                    Movie movie = movieCollection.Find(movieTitle);

                    if (movie != null)
                    {
                        Console.Write("Enter the amount of copies you would like to add: ");
                        int amount = Int32.Parse(Console.ReadLine());
                        movie.addAvailable(amount);
                        Console.WriteLine("\nSuccessfully added " + amount + " new copies of " + movie.getTitle());
                    }

                    else
                    {

                        Console.Write("Enter the starring actor(s): ");
                        actorList = Console.ReadLine();
                        Console.Write("Enter the director(s): ");
                        directorList = Console.ReadLine();
                        Console.Write("Select the genre: " +
                            "\n1. Drama" +
                            "\n2. Adventure" +
                            "\n3. Family" +
                            "\n4. Action" +
                            "\n5. Sci-Fi" +
                            "\n6. Comedy" +
                            "\n7. Thriller" +
                            "\n8. Other" +
                            "\nMake selection(1-8): ");

                        genre = genreArray[Int32.Parse(Console.ReadLine())];
                        Console.Write("Select the classification: " +
                            "\n1. General (G)" +
                            "\n2. Parental Guidance (PG)" +
                            "\n3. Mature (M15+)" +
                            "\n4. Mature Accompanied (MA15+)" +
                            "\nMake selection(1-4): ");
                        classification = classificationArray[Int32.Parse(Console.ReadLine())];
                        Console.Write("Enter the duration (minutes): ");
                        duration = Console.ReadLine();
                        Console.Write("Enter the release date (year): ");
                        releaseDate = Console.ReadLine();
                        Console.Write("Enter the number of copies available: ");
                        numberCopies = Int32.Parse(Console.ReadLine());

                        movieCollection.Insert(movieTitle, actorList, directorList, genre, classification, duration, releaseDate, numberCopies);

                        Console.WriteLine("\nSuccessfully added " + movieTitle + " with " + numberCopies + " copies available");
                    }

                    break;
                case "2":
                    
                    break;
                case "3":
                    string firstname;
                    string lastname;
                    string address;
                    string number;
                    string password;

                    Console.Write("Enter member's first name: ");
                    firstname = Console.ReadLine();
                    Console.Write("Enter member's last name: ");
                    lastname = Console.ReadLine();
                    Console.Write("Enter member's address: ");
                    address = Console.ReadLine();
                    Console.Write("Enter member's phone number: ");
                    number = Console.ReadLine();
                    while (true) {
                        Console.Write("Enter member's password(4 digits): ");
                        password = Console.ReadLine();

                        bool success = Int32.TryParse(password, out int result);

                        if(password.Length == 4 && success)
                        {
                            break;
                        }
                        else { Console.WriteLine("Enter a 4 digit password!"); }
                    }

                    membersCollection.registerMember(firstname, lastname, address, number, password);
                    StaffMenu(membersCollection, movieCollection);
                    
                    break;
                case "4":
                    string firstName;
                    string lastName;

                    Console.Write("Enter member's first name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Enter member's last name: ");
                    lastName = Console.ReadLine();
                    membersCollection.getPhoneNumber(firstName, lastName);
                    StaffMenu(membersCollection, movieCollection);
                    break;
                default:
                    Console.WriteLine($"An unexpected value ({input})\n");
                    StaffMenu(membersCollection, movieCollection);
                    break;
            }

            StaffMenu(membersCollection, movieCollection);
        }

        public static void MemberLogin(MemberCollection membersCollection, MovieCollection movieCollection)
        {

            string inputName;
            string inputPassword;

            bool loggedIn = false;

            int count = 0;

            while (!loggedIn)
            {
                Console.Write("\n=========Member Login=========" +
                    "\nUsername:");
                inputName = Console.ReadLine();
                Console.Write("Password:");
                inputPassword = Console.ReadLine();

                foreach (Member member in membersCollection.memberCollection)
                {
                    if(count == membersCollection.memberCount) { break; }
                        

                    if (inputName == member.userName() && inputPassword == member.returnPassword())
                    {
                        Console.WriteLine("Login Successful");
                        loggedIn = true;
                        MemberMenu(membersCollection, movieCollection, member);
                        break;
                    }

                    count++;
                }

                if (!loggedIn)
                {
                    Console.WriteLine("Wrong username or password!");
                    count = 0;
                }

            }

        }

        public static void MemberMenu(MemberCollection membersCollection, MovieCollection movieCollection, Member member)
        {
            Console.WriteLine("\n=========Member Menu=========="
                + "\n1. Display all movies"
                + "\n2. Borrow a movie DVD"
                + "\n3. Return a movie DVD"
                + "\n4. List current borrowed movie DVDs"
                + "\n5. Display top 10 most popular movies"
                + "\n0. Return to main menu"
                + "\n==============================="
                + "\n Please make a selection (1-5 or 0 to return to main menu)");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    MainMenu(membersCollection, movieCollection);
                    break;
                case "1":
                    movieCollection.InOrder(movieCollection.root);
                    Console.WriteLine("\n");
                    break;
                case "2":
                    Console.Write("Enter movie title: ");
                    string borrowTitle = Console.ReadLine();

                    Movie borrowMovie = movieCollection.Find(borrowTitle);
                    if(borrowMovie != null)
                    {   
                        if(borrowMovie.getAvailable() > 0)
                        {
                            member.borrowedMovies.Add(borrowTitle);
                            borrowMovie.addAvailable(-1);
                            borrowMovie.addRented();

                            Console.WriteLine("You borrowed " + borrowTitle);
                        }

                        else
                        {
                            Console.WriteLine("Movie is not available!");
                        }
                    }

                    else { Console.WriteLine("Movie not found!"); }

                    break;
                case "3":

                    bool found = false;

                    Console.Write("Enter movie title: ");
                    string returnTitle = Console.ReadLine();

                    Movie rentedMovie = movieCollection.Find(returnTitle);

                    for (int i = 0; i < member.borrowedMovies.Count; i++)
                    {
                        if (member.borrowedMovies[i].Equals(returnTitle))
                        {
                            member.borrowedMovies.RemoveAt(i);
                            found = true;
                            rentedMovie.addAvailable(1);
                            Console.WriteLine("You returned " + returnTitle);
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Movie not found!");
                    }

                    break;
                case "4":
                    Console.WriteLine("You are currently borrowing: ");
                    foreach(string borrowedMovie in member.borrowedMovies)
                    {
                        Console.WriteLine(borrowedMovie);
                    }


                    break;
                default:
                    Console.WriteLine($"An unexpected value ({input})\n");
                    MemberMenu(membersCollection, movieCollection, member);
                    break;
            }

            MemberMenu(membersCollection, movieCollection, member);

        }

    }

 }

