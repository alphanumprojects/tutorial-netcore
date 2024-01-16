using System;
using System.IO;

class Program
{
    static void Main()
    {
        string folderPath = @"D:\Works\internal\alpha-projects\temp-file"; // Ganti dengan path folder Anda

        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = folderPath;
        watcher.NotifyFilter = NotifyFilters.FileName;

        watcher.Created += OnCreated;

        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Memantau folder. Tekan 'q' untuk keluar.");
        while (Console.ReadKey().Key != ConsoleKey.Q) { }

        watcher.EnableRaisingEvents = false;
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        try
        {
            Console.WriteLine($"File baru terdeteksi: {e.Name}");

            // Lakukan pembacaan atau proses yang diperlukan pada file baru di sini
            // Contoh: Baca isi file
            string content = File.ReadAllText(e.FullPath);
            Console.WriteLine($"Isi file {e.Name}:");
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}