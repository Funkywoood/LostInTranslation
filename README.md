# LostInTranslation – WPF-Vokabeltrainer & Übersetzungshilfe

## 🧠 Projektbeschreibung

**LostInTranslation** ist eine Desktopanwendung zur Verwaltung und Erweiterung des persönlichen Vokabulars. Die Anwendung bietet einfache Funktionen zur Übersetzung und zum Speichern neuer Begriffe und unterstützt so das effiziente Sprachenlernen.

Die App ist mit .NET 8.0 als WPF-Anwendung (Windows Presentation Foundation) entwickelt worden und richtet sich an Nutzer, die gezielt ihren Wortschatz pflegen möchten.

---

## ⚙️ Verwendete Technologien

- **C# / .NET 8.0**
- **WPF (Windows Presentation Foundation)**
- **MVVM-artiger Aufbau**
- **Lokaler JSON-Speicher** zur Persistenz der Vokabeln (`vocabulary.json`)

---

## 🚀 Installation & Ausführung

### Voraussetzungen

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Windows-Betriebssystem
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) mit WPF-Komponenten

### Lokale Ausführung

1. Repository klonen:

   ```bash
   git clone https://github.com/dein-benutzername/LostInTranslation.git
   cd LostInTranslation
   ```

2. Projekt mit Visual Studio öffnen:  
   Datei `LostInTranslation.sln` doppelklicken oder via Menü öffnen.

3. Anwendung starten:
   - Im Visual Studio auf **Starten (F5)** klicken
   - Die App wird als Windows-Desktopanwendung ausgeführt

---

## ✨ Features

- Übersetzung neuer Wörter (abhängig von der Konfiguration in `TranslatorService.cs`)
- Vokabeln lokal speichern und laden
- JSON-Datei als Vokabelliste (`vocabulary.json`)
- Intuitive Benutzeroberfläche mit WPF
- Erweiterbare Architektur (z. B. für API-Anbindung)

---

## 📁 Projektstruktur

- `MainWindow.xaml.cs` – GUI und Interaktionen
- `TranslatorService.cs` – Übersetzungslogik (aktuell lokal)
- `VocabularyStore.cs` – Verwaltung des lokalen Vokabulars
- `vocabulary.json` – Lokaler Datenspeicher

---

## 🧑‍💻 Autor

- **Roli Spichtig**
- Kontakt: [https://rsfunkyweb.azurewebsites.net/]
