Class1.CS
---

# Fonctionnalités

- Gestion d'appareils DMX
- Gestion des canaux et valeurs
- Gestion mémoire des adresses DMX
- Vérification des conflits d'adresses
- Communication avec une interface Enttec Pro
- Envoi de trames DMX
- Support du protocole DMX512

---

# Classes disponibles

# Device_parameters

Classe représentant un appareil DMX.

## Attributs

| Nom | Type | Description |
|------|------|-------------|
| `Device_Name` | `string` | Nom de l'appareil |
| `Channel_Number` | `int` | Nombre de canaux |
| `Channel_Name` | `string[]` | Nom des canaux |
| `Channel_Value` | `int[]` | Valeur des canaux |
| `Starting_Adress` | `int` | Adresse DMX de départ |

---

## Constructeur

```csharp
Device_parameters(string deviceName, int ChannelNumber, int StartingAdress)
```

Initialise un appareil DMX avec :
- un nom
- un nombre de canaux
- une adresse de départ

---

## Méthodes

### Get_index_value

```csharp
int Get_index_value(int page_number, int ChannelNumber)
```

Calcule l'index réel dans le tableau des canaux.

---

### Get_Number_of_page

```csharp
int Get_Number_of_page(int ChannelNumber)
```

Retourne le nombre de pages nécessaires pour afficher les canaux.

---

### Change_Channel_Name

```csharp
void Change_Channel_Name(string new_Name, int page_number, int ChannelNumber)
```

Modifie le nom d'un canal.

---

### Change_Channel_Value

```csharp
void Change_Channel_Value(int new_Value, int page_number, int ChannelNumber)
```

Modifie la valeur d'un canal.

---

## Exemple

```csharp
Device_parameters projector = new Device_parameters("Projector", 8, 1);

projector.Change_Channel_Name("Dimmer", 0, 0);
projector.Change_Channel_Value(255, 0, 0);
```

---

# Project_Memory

Classe permettant de gérer l'occupation des adresses DMX.

---

## Constantes

| Nom | Valeur | Description |
|------|--------|-------------|
| `Max_adresse` | `511` | Adresse maximale DMX |
| `place_unused` | `false` | Adresse libre |
| `place_used` | `true` | Adresse utilisée |

---

## Attributs

| Nom | Type | Description |
|------|------|-------------|
| `Adress_list` | `bool[]` | Tableau des adresses utilisées |
| `Value_list` | `int[]` | Valeur DMX associée |

---

## Constructeur

```csharp
Project_Memory()
```

Initialise toute la mémoire DMX.

---

## Méthodes

### Fill_Adress_tab

```csharp
bool Fill_Adress_tab(int starting_adress, int ChannelNumber)
```

Réserve une plage d'adresses DMX.

### Retour

| Valeur | Description |
|--------|-------------|
| `true` | Adresse valide |
| `false` | Adresse invalide car deja occupée |

---

## Fonctionnement interne

La méthode privée :

```csharp
Is_place_available()
```

vérifie :
- les dépassements d'adresses
- les conflits mémoire

---

## Exemple

```csharp
Project_Memory memory = new Project_Memory();

bool success = memory.Fill_Adress_tab(1, 8);

if(success)
{
    Console.WriteLine("Adresse réservée");
}
```

---

# EnttecProManager

Classe permettant la communication avec une interface Enttec Pro.

## Compatible avec

- Enttec DMX USB Pro
- Interfaces compatibles FTDI

---

## Fonctionnalités

- Connexion série
- Gestion buffer DMX
- Envoi de trames
- Déconnexion propre
- Gestion IDisposable

---

## Attributs privés

| Nom | Type | Description |
|------|------|-------------|
| `_serialPort` | `SerialPort` | Port série |
| `_dmxBuffer` | `byte[]` | Buffer DMX |

---

## Propriété

```csharp
bool IsConnected
```

Indique si le périphérique est connecté.

---

## Méthodes

### Connect

```csharp
bool Connect(string portName)
```

Connexion au périphérique.

### Exemple

```csharp
manager.Connect("COM3");
```

---

### SetChannel

```csharp
void SetChannel(int channel, byte value)
```

Modifie la valeur d'un canal DMX.

### Exemple

```csharp
manager.SetChannel(1, 255);
```

---

### SendTest

```csharp
void SendTest()
```

Construit et envoie une trame DMX complète.

---

### Disconnect

```csharp
void Disconnect()
```

Ferme la connexion série.

---

### Dispose

```csharp
void Dispose()
```


# Auteur
Hayatache

# Aide pour ce projet 
https://github.com/hansvana/DMXtable/blob/master/DMXserial.cs

Projet développé en C# pour les deux controleurs ENTTEC DMX USB PRO et OPEN DMX.
