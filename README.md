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

- il choisit un Maison <- RULE
- Un Wizard "harry potter" choisit la maison "Gryffindor"
  - Alors il appartient à la maison "Gryffindor"

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

  