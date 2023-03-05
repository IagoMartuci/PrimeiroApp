namespace PrimeiroApp;
public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text); // Função de acessibilidade: https://learn.microsoft.com/pt-br/dotnet/maui/fundamentals/accessibility?view=net-maui-7.0
    }

    private async void btnZerarContagem_Clicked(object sender, EventArgs e)
    {
            if (await DisplayAlert("Pergunta", "Deseja realmente zerar a contagem?", "Sim", "Não"))
            {
                count = 0;
                CounterBtn.Text = "Click me";
            }
    }

    private void btnVerificar_Clicked(object sender, EventArgs e)
    {
        string texto = $"O nome tem {txtNome.Text.Length} caracteres";

        DisplayAlert("Mensagem", texto, "Ok");
    }

    private async void btnLimpar_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Pergunta", "Deseja realmente limpar a tela?", "Sim", "Não"))
        {
            txtNome.Text = string.Empty;
        }
    }

    private async void btnVerificarData_Clicked(object sender, EventArgs e)
    {
        int diasVividos = DateTime.Now.Subtract(txtDtNascimento.Date).Days;

        await Application.Current.MainPage
            .DisplayAlert("Mensagem", $"Você já viveu {diasVividos} dias", "Ok");
    }

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        string n1 = await Application.Current.MainPage
            .DisplayPromptAsync("Mensagem", "Digite o primeiro número", "Ok");

        string n2 = await Application.Current.MainPage
            .DisplayPromptAsync("Mensagem", "Digite o segundo número", "Ok");

        string operacao = await Application.Current.MainPage
            .DisplayActionSheet("Mensagem", "Selecione uma opção",
            "Cancelar", "Somar", "Subtrair", "Multiplicar", "Dividir");

        if (operacao != null)
        {
            if (operacao == "Somar")
            {
                double resultado = double.Parse(n1) + double.Parse(n2);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", $"O resultado é {resultado}", "Ok");
            }
            else if (operacao == "Subtrair")
            {
                double resultado = double.Parse(n1) - double.Parse(n2);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", $"O resultado é {resultado}", "Ok");
            }
            else if (operacao == "Multiplicar")
            {
                double resultado = double.Parse(n1) * double.Parse(n2);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", $"O resultado é {resultado}", "Ok");
            }
            else
            {
                double resultado = double.Parse(n1) / double.Parse(n2);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", $"O resultado é {resultado}", "Ok");
            }
        }
    }
}

