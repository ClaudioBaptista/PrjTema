using PrjTema.Resources.Theme;

namespace PrjTema
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool escuro = true;

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

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void btnTrocar_Clicked(object sender, EventArgs e)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                escuro = !escuro;
                if (escuro)
                {
                    mergedDictionaries.Add(new DarkTheme());
                    btnTrocar.Text = "Trocar para Tema Claro";
                }
                else
                {
                    mergedDictionaries.Add(new LightTheme());
                    btnTrocar.Text = "Trocar para Tema Escuro";
                }
            }
        }
    }

}
