namespace GG_Telefonos.Views;

public partial class GG_AllTelefonosPage : ContentPage
{
    public GG_AllTelefonosPage()
    {
        InitializeComponent();

        BindingContext = new Models.GG_AllTelefonos();
    }

    protected override void OnAppearing()
    {
        ((Models.GG_AllTelefonos)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GG_TelefonoPage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.GG_Telefono)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(GG_TelefonoPage)}?{nameof(GG_TelefonoPage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}