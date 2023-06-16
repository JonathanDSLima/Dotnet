using System.Collections.ObjectModel;
using app_cripto_ui.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace app_cripto_ui;

public partial class ListaTransacoes : ContentPage
{

    ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

    public ListaTransacoes()
	{
		InitializeComponent();

        listTransactions.ItemsSource = transactions;

        GetTransações();
    }

    public async void GetTransações()
    {
        var httpClient = new HttpClient();
        string url = "https://localhost:7146/api/Transaction";
        using var response = await httpClient.GetAsync(url);

        var json = await response.Content.ReadAsStringAsync();

        List<Transaction> objs = JsonConvert.DeserializeObject<List<Transaction>>(json);

        objs.ForEach(x => transactions.Add(x));
    }
}
