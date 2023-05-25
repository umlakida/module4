using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {   //використаний SortedList
        SortedList<int, Publication> publications = new SortedList<int, Publication>
        {
            { 1, new Publication("Flowers1", 2021, 300) },
            { 2, new Publication("Book1", 2020, 250) },
            { 3, new Publication("Book2", 2022, 50) },
            { 4, new Publication("Flowers2", 2020, 250) }
        };
        //додаємо
        publications.Add(5, new Publication("Flowers3", 2023, 200));

        Console.WriteLine("\n\tSorted:");
        foreach (KeyValuePair<int, Publication> publication in publications)
        {
            Console.WriteLine("Title: {0}, Year: {1}, Pages: {2}", publication.Value.Title, publication.Value.Year, publication.Value.PageAmount);
        }
        //видаляємо
        publications.Remove(4);
        //серіалізація
        Publication.Serialize(publications, "publications.dat");

        SortedList<int, Publication> deserializedPublications = Publication.Deserialize("publications.dat");
        Console.WriteLine("\n\tDeserialized:");
        //десеріалізація всіх об'єктів в окремому класі 
        foreach (KeyValuePair<int, Publication> publication in deserializedPublications)
        {
            Console.WriteLine("Title: {0}, Year: {1}, Pages: {2}", publication.Value.Title, publication.Value.Year, publication.Value.PageAmount);
        }
    }
}