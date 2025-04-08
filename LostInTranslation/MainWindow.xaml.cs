using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LostInTranslation
{
    public partial class MainWindow : Window
    {
        private Random _random = new Random();
        private VocabularyEntry _currentQuizEntry;
        private VocabularyStore _store = new VocabularyStore();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Phase 1: Übersetzer
        private async void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            var translator = new TranslatorService();
            string inputText = inputTextBox.Text;
            string selectedLanguage = ((ComboBoxItem)languageComboBox.SelectedItem).Tag.ToString();

            string translation = await translator.TranslateText(inputText, selectedLanguage);
            outputTextBlock.Text = translation;
        }

        // Phase 2: Quiz starten
        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            AskNextQuestion(); // Nächste Frage anzeigen
        }

        // Zeigt die nächste Frage im Quiz
        private void AskNextQuestion()
        {
            // Vokabeln für das Quiz laden
            var entries = _store.GetAllEntries();

            if (entries.Count == 0)
            {
                quizResultTextBlock.Text = "Keine Vokabeln verfügbar.";
                return;
            }

            _currentQuizEntry = entries[_random.Next(entries.Count)];
            string quizLanguage = ((ComboBoxItem)quizLanguageComboBox.SelectedItem).Tag.ToString();

            // Frage übersetzen
            var translator = new TranslatorService();
            questionTextBlock.Text = $"Was ist die Übersetzung für: {_currentQuizEntry.Original}? (Sprache: {quizLanguage})";
        }

        // Überprüft die Antwort des Benutzers
        private void CheckAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuizEntry == null)
            {
                quizResultTextBlock.Text = "Keine Frage aktiv.";
                return;
            }

            string userAnswer = quizAnswerTextBox.Text.Trim();
            string correctAnswer = _currentQuizEntry.Translation;

            // Antwort überprüfen
            if (string.Equals(userAnswer, correctAnswer, StringComparison.InvariantCultureIgnoreCase))
            {
                quizResultTextBlock.Text = $"Richtig! 🎉 Die Übersetzung von '{_currentQuizEntry.Original}' ist '{correctAnswer}'.";
                _currentQuizEntry.CorrectCount++; // Zählt die richtige Antwort
            }
            else
            {
                quizResultTextBlock.Text = $"Falsch. Die richtige Antwort ist: {correctAnswer}.";
            }

            // Nach der Überprüfung zur nächsten Frage übergehen
            AskNextQuestion();
        }
    }
}
