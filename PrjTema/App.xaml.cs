using PrjTema.Resources.Theme; // Supondo que DarkTheme e LightTheme são definidos em arquivos .xaml
using System.Collections.ObjectModel; // Para ICollection

namespace PrjTema
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitTheme();
            MainPage = new AppShell();
        }

        private void InitTheme()
        {
            Application.Current.UserAppTheme = AppTheme.Dark;  // Corrigido de AppAction.Current para Application.Current
            Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
        }

        public static AppTheme ChangeTheme()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            // Alternar entre temas Claro e Escuro
            if (Application.Current.UserAppTheme == AppTheme.Dark)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                mergedDictionaries.Remove(new DarkTheme()); // Remover o tema escuro
                mergedDictionaries.Add(new LightTheme());  // Adicionar o tema claro
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                mergedDictionaries.Remove(new LightTheme()); // Remover o tema claro
                mergedDictionaries.Add(new DarkTheme());  // Adicionar o tema escuro
            }

            // Notificar que o tema mudou
            ThemeChanged?.Invoke(Application.Current.UserAppTheme);
            return Application.Current.UserAppTheme;
        }

        // Event handler para notificação de mudança de tema
        public static event Action<AppTheme> ThemeChanged;
    }
}