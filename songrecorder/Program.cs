
using System;
using System.Collections.Generic;

// Song record
public record Song(string Title, string Artist, int DurationSeconds);

// Playlist class
public class Playlist
{
    // Private list
    private List<Song> songs = new List<Song>();

    // Add a song
    public void Add(Song song)
    {
        songs.Add(song);
    }

    // Indexer
    public Song this[int i]
    {
        get { return songs[i]; }
    }

    // Number of songs
    public int Count
    {
        get { return songs.Count; }
    }

    // Calculate total duration
    public int TotalDuration
    {
        get
        {
            int total = 0;

            foreach (Song song in songs)
            {
                total += song.DurationSeconds;
            }

            return total;
        }
    }
}

class Program
{
    static void Main()
    {
        Playlist playlist = new Playlist();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\n MUSIC PLAYLIST");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. View Playlist");
            Console.WriteLine("3. Select Song by Index");
            Console.WriteLine("4. Total Duration");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid option.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Song Title: ");
                    string title = Console.ReadLine()!;

                    Console.Write("Enter Artist: ");
                    string artist = Console.ReadLine()!;

                    Console.Write("Enter Duration (seconds): ");

                    if (!int.TryParse(Console.ReadLine(), out int duration)
                        || duration <= 0)
                    {
                        Console.WriteLine("Invalid duration.");
                        break;
                    }

                    Song song = new Song(title, artist, duration);
                    playlist.Add(song);

                    Console.WriteLine("Song added successfully!");
                    break;

                case 2:
                    Console.WriteLine("\n YOUR PLAYLIST");

                    for (int i = 0; i < playlist.Count; i++)
                    {
                        Console.WriteLine($"{i}. {playlist[i].Title} - {playlist[i].Artist}");
                    }

                    Console.WriteLine($"Total Songs: {playlist.Count}");
                    break;

                case 3:
                    Console.Write("Enter Song Index: ");

                    if (int.TryParse(Console.ReadLine(), out int index)
                        && index >= 0 && index < playlist.Count)
                    {
                        Song selected = playlist[index];

                        Console.WriteLine($"Title: {selected.Title}");
                        Console.WriteLine($"Artist: {selected.Artist}");
                        Console.WriteLine($"Duration: {selected.DurationSeconds} seconds");
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;

                case 4:
                    Console.WriteLine(
                        $"Total Duration: {playlist.TotalDuration} seconds"
                    );
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        // Demonstrate record equality
        Console.WriteLine("\n RECORD EQUALITY TEST");

        Song song1 = new Song("Hello", "Adele", 295);
        Song song2 = new Song("Hello", "Adele", 295);

        Console.WriteLine($"Are songs equal? {song1 == song2}");

        // Demonstrate WITH expression
        Song song3 = song1 with { Title = "Hello Remix" };

        Console.WriteLine($"Original Song: {song1.Title}");
        Console.WriteLine($"Modified Song: {song3.Title}");
    }
}
