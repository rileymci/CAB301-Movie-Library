using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301
{
    class Movie
    {
        private string title;
        private string actList;
        private string directorList;
        private string genre;
        private string classification;
        private string duration;
        private string released;

        private int available;
        private int rented;

        public Movie Lchild;
        public Movie Rchild;

        public Movie(string title, string actList, string directorList, string genre, string classification, string duration, string released, int available)
        {
            this.title = title;
            this.actList = actList;
            this.directorList = directorList;
            this.genre = genre;
            this.classification = classification;
            this.duration = duration;
            this.released = released;

            this.available = available;
            rented = 0;
        }

        public string getTitle()
        {
            return title;
        }

        public void DisplayMovie()
        {
            Console.WriteLine("Title: " + title
                + "\nStarring: " + actList
                + "\nDirector: " + directorList
                + "\nGenre: " + genre
                + "\nClassification: " + classification
                + "\nDuration: " + duration
                + "\nRelease Date: " + released
                + "\nCopies Available: " + available
                + "\nTimes rented: " + rented + "\n");
        }


        public void addAvailable(int amount)
        {
            available += amount;
        }

        public void addRented()
        {
            rented += 1;
        }

        public int getAvailable()
        {
            return available;
        }

    }
}
