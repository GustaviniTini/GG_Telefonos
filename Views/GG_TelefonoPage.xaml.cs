namespace GG_Telefonos.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class GG_TelefonoPage : ContentPage

{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "GG_telefonos.txt");

    public GG_TelefonoPage()
    {
        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));

    }

    private void LoadNote(string fileName)
    {
        Models.GG_Telefono noteModel = new Models.GG_Telefono();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }
        BindingContext = noteModel;
    }



    private async void GG_SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.GG_Telefono note)
            File.WriteAllText(note.Filename, GG_TextEditor.Text);
      

        await Shell.Current.GoToAsync("..");
    }

    private async void GG_DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.GG_Telefono note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }







    public string ItemId
    {
        set { LoadNote(value); }
    }
}