<div align="center">

#  Application de Gestion de Médicaments

[![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)](#)
[![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](#)
[![WPF](https://img.shields.io/badge/WPF-0078D4?style=for-the-badge&logo=windows&logoColor=white)](#)
[![MariaDB](https://img.shields.io/badge/MariaDB-003545?style=for-the-badge&logo=mariadb&logoColor=white)](#)

*Une solution complète développée en C# (.NET 8.0) permettant de gérer efficacement les médicaments, les patients et les ordonnances.*

</div>

---

##  Architecture Logicielle

Le projet suit une architecture en couches (N-Tier) pour séparer les responsabilités et faciliter la maintenance :

| Couche | Description |
| :--- | :--- |
|  **MedicamentBO** *(Business Objects)* | Couche métier contenant les entités principales (`Medicament`, `Patient`, `Ordonnance`, `Utilisateur`) ainsi que la logique de gestion (`BibliotequeMedicament`, `BibliothequePatient`). |
|  **MedecineApp** *(Data Access Layer)* | Couche d'accès aux données. Contient le `BddRepository` chargé de la communication avec la base de données MariaDB. |
|  **MedicamentGUI** *(Presentation Layer)* | Interface graphique utilisateur développée en WPF, permettant une interaction visuelle riche (gestion via `MedicamentPage`, `PatientPage`, etc.). |
|  **MedicamentConsole** | Interface en ligne de commande (CLI) alternative pour interagir avec l'application. |
|  **MedecineTest** | Projet de tests unitaires garantissant la fiabilité des composants et de la logique métier. |

---

##  Technologies

- **Langage** : C#
- **Framework** : .NET 8.0
- **Interface Graphique** : WPF (Windows Presentation Foundation)
- **Base de données** : MariaDB
- **Tests** : Framework de tests unitaires intégré

---

##  Installation et Configuration

### 1. Prérequis
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Serveur MariaDB fonctionnel

### 2. Étapes d'installation

1. **Cloner le repository** :
   ```bash
   git clone <https://github.com/Jules-pecquereau/MedicamentMihnC->
   ```

2. **Ouvrir la solution** `MedicamentMihnC-.sln` dans Visual Studio ou Visual Studio Code.

3. **Restaurer les dépendances NuGet** :
   ```bash
   dotnet restore
   ```

4. **Configurer la base de données** :
   Modifiez la chaîne de connexion à la base de données MariaDB dans les fichiers `App.config` des projets `MedicamentGUI` et `MedicamentConsole`.

5. **Compiler et exécuter** :
   - Pour l'interface graphique : Exécutez le projet `MedicamentGUI`.
   - Pour le terminal : Exécutez le projet `MedicamentConsole`.

---
