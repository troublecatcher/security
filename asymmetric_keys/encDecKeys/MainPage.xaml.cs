using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Storage;

namespace encDecKeys;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        selInitFileBtn.Clicked += SelInitFileBtn_Grab;
        selDecrFileBtn.Clicked += SelDecrFileBtn_Grab;

        createOpenKey.Clicked += generateOpenKey;
        createPrivateKey.Clicked += generatePrivateKey;

        selOpenKey.Clicked += ChooseOpenKey;
        selPrivateKey.Clicked += ChoosePrivateKey;

        downloadEncrypted.Clicked += saveEncrypted;
        downloadDecrypted.Clicked += saveDecrypted;
    }
    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    byte[] initial;
    string initialName;
    byte[] encrypted;
    byte[] decrypted;
    string openxml;
    string privatexml;

    async void SelInitFileBtn_Grab(System.Object sender, System.EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        var stream = await result.OpenReadAsync();
        initial = ReadFully(stream);
        initialName = result.FileName;

        Regex r = new Regex("([^\\/]*)$");
        selInitFileBtn.Text = r.Match(result.FullPath.ToString()) + " ✖";
        selInitFileBtn.Clicked -= SelInitFileBtn_Grab;
        selInitFileBtn.Clicked += SelInitFileBtn_Throw;
        selInitFileBtn.BackgroundColor = Colors.Brown;

        selDecrFileBtn.IsVisible = false;
        selDecrFileLabel.IsVisible = false;

        selOpenKey.IsEnabled = true;
        //createOpenKey.IsEnabled = false;
        //createPrivateKey.IsEnabled = false;
    }

    void SelInitFileBtn_Throw(System.Object sender, System.EventArgs e)
    {
        selInitFileBtn.Text = "Выбрать файл...";
        selInitFileBtn.BackgroundColor = Color.FromArgb("#512bd4");
        selInitFileBtn.Clicked -= SelInitFileBtn_Throw;
        selInitFileBtn.Clicked += SelInitFileBtn_Grab;

        selDecrFileBtn.IsVisible = true;
        selDecrFileLabel.IsVisible = true;

        selOpenKey.IsEnabled = false;
        downloadEncrypted.IsVisible = false;
        //createOpenKey.IsEnabled = true;
        //createPrivateKey.IsEnabled = true;
    }

    async void SelDecrFileBtn_Grab(System.Object sender, System.EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        var stream = await result.OpenReadAsync();
        encrypted = ReadFully(stream);
        initialName = result.FileName;

        Regex r = new Regex("([^\\/]*)$");
        selDecrFileBtn.Text = r.Match(result.FullPath.ToString()) + " ✖";
        selDecrFileBtn.Clicked -= SelDecrFileBtn_Grab;
        selDecrFileBtn.Clicked += SelDecrFileBtn_Throw;
        selDecrFileBtn.BackgroundColor = Colors.Brown;

        selInitFileBtn.IsVisible = false;
        selInitFileLabel.IsVisible = false;

        selPrivateKey.IsEnabled = true;
        //createOpenKey.IsEnabled = false;
        //createPrivateKey.IsEnabled = false;
    }

    void SelDecrFileBtn_Throw(System.Object sender, System.EventArgs e)
    {
        selDecrFileBtn.Text = "Выбрать файл...";
        selDecrFileBtn.BackgroundColor = Color.FromArgb("#512bd4");
        selDecrFileBtn.Clicked -= SelDecrFileBtn_Throw;
        selDecrFileBtn.Clicked += SelDecrFileBtn_Grab;

        selInitFileBtn.IsVisible = true;
        selInitFileLabel.IsVisible = true;

        selPrivateKey.IsEnabled = false;
        downloadDecrypted.IsVisible = false;
        //createOpenKey.IsEnabled = true;
        //createPrivateKey.IsEnabled = true;
    }

    async void generateOpenKey(System.Object sender, System.EventArgs e)
    {
        var path = await FolderPicker.PickAsync(default);
        //await DisplayAlert("Alert", path.Folder.Path.ToString().Remove(0, 7), "OK");

        StreamWriter writer = new StreamWriter(path.Folder.Path.Remove(0, 7) + "openKey.xml", false);
        string publicOnlyKeyXML = rsa.ToXmlString(false);
        writer.Write(publicOnlyKeyXML);
        writer.Close();

        createOpenKey.Text = path.Folder.Name.ToString() + "/openKey.xml" + " ✓";
        createOpenKey.IsEnabled = false;
    }
    async void generatePrivateKey(System.Object sender, System.EventArgs e)
    {
        var path = await FolderPicker.PickAsync(default);

        StreamWriter writer = new StreamWriter(path.Folder.Path.Remove(0, 7) + "privateKey.xml", false);
        string publicPrivateKeyXML = rsa.ToXmlString(true);
        writer.Write(publicPrivateKeyXML);
        writer.Close();

        createPrivateKey.Text = path.Folder.Name.ToString() + "/privateKey.xml" + " ✓";
        createPrivateKey.IsEnabled = false;
    }
    async void ChooseOpenKey(System.Object sender, System.EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        var stream = await result.OpenReadAsync();
        StreamReader reader = new StreamReader(stream);
        openxml = reader.ReadToEnd();
        
        reader.Close();

        downloadEncrypted.IsVisible = true;

        selOpenKey.Text = "✓";
        selOpenKey.IsEnabled = false;

    }
    async void ChoosePrivateKey(System.Object sender, System.EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        var stream = await result.OpenReadAsync();
        StreamReader reader = new StreamReader(stream);
        privatexml = reader.ReadToEnd();
        
        reader.Close();

        downloadDecrypted.IsVisible = true;

        selPrivateKey.Text = "✓";
        selPrivateKey.IsEnabled = false;
    }
    async void saveEncrypted(System.Object sender, System.EventArgs e)
    {
        rsa.FromXmlString(openxml);
        encrypted = rsa.Encrypt(initial, false);

        var folder = await FolderPicker.PickAsync(default);
        var path = folder.Folder.Path.Remove(0, 7);
        path += "/" + initialName;

        using var writer = new BinaryWriter(File.OpenWrite(path));
        writer.Write(encrypted);
    }
    async void saveDecrypted(System.Object sender, System.EventArgs e)
    {
        rsa.FromXmlString(privatexml);
        decrypted = rsa.Decrypt(encrypted, false);

        var folder = await FolderPicker.PickAsync(default);
        var path = folder.Folder.Path.Remove(0, 7);
        path += "/" + initialName;

        using var writer = new BinaryWriter(File.OpenWrite(path));
        writer.Write(decrypted);
    }
    public static byte[] ReadFully(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
}


