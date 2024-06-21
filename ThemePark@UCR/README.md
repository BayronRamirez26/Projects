# ThemePark@UCR

- University of Costa Rica
- School of Computer Science and Informatics
- Integrated Project in Software Engineering and Databases
- Semester I, 2024

---

# Table of contents

| Section |
|---------|
| [Definitions, acronyms, and abbreviations](#definitions-acronyms-and-abbreviations) |
| [Introduction](#introduction) |
| [Teams, team members, and roles](#teams-team-members-and-roles) |
| [Project description](#project-description) |
| [Context and current situation](#context-and-current-situation) |
| [Stakeholders and types of users](#stakeholders-and-types-of-users) |
| [Proposed solution](#proposed-solution) |
| [Analysis of the environment](#analysis-of-the-environment) |
| [Product vision](#product-vision) |
| [Relationship with other external systems](#relationship-with-other-external-systems) |
| [Module descriptions](#module-descriptions) |
| [Functional requirements](#functional-requirements) |
| [Product roadmap](#product-roadmap) |
| [Non-functional requirements](#non-functional-requirements) |
| [Technical decisions](#technical-decisions) |
| [Methodologies and defined processes](#applied-methodologies-and-defined-processes) |
| [Artifacts used in the project](#artifacts-used-in-the-project) |
| [Technologies used](#technologies-used) |
| [Code repository and git strategy](#code-repository-and-git-strategy) |
| [Definition of Done](#definition-of-done) |
| [Data requirements](#data-requirements) |
| [Conceptual design of the database](#conceptual-design-of-the-database) |
| [Logical design of the database](#logical-design-of-the-database) |
| [References](#references) |

---

# Definitions, acronyms, and abbreviations

- UCR: Universidad de Costa Rica (University of Costa Rica)
- VR: Virtual Reality
- PIBDS: Proyecto Integrador de Base de Datos e Ingenieria de Software

# Introduction

The objective for this document is to provide a guide to the virtual reality "ThemePark@UCR" project developed by the students from the PIBDS course at UCR. It captures the joint efforts from all the developers involved.

Througout this document, you will be able to take a closer look into the development process, including descriptions of the product, instructions for its use, the goals and challenges that we were able to achieve and overcome along the way.

The document has been structured for the correct understanding from beggining to end of the project, all the information necessary can be found here so that the users and other collaborators can understand and contribute with the project.

The associated repository has additional resources and assets, to provide those who read it the best undesrtanding and knowledge required.

---

# Teams, team members, and roles

## Ctrl+Alt+Defeat

- Díaz, Jorge (Team Ambassador, Software Quality Assurance Team, Software Developer)
- Espinoza, Sara (Scrum Master, Database Team, Software Developer)
- Ulate, Francisco (Git Management Team, Software Developer)
- Van der Laat, Daniel (Look&Feel Team, Software Developer)
- Víquez, Christopher (Clean Code Principles Team, Software Developer)

## Los Chayannes

- Arce, Fernando (Look&Feel Team, Software Developer)
- Carrion, Archibald Emmanuel (Scrum Master, Software Developer)
- Madriz, Jorge ( Team Ambassador,Software Developer )
- Gamboa, Brilly (Git Management Team, Software Quality Assurance Team, Software Developer)
- Vega, Fabián (Database Team, Clean Code Principles Team, Software Developer)

## La Gran Estafa
- Ramirez, Bayron (Scrum Master, Database Team, Software Developer)
- Agüero, Randy (Git Management Team, Clean Code Principles Team, Software Developer)
- Torres, Mauricio (Look&Feel Team, Software Developer)
- Vega, Maria Fernanda (Software Quality Assurance Team, Software Developer)

## Team Possible
- Castro, Steven (Scrum Master, Clean Code Principles, Software Developer)
- Rojas, Esteban (Team Ambassador, Clean Code Principles, Software Developer)
- Obando, David (Database Team, Software Quality Assurance Team, Software Developer)
- Ceciliano, Johan (Git Management Team, Software Developer)
- Núnez, Joseph (Look&Feel Team, Software Developer)

---

# Project description

## Context and current situation

The Sofware Engineering and Databases integrative project, has the porpouse of offering a practical and realistic experience in sofware development students. The project simulates a professional environment by creating a computer system which is a Web/VR application with an associated relational database. This learning environment seeks to apply the concepts learned in the courses and familiarize students with the activities and processes they will encounter in the professional field.

This hands-on approach, in addition to technical implementation, also involves project management under the agile Scrum methodology, adapted to distributed teams (Scrum of Scrum. The project structure includes multiple interactions, each focused on diferent phases of development, from initial conceptualization to final implementation and refinement of the application.

We believe that there are no VR experiences for any university in Costa Rica and we want to be the change.

## Problem to be solved

The ThemePark@UCR aims to replicate the UCR campus and provide an immersive experience of the UCR life.

One of the main issues to solve is accesibility, we want to give those that are unable to experience the universtity physically an accessible way to explore the campus and its facilities while interacting with other members of the community.

With this unique and immersive experience with the vr enviroment we allow users to interact with classrooms, buildings and the community since no othe colleges in Cost Rica give this experience, also for prospective students they can experience the campus virtully  and get a better understanding of the enviroment and culture.

## Stakeholders and types of users

Types of users:
- Administrator: Manages the entities from the database that will appear in the 3D environment.
- Current students: The students currently enrolled in the UCR.
- Prospective students: People that are interested in enrolling into the UCR.
- Teachers: Teachers that will use the environment to support their classes.
- Researchers: Researches working in the UCR.
- Visitors: People who are visiting the UCR and want to learn more about it.

## Proposed solution
The development of the project consists of a robust and scalable solution based on agile methodologies and modern software design and architecture principles. Scrum methodology is used, so that the project development is structured in four sprints, ranging from initial conceptualization to final implementation and refinement, thus allowing for adaptation to changes.
The proposal will be guided by SOLID principles to ensure that the code is manageable and maintainable. As these principles are fundamental to developing software that facilitates scalability and allows for long-term modifications without compromising functionality.
Part of the proposal consists of a clean architecture using the Domain-Driven Design (DDD) approach, which will help to modularize the system and improve the interaction between its components.

The development team has been organized into subgroups, each dedicated to a specific module of the system: Learning Spaces, Learning Zones, Interactive Learning Elements and Interaction.

## Analysis of the environment

### Business strategies and system goals from the business perspective

By offering a unique and immersive virtual reality experience the university wants to attract prospective students and new members for the community and differentiate from other universities providing an accesible VR enviroment. The university is looking to innovate and show its modern facilities.

With the virtual experience we estimate higher rates of enrollment and student retention since there are various constraints to attend the university.

### Clients

- Administrator
- Current students
- Prospective students
- Teachers
- Researchers
- Visitors

### Expected use of the application

We want users to be able to explore the campus, go to classes and interact with the facilities, depending on the permissions and role in the community the user might have different ways to interact with the ThemePark@UCR

### Related Legacy Systems

At the moment there are no related Legacy Systems involved

### Regulatory Aspects

It is expected that we follow the right regulations for the virtual enviroment and user protection and always complying with the standards set and needed. We aim to make an accesible portal to ensure equality.

### Assumptions and Business Restrictions

It's assumed that the target audience is knows and has access to devices capable of running the application.
Since the application is developed by students currently enrolled in the carrer for Computer and Information Sciences, there are time, budget and resources constraints that might affect development and maintenance of the virtual enviroment.

## Product vision

For the future and current community of the UCR who need more/better accessibility to the university and its resources.

The ThemePark@UCR is a web/VR portal that seeks to universalize access to the UCR through technology.

Unlike existing systems that require our community to be physically present at the UCR's campuses, our product will provide a completely virtual university experience.

## Relationship with other external systems

Our product is currently a standalone system, but in the future it might be connected to the UCR user services so that all students, professors and administrators of the UCR can log in into our system with their existing credentials.

## Module and Epics description

### Learning Areas

Learning Areas refers to the physical locations within the university, such as the site of the campus itself, the buildings, both outside and inside, the recreational areas, and more. This module will be responsible for creating and managing these areas, as well as the assets that make them up.

For the current version of the product, the Learning Areas module will be responsible for creating and managing only the buildings.

#### Epics

**Epic 1:** As an administrator, I want to manage buildings in the virtual world so that students can have a space to attend their classes

**User Stories:**
As an administrator, I want to modify the properties of the building.
As an administrator, I want to validate the position of a building when I update it, so that I can avoid any collision with other objects
As an administrator, I want to be able to switch the level position, so I can reordered it.
As an administrator, I want to search for a building by attributes like name, so that I can more easily see the details of a specific building.
As an administrator, I want to validate the position of a building when I create it, so that I can avoid any collision with other objects
As an administrator, I want to create a new building so that students have a learning space
As an administrator, I want to delete an existing building so that I can get rid of a space that's no longer needed.

**Epic 2:** As an administrator, I want to manage the levels of a building in the virtual world so that students can have a space to attend their classes

**User Stories:**
As an administrator, I want to create a new level of a building so that i can manage the levels of the building
As an administrator, I want to be able to view a list of the levels of a building so that I can determine if it suits my needs.
As an administrator, I want to delete an existing level of a building so that I can better reflect the reality of the building.
As an administrator, I want to modify the properties of the level of a building so that I can better reflect the reality of the building.

**Epic 3: **

As an administrator, I want to see the outside of the bulding plain model, so that I can have an idea of it's size.

**User Story:**
As an administrator, I want to manage buildings in the virtual world so that students can have a space to attend their classes

### Interaction (Team Possible)
The interaction module is dedicated to the development and maintenance of authentication and authorization systems to protect access to the virtual environment. It is responsible for managing specific roles and permissions that differentiate users.

#### Epics
For sprint 0 we have the following epics:

- As an Administrator I want to login to the UCR theme park with my given credentials, so that I can administrate other accounts
- As an administrator, I want to manage user accounts (create, update or delete) so that I can have control over who can use the application
- As a Student I want to create my personal account for the UCR Theme Park portal so that I can become a member of the virtual community

### Learning Components (La Gran Estafa)
Learning components are elements that facilitate knowledge acquisition. In the context of this project, these elements enable interaction where users can input information such as text, images, graphics, among others. This module has a strong dependence on other modules because the process of assigning learning components necessitates their connection to Learning Spaces. These Learning Spaces, in turn, are linked to Learning Areas. In simpler terms, to assign a learning component, it must first be associated with a specific Learning Space, and that Learning Space must belong to a broader Learning Area.

#### Epics
For  sprint #0, we have developed the Epic related to whiteboard administration, as part of a learning component:

- As an administrator, I want to create new whiteboards in virtual classrooms so that teachers and students have additional interactive spaces for collaboration.

## Functional requirements
- Administrator can use a virtual portal to access and modify the database of entities that will be present in the VR environment.
- [Jira](http://10.1.4.22:8080/projects/PIIB2401G1)

## Product roadmap

1. Webpage for the administrator to manage the different project components in the database.
2. Model the UCR environments in 3D.
3. Allow users to interact with the 3D environments.
4. Open the product to current and potential students.

## Non-functional requirements
### Clean Code:
- Documentation: Code must be adequately documented, including clear and concise comments explaining its functionality, purpose, and any special considerations.
- Coding Standards: Code must adhere to the coding standards established by the team or organization. This may include naming conventions, indentation style, among others.
- Code Errors: All code errors, including warnings and compilation errors, have been removed or corrected.
- Meaningful Variable Names: Variable names should be descriptive and meaningful, aiding in code understanding.
- Variable Naming: Consistent and understandable naming conventions must be followed.
- C# Conventions: In the case of using C# as the programming language, established conventions for this language must be followed.

### Architecture Integrity
- No Architecture Breakage: Implemented code does not violate established architectural principles and patterns for the project.
- Bad References: All incorrect or unwanted references between components have been eliminated.
- Proper Service Injection: Services are correctly injected into classes that need them, following good dependency injection practices.
- Interface Usage for Service Injection: Interfaces are used to inject services instead of depending directly on concrete implementations, allowing for greater flexibility and maintainability of the code.

### Design Principles and Best Practices
- SOLID Principles: Code follows the SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion), ensuring a modular, flexible, and easy-to-maintain design
- Single Responsibility: Each class or component has a single responsibility, aiding in its understanding, testing, and maintenance.
- Small Interfaces: Interfaces are small and cohesive, with a coherent and related set of methods.
- Dependency Inversion: Dependencies are inverted through interfaces, facilitating component substitution and reducing coupling between modules.
- Polymorphism: If inheritance and polymorphism are used, ensure they are implemented correctly and consistently with the overall system design.
- Other Considerations: Successful Compilation: The code compiles without errors and produces a functional executable or library.
- Test Coverage: Unit and/or integration tests have been conducted to ensure code quality and reliability, and adequate test coverage has been achieved.

---

# Technical decisions

## Applied methodologies and defined processes

The SCRUM framework was chosen to develop the project. There are 4 teams working on different functionalities that cooperate with each other and maintain agile development.

The project will consist of 4 sprints in which the totality of the project vision will be attempted.

Given the SCRUM framewotk used in the development, there are 4 main roles that apply to the project:
- Product Owner(PO): This user will prioritize the features to be developed based on the business needs, and keep the product vision.
- Technical Advisors: They advice the developers on any technical ambiguity that they might have.  
- Scrum Master: Manages the agile methologies that the team must follow, and solve any impediments that they might face.
- Scrum Ambassador: Communicates with other development teams to coordinate solutions.  
- Developers: Develop the user stories for the sprints.

## Artifacts used in the project

The artifacts used in the project are as follows:

- Git will be used as the version control system.
- GitHub will be used as the code repository.
- Swagger will be used as the API documentation tool.
- Blazor will be used as the main frontend framework.
- The BlazorStrap and MudBlazor libraries will be used on the frontend.
- Kiota will be used as the main API client generator.

## Technologies used

The technologies used in the project are as follows:

- C# as the main programming language for the backend.
- .NET 8.0 as the main framework for the backend.
- Unity will be used as the main engine for the VR environment.
- SQL Server will be used as the main database management system.

## Code repository and git strategy

### GitHub

It was decided to use GitHub as the code repository.

[Repository](https://github.com/UCR-PI-IS/ecci_ci0128_i2024_g01_pi.git)

### Git Flow

The Git Flow branching strategy is a highly popular branching model that provides a framework for managing the workflow in software development projects. It is based on the idea of having two main branches and several support branches for continuous development and code stability. If required, a specific naming format could be defined.

#### Main Branches

- Master (Main): This branch contains stable and production-ready source code. Ideally, only well-tested and validated commits are merged into this branch.
- Develop: It is the main integration branch where all finished and tested features are merged. It is less stable than the main branch, as it may contain work-in-progress code and unfinished features.

#### Support Branches
 
- Feature Branches: Each new feature or functionality is developed in a branch branched off from “develop” and used for developing new features or enhancements. Once the feature is complete and tested, it is merged back into the “develop” branch.
- Release Branches: Branched off from “develop” when preparing a new version for release. Final testing and minor bug fixes or documentation are done here before merging into master and develop. Branches are merged with a version number.
- Hotfix Branches: Branched off from “main” and used to fix critical issues in production. They are merged back into the “main” (master) branch and “develop”. Once the issue is resolved, it is tagged with a version number. This branch addresses bugs found in the production version "Main", so it should not be mixed with bugs that may appear in “Features” and/or “develop”.
- Bugs branches: For cases where bugs are found in "develop" or "feature", other branches should be created, to which a different naming format should be assigned if required. BUT THEY SHOULD NOT BE ADDED TO THE HOTFIX BRANCH.

#### Main Merge Branches

- According to the Branching strategy, merging to the Main branch is only permitted from the Release and Hotfix branches.

#### Approval Process

- For merging into "develop", approval from at least one member per team is required. This is for each development branch.
- For each merge from a team's branch, approval from at least two team members is necessary.
- Verification should be performed each time a pull request is made to any branch

#### Cross-Team Approval

- When commits from a team member affect a module outside their team's scope, at least one member from each involved team must approve the merge request before merging into branches derived from "main".

#### Feature Branches

- Each functionality to be incorporated by the teams must reside in a branch derived from the team's branch. This aligns with Git Flow's concept of feature branches.

#### Merge Strategy

- Merges can be regular or Squash Merges, depending on the branch. Squash Merges seem ideal for branches like "Release" to keep the project history clean and avoid unnecessary commits. Detailed commit information can be accessed through the necessary feature branches if needed. A defined format for merges, commits, etc., should be established.

#### Pull Request Strategy (Checklist):

Verification should be performed each time a pull request is made to any branch. As per the defined guidelines, it should be confirmed among teams which members should review and how PRs are verified (see below : “Checklist*).

A checklist should be defined, considering "Clean Architecture" principles. Criteria should be established, taking into account the project's requirements and standards. (TODO)

**PR Checklist**

## Definition of Done - Sprint 1

- Architecture that follows the principles of clean architecture.
- Code that follows the principles of clean code.
- Code that follows the SOLID principles.
- Each pull request must complete a user story or be an indispensable fix.
- Each pull request must be approved by at least one member from each team.
- Appropriately commented code.
- Follow C# coding standards.
- Everything must compile correctly.
- For a user story to be accepted, it must fulfill every acceptance criteria.
- All acceptance criteria must be validated by the PO.

## Data requirements

For the Sprint 0 our data requirements are divided on four major functionalities:

### Learning Areas

One of the major components for the ThemePark@UCR are the learning areas. These consist of the large structures where the UCR will be represented. Given that, the most important agents are the buildings and all the other factors associated with them. A building needs to be placed in a Campus Site of the University. Also, a building can have multiple levels, where each one will have assets to form their floor, ceiling and walls.

Learning areas are primarily composed of one strong entity and a series of weak entities that all derive from each other in a hierarchical manner. The strong entity is University, followed by the weak entities Campus, Site, Building, Level, and Learning Space from the following component, in that order. The decision was made as it was deemed necessary to properly identify each physical location in the university.

Within the Learning Area component, Building and Level have a relationship with various Asset subtypes that will be used to represent the 3D objects that will make them up in the VR environment.

Within the Learning Area component, the hierarchical relationship between the entities from University to Learning Space is represented with the foreign key approach. The University entity has a one-to-many relationship with Campus, Campus with Site, Site with Building, Building with Level, and Level with Learning Space.

### Learning Spaces

The clients require several functionalities of the learning spaces that need to be reflected in the database data. All learning spaces are required to have a modifiable dimension, type, and color. Also, these learning spaces need to be located on a valid level, inside a building, and in other learning areas.

These learning spaces need to be able to be accessed from inside a level, so access points need to be added.

As mentioned before, Learning Spaces are weak entities that derive from the Learning Area component. They can be furthered divided into the categories of Classroom, Laboratory, and Auditorium.

Learning Spaces have a relationship with various Asset subtypes, which will be used to represent the 3D objects that will make them up in the VR environment.

Learning Space was represented as an Entity and each of its subtypes, Classroom, Laboratory, and Auditorium, were also represented as entities with foreign keys to Learning Space.

### Learning Components

Learning Components are specialized subtypes of Assets. The two main types of Learning Components are Whiteboards and Projectors. Whiteboards also have Whiteboard Elements, also subtypes of assets, while Projectors have Projections.

Each of the Learning Components and their subtypes were represented as entities with foreign keys to Asset. Whiteboard Elements has a foreign key to Whiteboard, and Projections has a foreign key to Projector to represent the relationships between the entities.

### Interaction

ThemePark@UCR development model in charge of the interaction between users in the platform and the different options and other modules. These consist in the authorization and authentication of different users and given their roles they will have different roles and permissions according to their roles. The different users that are going to be worked on for this Sprint 0 are Administrator, which will be able to manage the different account and will be given total access and interaction with the other modules feature, and  Student, which will be given enough permissions to go into the portal and interact with the space.

The interactivity component has the Person and User entities which represent the people that will use the VR environment. The Person entity was created, since you don't necessarily have to be a user to be in the VR environment. The person can be of a different type and be given permissions based on their role. The current types of design are Student, Professor, Researcher, Administrator, External.

Each Person with a type will have an user, which will have 1 or various roles and based on their role will have permissions within the platform.

### Assets

The Asset entity was created to represent the 3D objects that will make up the VR environment in Unity. It is used by various components.

Assets are represented as a super-type entity that represents the 3D objects that will make up the VR environment in Unity. The subtypes of Assets were represented as entities with foreign keys to Asset.

## Conceptual design of the database

[Link to the diagram](https://drive.google.com/file/d/188R1emOmi_hK8iyPwmW2WrfvHW293jxL/view?usp=sharing)

![Conceptual design](/Img/conceptual-design.svg)

## Logical design of the database

[Link to the diagram](https://docs.google.com/spreadsheets/d/16Hi23GCPpdvP-oow2ZNNKjwJbHBnnt_u06DqE8llZPY/edit?usp=sharing)

---

# References

https://docs.microsoft.com/en-us/dotnet/

https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16

https://learn.microsoft.com/en-us/openapi/kiota/

https://swagger.io/docs/

https://mudblazor.com/docs/overview

https://blazorstrap.io/V5/V5/

---

## Installation

*Installation is not part of the Sprint 0 description, not sure where to put this, but it was already in the README, so I'm leaving it here.*

The minimal requirements for running the project in terms of .NET is the Desktop Runtime .NET 8.0 Desktop Runtime (v8.0.4) vertion

```shell
https://dotnet.microsoft.com/es-es/download/dotnet/8.0
```
