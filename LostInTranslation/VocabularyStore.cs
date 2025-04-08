using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LostInTranslation
{
    public class VocabularyStore
    {
        private const string FilePath = "vocabulary.json";  // Der Speicherort für das Vokabel-JSON
        private List<VocabularyEntry> _entries = new List<VocabularyEntry>();

        public VocabularyStore()
        {
            Load();  // Lädt die Vokabeln beim Start
        }

        // Fügt eine neue Vokabel hinzu
        public void AddEntry(string original, string translation)
        {
            _entries.Add(new VocabularyEntry
            {
                Original = original,
                Translation = translation,
                CorrectCount = 0  // Beim ersten Speichern ist der Fortschritt 0
            });

            Save();  // Speichert nach dem Hinzufügen
        }

        // Gibt alle gespeicherten Vokabeln zurück
        public List<VocabularyEntry> GetAllEntries()
        {
            return _entries;
        }

        // Speichert die Vokabeln als JSON-Datei
        private void Save()
        {
            var json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        // Lädt die Vokabeln aus der JSON-Datei
        private void Load()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                _entries = JsonSerializer.Deserialize<List<VocabularyEntry>>(json) ?? new List<VocabularyEntry>();
            }
        }
    }
}
