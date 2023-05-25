using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//є інтерфейс
interface IComparable<T>
{
    int CompareTo(T other);
}

[Serializable] // є серіалізація
class Publication : IComparable<Publication>
{ //є поля назва, рік і к-сть сторінок, разом з властивостями 
    public string Title { get; set; }
    public int Year { get; set; }
    public int PageAmount { get; set; }
    // і конструктором
    public Publication(string title, int year, int pageAmount)
    {
        Title = title;
        Year = year;
        PageAmount = pageAmount;
    }
    
    public int CompareTo(Publication other)
    {
        return Title.CompareTo(other.Title);
    }
    //прописані методи серіалізації і де- об'єктів
    public static void Serialize(SortedList<int, Publication> publications, string fileName)
    {
        FileStream Sstream = new FileStream("publications.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(Sstream, publications);
        Sstream.Flush();
        Sstream.Close();
    }

    public static SortedList<int,Publication> Deserialize(string fileName)
    {
        FileStream Dstream = new FileStream("publications.dat", FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        return (SortedList<int, Publication>)bf.Deserialize(Dstream);
    }


    //нижче є набагато гнучкіший варіант реалізація серілазіції і де-. Зверху надто жорстке але хай буде 

    //public static void Serialize(List<Publication> publications, string fileName)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    using (FileStream stream = new FileStream(fileName, FileMode.Create))
    //    {
    //        formatter.Serialize(stream, publications);
    //    }
    //}

    //public static List<Publication> Deserialize(string fileName)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    using (FileStream stream = new FileStream(fileName, FileMode.Open)) 
    //    {
    //        return (List<Publication>)formatter.Deserialize(stream);
    //    }
    //}
}