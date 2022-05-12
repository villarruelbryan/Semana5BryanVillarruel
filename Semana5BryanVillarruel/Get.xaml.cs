using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana5BryanVillarruel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Get : ContentPage
    {
        private const string Url = "http://192.168.100.26/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Semana5BryanVillarruel.Datos> _post;

        public Get()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Semana5BryanVillarruel.Datos> posts=JsonConvert.DeserializeObject<List<Semana5BryanVillarruel.Datos>>(content);
            _post = new ObservableCollection<Semana5BryanVillarruel.Datos>(posts);
            MyListView.ItemsSource = _post;
        }
    }
}