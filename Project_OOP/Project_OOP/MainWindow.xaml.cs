using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
 
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Project_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bedrijf> bedrijvenLijst = new List<Bedrijf>();
        List<Persoon> personenLijst = new List<Persoon>();
        string selectieBedrijf;
        string selectiePersoon;
        string path;
        public MainWindow()
        {
            selectieBedrijf = "Bedrijf";
            selectiePersoon = "Persoon";
            path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            InitializeComponent();
            cmbxKeuze.Items.Add(selectiePersoon);
            cmbxKeuze.Items.Add(selectieBedrijf);

        }
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxVoornaam.Text))
            {
                MessageBox.Show("Voornaam is verplicht.");
                return;
            }


            if (string.IsNullOrWhiteSpace(tbxAchternaam.Text))
            {
                MessageBox.Show("Achternaam is verplicht.");
                return;
            }


            if (!string.IsNullOrWhiteSpace(tbxMail.Text) && !IsEmailValid(tbxMail.Text))
            {
                MessageBox.Show("Ongeldig e-mailadres.");
                return;
            }


            if (string.IsNullOrWhiteSpace(tbxAdres.Text))
            {
                MessageBox.Show("Adres is verplicht.");
                return;
            }

            if (cmbxKeuze.SelectedItem != null && cmbxKeuze.SelectedItem.ToString() == "Bedrijf")
            {
                


                Bedrijf bedrijf = new Bedrijf(tbxBedrijfsnaam.Text, tbxAdres.Text, tbxNummer.Text, tbxMail.Text);
                bedrijvenLijst.Add(bedrijf);
                LstvBedrijven.Items.Refresh();



                tbxBedrijfsnaam.Text = "";
                tbxAdres.Text = "";
                tbxMail.Text = "";
                tbxNummer.Text = "";

                string json = JsonConvert.SerializeObject(bedrijf);

                StreamWriter sw = new StreamWriter(File.Open(
                System.IO.Path.Combine(path, "bedrijf.txt"),
                FileMode.Append, FileAccess.Write));
                sw.Write(json + "\r\n");
                sw.Close();



                


            } 

            

            if (cmbxKeuze.SelectedItem != null && cmbxKeuze.SelectedItem.ToString() == "Persoon")
                {
               
                    Persoon persoon = new Persoon(tbxVoornaam.Text, tbxAchternaam.Text, tbxAdres.Text, tbxNummer.Text, tbxMail.Text);
                    personenLijst.Add(persoon);
                    LstvPersonen.Items.Refresh();
                    tbxAchternaam.Text = "";
                    tbxVoornaam.Text = "";
                    tbxAdres.Text = "";
                    tbxMail.Text = "";
                    tbxNummer.Text = "";

                    string json = JsonConvert.SerializeObject(persoon);


                    StreamWriter sw = new StreamWriter(File.Open(
                    System.IO.Path.Combine(path, "persoon.txt"),
                    FileMode.Append, FileAccess.Write));
                    sw.Write(json + "\r\n");
                    sw.Close();
                
                

                
                   

            }
            
            
        }

        private void cmbxKeuze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbxKeuze.SelectedItem != null)
            {
                string selectedOption = cmbxKeuze.SelectedItem.ToString();

                if (selectedOption == selectieBedrijf)
                {
                    tbxBedrijfsnaam.IsEnabled = true;
                    tbxAdres.IsEnabled = true;
                    tbxMail.IsEnabled = true;
                    tbxNummer.IsEnabled = true;
                    tbxAchternaam.IsEnabled = false;
                    tbxVoornaam.IsEnabled = false;
                    btnToevoegen.IsEnabled = true;
                }
                else if (selectedOption == selectiePersoon)
                {
                    tbxBedrijfsnaam.IsEnabled = false;
                    tbxAdres.IsEnabled = true;
                    tbxMail.IsEnabled = true;
                    tbxNummer.IsEnabled = true;
                    tbxAchternaam.IsEnabled = true;
                    tbxVoornaam.IsEnabled = true;
                    btnToevoegen.IsEnabled = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string[] regels = File.ReadAllLines(System.IO.Path.Combine(path, "persoon.txt"));

            foreach (string regel in regels)
            {
                Persoon persoon = JsonConvert.DeserializeObject<Persoon>(regel);
                personenLijst.Add(persoon);
            }
            string[] regels2 = File.ReadAllLines(System.IO.Path.Combine(path, "bedrijf.txt"));

            
            foreach (string regel in regels2)
            {
                Bedrijf bedrijf = JsonConvert.DeserializeObject<Bedrijf>(regel);
                bedrijvenLijst.Add(bedrijf);
            }
            LstvBedrijven.ItemsSource = bedrijvenLijst;
            LstvPersonen.ItemsSource = personenLijst;
        }

        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            List<Persoon> gefilterdePersonen = new List<Persoon>();
            List<Bedrijf> gefilterdeBedrijven = new List<Bedrijf>();
            string zoekterm = tbxZoek.Text;

            foreach (Persoon persoon in personenLijst)
            {
              
                if (persoon.Voornaam.Contains(zoekterm) ||
                    persoon.Achternaam.Contains(zoekterm) ||
                    persoon.Telefoonnummer.Contains(zoekterm) ||
                    persoon.Adres.Contains(zoekterm) ||
                    persoon.Email.Contains(zoekterm))
                {
                    
                    gefilterdePersonen.Add(persoon);
                }
            }
            foreach(Bedrijf bedrijf in bedrijvenLijst)
            {
                if (bedrijf.Naam.Contains(zoekterm) ||
                    bedrijf.Telefoonnummer.Contains(zoekterm) ||
                    bedrijf.Adres.Contains(zoekterm) ||
                    bedrijf.Email.Contains(zoekterm))
                {

                    gefilterdeBedrijven.Add(bedrijf);
                }
            }

            
            LstvPersonen.ItemsSource = gefilterdePersonen;
            LstvBedrijven.ItemsSource = gefilterdeBedrijven;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            LstvPersonen.ItemsSource = personenLijst;
            LstvBedrijven.ItemsSource = bedrijvenLijst;
        }

        private void btnVeranderPersoon_Click(object sender, RoutedEventArgs e)
        {
            if (LstvPersonen.SelectedItem != null)
            {
                Persoon geselecteerdePersoon = (Persoon)LstvPersonen.SelectedItem;

                if (!string.IsNullOrWhiteSpace(tbxAchternaam.Text))
                {
                    geselecteerdePersoon.Achternaam = tbxAchternaam.Text;
                }

                if (!string.IsNullOrWhiteSpace(tbxVoornaam.Text))
                {
                    geselecteerdePersoon.Voornaam = tbxVoornaam.Text;
                }

                if (!string.IsNullOrWhiteSpace(tbxMail.Text) && IsEmailValid(tbxMail.Text))
                {
                    geselecteerdePersoon.Email = tbxMail.Text;
                }
                else
                {
                    MessageBox.Show("Ongeldig e-mailadres.");
                    return; 
                }

                if (!string.IsNullOrWhiteSpace(tbxNummer.Text))
                {
                    geselecteerdePersoon.Telefoonnummer = tbxNummer.Text;
                }

                if (!string.IsNullOrWhiteSpace(tbxAdres.Text))
                {
                    geselecteerdePersoon.Adres = tbxAdres.Text;
                }

                int index = personenLijst.IndexOf(geselecteerdePersoon);
                if (index != -1)
                {
                    personenLijst[index] = geselecteerdePersoon;
                }
                else
                {
                    MessageBox.Show("Geselecteerde persoon niet gevonden in de lijst.");
                }
                UpdatePersonenBestand();
                LstvPersonen.Items.Refresh();
            }
        }

        private void btnVeranderBedrijf_Click(object sender, RoutedEventArgs e)
        {
            if (LstvBedrijven.SelectedItem != null)
            {
                Bedrijf geselecteerdBedrijf = (Bedrijf)LstvBedrijven.SelectedItem;


               
                if (!string.IsNullOrWhiteSpace(tbxBedrijfsnaam.Text))
                {
                    geselecteerdBedrijf.Naam = tbxBedrijfsnaam.Text;
                }

                if (!string.IsNullOrWhiteSpace(tbxMail.Text) && IsEmailValid(tbxMail.Text))
                {
                    geselecteerdBedrijf.Email = tbxMail.Text;
                }
                else
                {
                    MessageBox.Show("Ongeldig e-mailadres.");
                    return; 
                }

                if (!string.IsNullOrWhiteSpace(tbxNummer.Text))
                {
                    geselecteerdBedrijf.Telefoonnummer = tbxNummer.Text;
                }

             
                if (!string.IsNullOrWhiteSpace(tbxAdres.Text))
                {
                    geselecteerdBedrijf.Adres = tbxAdres.Text;
                }

           
                int index = bedrijvenLijst.IndexOf(geselecteerdBedrijf);

                if (index != -1)
                {
                    
                    bedrijvenLijst[index] = geselecteerdBedrijf;
                   
                }
                else
                {
                    
                    MessageBox.Show("Geselecteerd bedrijf niet gevonden in de lijst.");
                }

                UpdateBedrijvenBestand();
                LstvBedrijven.Items.Refresh();
            }
        }

        private void btnVerwijderBedrijf_Click(object sender, RoutedEventArgs e)
        {
            Bedrijf geselecteerdBedrijf = (Bedrijf)LstvBedrijven.SelectedItem;

            
            bedrijvenLijst.Remove(geselecteerdBedrijf);

            
            LstvBedrijven.Items.Refresh();
            UpdateBedrijvenBestand();
        }

        private void btnVerwijderPersoon_Click(object sender, RoutedEventArgs e)
        {
            if (LstvPersonen.SelectedItem != null)
            {
                Persoon geselecteerdePersoon = (Persoon)LstvPersonen.SelectedItem;

                
                personenLijst.Remove(geselecteerdePersoon);

                LstvPersonen.Items.Refresh();

                
                UpdatePersonenBestand();
            }

        }
        private void UpdateBedrijvenBestand()
        {
            string bedrijvenBestand = System.IO.Path.Combine(path, "bedrijf.txt");

         
            List<string> bedrijfData = new List<string>();
            foreach (Bedrijf bedrijf in bedrijvenLijst)
            {
                bedrijfData.Add(JsonConvert.SerializeObject(bedrijf));
            }

          
            File.WriteAllLines(bedrijvenBestand, bedrijfData);
        }
        private void UpdatePersonenBestand()
        {
            string personenBestand = System.IO.Path.Combine(path, "persoon.txt");

          
            List<string> persoonData = new List<string>();
            foreach (Persoon persoon in personenLijst)
            {
                persoonData.Add(JsonConvert.SerializeObject(persoon));
            }

           
            File.WriteAllLines(personenBestand, persoonData);
        }
        public bool IsEmailValid(string email)
        {
           
            string emailControle = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            
            Regex regex = new Regex(emailControle);

            
            return regex.IsMatch(email);
        }

    }
}