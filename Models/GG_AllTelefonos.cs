using System.Collections.ObjectModel;

namespace GG_Telefonos.Models;

internal class GG_AllTelefonos
{
    public ObservableCollection<GG_Telefono> Notes { get; set; } = new ObservableCollection<GG_Telefono>();

    public GG_AllTelefonos() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<GG_Telefono> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new GG_Telefono()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetCreationTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (GG_Telefono note in notes)
            Notes.Add(note);
    }
}