# Projet de Contrôle DMX

## Présentation

Ce projet permet de contrôler des équipements d’éclairage via le protocole **DMX512** en utilisant une application C#.

---

## Protocole DMX512

### Qu’est-ce que le DMX ?

Le **DMX512 (Digital Multiplex)** est un protocole standard utilisé en éclairage scénique.

- Communication **unidirectionnelle**
- Jusqu’à **512 canaux par univers**
- Chaque canal possède une valeur entre **0 et 255**
- Utilise la couche physique **RS-485**

---

### Structure d’une trame DMX

Une trame DMX est envoyée en continu et se compose de :

1. **Break**
   - Signal bas (> 88 µs)
   - Indique le début d’une nouvelle trame

2. **Mark After Break (MAB)**
   - Signal haut court (~8 µs)

3. **Start Code**
   - Généralement `0x00` (données standards)

4. **Données (slots)**
   - Jusqu’à **512 canaux**
   - Chaque canal = 1 octet (0–255)

#### Exemple :
| Canal | Fonction     |
|------|-------------|
| 1    | Intensité    |
| 2    | Rouge        |
| 3    | Vert         |
| 4    | Bleu         |

## Interfaces matérielles

Ce projet supporte les interfaces suivantes :

### Enttec Open DMX USB
- Interface simple
- Pas de buffer interne
- Timing géré par le logiciel (windows)
- Moins stable

### Enttec DMX USB Pro
- Interface avancée
- Buffer interne (gestion hardware)
- Plus stable et fiable
- Protocole série structuré

> Important : ces deux interfaces nécessitent une gestion différente dans le code.
> une aura une gestion via un driver windows et l'autre via une librairie visual....

---

## Environnement de développement

- **Langage** : C++
- **Système de build** : Visual Studio 2022 (le rose tu sais)
- **OS cible** : Windows 10

---

## Librairies utilisées

- Communication USB (Open DMX) :

## Validation du code

### Mesure DMX
#### Schema de mesure
#### Premiere mesure
 ![plot](./Mesure/Mesure_DMX.png) 
| premiere page | deuxieme page     |
|------|-------------|
| ![plot](./Mesure/image_terminal_1.png)   | ![plot](./Mesure/image_terminal_2.png)    |
#### Remarque
comme on peut le voir, les trames presentes sur l'oscilloscope sont bien correct
| valeur attendu (binaire) | valeur que l'on obtient (binaire) | channel |
|------|-------------|--|
|0b0000 0000|0b0000 0000|0|
| 0b1111 1111  | 0b1111 1111 |1|
| 0b0101 0011  | 0b0101 0011 |2|
| 0b0000 0000  | 0b0000 0000 |3|
| 0b0101 0011  | 0b0101 0011 |4|
| 0b0000 0000  | 0b0000 0000 |5|
| 0b1111 1111  | 0b1111 1111 |6|
| 0b0000 0000  | 0b0000 0000 |7|
| 0b0000 0000  | 0b0000 0000 |8|

