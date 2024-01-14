using ProiectSalonApp.Models;
namespace ProiectSalonApp;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Services)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Services)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((Services)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Services)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    private async void OnDeleteItemClicked(object sender, EventArgs e)
    {
        var selectedProduct = listView.SelectedItem as Product;
        if (selectedProduct != null)
        {
            // Call your method to delete the product from the database
            await App.Database.DeleteProductAsync(selectedProduct);

            // Refresh the ListView
            listView.ItemsSource = await App.Database.GetProductsAsync();

            // Optionally, deselect the item in the ListView
            listView.SelectedItem = null;
        }
        else
        {
            // Notify the user if no item is selected
            await DisplayAlert("Error", "Please select an item to delete.", "OK");
        }
    }

}