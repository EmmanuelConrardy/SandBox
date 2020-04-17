# 4MOC - Design Pattern



#### Méthodologie : 

- **TDD** - Test Driven Dev
- **BDD** - Behaviour Driven Dev
- **DDD** - Domain Driven Design



#### DDD [Glossary / Ubiquitous language]

###### Glossaire : 

- Wizard
- House
- Spell
- Damage
- State

#### BDD [Très Amigo]

###### Wizard

- Rule : Le choixpeau Attribut une maison 
   - Un Choixpeau est mis sur la tête d'un Wizard "Drago" sans maison
   - Quand le Choixpeau à announce le nom de la maison "Slytherin"
   - Alors "Drago" appartient à la maison "Slytherin"

- Rule : Un sorcier lance un sort sur un autre sorcier 
  - Un Wizard "Harry potter" lance le sort offensif "stupefix"
  - Sur "Albus Dumbledort"
  - Alors "Albus Dumbledort" est "stun" et il prend 1 damage

###### Game Wizard Dual

- Turn by Turn
- Deatheater / Auror
- Winning when a side party is dead

- Deatheater
 - Ability : 2/3 
 - Attack -> 2 pt
 - Confuse -> -1

- Auror
 - Ability : 2/3
 - Attack -> 2 pt
 - Heal -> +1

- House rule
- Deatheater win -> -1 for all
- Auror -> 1pt for each living




#### TDD [Red Green Refactor]

- On commence par les tests unitaire
- Ensuite on le fait passer au vert le plus simplement possible
- On refactorise si nécessaire

 

#### Pour run Hello World:

```c#
dotnet build
dotnet test
dotnet run -p
Aller dans SandBox apres faire: /SandBox/Playground.csproj`
```

 

#### Value Object

Immutable
A + B = B + A
Equals()
GetHashCode()
ValueOf() method
Private constructor
Sealed



#### Entity

Define by an ID < immutable



#### Service

Define by an interface.
The interface is used to collaborate with domain object.

   