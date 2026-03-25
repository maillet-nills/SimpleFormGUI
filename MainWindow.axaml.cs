using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SimpleFormGUI;

public partial class MainWindow : Window
{
    // Variables globales
    string[] tabNoms = new string[100];
    string[] tabSexes = new string[100];
    int[] tabNaissances = new int[100];
    int[] tabFautes = new int[100];
    int nbCandidats, nbCandidatsF, nbCandidatsM;
    public MainWindow()
    {
        InitializeComponent();
        nbCandidats = 0;
        nbCandidatsF = 0;
        nbCandidatsM = 0;
    }

    // Bouton "Enregistrer un candidat"
    private void BtnEnregistrerCandidat_Click(object sender, RoutedEventArgs e)
    {
        tabNoms[nbCandidats] = InputNom.Text;
        tabNaissances[nbCandidats] = Convert.ToInt16(InputAnnee.Text);
        if (RadioMasculin.IsChecked == true)
        {
            tabSexes[nbCandidats] = "masculin";
            nbCandidatsM++;
        }
        else
        {
            tabSexes[nbCandidats] = "feminin";
            nbCandidatsF++;
        }
        LabelNumeroCandidat.Text = Convert.ToString(nbCandidats);
        nbCandidats++;
    }

    // Bouton "Enregistrer un résultat"
    private void BtnEnregistrerResultat_Click(object sender, RoutedEventArgs e)
    {
        int numeroCandidat = Convert.ToInt16(InputNumeroCandidat.Text);
        tabFautes[numeroCandidat] = Convert.ToInt16(InputNbFautes.Text);

    }

    // Bouton "Afficher reçus"
    private void BtnAfficherRecus_Click(object sender, RoutedEventArgs e)
    {
        int nbRecus, nbRecusM, nbRecusF;
        nbRecus = 0;
        nbRecusM = 0;
        nbRecusF = 0;
        ListeRecus.Items.Clear();

        for (int i = 0; i < nbCandidats; i++)
        {
            ListeRecus.Items.Add((tabNoms[i]));
            nbRecus++;
            if (tabSexes[i] == "masculin")
            {
                nbRecusM++;
            }
            else
            {
                nbRecusF++;
            }
        }

        if (nbCandidats != 0)
        {
            LabelPctRecus.Text = Convert.ToString((nbRecus / nbCandidats) * 100);
        }else if (nbCandidatsM != 0)
        {
            LabelPctRecusH.Text = Convert.ToString((nbRecusM / nbCandidatsM) * 100);
        }else if (nbCandidatsF != 0)
        {
            LabelPctRecusF.Text = Convert.ToString((nbRecusF / nbCandidatsF) * 100);
        }
    }
}