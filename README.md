# Oeuvre

The Theater Of Evolutionary Architecture

### Oeuvre
/ˈəːvr(ə)/

**Pronounced as:** uh·vruh | noun: oeuvre; plural noun: oeuvres

**Meaning:** The body of work of a painter, composer, or author. A work of art, music, or literature.

### Introducing Oeuvre

Oeuvre is a social article publishing portal that enables users to write and publish and share their articles. 
At some level Oeuvre is an Experimental Test-Bed for Evolutionary Architecture. This project will also demonstrate how quickly and efficiently DDD aligns to the changes in business.

The technology stack used is .Net, but the concept can be applied to all the programming language that supports OOPS.

### Instructions for Running

1. Install [.Net Core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.1https://dotnet.microsoft.com/download/dotnet-core/3.1) or above

2. Install [Postgres](https://www.postgresql.org/download/) Database Server

3. Clone Git Repository - git clone https://github.com/codefinity/oeuvre.git

4. To Run - Use console command 'dotnet run'

### Running Code Coverage

1. On console make sure you are in the test project folder

2. Run this command to generate report in XML format. The Report is saved in /TestResults Folder.

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit*]\*" /p:CoverletOutput="./TestResults/"

3. Run this command to generate HTML report from the XML report. The Report is saved in /TestResults/html Folder. To view the report, open the index.html file in the browser.

reportgenerator "-reports:TestResults\coverage.cobertura.xml" "-targetdir:TestResults\html" -reporttypes:HTML;


### Event Stroming Boards

- [Big Picture Event Sorming](https://miro.com/app/board/o9J_knjMlGU=/)
- [Design Level Event Storming](https://miro.com/app/board/o9J_kniwpWE=/)
- [More Design Level Event Storming](https://miro.com/app/board/o9J_knmsmnU=/)

### Evolution - One

- **Current Working Branch:** evolution-one 
- [Requirements for Phase One published](https://github.com/codefinity/oeuvre/tree/evolution-one/server/src/Specifications/Features)
- [Ubiquitous Language](https://github.com/codefinity/oeuvre/tree/evolution-one/server/src/Specifications/Features)

### Inspired By

#### Event Storming References

- [mariuszgil/awesome-eventstorming](https://github.com/mariuszgil/awesome-eventstorming)
- [ddd-crew
/
eventstorming-glossary-cheat-sheet](https://github.com/ddd-crew/eventstorming-glossary-cheat-sheet)

#### Github 

- [kgrzybek
/
modular-monolith-with-ddd](https://github.com/kgrzybek/modular-monolith-with-ddd)

#### Articles

- [Simple Domain Events with EFCore and MediatR](https://cfrenzel.com/domain-events-efcore-mediatr/)
- [Avoid In-Memory Databases for Tests](https://jimmybogard.com/avoid-in-memory-databases-for-tests/)

##### Code Coverage

- [Measuring .NET Core Test Coverage with Coverle](https://www.tonyranieri.com/blog/2019/07/31/Measuring-.NET-Core-Test-Coverage-with-Coverlet/)
- [Use code coverage for unit testing](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)

##### Issue Resolutions

- [Allow optional dependents to be added later when using table splitting](https://github.com/dotnet/efcore/issues/17422)



#### Books

- [Implementing Domain-Driven Design](https://www.oreilly.com/library/view/implementing-domain-driven-design/9780133039900/)
- [Patterns, Principles, and Practices of Domain-Driven Design](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
- [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.oreilly.com/library/view/domain-driven-design-tackling/0321125215/)
- [Hands-On Domain-Driven Design with .NET Core](https://www.packtpub.com/in/application-development/hands-domain-driven-design-net-core)
