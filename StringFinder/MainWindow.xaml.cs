using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace StringFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         

        private List<FileSearch> wordDocs = new List<FileSearch>();
        private List<FileSearch> pdfDocs = new List<FileSearch>();
        private string inputString;
        
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddWordDoc(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                wordDocs.Add(new FileSearch() { FilePath = fileDialog.FileName, FileFound = "black" });
                ListBoxWordDocs.ItemsSource = wordDocs;
                ListBoxWordDocs.Items.Refresh();
            }
        }

        private void RemoveWordDoc(object sender, RoutedEventArgs e)
        {
            try
            {
                wordDocs.RemoveAt(ListBoxWordDocs.SelectedIndex);
                ListBoxWordDocs.ItemsSource = wordDocs;
                ListBoxWordDocs.Items.Refresh();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("ERROR REMOVING DOC FILE");
            }
        }

        private void AddPDFDoc(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                pdfDocs.Add(new FileSearch() { FilePath = fileDialog.FileName, FileFound = "black" });
                ListBoxPDFDocs.ItemsSource = pdfDocs;
                ListBoxPDFDocs.Items.Refresh();
            }
        }
        
        
        private void RemovePDFDoc(object sender, RoutedEventArgs e)
        {
            try
            {
                pdfDocs.RemoveAt(ListBoxPDFDocs.SelectedIndex);
                ListBoxPDFDocs.ItemsSource = pdfDocs;
                ListBoxPDFDocs.Items.Refresh();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("ERROR REMOVING PDF FILE");
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            inputString = TextBoxStringInput.Text;
            Debug.WriteLine("Searching for: " + inputString);

            //PDF Search - Using iTextSharp Library
            foreach (var pdf in pdfDocs)
            {
                List<int> pagehits = new List<int>(); //Pages string is found
                if (File.Exists(pdf.FilePath))
                {
                    //Create a new reader
                    PdfReader reader = new PdfReader(pdf.FilePath);

                    for(int page = 1; page <= reader.NumberOfPages; page++)
                    {

                        //Method to convert PDF to text
                        ITextExtractionStrategy extractionStrategy = new SimpleTextExtractionStrategy();
                        
                        //Extract each page as text and search, add page no. to list if match
                        string currentPageText = PdfTextExtractor.GetTextFromPage(reader, page, extractionStrategy);
                        

                        Debug.WriteLine("PAGE: " + page);
                        Debug.WriteLine(currentPageText);
                        if (Regex.IsMatch(currentPageText, inputString, RegexOptions.IgnoreCase))
                        {
                            Debug.WriteLine("Match on page: " + page);
                            pagehits.Add(page);
                        }

                    }

                    //Update FileSearch details for pdf
                    if(pagehits.Count > 0)
                    {
                        pdf.FileFoundLocations = pagehits;
                        pdf.FileFound = "Green";
                        ListBoxPDFDocs.ItemsSource = pdfDocs;
                        ListBoxPDFDocs.Items.Refresh();
                    }

                    reader.Close();

                }
            }
            
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (FileSearch file in wordDocs)
            {
                file.FileFound = "black";
                file.FileFoundLocations.Clear();
            }

            foreach (FileSearch file in pdfDocs)
            {
                file.FileFound = "black";

                try
                {
                    file.FileFoundLocations.Clear();
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex);
                }
            }

            ListBoxWordDocs.ItemsSource = wordDocs;
            ListBoxWordDocs.Items.Refresh();
            ListBoxPDFDocs.ItemsSource = pdfDocs;
            ListBoxPDFDocs.Items.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process acrobat = new Process();
            acrobat.StartInfo.FileName = "acroRd32.exe";
            acrobat.StartInfo.Arguments = "/A \"page=2=OpenActions\""+pdfDocs[ListBoxPDFDocs.SelectedIndex].FilePath;
            acrobat.Start();
        }
    }

    public class FileSearch
    {
        public string FilePath { get; set; }
        public string FileFound { get; set; }
        public List<int> FileFoundLocations { get; set; }
    }
}
