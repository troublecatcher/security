using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using CommunityToolkit.Maui.Storage;

namespace DigitalSignature;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        uploadFileBtn.Clicked += UploadFile_Grab;
        downloadDigSigBtn.Clicked += CreateDigSig;
        uploadDigSigBtn.Clicked += UploadDigSig;
    }
    byte[] file;
    string fileName;
    byte[] digsig;
    byte[] hash;
    DSAParameters dsaparams;
    SHA1 sha1 = new SHA1CryptoServiceProvider();
    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();


    private async void UploadFile_Grab(object sender, EventArgs e)
	{
        var result = await FilePicker.PickAsync();
        var stream = await result.OpenReadAsync();
        file = ReadFully(stream);
        fileName = result.FileName;

        Regex r = new Regex("([^\\/]*)$");
        uploadFileBtn.Text = r.Match(result.FullPath.ToString()) + " ✖";
        uploadFileBtn.BackgroundColor = Colors.Brown;

        uploadFileBtn.Clicked -= UploadFile_Grab;
        uploadFileBtn.Clicked += UploadFile_Throw;
        digSigLabel.IsVisible = true;
        uploadDigSigBtn.IsVisible = true;
        downloadDigSigBtn.IsVisible = true;
    }
    private void UploadFile_Throw(object sender, EventArgs e)
    {
        file = null;
        uploadFileBtn.Text = "Выбрать";
        uploadFileBtn.BackgroundColor = Color.FromArgb("#512bd4");
        uploadFileBtn.Clicked += UploadFile_Grab;
        uploadFileBtn.Clicked -= UploadFile_Throw;
        digSigLabel.IsVisible = false;
        uploadDigSigBtn.IsVisible = false;
        downloadDigSigBtn.IsVisible = false;
    }
    private async void CreateDigSig(object sender, EventArgs e)
    {
        hash = sha1.ComputeHash(file);
        digsig = rsa.SignHash(hash, "1.3.14.3.2.26");

        var folder = await FolderPicker.PickAsync(default);
        var path = folder.Folder.Path;
        path = path.Remove(0, 7);
        path += $"{fileName}.signature";
        using var writer = new BinaryWriter(File.OpenWrite(path));
        writer.Write(digsig);

        await DisplayAlert("Успех", $"Цифровая подпись {path} успешно создана", "Круто");
        UploadFile_Throw(sender, e);
    }
    private async void UploadDigSig(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        var stream = await result.OpenReadAsync();
        digsig = ReadFully(stream);

        hash = sha1.ComputeHash(file);

        bool match = rsa.VerifyHash(hash, "1.3.14.3.2.26", digsig);
        if (match) await DisplayAlert("Результат", "Данные не были изменены", "Оk");
              else await DisplayAlert("Результат", "Данные были изменены...", "Оk");
        UploadFile_Throw(sender, e);
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


